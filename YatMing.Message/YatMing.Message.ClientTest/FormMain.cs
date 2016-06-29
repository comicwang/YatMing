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

namespace YatMing.Message.ClientTest
{
    public partial class FormMain : Form, IPushCallback
    {
        IPushService _pushProxy = null;
        string _id = string.Empty;

        public FormMain()
        {
            InitializeComponent();
        }

        public void NotifyMessage(string message)
        {
            textBox1.AppendText(message + "\r\n");
        }

        public void NotifyMutimedia(MediaDTO medias)
        {
            richTextBox1.Rtf = Encoding.Default.GetString(medias.MediaContent);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //将回调类型的实例传递给通道
            DuplexChannelFactory<IPushService> channel = new DuplexChannelFactory<IPushService>(new InstanceContext(this), "push");
            _pushProxy = channel.CreateChannel();
            _id = Guid.NewGuid().ToString();
            _pushProxy.Regist(_id);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _pushProxy.UnRegist(_id);
        }
    }
}
