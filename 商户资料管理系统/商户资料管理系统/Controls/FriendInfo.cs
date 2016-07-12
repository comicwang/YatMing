using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 商户资料管理系统.YatServer;

namespace 商户资料管理系统
{
    public partial class FriendInfo : UserControl
    {
        private ToolTip tip = new ToolTip();

        public FriendInfo()
        {
            InitializeComponent();
            picImage.ReadOnly = true;
        }

        private FormEmploeeInfo _tipForm = null;

        private byte[] OrginImage;

        public int Order = -1;

        public FriendInfo(FriendData data)
            : this()
        {
            if (data != null)
            {
                lblName.Text = data.Name;
                lblEmotion.Text = data.Emotion;
                tip.SetToolTip(lblEmotion, data.Emotion);
                Order = data.Order;
                ChatName = data.Name;
                _tipForm = new FormEmploeeInfo(data.Data);
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

        public void SetLocation()
        {
            Point point = this.PointToScreen(this.TopLevelControl.Location);
            _tipForm.Location = new Point(point.X - _tipForm.Width, point.Y + picImage.Location.Y);
            picImage.MouseHover += control_MouseHover;
            picImage.MouseLeave += control_MouseLeave;
        }

        void control_MouseLeave(object sender, EventArgs e)
        {
            if (_tipForm != null)
            {
                _tipForm.Hide();
            }
        }

         void control_MouseHover(object sender, EventArgs e)
        {
            if (_tipForm != null)
            {
                _tipForm.Show();
            }
        }

        public event EventHandler ChangedState;

        public void SetState(bool onLine)
        {
            if (onLine)
            {
                Order = 0;
                picImage.SetPicture(OrginImage);
            }
            else
            {
                Order = -1;
                picImage.SetPicGray();
            }
            if (ChangedState != null)
                ChangedState(onLine, EventArgs.Empty);
        }

        public void SetImage(Image img)
        {
            this.picImage.Image = img;
            OrginImage = picImage.GetPictureStream();
        }

        private void FriendInfo_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(251, 239, 191);
        }

        private void FriendInfo_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
        }

        private void FriendInfo_Click(object sender, EventArgs e)
        {
            this.Height = 60;
            picImage.Width = 50;
            picImage.Height = 50;
            lblName.Location = new Point(lblName.Location.X + 20, lblName.Location.Y);
        }

        public void ClearClick()
        {
            this.Height = 40;
            picImage.Width = 30;
            picImage.Height = 30;
            lblName.Location = new Point(lblName.Location.X - 20, lblName.Location.Y);
            Selected = false;
        }

        public bool Selected { get;set; }

        public string ChatName { get; private set; }
    }

    public enum FriendState
    {
        Online,
        OutLine,
        Undefined
    }

    public class FriendData
    {
        public FriendState State { get; set; }

        public string Name { get; set; }

        public byte[] Image { get; set; }

        public string Emotion { get; set; }

        public int Order { get; set; }

        public TEmployeeDTO Data { get; set; }
    }
}
