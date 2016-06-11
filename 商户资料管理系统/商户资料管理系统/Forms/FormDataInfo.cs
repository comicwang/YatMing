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
    public partial class FormDataInfo : Form
    {
        private string _baseInfoId = string.Empty;

        public FormDataInfo()
        {
            InitializeComponent();
        }

        public TDataInfoDTO DataInfo
        {
            get
            {
                TDataInfoDTO result = new TDataInfoDTO();
                result.MetaDataId = CommomHelper.GuidGetter(txtDataName.Tag);
                txtDataName.Tag = result.MetaDataId;//名称
                result.DataName = txtDataName.Text;
                result.DataDescription = txtDescription.Text;
                result.DataContent = string.IsNullOrEmpty(txtData.Text) ? btnScan.Tag as byte[] : IOHelper.GetStreamBuffer(txtData.Text);
                result.DownloadTimes = txtDescription.Tag == null ? 0 : CommomHelper.IntGetter(txtDescription.Tag.ToString()); //描述
                result.LastModifyTime = DateTime.Now;
                result.CreateTime = txtUploadBy.Tag == null ? DateTime.Now : CommomHelper.ParseDateTime(txtUploadBy.Tag);//上传人
                result.BaseInfoId = CommomHelper.NullGetter(txtData.Tag);
                result.UploadPeople = txtUploadBy.Text;
                result.FileSize = txtFileSize.Text;
                return result;
            }
            set
            {
                txtDataName.Tag = value.MetaDataId;
                txtDataName.Text = value.DataName;
                txtDescription.Text = value.DataDescription;
                txtDescription.Tag = value.DownloadTimes;
                txtUploadBy.Tag = value.CreateTime;
                txtUploadBy.Text = value.UploadPeople;
                txtData.Tag = value.BaseInfoId;
                btnScan.Tag = value.DataContent;
                txtFileSize.Text = value.FileSize;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            txtData.Text = openFileDialog1.FileName;
            txtDataName.Text = Path.GetFileName(openFileDialog1.FileName);
            FileInfo info = new FileInfo(openFileDialog1.FileName);
            txtFileSize.Text = info.Length.ToString();
        }
    }
}
