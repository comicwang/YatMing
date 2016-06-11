using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 商户资料管理系统
{
    public static class SetExToolTip
    {
        static Form _tipForm = null;

        public static void SetTips(this ToolStripLabel control, Form tipForm)
        {
            Control ctl = control.GetCurrentParent().TopLevelControl;
            Rectangle rec = ctl.RectangleToScreen(ctl.Bounds);
            tipForm.Location = new Point(rec.Right - tipForm.Width - 55, rec.Bottom - tipForm.Height - 50);
            _tipForm = tipForm;
            control.MouseHover += control_MouseHover;
            control.MouseLeave += control_MouseLeave;
        }

        static void control_MouseLeave(object sender, EventArgs e)
        {
            if (_tipForm != null)
            {
                _tipForm.Hide();
            }
        }

        static void control_MouseHover(object sender, EventArgs e)
        {
            if (_tipForm != null)
            {
                _tipForm.Show();
            }
        }
    }
}
