using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 商户资料管理系统.YatServer;
using 商户资料管理系统.Common;

namespace 商户资料管理系统
{
    public partial class FriendInfoLst : UserControl
    {
        private YatMingServiceClient _client;
        public Dictionary<string, FriendInfo> Friends = new Dictionary<string, FriendInfo>();
        public int OnlineCount { get; set; }

        public FriendInfoLst()
        {
            InitializeComponent();
        }

        public void InitializeFriends(string myNickName)
        {
            _client = ServiceProvider.Clent;
            OnlineCount = 0;
            Friends.Clear();
            TEmployeeDTO[] result = _client.TEmployeeQueryAll();
            Array.ForEach(result, t => {
                FriendData data = new FriendData();
                data.Image = t.EntryImage;
                data.Name = t.EmployeeName;
                data.Data = t;
                TLoginDTO login = _client.TLoginQueryById(t.EmployeeId);
                data.State = CommomHelper.ParseState(login.State);
                data.Order = login.State;
                if (t.EmployeeName == myNickName)
                {
                    data.Order = 1;
                    data.State = FriendState.Online;
                }
                data.Emotion = t.Emotion;
                FriendInfo info = new FriendInfo(data);
                info.Width = this.Width;
                info.Click += info_Click;
                info.ChangedState += info_ChangedState;
                info.DoubleClick += info_DoubleClick;
                Friends.Add(t.EmployeeName, info);           
            });
            OrderList();
        }

        private void info_ChangedState(object sender, EventArgs e)
        {
            if ((bool)sender)
                OnlineCount++;
            else
                OnlineCount--;
            OrderList();
        }

        private void info_DoubleClick(object sender, EventArgs e)
        {
            if (OnSelected != null)
                OnSelected(sender, e);
        }

        public event EventHandler OnSelected;

        public FriendInfo SelectedInfo { get; set; }

        private void info_Click(object sender, EventArgs e)
        {
            FriendInfo info = sender as FriendInfo;
            info.Selected = true;
            SelectedInfo = info;
            foreach (KeyValuePair<string, FriendInfo> item in Friends)
            {
                if (item.Value.Selected && item.Value != info)
                {
                    item.Value.ClearClick();
                    break;
                }
            }
        }

        public void OrderList()
        {
            var result = Friends.OrderByDescending(t => t.Value.Order).ToList();
            Friends.Clear();            
            foreach (var item in result)
            {
                Friends.Add(item.Key, item.Value);
            }
            pnlMain.Controls.Clear();
            foreach (KeyValuePair<string,FriendInfo> item in Friends)
            {
                this.pnlMain.Controls.Add(item.Value);
                item.Value.SetLocation();
            }
        }
    }
}
