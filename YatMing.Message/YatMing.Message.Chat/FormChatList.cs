using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace YatMing.Message.Chat
{
    public partial class FormChatList : Form
    {

        private TcpClient _client;
        private BinaryReader _br;
        private BinaryWriter _bw;
        private bool _isExit = false;
        private Dictionary<string, FormMain> _lstChatForm = new Dictionary<string, FormMain>();
        private string _nickName = string.Empty;

        public FormChatList(string nickName)
        {
            InitializeComponent();
            _nickName = nickName;
            Text = _nickName;
        }

        private void FormChatList_Load(object sender, EventArgs e)
        {
            //登录到服务器
            try
            {
                _client = new TcpClient();
                _client.Connect(IPAddress.Parse(ConfigurationManager.AppSettings["Ip"]), int.Parse(ConfigurationManager.AppSettings["Port"]));
            }
            catch (Exception ex)
            {
                MessageBox.Show("链接服务器失败：" + ex.Message);
                return;
            }
            //获取网络流
            NetworkStream networkStream = _client.GetStream();
            //将网络流作为二进制读写对象
            _br = new BinaryReader(networkStream);
            _bw = new BinaryWriter(networkStream);
            Thread threadReceive = new Thread(new ThreadStart(ReceiveData));
            threadReceive.IsBackground = true;
            threadReceive.Start();
            //发送登录消息
            SendMessage("Login," + _nickName);
        }

        /// <summary>
        /// 处理服务器信息
        /// </summary>
        private void ReceiveData()
        {
            string receiveString = null;
            Action actionDelegate = null;
            while (_isExit == false)
            {
                try
                {
                    //从网络流中读出字符串
                    //此方法会自动判断字符串长度前缀，并根据长度前缀读出字符串
                    receiveString = _br.ReadString();
                }
                catch
                {
                    if (_isExit == false)
                    {
                        MessageBox.Show("与服务器失去连接");
                    }
                    break;
                }
                string[] splitString = receiveString.Split(',');
                string command = splitString[0].ToLower();
                actionDelegate = null;
                if (_nickName == splitString[1])
                    continue;
                switch (command)
                {
                    case "login":   //格式： login,用户名                    
                        actionDelegate = () =>
                           {
                               FormMain form = new FormMain(_nickName, splitString[1]);
                               form.OnSendMessage += form_OnSendMessage;
                               _lstChatForm.Add(splitString[1], form);
                               lstFriend.Items.Add(splitString[1]);
                           };

                        break;
                    case "logout":  //格式： logout,用户名
                        actionDelegate = () =>
                           {
                               FormMain form = _lstChatForm[splitString[1]];
                               form.ShowTips("对方已经离线，可能无法立即回复");
                               _lstChatForm.Remove(splitString[1]);
                               lstFriend.Items.Remove(splitString[1]);
                           };
                        break;
                    case "talk":    //格式： talk,用户名,对话信息
                        actionDelegate = () =>
                           {
                               FormMain form = _lstChatForm[splitString[1]];
                               form.Show();
                               form.AppendRtf(splitString[2], splitString[1]);
                           };
                        break;
                    default:
                        break;
                }
                if (actionDelegate != null)
                    this.Invoke(actionDelegate);
            }
            Application.Exit();
        }

        private void form_OnSendMessage(object sender, EventSendMessage e)
        {
            SendMessage("Talk," + e.ChatName + "," + e.Message);
        }

        /// <summary>
        /// 向服务端发送消息
        /// </summary>
        /// <param name="message"></param>
        private void SendMessage(string message)
        {
            try
            {
                //将字符串写入网络流，此方法会自动附加字符串长度前缀
                _bw.Write(message);
                _bw.Flush();
            }
            catch
            {
                MessageBox.Show("发送失败");
            }
        }

        private void FormChatList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_client != null)
            {
                try
                {
                    SendMessage("Logout," + _nickName);
                    _isExit = true;
                    _br.Close();
                    _bw.Close();
                    _client.Close();
                }
                catch
                {
                }
            }
        }

        private void lstFriend_DoubleClick(object sender, EventArgs e)
        {
           string chat= lstFriend.SelectedItem.ToString();
           FormMain form = _lstChatForm[chat];
           form.Show();
        }
    }
}
