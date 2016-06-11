using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using 商户资料管理系统.Common;
using 商户资料管理系统.YatServer;

namespace 商户资料管理系统
{
    public partial class FormDataInfoEx : Form
    {
        private static YatMingServiceClient _client = ServiceProvider.Clent;
        private Queue<string> _fileNames = new Queue<string>();
        private string _uploadBy = string.Empty;
        private string _id = string.Empty;
        private UploadControl _currentControl = null;
        private ManualResetEvent manualReset = new ManualResetEvent(true);
        private Thread _thread = null;
        public FormDataInfoEx(string baseInfoId,string uploadby)
        {
            InitializeComponent();
            InitializeQueue();
            _id = baseInfoId;
            _uploadBy = uploadby;
            ToolTip tip = new ToolTip();
            tip.SetToolTip(btnUpload, "拖拽文件也能上传");
        }

        private void InitializeQueue()
        {
            _thread = new Thread(new ParameterizedThreadStart(delegate
            {

                while (true)
                {
                    if (_fileNames.Count > 0 && backgroundWorker1.IsBusy == false)
                    {
                        string filePath = _fileNames.Dequeue();
                        bool result = Upload(filePath);
                        if (!result)
                            _fileNames.Enqueue(filePath);
                    }
                }

            }));
            _thread.IsBackground = true;
            _thread.Start();
        }

        private bool Upload(string fileName)
        {
            bool result = false;
            foreach (Control ctl in flowLayoutPanel1.Controls)
            {
                if (ctl.Name == Path.GetFileNameWithoutExtension(fileName))
                {
                    _currentControl = ctl as UploadControl;
                    if (_currentControl.InvokeRequired)
                    {
                        Action actionDelegate = () =>
                        {
                            if (_currentControl.IsPause)
                                return;
                            result = true;
                            _currentControl.SetState(UploadState.Uploading);
                            backgroundWorker1.RunWorkerAsync(fileName);
                        };
                        // 或者
                        // Action<string> actionDelegate = delegate(string txt) { this.label2.Text = txt; };
                        _currentControl.Invoke(actionDelegate);
                    }
                    break;
                }
            }
            return result;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string[] names = openFileDialog1.FileNames;
            Array.ForEach(names, t =>
            {
                AddQueue(t);
            });
        }

        private void AddQueue(string t)
        {
            _fileNames.Enqueue(t);
            UploadControl control = new UploadControl();
            control.FileName = (flowLayoutPanel1.Controls.Count + 1) + "." + Path.GetFileNameWithoutExtension(t);
            control.Width = flowLayoutPanel1.Width;
            control.Dock = DockStyle.Top;
            control.Name = Path.GetFileNameWithoutExtension(t);
            control.OnPauseChanged += control_OnPauseChanged;
            flowLayoutPanel1.Controls.Add(control);
        }

        private void control_OnPauseChanged(object sender, EventArgs e)
        {
            UploadControl control = sender as UploadControl;
            if (control == _currentControl)
            {
                bool isPause = control.IsPause;
                if (isPause)
                {
                    manualReset.Reset();
                    control.SetState(UploadState.Pause);
                }
                else
                {
                    manualReset.Set();
                    control.SetState(UploadState.Uploading);
                }
            }
        }

        private void flowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {
            string[] result = e.Data.GetData(DataFormats.FileDrop) as string[];
            Array.ForEach(result, t =>
            {
                AddQueue(t);
            });
            
        }

        private void flowLayoutPanel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string filePath = e.Argument.ToString();
            TDataInfoDTO result = new TDataInfoDTO();
            result.MetaDataId = Guid.NewGuid().ToString();
            result.DataName = Path.GetFileName(filePath);
           // result.DataDescription = txtDescription.Text;
            byte[] total = IOHelper.GetStreamBuffer(filePath);
            result.DownloadTimes = 0;
            result.LastModifyTime = DateTime.Now;
            result.CreateTime = DateTime.Now;
            result.BaseInfoId = _id;
            result.UploadPeople = _uploadBy;
            result.FileSize = total.Length.ToString();

            bool success = _client.TDataInfoAdd(result);
            if (success)
            {
                byte[] buffer = new byte[4096000]; //4M
                int percent = total.Length / buffer.Length;
                for (long index = 0; index < percent; index++)
                {
                    buffer = total.Skip((int)index * buffer.Length).Take(buffer.Length).ToArray();
                    bool upSuccess = _client.TDataInfoUploadFile(buffer, result.MetaDataId, (int)(index * buffer.Length / 40960000));
                    if (upSuccess == false)
                    {
                        e.Result = false;
                        return;
                    }
                    backgroundWorker1.ReportProgress((int)((index + 1) * buffer.Length * 100 / total.Length));
                    manualReset.WaitOne();
                }
                int left = total.Length % buffer.Length;
                if (left > 0)
                {
                    byte[] leftBuffer = total.Skip(percent * buffer.Length).Take(left).ToArray();
                    bool upSuccess = _client.TDataInfoUploadFile(leftBuffer, result.MetaDataId, total.Length / 40960000);
                    if (upSuccess == false)
                    {
                        e.Result = false;
                        return;
                    }
                    manualReset.WaitOne();
                    backgroundWorker1.ReportProgress(100);

                }
                e.Result = true;
            }
            
          
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _currentControl.Percent = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bool result = (bool)e.Result;
            if (result)
                _currentControl.SetState(UploadState.Complete);
            else
                _currentControl.SetState(UploadState.Failed);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy || _fileNames.Count > 0)
            {
              DialogResult result=  MessageBox.Show("当前存在未上传完的文件，是否确定取消上传？", "重要提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
              if (result == DialogResult.No)
              {
                  return;
              }
            }
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy || _fileNames.Count > 0)
            {
                DialogResult result = MessageBox.Show("当前存在未上传完的文件，是否确定取消上传？", "重要提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                if (result == DialogResult.No)
                {
                    return;
                }
            }
            DialogResult = DialogResult.Cancel;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }


    }
}
