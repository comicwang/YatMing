using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 商户资料管理系统
{
    internal class FaceBox : Label
    {
        internal FaceBox(int FaceID)
        {
            //样式控制
            base.AutoSize = false;
            base.Text = string.Empty;
            base.BackColor = Color.Transparent;
            this.Size = new Size(30, 30);

            //屏闭系统绘制
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.UserPaint, true);
            this.UpdateStyles();
            this.DoubleBuffered = true;

            this.faceID = FaceID;
        }

        //样式控制
        internal new bool AutoSize { get { return false; } }
        internal new string Text { get { return string.Empty; } }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (this.Size != new Size(30, 30))
                this.Size = new Size(30, 30);
        }

        int faceID;

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            e.Graphics.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("Face_" + this.faceID), 3, 3, 24, 24);

            if (this.mouseOn)
                e.Graphics.DrawRectangle(Pens.SteelBlue, 0, 0, this.Width - 1, this.Height - 1);
        }

        bool mouseOn;
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            this.mouseOn = true;
            this.Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            this.mouseOn = false;
            this.Invalidate();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (this.Selected != null)
                this.Selected(this.faceID);
        }

        internal delegate void SelectedHandler(int faceID);
        internal event SelectedHandler Selected;
    }
}
