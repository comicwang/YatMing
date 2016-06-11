using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 商户资料管理系统.Properties;

namespace 商户资料管理系统
{
    public partial class UploadControl : UserControl
    {
        public UploadControl()
        {
            InitializeComponent();
            pictureBox1.Tag = false;
            Uploadloaded = false;
        }

        public event EventHandler OnPauseChanged;

        [Category("行为"), Description("滚动条的值")]
        public int Percent
        {
            get { return progressBar1.Value; }
            set { progressBar1.Value = value; }
        }

        [Category("行为"), Description("上传文件名称")]
        public string FileName
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        [Category("行为"), Description("是否暂停上传")]
        public bool IsPause
        {
            get { return (bool)pictureBox1.Tag; }
            set { pictureBox1.Tag = value; pictureBox1.Image = value ? Resources.pouse : Resources.downloading; }
        }

        [Category("行为"), Description("是否上传完成")]
        public bool Uploadloaded
        {
            get;
            set;
        }

        public void SetState(UploadState state)
        {
            switch (state)
            {
                case UploadState.Wait:
                    label2.Text = "等待中..";
                    break;
                case UploadState.Uploading:
                    label2.Text = "上传中..";
                    break;
                case UploadState.Complete:
                    label2.Text = "上传完成";
                    Uploadloaded = true;
                    break;
                case UploadState.Failed:
                    label2.ForeColor = Color.Red;
                    Uploadloaded = true;
                    label2.Text = "上传失败";
                    break;
                case UploadState.Pause:
                    label2.Text = "暂停中..";
                    break;
                default:
                    break;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Uploadloaded)
                return;
            bool result = (bool)pictureBox1.Tag;
            IsPause = !result;
            if (OnPauseChanged != null)
                OnPauseChanged(this, EventArgs.Empty);
        }
    }

    public enum UploadState
    {
        Wait,
        Pause,
        Uploading,
        Complete,
        Failed
    }
}
