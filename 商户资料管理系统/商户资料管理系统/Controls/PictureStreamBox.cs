using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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
        public event EventHandler OnChangedPicture;
        ToolTip tip = new ToolTip();

        public PictureStreamBox()
        {
            InitializeComponent();
            this.SizeMode = PictureBoxSizeMode.StretchImage;          
            this.Image = Resources._default;
            tip.SetToolTip(this, "双击选择图片");
            this.DoubleClick += PictureStreamBox_Click;
        }

        private bool _readOnly = false;

        public bool ReadOnly
        {
            get 
            { 
                return _readOnly;
            }
            set
            { 
                _readOnly = value;
                if (value)
                    tip.Dispose();
                else
                {
                    tip = new ToolTip();
                    tip.SetToolTip(this, "双击选择图片");
                }
            }
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
                if (OnChangedPicture != null)
                    OnChangedPicture(this, EventArgs.Empty);
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

        public void SetPicGray()
        {
            this.Image = ToGray(new Bitmap(this.Image));
        }

        /**/
        /// <summary>
        /// 变成黑白图
        /// </summary>
        /// <param name="bmp">原始图</param>
        /// <param name="mode">模式。0:加权平均  1:算数平均</param>
        /// <returns></returns>
        private Bitmap ToGray(Bitmap image)
        {
            if (image == null)
            {
                return null;
            }
            //原来图片的长度

            int width = image.Width;

            //原来图片的高度

            int height = image.Height;

            //改变色素

            //横坐标

            for (int x = 0; x < width; x++)
            {

                //纵坐标

                for (int y = 0; y < height; y++)
                {

                    //获得坐标(x,y)颜色

                    Color color = image.GetPixel(x, y);

                    //获得该颜色下的黑白色

                    int value = (color.R + color.G + color.B) / 3;

                    //设置颜色

                    image.SetPixel(x, y, Color.FromArgb(value, value, value));

                }

            }

            return image;
        }
    }
}
