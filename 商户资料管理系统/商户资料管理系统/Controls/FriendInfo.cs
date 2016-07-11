using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 商户资料管理系统.Controls
{
    public partial class FriendInfo : UserControl
    {
        private ToolTip tip = new ToolTip();

        public FriendInfo()
        {
            InitializeComponent();
        }

        private byte[] OrginImage;

        public FriendInfo(FriendData data)
            : this()
        {
            if (data != null)
            {
                lblName.Text = data.Name;
                lblTime.Text = data.LastChatTime.ToString("hh-mm");               
                tip.SetToolTip(lblMessage, data.LastChatMessage);
                lblMessage.Text = data.LastChatMessage;
                if (data.Image != null && data.Image.Length > 0)
                {
                    OrginImage = data.Image;
                    if (data.State == FriendState.Online)
                        picImage.SetPicture(data.Image);
                    else
                    {
                        picImage.SetPicture(data.Image);
                        picImage.SetPicGray();
                    }
                }
                else
                {
                    OrginImage = picImage.GetPictureStream();
                    if (data.State == FriendState.OutLine)
                        picImage.SetPicGray();
                }
            }
        }

        public void SetState(bool onLine)
        {
            if (onLine)
                picImage.SetPicture(OrginImage);
            else
                picImage.SetPicGray();
        }

        public void SetImage(Image img)
        {
            this.picImage.Image = img;
            OrginImage = picImage.GetPictureStream();
        }


        public void UpdateMessage(DateTime date, string message)
        {
            lblTime.Text = date.ToString("hh-mm");
            tip.SetToolTip(lblMessage, message);
            lblMessage.Text = message;
        }
    }

    public enum FriendState
    {
        Online,
        OutLine
    }

    public class FriendData
    {
        public FriendState State { get; set; }

        public string Name { get; set; }

        public byte[] Image { get; set; }

        public DateTime LastChatTime { get; set; }

        public string LastChatMessage { get; set; }
    }
}
