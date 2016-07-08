using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using YatMing.Message.Contracts;

namespace 商户资料管理系统
{
    public partial class FormNotify : Form, IPushCallback
    {
        public IPushService _pushProxy = null;
        string _id = string.Empty;

        public FormNotify(string id)
        {
            InitializeComponent();
            _id = id;
        }

        public void NotifyMessage(string message)
        {
            richTextBox1.Text = message;
            ShowNotify();
        }

        public void NotifyMutimedia(MediaDTO medias)
        {
            richTextBox1.Rtf = Encoding.Default.GetString(medias.MediaContent);
            ShowNotify();
        }

        private void ShowNotify()
        {
            Rectangle rct = Screen.AllScreens[0].WorkingArea;
            this.Left = rct.Width - this.Width - 5;
            this.Top = rct.Height;
            timer1.Start();
           // this.Visible = true;
            this.StartPosition = FormStartPosition.Manual;
            this.Show();
        }

        public void InitializeNotify()
        {
            try
            {
                //将回调类型的实例传递给通道
                DuplexChannelFactory<IPushService> channel = new DuplexChannelFactory<IPushService>(new InstanceContext(this), "push");
                _pushProxy = channel.CreateChannel();
                _pushProxy.Regist(_id);

                Rectangle rct = Screen.AllScreens[0].WorkingArea;
                this.Left = rct.Width - this.Width - 5;
                this.Top = rct.Height;
            }
            catch
            {
            }
        }

        private void FormNotify_Load(object sender, EventArgs e)
        {
            
        }

        private void FormNotify_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
            //_pushProxy.UnRegist(_id);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
             Rectangle rct = Screen.AllScreens[0].WorkingArea;
             if (this.Top >= rct.Height - this.Height)
                 this.Top -= 5;
             else
                 timer1.Stop();
        }
    }
}
