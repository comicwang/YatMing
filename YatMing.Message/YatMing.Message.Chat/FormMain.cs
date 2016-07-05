using LayeredSkin.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YatMing.Message.Chat
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer, true);
          
            InitializeComponent();
        }

        private void layeredButton1_Click(object sender, EventArgs e)
        {

        }

        private void layeredButton2_Click(object sender, EventArgs e)
        {

        }

        private Image ChangeAlpha(Image image, int alp)
        {

            Bitmap img = new Bitmap(image);

            using (Bitmap bmp = new Bitmap(img.Width, img.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
            {

                using (Graphics g = Graphics.FromImage(bmp))
                {

                    g.DrawImage(img, 0, 0);

                    for (int h = 0; h <= img.Height - 1; h++)
                    {

                        for (int w = 0; w <= img.Width - 1; w++)
                        {

                            Color c = img.GetPixel(w, h);

                            bmp.SetPixel(w, h, Color.FromArgb(alp * 255 / 100, c.R, c.G, c.B));

                        }

                    }

                    return (Image)bmp.Clone();

                }

            }

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = ChangeAlpha(this.BackgroundImage,60);
            userRichTexBox1.SetBackGroundImage(this.BackgroundImage, userRichTexBox1.Location, this.Size);
            userRichTexBox1.Text = "你好！";

            userRichTexBox2.SetBackGroundImage(this.BackgroundImage, userRichTexBox2.Location, this.Size);
        }
    }
}
