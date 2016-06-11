using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 商户资料管理系统
{
    public partial class WarningBox : UserControl
    {
        public WarningBox()
        {
            InitializeComponent();
            this.Hide();
            toolTip1.SetToolTip(btnClose, "关闭");
        }

        private bool _autoClose = false;
        [Category("行为"),Description("是否自动关闭窗口"),DefaultValue(false)]
        public bool AutoClose
        {
            get { return _autoClose; }
            set { _autoClose = value; tmClose.Enabled = value; }
        }

        [Category("行为"), Description("自动关闭窗口的时间"), DefaultValue(3000)]
        public int AutoCloseTime
        {
            get { return tmClose.Interval; }
            set { tmClose.Interval = value; }
        }

        [Category("行为"), Description("窗口提示类型"), DefaultValue(typeof(MessageType),"Info")]
        public MessageType MessageType
        {
            get { return (MessageType)label1.ImageIndex; }

            set { label1.ImageIndex = Convert.ToInt32(value); }
        }

        [Category("外观"), Description("文字颜色"), DefaultValue(typeof(Color), "Black")]
        public Color FontColor
        {
            get { return label1.ForeColor; }

            set { label1.ForeColor = value; }
        }

        public void ShowMessage(string message)
        {
            label1.Text = message;
            _autoClose = false;
            this.Show();
        }

        public void ShowMessage(string message, MessageType messageType)
        {
            MessageType = messageType;
            ShowMessage(message);
        }

        public void ShowMessage(string message, MessageType messageType, int autoCloseTime)
        {
            ShowMessage(message, messageType);
            _autoClose = true;
            tmClose.Start();
            AutoCloseTime = autoCloseTime;
           
        }

        public void ShowMessage(string message, MessageType messageType, int autoCloseTime, Color fontColor)
        {
            FontColor = fontColor;
            ShowMessage(message, messageType, autoCloseTime);
            FontColor = Color.Black;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            tmClose.Stop();
            this.Hide();
        }

        private void tmClose_Tick(object sender, EventArgs e)
        {
            tmClose.Stop();
            this.Hide();
        }
    }

    public enum MessageType
    {
        Info = 0,
        Warning = 1,
        Error = 2
    }
}
