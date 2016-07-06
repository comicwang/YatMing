using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YatMing.Message.Chat
{
    public static class CommonHelp
    {
        public static void SetBackgroundImage(this Control control, Image img,Point point, Size formSize)
        {
            Image transImg = img.GetThumbnailImage(formSize.Width, formSize.Height, null, control.Handle);
            Bitmap result = new Bitmap(control.Width, control.Height);
            Graphics grp = Graphics.FromImage(result);
            grp.DrawImage(transImg, new Rectangle(0, 0, control.Width, control.Height), new Rectangle(point.X, point.Y, control.Width, control.Height), GraphicsUnit.Pixel);
            grp.Dispose();
            control.BackgroundImage = result;
        }

        public static void SetBackgroundImage(this Panel control, Image img, Point point, Size formSize)
        {
            Image transImg = img.GetThumbnailImage(formSize.Width, formSize.Height, null, control.Handle);
            Bitmap result = new Bitmap(control.Width, control.Height);
            Graphics grp = Graphics.FromImage(result);
            grp.DrawImage(transImg, new Rectangle(0, 0, control.Width, control.Height), new Rectangle(point.X, point.Y, control.Width, control.Height), GraphicsUnit.Pixel);
            grp.Dispose();
            control.BackgroundImage = result;
        }

        public static void InsertImage(this RichTextBox rictextBox, Image image)
        {
            Clipboard.SetImage(image);
            rictextBox.Paste();
            Clipboard.Clear();
        }
    }
}
