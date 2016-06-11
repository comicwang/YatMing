using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Update.YatService;

namespace Update
{
    public partial class FormUpdate : Form
    {
        private static YatMingServiceClient _client = new YatMingServiceClient();
        private string[] _fileLst = null;
        private byte[][] _fileContent = null;
        private string[] _deleteLst = null;

        public FormUpdate()
        {
            InitializeComponent();
            InitializeLstView();
        }

        private void InitializeLstView()
        {
            string[] tempLst = null;
            bool result = _client.TLoginUpdateSys(out tempLst, out _deleteLst, out _fileContent);
            if (result)
            {
                //添加删除列表
                if (_deleteLst != null && _deleteLst.Length > 0)
                {
                    lvUpdateList.Items.Add(new ListViewItem(new string[] { "文件删除个数:" + _deleteLst.Length, "", "0%" }));
                }

                //添加更新列表
                List<string> lstFile = new List<string>();
                foreach (string item in tempLst)
                {
                    string[] arr = item.Split(';');
                    if (arr != null && arr.Length > 1)
                    {
                        string[] fileTemp = arr[0].Split('\\');
                        lvUpdateList.Items.Add(new ListViewItem(new string[] { fileTemp[fileTemp.Length - 1], arr[1], "0%" }));
                        lstFile.Add(arr[0]);
                    }
                }              
                _fileLst = lstFile.ToArray();
            }
            else
            {
                lbState.Text = "获取更新文件失败！";
            }
            btnFinish.Enabled = !result;
            btnNext.Enabled = result;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                return;
            }
            //关闭程序，开启主窗体
            System.Diagnostics.Process.Start(Path.Combine(Application.StartupPath, "商户资料管理系统.exe"));
            Application.Exit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            lbState.Text = "正在下载更新中...";
            //开始更新
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //循环删除文件
                for (int deleteIndex = 0; deleteIndex < _deleteLst.Length; deleteIndex++)
                {
                    string deleteTemp = Path.Combine(Application.StartupPath, _deleteLst[deleteIndex]);
                    if (File.Exists(deleteTemp))
                        File.Delete(deleteTemp);
                    backgroundWorker1.ReportProgress(1, new int[] { deleteIndex, (deleteIndex + 1) * 100 / _deleteLst.Length });
                }

                //获取文件总大小
                long totalSize = 0;
                Array.ForEach(_fileContent, t => { totalSize += t.Length; });
                long currentSize = 0;

                //循环更新文件
                for (int uploadIndex = 0; uploadIndex < _fileLst.Length; uploadIndex++)
                {
                    string sourcePath = string.Empty;
                    string[] tempFile = _fileLst[uploadIndex].Split('\\');
                    //遍历文件夹，判断是否存在-不存在需要删除
                    for (int folderDeep = 0; folderDeep < tempFile.Length - 1; folderDeep++)
                    {
                        if (string.IsNullOrEmpty(sourcePath))
                            sourcePath = Path.Combine(Application.StartupPath, tempFile[folderDeep]);
                        else
                            sourcePath = Path.Combine(sourcePath, tempFile[folderDeep]);
                        if (Directory.Exists(sourcePath) == false)
                            Directory.CreateDirectory(sourcePath);
                    }

                    sourcePath = Path.Combine(Application.StartupPath, _fileLst[uploadIndex]);
                    if (File.Exists(sourcePath))
                        File.Delete(sourcePath);//删除要覆盖的文件

                    //开始写入新的文件
                    using (FileStream stream = new FileStream(sourcePath, FileMode.Append))
                    {
                        byte[] total = _fileContent[uploadIndex];
                        byte[] buffer = new byte[10240];  //10KB
                        long sCurrentSize = 0;
                        int piz = total.Length / buffer.Length;
                        for (int i = 0; i < piz; i++)
                        {
                            buffer = total.Skip(i * 10240).Take(buffer.Length).ToArray();
                            currentSize += buffer.Length;
                            sCurrentSize += buffer.Length;
                            stream.Write(buffer, 0, buffer.Length);
                            backgroundWorker1.ReportProgress((int)(currentSize * 100 / totalSize), new int[] { uploadIndex + _deleteLst.Length, (int)(sCurrentSize * 100 / total.Length) });
                        }
                        int left = total.Length % buffer.Length;
                        if (left > 0)
                        {
                            buffer = total.Skip(piz * 10240).Take(left).ToArray();
                            currentSize += buffer.Length;
                            stream.Write(buffer, 0, buffer.Length);
                            backgroundWorker1.ReportProgress((int)(currentSize * 100 / totalSize), new int[] { uploadIndex + _deleteLst.Length, 100 });
                        }
                    }
                }

                e.Result = null;
            }
            catch (Exception ex)
            {
                e.Result = ex.Message;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == false && e.Result == null)
            {
                lbState.Text = "更新完成！";
                btnNext.Enabled = false;
                btnFinish.Enabled = true;
            }
            else
            {
                lbState.Text = "更新失败：" + e.Result.ToString();
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbDownFile.Value = e.ProgressPercentage;
            int[] result = e.UserState as int[];
            this.lvUpdateList.Items[result[0]].SubItems[2].Text = result[1].ToString() + "%";
        }
    }
}
