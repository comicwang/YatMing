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

namespace 商户资料管理系统
{
    public partial class PictureStreamBox : PictureBox
    {
        public PictureStreamBox()
        {
            InitializeComponent();
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            ToolTip tip = new ToolTip();
            this.Image = Resources._default;
            tip.SetToolTip(this, "双击选择图片");
            this.DoubleClick += PictureStreamBox_Click;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {            
            base.OnPaint(pe);
        }

        private void PictureStreamBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "图片文件|*.png;*.jpg;*.bmp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.Image = Image.FromFile(dialog.FileName);
            }
        }

        public void SetPicture(byte[] buffer)
        {
            if (buffer == null || buffer.Length == 0)
                this.Image = Resources._default;
            else
                this.Image = IOHelper.BytesToImage(buffer);
        }

        public byte[] GetPictureStream()
        {
            if (this.Image == null)
            {
                return new byte[0];
            }
            Bitmap bitmap = new Bitmap(this.Image);
            return IOHelper.ImageToBytes(bitmap);
        }
    }
}
