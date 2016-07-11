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

namespace 商户资料管理系统.Controls
{
    public partial class FriendInfoLst : UserControl
    {
        private YatMingServiceClient _client = ServiceProvider.Clent;

        public FriendInfoLst()
        {
            InitializeComponent();
        }

        public void InitializeFriends()
        {
            TEmployeeDTO[] result = _client.TEmployeeQueryAll();
            Array.ForEach(result, t => {
                FriendData data = new FriendData();
                data.Image = t.EntryImage;
            });
        }
    }
}
