using _SCREEN_CAPTURE;
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
using 商户资料管理系统.Common;
using 商户资料管理系统.YatServer;

namespace 商户资料管理系统
{
    public partial class FormChat : Form
    {
        private static readonly string section = "Skin";
        private static readonly string Id = "ChatSkin";
        private static string dataForlder = Path.Combine(Application.StartupPath, "Skin");
        private string _nickName = string.Empty;
        private string _chatName = string.Empty;
        private FrmCapture m_frmCapture;
        private YatMingServiceClient _client = ServiceProvider.Clent;
        private bool _needFlash = false;
        public FormChat(string nickName, string chatName)
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            _nickName = nickName;
            _chatName = chatName;
            lylblName.Text = _chatName;
            rtbSend.RichTextBox.SelectionFont = Default_Font;
            RegisterHotKey(this.Handle, 102, KeyModifiers.Ctrl, Keys.A);
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers fsModifiers, Keys vk);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private const int Hot_Key = 0x0312;

        #region 拖动窗口

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        #endregion

        #region 窗口闪烁

        [DllImport("user32")]//调用Windows API函数
        private static extern long FlashWindow(IntPtr handle, bool bInvert);


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_needFlash)
                FlashWindow(this.Handle, true);
        }

        public void FlashWindow()
        {
            _needFlash = true;
            timer1.Start();
        }

        #endregion

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == Hot_Key)
            {
                if (m.WParam.ToInt32() == 101)
                {
                    btnSend_Click(null, EventArgs.Empty);
                }
                else if (m.WParam.ToInt32() == 102)
                {
                    StartCapture(true);
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
            try
            {
                //查询对方信息
                TEmployeeDTO result = _client.TEmployeeQueryAll().Where(t => t.EmployeeName == _chatName).FirstOrDefault();
                if (result != null && result.EntryImage != null && result.EntryImage.Length > 0)
                {
                    picImage.SetPicture(result.EntryImage);
                    this.ShowInTaskbar = true;
                }
            }
            catch
            {
            }

            //读取皮肤配置文件
            //选取选中的配置文件
            string skinItem = string.Empty;
            if (SettingHelper.ValueExists(section, Id))
            {
                skinItem = SettingHelper.ReadString(section, Id, string.Empty);
            }
            else
            {
                skinItem = "d8ffa25210f6ab3bf7923ca55fb03b56.jpg";
                SettingHelper.WriteString(section, Id, skinItem);
            }
            this.BackgroundImage = Image.FromFile(Path.Combine(dataForlder, skinItem));
            SetSkin(this.BackgroundImage);
        }

        private void SetSkin(Image image)
        {
            this.BackgroundImage = ChangeAlpha(image, 60);
            menuWord.SetBackgroundImage(this.BackgroundImage, panel2.Location, this.Size);
            rtbHistory.SetBackgroundImage(this.BackgroundImage, pnlHistory.Location, this.Size);
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
            rtbHistory.RichTextBox.AppendText(sendPeople + " " + DateTime.Now + "\r\n");

            rtbHistory.RichTextBox.Select(rtbHistory.RichTextBox.Text.Length, 0);
            rtbHistory.RichTextBox.SelectedRtf = text;

            rtbHistory.RichTextBox.ScrollToCaret();
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
            _needFlash = false;
            timer1.Stop();
            RegisterHotKey(Handle, 101, KeyModifiers.None, Keys.Enter);
        }

        private void FormMain_Deactivate(object sender, EventArgs e)
        {
            _needFlash = true;
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

        //启动截图
        private void StartCapture(bool bFromClip)
        {
            if (m_frmCapture == null || m_frmCapture.IsDisposed)
            {
                m_frmCapture = new FrmCapture();
                m_frmCapture.OnFinished += m_frmCapture_OnFinished;
            }
            m_frmCapture.IsCaptureCursor = true;//checkBox_CaptureCursor.Checked;
            m_frmCapture.IsFromClipBoard = bFromClip;
            m_frmCapture.Show();
        }

        void m_frmCapture_OnFinished(object sender, EventArgs e)
        {
            rtbSend.RichTextBox.Paste();
        }

        private void tsmCutScreen_Click(object sender, EventArgs e)
        {
            StartCapture(false);
        }

        private void layeredPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        //表情图
        FormFace form = null;

        private void tsmFace_Click(object sender, EventArgs e)
        {
            Point point = menuWord.PointToScreen(menuWord.Location);
            if (form == null)
            {
                form = new FormFace();
                form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                form.StartPosition = FormStartPosition.Manual;
                form.AddFace += form_AddFace;
            }
            form.Location = new Point(point.X + 60, point.Y - form.Height + 20);
            form.Show();
        }

        private void form_AddFace(string faceID)
        {
            rtbSend.RichTextBox.AddFile(IOHelper.ImageToBytes((Bitmap)Properties.Resources.ResourceManager.GetObject(faceID)));
        }

        //字体
        private static readonly Font Default_Font = new Font("宋体", 12);

        private Font oldFont = null;
        private Font newFont = null;

        private void tsbBold_Click(object sender, EventArgs e)
        {
            oldFont = this.rtbSend.RichTextBox.SelectionFont;
            if (oldFont.Bold)
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Bold);
            else
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Bold);
            tsbBold.Checked = !oldFont.Bold;
            this.rtbSend.RichTextBox.SelectionFont = newFont;
            this.rtbSend.RichTextBox.Focus();
        }

        private void tsbItal_Click(object sender, EventArgs e)
        {
            oldFont = this.rtbSend.RichTextBox.SelectionFont;
            if (oldFont.Italic)
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Italic);
            else
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Italic);
            tsbItal.Checked = !oldFont.Italic;
            this.rtbSend.RichTextBox.SelectionFont = newFont;
            this.rtbSend.RichTextBox.Focus();
        }

        private void tsbUnderline_Click(object sender, EventArgs e)
        {
            oldFont = this.rtbSend.RichTextBox.SelectionFont;
            if (oldFont.Underline)
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Underline);
            else
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Underline);
            tsbUnderline.Checked = !oldFont.Underline;
            this.rtbSend.RichTextBox.SelectionFont = newFont;
            this.rtbSend.RichTextBox.Focus();
        }

        private void tsbLeft_Click(object sender, EventArgs e)
        {
            if (this.rtbSend.RichTextBox.SelectionAlignment == HorizontalAlignment.Left)
                this.rtbSend.RichTextBox.SelectionAlignment = HorizontalAlignment.Center;
            else
                this.rtbSend.RichTextBox.SelectionAlignment = HorizontalAlignment.Left;
            this.rtbSend.RichTextBox.Focus();
        }

        private void tsbCenter_Click(object sender, EventArgs e)
        {
            if (this.rtbSend.RichTextBox.SelectionAlignment == HorizontalAlignment.Center)
                this.rtbSend.RichTextBox.SelectionAlignment = HorizontalAlignment.Left;
            else
                this.rtbSend.RichTextBox.SelectionAlignment = HorizontalAlignment.Center;
            this.rtbSend.RichTextBox.Focus();
        }

        private void tsbRight_Click(object sender, EventArgs e)
        {
            if (this.rtbSend.RichTextBox.SelectionAlignment == HorizontalAlignment.Right)
                this.rtbSend.RichTextBox.SelectionAlignment = HorizontalAlignment.Left;
            else
                this.rtbSend.RichTextBox.SelectionAlignment = HorizontalAlignment.Right;
            this.rtbSend.RichTextBox.Focus();
        }

        private void tsbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tsbSize.Text))
                return;
            rtbSend.RichTextBox.SelectionFont = new Font(tsbFont.Text, GeneralUtil.ParseInt(tsbSize.Text));
            rtbSend.RichTextBox.Focus();
        }

        private void tsbFont_DropDown(object sender, EventArgs e)
        {
            tsbFont.LoadFontFamilies();
        }

        private void tsbSize_DropDown(object sender, EventArgs e)
        {
            if (tsbSize.Items.Count == 0)
                this.tsbSize.Items.AddRange(new object[] {
            "8",
            "10",
            "12",
            "14",
            "18",
            "24",
            "36"});
        }

        private void tsbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbSend.RichTextBox.SelectionFont = new Font(tsbFont.Text, GeneralUtil.ParseInt(tsbSize.Text));
            rtbSend.RichTextBox.Focus();
        }

        private void tsbSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                if (e.KeyChar <= '7' && e.KeyChar > '0')
                    tsbSize.SelectedIndex = GeneralUtil.ParseInt(e.KeyChar) - 1;
            }
            else if (!Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tsmColor_ButtonClick(object sender, EventArgs e)
        {
            rtbSend.RichTextBox.SelectionColor = tsmColor.Color;
        }

        private void tsmColor_SelectedColorChanged(object sender, EventArgs e)
        {
            rtbSend.RichTextBox.SelectionColor = tsmColor.Color;
        }

        private void tsmFont_Click(object sender, EventArgs e)
        {
            tsFont.Visible = !tsFont.Visible;
            //pnlHistory.Height = tsbFont.Visible ? pnlHistory.Height - 26 : pnlHistory.Height + 26;
        }

        private void tsbClear_Click(object sender, EventArgs e)
        {
            tsbSize.Text = "12";
            tsbFont.Text = "宋体";
            rtbSend.RichTextBox.SelectionFont = Default_Font;
            rtbSend.RichTextBox.SelectionColor = DefaultForeColor;
        }

    }

    public class EventSendMessage : EventArgs
    {
        public string Message { get; set; }

        public string ChatName { get; set; }
    }
}
