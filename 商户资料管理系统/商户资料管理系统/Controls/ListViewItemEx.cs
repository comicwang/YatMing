using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 商户资料管理系统.Common;
using 商户资料管理系统.Properties;
using 商户资料管理系统.YatServer;

namespace 商户资料管理系统
{
    public class ListViewItemEx : ListViewItem
    {
        private ProgressBar _pb = null;
        private PictureBox _pbox = null;
        private string _baseId = string.Empty;
        private string _saveHistory = string.Empty;
        private BackgroundWorker _bgwork = null;
        private ToolTip _tip = null;
        private static YatMingServiceClient _client = ServiceProvider.Clent;

        public ListViewItemEx()
            : base()
        {
          
        }

        public ListViewItemEx(string baseId)
            :base()
        {
            _baseId = baseId;
        }

        private void pic_Click(object sender, EventArgs e)
        {
            try
            {
                if (OpareteType == OpareteTypeEnum.Download)
                    _bgwork.RunWorkerAsync(new object[] { _saveHistory });
                else
                    _bgwork.RunWorkerAsync(new object[] { IOHelper.GetStreamBuffer(_saveHistory), ItemData.MetaDataId });
                _pbox.Visible = false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SetOtherControl()
        {
            Rectangle rct = this.Bounds;           
            _pb = new ProgressBar();
            _pb.Height = 10;
            _pb.Width = rct.Width;
            _pb.Location = new Point(rct.Left, rct.Top + (rct.Height - _pb.Height) / 2);
            _pb.Visible = false;
            this.ListView.Controls.Add(_pb);

            _pbox = new PictureBox();
            _pbox.Width = 15;
            _pbox.Height = 15;
            _pbox.Image = Resources.retry;
            _pbox.Cursor = Cursors.Hand;
            _pbox.Click += pic_Click;
            _pbox.Visible = false;
            _pbox.Location = new Point(rct.Left, rct.Top + (rct.Height - _pb.Height) / 2);
            _pbox.SizeMode = PictureBoxSizeMode.Zoom;
            this.ListView.Controls.Add(_pbox);

            _bgwork = new BackgroundWorker();
            _bgwork.WorkerReportsProgress = true;
            _bgwork.WorkerSupportsCancellation = true;
            _bgwork.DoWork += _bgwork_DoWork;
            _bgwork.RunWorkerCompleted += _bgwork_RunWorkerCompleted;
            _bgwork.ProgressChanged += _bgwork_ProgressChanged;
        }

        #region 后台事件

        private void _bgwork_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!_pb.Visible)
                _pb.Visible = true;
            _pb.Value = e.ProgressPercentage;
        }

        private void _bgwork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((bool)e.Result == false)
            {
                ReportError();
            }
            else
            {
                Hide();
            }
        }

        private void _bgwork_DoWork(object sender, DoWorkEventArgs e)
        {
            if (OpareteType == OpareteTypeEnum.Upload)
            {
                try
                {
                    object[] arg = e.Argument as object[];
                    byte[] total = arg[0] as byte[];
                    string id = arg[1].ToString();
                    byte[] buffer = new byte[409600]; //400kb
                    int percent = total.Length / buffer.Length;
                    for (long index = 0; index < percent; index++)
                    {
                        buffer = total.Skip((int)index * buffer.Length).Take(buffer.Length).ToArray();
                        bool result = _client.TDataInfoUploadFile(buffer, id, (int)(index * buffer.Length / 40960000));
                        if (result == false)
                        {
                            e.Result = false;
                            return;
                        }
                        _bgwork.ReportProgress((int)((index + 1) * buffer.Length * 100 / total.Length));
                    }
                    int left = total.Length % buffer.Length;
                    if (left > 0)
                    {
                        byte[] leftBuffer = total.Skip(percent * buffer.Length).Take(left).ToArray();
                        bool result = _client.TDataInfoUploadFile(leftBuffer, id, total.Length / 40960000);
                        if (result == false)
                        {
                            e.Result = false;
                            return;
                        }
                        _bgwork.ReportProgress(100);

                    }
                    e.Result = true;
                }
                catch (Exception)
                {
                    e.Result = false;
                }
            }
            else
            {
                try
                {
                    object[] obj = e.Argument as object[];
                    if (ItemData == null)
                    {
                        e.Result = null;
                        return;
                    }
                    long totalSize = long.Parse(ItemData.FileSize);
                    long total = 0;
                    byte[] buffer = null;
                    bool success = true;
                    while (success)
                    {
                        using (FileStream stream = new FileStream(obj[0].ToString(), FileMode.Append))
                        {
                            success = _client.TDataInfoDownloadFile(out buffer, total, ItemData.MetaDataId);
                            if (success == false)
                            {
                                break;
                            }
                            total += buffer.Length;
                            _bgwork.ReportProgress((int)(total * 100 / totalSize));
                            stream.Write(buffer, 0, buffer.Length);
                        }
                    }
                    e.Result = (total == totalSize);
                }
                catch (Exception)
                {
                    e.Result = false;
                }
            }
        }

        #endregion

        public TDataInfoDTO ItemData { get; set; }

        public void UploadFile(string filePath,string parentId,ImageList lstImage)
        {
            SetOtherControl();
            _saveHistory = filePath;
            try
            {
                TDataInfoDTO uploadDTO = new TDataInfoDTO();
                uploadDTO.MetaDataId = Guid.NewGuid().ToString();
                uploadDTO.DataName = Path.GetFileName(filePath);
                uploadDTO.DownloadTimes = 0;
                uploadDTO.LastModifyTime = DateTime.Now;
                uploadDTO.CreateTime = DateTime.Now;
                uploadDTO.BaseInfoId = _baseId;
                uploadDTO.UploadPeople = CommonData.LoginInfo.EmployeeName;
                FileInfo info = new FileInfo(filePath);
                uploadDTO.FileSize = info.Length.ToString();
                uploadDTO.IsForlder = false;
                uploadDTO.ParentId = parentId;
                bool success = _client.TDataInfoAdd(uploadDTO);
                if (success && !_bgwork.IsBusy)
                {
                    this.ToolTipText = string.Format("文件名称:{0}\r\n文件大小:{1}M\r\n上传时间:{2}\r\n上传人:{3}\r\n修改时间:{4}\r\n下载次数:{5}\r\n文件描述:{6}", uploadDTO.DataName,CommomHelper.ParseMB(uploadDTO.FileSize), uploadDTO.CreateTime, uploadDTO.UploadPeople, uploadDTO.LastModifyTime, uploadDTO.DownloadTimes, uploadDTO.DataDescription);
                    this.ImageIndex = CommomHelper.GetImageIndex(filePath, uploadDTO.MetaDataId, lstImage);
                    ItemData = uploadDTO;
                    byte[] buffer = IOHelper.GetStreamBuffer(filePath);
                    OpareteType = OpareteTypeEnum.Upload;
                    _bgwork.RunWorkerAsync(new object[] { buffer, uploadDTO.MetaDataId });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DownLoadFile()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "所有文件|*.*";
            dialog.FileName = ItemData.DataName;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SetOtherControl();
                if (_bgwork.IsBusy == false)
                {
                    OpareteType = OpareteTypeEnum.Download;
                    _saveHistory = dialog.FileName;
                    _bgwork.RunWorkerAsync(new object[] { dialog.FileName });
                }
            }
        }

        public OpareteTypeEnum OpareteType { get; private set; }

        public void Hide()
        {
            _pb.Visible = false;
            _pbox.Visible = false;
            if (_tip != null)
                _tip.Dispose();
        }

        public void ReportError()
        {
            _pb.ForeColor = Color.Red;
            _pbox.Visible = true;
            _pb.Visible = false;
            _tip = new ToolTip();
            _tip.SetToolTip(_pbox, "文件操作失败,可以尝试重新操作");
        }

    }

    public enum OpareteTypeEnum
    {
        Upload,
        Download
    }
}
