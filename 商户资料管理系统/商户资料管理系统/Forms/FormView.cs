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
using 商户资料管理系统.YatServer;

namespace 商户资料管理系统
{
    public partial class FormView : Form
    {
        private static YatMingServiceClient _client = ServiceProvider.Clent;
        public FormView()
        {
            InitializeComponent();
        }

        public void View(string dataId)
        {
            panel1.Visible = true;
            TDataInfoDTO dto = _client.TDataInfoQueryById(dataId);
            Text = dto.DataName;
            //文件图片
            if (dto.DataName.ToLower().EndsWith(".png") || dto.DataName.ToLower().EndsWith(".jpg") || dto.DataName.ToLower().EndsWith(".bmp") || dto.DataName.ToLower().EndsWith(".jpeg") || dto.DataName.ToLower().EndsWith(".doc") || dto.DataName.ToLower().EndsWith(".docx") || dto.DataName.ToLower().EndsWith(".ppt") || dto.DataName.ToLower().EndsWith(".pptx") || dto.DataName.ToLower().EndsWith(".xls"))
            {
                string temp = Path.Combine(System.Environment.GetEnvironmentVariable("TEMP"), dto.MetaDataId + Path.GetExtension(dto.DataName));
                 if (File.Exists(temp))
                 {
                     panel1.Visible = false;
                     webBrowser1.Navigate(temp);
                 }
                 else
                 {
                     label1.Text = "文件加载中...";
                     if (backgroundWorker1.IsBusy == false)
                         backgroundWorker1.RunWorkerAsync(new object[] { dto, temp });
                 }
            }
           //视频
            else if (dto.DataName.ToLower().EndsWith("mp4") || dto.DataName.ToLower().EndsWith("ogg") || dto.DataName.ToLower().EndsWith("webm") || dto.DataName.ToLower().EndsWith("flv"))
            {
                string dns = _client.Endpoint.Address.Uri.AbsoluteUri;

                dns = dns.Remove(dns.LastIndexOf('/'));
                //System.Diagnostics.Process.Start("iexplore.exe", "http://" + dns + "/index.html?name=" + dto.DataName); 
                panel1.Visible = false;

                webBrowser1.Navigate(dns + "/index.html?name=" + dto.MetaDataId + Path.GetExtension(dto.DataName));

            }
            else
            {
                progressBar1.Visible = false;
                label1.Text = "文件类型不支持预览...";
            }
        }  

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                object[] obj = e.Argument as object[];
                TDataInfoDTO dto = obj[0] as TDataInfoDTO;
                long totalSize = long.Parse(dto.FileSize);
                if (dto == null)
                {
                    e.Result = null;
                    return;
                }

                long total = 0;
                byte[] buffer = null;
                bool success = true;
                while (success)
                {
                    using (FileStream stream = new FileStream(obj[1].ToString(), FileMode.Append))
                    {
                        success = _client.TDataInfoDownloadFile(out buffer, total, dto.MetaDataId);
                        if (success == false)
                        {
                            break;
                        }
                        total += buffer.Length;
                        backgroundWorker1.ReportProgress((int)(total * 100 / totalSize));
                        stream.Write(buffer, 0, buffer.Length);
                    }
                }
                e.Result = obj[1].ToString();
            }
            catch (Exception)
            {
                e.Result = null;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            panel1.Visible = false;
            if (e.Result != null)
                webBrowser1.Navigate(e.Result.ToString());
        }

        private void FormView_FormClosing(object sender, FormClosingEventArgs e)
        {
            backgroundWorker1.CancelAsync();
            e.Cancel = false;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
           // webBrowser1.Document.InvokeScript("setSrc");
        }
    }
}
