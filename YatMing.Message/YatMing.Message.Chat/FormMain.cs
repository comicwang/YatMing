using LayeredSkin.Forms;
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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace YatMing.Message.Chat
{
    public partial class FormMain : Form
    {
        private string _nickName = string.Empty;
        private string _chatName = string.Empty;
        public FormMain(string nickName, string chatName)
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            _nickName = nickName;
            _chatName = chatName;
            lylblName.Text = _chatName;
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers fsModifiers, Keys vk);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private const int Hot_Key = 0x0312;

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == Hot_Key)
            {
                if (m.WParam.ToInt32() == 101)
                {
                    btnSend_Click(null, EventArgs.Empty);
                }
            }

            base.WndProc(ref m);
        }

        private void layeredButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void layeredButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private Image ChangeAlpha(Image image, int alp)
        {

            Bitmap img = new Bitmap(image);

            using (Bitmap bmp = new Bitmap(img.Width, img.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
            {

                using (Graphics g = Graphics.FromImage(bmp))
                {

                    g.DrawImage(img, 0, 0);

                    for (int h = 0; h <= img.Height - 1; h++)
                    {

                        for (int w = 0; w <= img.Width - 1; w++)
                        {

                            Color c = img.GetPixel(w, h);

                            bmp.SetPixel(w, h, Color.FromArgb(alp * 255 / 100, c.R, c.G, c.B));

                        }

                    }

                    return (Image)bmp.Clone();

                }

            }

        }

        private Color GetMiddleColor(Image image)
        {
            Dictionary<Color, int> dicColor = new Dictionary<Color, int>();
            int count = 0;
            Color result = Color.Black;
            Bitmap img = new Bitmap(image);
            using (Bitmap bmp = new Bitmap(img.Width, img.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
            {
                using (Graphics grp = Graphics.FromImage(bmp))
                {
                    grp.DrawImage(img, 0, 0);
                    for (int h = 0; h <= img.Height - 1; h++)
                    {

                        for (int w = 0; w <= img.Width - 1; w++)
                        {
                            Color c = img.GetPixel(w, h);
                            if (dicColor.ContainsKey(c))
                                dicColor[c] += 1;
                            else
                                dicColor.Add(c, 0);
                        }
                    }
                }

            }
            foreach (KeyValuePair<Color, int> item in dicColor)
            {
                if (count < item.Value)
                {
                    count = item.Value;
                    result = item.Key;
                }
            }
            return result;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            rtbHistory.RichTextBox.ReadOnly = true;
            SetSkin(this.BackgroundImage);
        }

        private void SetSkin(Image image)
        {
            this.BackgroundImage = ChangeAlpha(image, 60);
            menuWord.SetBackgroundImage(this.BackgroundImage, panel2.Location, this.Size);
            rtbHistory.SetBackgroundImage(this.BackgroundImage, panel3.Location, this.Size);
            rtbSend.SetBackGroundImage(this.BackgroundImage, rtbSend.Location, this.Size);
            Color midColor = GetMiddleColor(image);
            btnClose.BackColor = midColor;
            btnSend.BackColor = midColor;
        }

        private void lybtnSkin_Click(object sender, EventArgs e)
        {
            Point point = new Point(this.Location.X + this.Width - 30, this.Location.Y + 30);
            FormSkin form = new FormSkin();
            form.StartPosition = FormStartPosition.Manual;
            form.Location = point;
            if (form.ShowDialog() == DialogResult.OK)
            {
                SetSkin(form.SelectedImage);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void AppendRtf(string text, string sendPeople)
        {
            //发送头
            rtbHistory.RichTextBox.SelectionColor = Color.Blue;
            rtbHistory.RichTextBox.AppendText(sendPeople + DateTime.Now + "\r\n");

            rtbHistory.RichTextBox.Select(rtbHistory.RichTextBox.Text.Length, 0);
            rtbHistory.RichTextBox.SelectedRtf = text;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //自己这边新增消息
            AppendRtf(rtbSend.RichTextBox.Rtf, _nickName);
            //发送消息
            if (OnSendMessage != null)
                OnSendMessage(this, new EventSendMessage() { Message = rtbSend.RichTextBox.Rtf, ChatName = _chatName });
            rtbSend.RichTextBox.Clear();
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {
            RegisterHotKey(Handle, 101, KeyModifiers.None, Keys.Enter);
        }

        private void FormMain_Deactivate(object sender, EventArgs e)
        {
            UnregisterHotKey(Handle, 101);
        }

        private void tsmImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "图片文件|*.png;*.jpg;*.jpeg";
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Array.ForEach(dialog.FileNames, t =>
                {
                    rtbSend.RichTextBox.InsertImage(Image.FromFile(t));
                });
            }
        }

        /// <summary>
        /// 显示消息
        /// </summary>
        /// <param name="tip"></param>
        public void ShowTips(string tip)
        {
            warningBox1.ShowMessage(tip, MessageType.Info);
        }

        public delegate void SendMessageHandle(object sender, EventSendMessage e);

        public event SendMessageHandle OnSendMessage;
    }

    [Flags()]
    public enum KeyModifiers
    {
        None = 0,
        Alt = 1,
        Ctrl = 2,
        Shift = 4,
        WindowsKey = 8
    }

    public class EventSendMessage : EventArgs
    {
        public string Message { get; set; }

        public string ChatName { get; set; }
    }
}
