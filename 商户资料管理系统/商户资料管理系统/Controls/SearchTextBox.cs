using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using 商户资料管理系统.Properties;

namespace 商户资料管理系统
{
    public partial class SearchTextBox : TextBox
    {
        public delegate void OnSearchHander(object sender, SearchEventArgs e);

        [Category("数据"), Description("定义TextBox的搜索事件")]
        public event OnSearchHander OnSearch;

        private PictureBox pic = null;

        public SearchTextBox()
        {
            InitializeComponent();
            pic = new PictureBox();
            pic.Image = _searchImage;
            pic.Width = 16;
            pic.Height = 16;
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.MouseEnter += pic_MouseEnter;
            pic.MouseLeave += pic_MouseLeave;
            pic.Click += pic_Click;
            ToolTip tip = new ToolTip();
            tip.SetToolTip(pic, "搜索");
            this.Controls.Add(pic);
            if (onPreset)
                SetPresetText(true);
        }

        private Image _searchImage = Resources.search;

        [Category("外观"), Description("获取或者设置搜索图标,建议使用16*16的png图标")]
        public Image SearchImage
        {
            get { return _searchImage; }
            set { _searchImage = value; pic.Image = value; }
        }

        private string presetText = "请输入商户文字";
        [Category("设计"), Description("获取或者预设文字")]
        public string PresetText
        {
            get { return presetText; }
            set { presetText = value; SetPresetText(true); }
        }


        private bool onPreset = true;
        [Category("设计"), Description("是否设置预设文字"), DefaultValue(true)]
        public bool OnPreset
        {
            get { return onPreset; }
            set { onPreset = value; SetPresetText(value); }
        }

        void pic_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.IBeam;
            pic.BackColor = Color.Transparent;
        }

        void pic_MouseEnter(object sender, EventArgs e)
        {
            pic.BackColor = _hoverColor;
            Cursor = Cursors.Hand;
        }

        void pic_Click(object sender, EventArgs e)
        {
            if (OnSearch != null)
            {
                OnSearch(sender, new SearchEventArgs(this.Text));
            }
        }

        private Color _hoverColor = Color.Gray;

        [Category("外观"), Description("获取或者设置搜索图标鼠标进入的颜色"), DefaultValue(typeof(Color), "gray")]
        public Color HoverColor
        {
            get { return _hoverColor; }
            set { _hoverColor = value; }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private const int WM_PAINT = 0xF;
        private const int Hot_Key = 0x0312;

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers fsModifiers, Keys vk);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        protected override void OnGotFocus(EventArgs e)
        {
            if (onPreset && Text == presetText)
                SetPresetText(false);

            RegisterHotKey(Handle, 100, KeyModifiers.None, Keys.Enter);
            base.OnGotFocus(e);
        }

        private void SetPresetText(bool needPreset)
        {
            if (needPreset)
            {
                ForeColor = Color.Gray;
                Text = presetText;
            }
            else
            {
                ForeColor = Color.Black;
                this.Clear();
            }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            if (onPreset && Text == string.Empty)
                SetPresetText(true);

            UnregisterHotKey(Handle, 100);
            base.OnLostFocus(e);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_PAINT)
            {
                if (BorderStyle == System.Windows.Forms.BorderStyle.FixedSingle)
                {
                    pic.Location = new Point(this.Width - 18, 2);
                }
                else
                    pic.Location = new Point(this.Width - 20, 0);
            }
            else if (m.Msg == Hot_Key)
            {
                if (m.WParam.ToInt32() == 100)
                {
                    //搜索
                    if (OnSearch != null)
                    {
                        OnSearch(this.pic, new SearchEventArgs(this.Text));
                    }
                }
            }

            base.WndProc(ref m);
        }
    }


    public class SearchEventArgs : EventArgs
    {
        public SearchEventArgs(string text)
        {
            _searchText = text;
        }

        private string _searchText;

        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; }
        }

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
}
