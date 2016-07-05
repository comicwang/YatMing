using System;  
using System.Collections.Generic;  
using System.ComponentModel;  
using System.Drawing;  
using System.Data;  
using System.Text;  
using System.Windows.Forms;

namespace RichTextBoxBackPicture
{
    public partial class UserRichTexBox : UserControl
    {
        public UserRichTexBox()
        {
            //为用户控制启用双缓冲等控件样式，否则RichTextBox输入时，会有残影  
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
        }

        /// <summary>   
        /// Required designer variable.  
        /// </summary>  
        private System.ComponentModel.IContainer components = null;

        /// <summary>   
        /// Clean up any resources being used.  
        /// </summary>  
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>  
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>   
        /// Required method for Designer support - do not modify   
        /// the contents of this method with the code editor.  
        /// </summary>  
        private void InitializeComponent()
        {
            this.alphaRichTextBox1 = new RichTextBoxBackPicture.AlphaRichTextBox();
            this.SuspendLayout();
            //   
            // alphaRichTextBox1  
            //   
            this.alphaRichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alphaRichTextBox1.Location = new System.Drawing.Point(0, 0);
           // this.alphaRichTextBox1.Name = "alphaRichTextBox1";
            this.alphaRichTextBox1.Size = new System.Drawing.Size(150, 150);
            this.alphaRichTextBox1.TabIndex = 0;
            this.alphaRichTextBox1.Text = "";
            this.alphaRichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            //   
            // UserRichTexBox  
            //   
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.alphaRichTextBox1);
            this.Name = "UserRichTexBox";
            this.ResumeLayout(false);

        }

        #endregion

        private AlphaRichTextBox alphaRichTextBox1;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        public void SetBackGroundImage(Image img, Point point, Size formSize)
        {
            Image transImg = img.GetThumbnailImage(formSize.Width, formSize.Height, null, this.Handle);

            Bitmap result = new Bitmap(this.Width, this.Height);

            Graphics grp = Graphics.FromImage(result);
            grp.DrawImage(transImg, new Rectangle(0, 0, this.Width, this.Height), new Rectangle(0, point.Y, this.Width, this.Height), GraphicsUnit.Pixel);
            grp.Dispose();
            this.BackgroundImage = result;
        }

        public override string Text
        {
            get
            {
                return alphaRichTextBox1.Text;
            }
            set
            {
                alphaRichTextBox1.Text = value;
            }
        }
    }


    public class AlphaRichTextBox : RichTextBox
    {
        //关键点：支持透明背景  
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20;
                return cp;
            }
        }
    }
}
       

