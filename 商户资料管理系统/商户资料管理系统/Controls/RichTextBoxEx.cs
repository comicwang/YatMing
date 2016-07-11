
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace 商户资料管理系统
{
    public class RichTextBoxEx : RichTextBox
    {
        #region Interop-Defines
        [StructLayout(LayoutKind.Sequential)]
        private struct CHARFORMAT2_STRUCT
        {
            public UInt32 cbSize;
            public UInt32 dwMask;
            public UInt32 dwEffects;
            public Int32 yHeight;
            public Int32 yOffset;
            public Int32 crTextColor;
            public byte bCharSet;
            public byte bPitchAndFamily;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public char[] szFaceName;
            public UInt16 wWeight;
            public UInt16 sSpacing;
            public int crBackColor; // Color.ToArgb() -> int
            public int lcid;
            public int dwReserved;
            public Int16 sStyle;
            public Int16 wKerning;
            public byte bUnderlineType;
            public byte bAnimation;
            public byte bRevAuthor;
            public byte bReserved1;
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        private const int WM_USER = 0x0400;
        private const int EM_GETCHARFORMAT = WM_USER + 58;
        private const int EM_SETCHARFORMAT = WM_USER + 68;
        private const int SCF_SELECTION = 0x0001;
        private const int SCF_WORD = 0x0002;
        private const int SCF_ALL = 0x0004;
        #region CHARFORMAT2 Flags
        private const UInt32 CFE_BOLD = 0x0001;
        private const UInt32 CFE_ITALIC = 0x0002;
        private const UInt32 CFE_UNDERLINE = 0x0004;
        private const UInt32 CFE_STRIKEOUT = 0x0008;
        private const UInt32 CFE_PROTECTED = 0x0010;
        private const UInt32 CFE_LINK = 0x0020;
        private const UInt32 CFE_AUTOCOLOR = 0x40000000;
        private const UInt32 CFE_SUBSCRIPT = 0x00010000;  /* Superscript and subscript are */
        private const UInt32 CFE_SUPERSCRIPT = 0x00020000;  /*  mutually exclusive    */
        private const int CFM_SMALLCAPS = 0x0040;   /* (*) */
        private const int CFM_ALLCAPS = 0x0080;   /* Displayed by 3.0 */
        private const int CFM_HIDDEN = 0x0100;   /* Hidden by 3.0 */
        private const int CFM_OUTLINE = 0x0200;   /* (*) */
        private const int CFM_SHADOW = 0x0400;   /* (*) */
        private const int CFM_EMBOSS = 0x0800;   /* (*) */
        private const int CFM_IMPRINT = 0x1000;   /* (*) */
        private const int CFM_DISABLED = 0x2000;
        private const int CFM_REVISED = 0x4000;
        private const int CFM_BACKCOLOR = 0x04000000;
        private const int CFM_LCID = 0x02000000;
        private const int CFM_UNDERLINETYPE = 0x00800000;  /* Many displayed by 3.0 */
        private const int CFM_WEIGHT = 0x00400000;
        private const int CFM_SPACING = 0x00200000;  /* Displayed by 3.0 */
        private const int CFM_KERNING = 0x00100000;  /* (*) */
        private const int CFM_STYLE = 0x00080000;  /* (*) */
        private const int CFM_ANIMATION = 0x00040000;  /* (*) */
        private const int CFM_REVAUTHOR = 0x00008000;

        private const UInt32 CFM_BOLD = 0x00000001;
        private const UInt32 CFM_ITALIC = 0x00000002;
        private const UInt32 CFM_UNDERLINE = 0x00000004;
        private const UInt32 CFM_STRIKEOUT = 0x00000008;
        private const UInt32 CFM_PROTECTED = 0x00000010;
        private const UInt32 CFM_LINK = 0x00000020;
        private const UInt32 CFM_SIZE = 0x80000000;
        private const UInt32 CFM_COLOR = 0x40000000;
        private const UInt32 CFM_FACE = 0x20000000;
        private const UInt32 CFM_OFFSET = 0x10000000;
        private const UInt32 CFM_CHARSET = 0x08000000;
        private const UInt32 CFM_SUBSCRIPT = CFE_SUBSCRIPT | CFE_SUPERSCRIPT;
        private const UInt32 CFM_SUPERSCRIPT = CFM_SUBSCRIPT;
        private const byte CFU_UNDERLINENONE = 0x00000000;
        private const byte CFU_UNDERLINE = 0x00000001;
        private const byte CFU_UNDERLINEWORD = 0x00000002; /* (*) displayed as ordinary underline */
        private const byte CFU_UNDERLINEDOUBLE = 0x00000003; /* (*) displayed as ordinary underline */
        private const byte CFU_UNDERLINEDOTTED = 0x00000004;
        private const byte CFU_UNDERLINEDASH = 0x00000005;
        private const byte CFU_UNDERLINEDASHDOT = 0x00000006;
        private const byte CFU_UNDERLINEDASHDOTDOT = 0x00000007;
        private const byte CFU_UNDERLINEWAVE = 0x00000008;
        private const byte CFU_UNDERLINETHICK = 0x00000009;
        private const byte CFU_UNDERLINEHAIRLINE = 0x0000000A; /* (*) displayed as ordinary underline */
        #endregion
        #endregion
        public RichTextBoxEx()
        {
            // Otherwise, non-standard links get lost when user starts typing
            // next to a non-standard link
            this.DetectUrls = false;
        }

        [DefaultValue(false)]
        public new bool DetectUrls
        {
            get { return base.DetectUrls; }
            set { base.DetectUrls = value; }
        }
        /// <summary>
        /// Insert a given text as a link into the RichTextBox at the current insert position.
        /// </summary>
        /// <param name="text">Text to be inserted</param>
        public void InsertLink(string text)
        {
            InsertLink(text, this.SelectionStart);
        }
        /// <summary>
        /// Insert a given text at a given position as a link. 
        /// </summary>
        /// <param name="text">Text to be inserted</param>
        /// <param name="position">Insert position</param>
        public void InsertLink(string text, int position)
        {
            if (position < 0 || position > this.Text.Length)
                throw new ArgumentOutOfRangeException("position");
            this.SelectionStart = position;
            this.SelectedText = text;
            this.Select(position, text.Length);
            this.SetSelectionLink(true);
            this.Select(position + text.Length, 0);
        }

        /// <summary>
        /// Insert a given text at at the current input position as a link.
        /// The link text is followed by a hash (#) and the given hyperlink text, both of
        /// them invisible.
        /// When clicked on, the whole link text and hyperlink string are given in the
        /// LinkClickedEventArgs.
        /// </summary>
        /// <param name="text">Text to be inserted</param>
        /// <param name="hyperlink">Invisible hyperlink string to be inserted</param>
        public void InsertLink(string text, string hyperlink)
        {
            InsertLink(text, hyperlink, this.SelectionStart);
        }
        /// <summary>
        /// Insert a given text at a given position as a link. The link text is followed by
        /// a hash (#) and the given hyperlink text, both of them invisible.
        /// When clicked on, the whole link text and hyperlink string are given in the
        /// LinkClickedEventArgs.
        /// </summary>
        /// <param name="text">Text to be inserted</param>
        /// <param name="hyperlink">Invisible hyperlink string to be inserted</param>
        /// <param name="position">Insert position</param>
        public void InsertLink(string text, string hyperlink, int position)
        {
            if (position < 0 || position > this.Text.Length)
                throw new ArgumentOutOfRangeException("position");
            this.SelectionStart = position;
            this.SelectedRtf = @"{\rtf1\ansi\ansicpg936\deff0\deflang1033\deflangfe2052 " + text + @"\v #" + hyperlink + @"\v0}";
            this.Select(position, text.Length + hyperlink.Length + 1);
            this.SetSelectionLink(true);
            this.Select(position + text.Length + hyperlink.Length + 1, 0);
        }
        /// <summary>
        /// Set the current selection's link style
        /// </summary>
        /// <param name="link">true: set link style, false: clear link style</param>
        public void SetSelectionLink(bool link)
        {
            SetSelectionStyle(CFM_LINK, link ? CFE_LINK : 0);
        }
        /// <summary>
        /// Get the link style for the current selection
        /// </summary>
        /// <returns>0: link style not set, 1: link style set, -1: mixed</returns>
        public int GetSelectionLink()
        {
            return GetSelectionStyle(CFM_LINK, CFE_LINK);
        }

        private void SetSelectionStyle(UInt32 mask, UInt32 effect)
        {
            CHARFORMAT2_STRUCT cf = new CHARFORMAT2_STRUCT();
            cf.cbSize = (UInt32)Marshal.SizeOf(cf);
            cf.dwMask = mask;
            cf.dwEffects = effect;
            IntPtr wpar = new IntPtr(SCF_SELECTION);
            IntPtr lpar = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
            Marshal.StructureToPtr(cf, lpar, false);
            IntPtr res = SendMessage(Handle, EM_SETCHARFORMAT, wpar, lpar);
            Marshal.FreeCoTaskMem(lpar);
        }

        private int GetSelectionStyle(UInt32 mask, UInt32 effect)
        {
            CHARFORMAT2_STRUCT cf = new CHARFORMAT2_STRUCT();
            cf.cbSize = (UInt32)Marshal.SizeOf(cf);
            cf.szFaceName = new char[32];
            IntPtr wpar = new IntPtr(SCF_SELECTION);
            IntPtr lpar = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
            Marshal.StructureToPtr(cf, lpar, false);
            IntPtr res = SendMessage(Handle, EM_GETCHARFORMAT, wpar, lpar);
            cf = (CHARFORMAT2_STRUCT)Marshal.PtrToStructure(lpar, typeof(CHARFORMAT2_STRUCT));
            int state;
            // dwMask holds the information which properties are consistent throughout the selection:
            if ((cf.dwMask & mask) == mask)
            {
                if ((cf.dwEffects & effect) == effect)
                    state = 1;
                else
                    state = 0;
            }
            else
            {
                state = -1;
            }

            Marshal.FreeCoTaskMem(lpar);
            return state;
        }

        //关键点：支持透明背景  
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20;
                return cp;
            }
        }

        //支持GIF

        /// <summary>
        /// 重绘
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0xF)
            {
                foreach (Control _SubControl in base.Controls)
                {
                    _SubControl.Tag = "1";
                }

                GetRichTextObjRectangle();

                for (int i = 0; i != base.Controls.Count; i++)
                {
                    if (base.Controls[i].Tag.ToString() == "1")
                    {
                        base.Controls.RemoveAt(i);
                        i--;
                    }
                }
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// 添加一个文件资源到RTF数据
        /// </summary>
        /// <param name="p_FileFullPath">文件路径</param>    
        public void AddFile(byte[] _FileBytes)
        {
           // byte[] _FileBytes = File.ReadAllBytes(p_FileFullPath);
            Image _Image = Image.FromStream(new MemoryStream(_FileBytes));
            string _Guid = BitConverter.ToString(Guid.NewGuid().ToByteArray()).Replace("-", "");
            StringBuilder _RtfText = new StringBuilder(@"{\rtf1\ansi\ansicpg936\deff0\deflang1033\deflangfe2052{\fonttbl{\f0\fnil\fcharset134 \'cb\'ce\'cc\'e5;}}\uc1\pard\lang2052\f0\fs18{\object\objemb{\*\objclass Paint.Picture}");
            int _Width = _Image.Width * 15;
            int _Height = _Image.Height * 15;
            _RtfText.Append(@"\objw" + _Width.ToString() + @"\objh" + _Height.ToString());
            _RtfText.AppendLine(@"{\*\objdata");
            _RtfText.AppendLine(@"010500000200000007000000504272757368000000000000000000" + BitConverter.ToString(BitConverter.GetBytes(_FileBytes.Length + 20)).Replace("-", ""));
            _RtfText.Append("7A676B65" + _Guid); //标记            
            _RtfText.AppendLine(BitConverter.ToString(_FileBytes).Replace("-", ""));
            _RtfText.AppendLine(@"0105000000000000}{\result{\pict\wmetafile0}}}}");
            base.SelectedRtf = _RtfText.ToString();
        }

        /// <summary>
        /// 获取选择的文件
        /// </summary>
        /// <returns>文件列表</returns>
        public IList<MemoryStream> LoadSelectFile()
        {
            IList<MemoryStream> _FileList = new List<MemoryStream>();
            int _Index = base.SelectedRtf.IndexOf(@"{\*\objdata");
            if (_Index == -1) return _FileList;

            while (_Index != -1)
            {
                MemoryStream _File = new MemoryStream();
                _Index += 80;
                string _LengthText = base.SelectedRtf.Substring(_Index, 8);

                int _Length = BitConverter.ToInt32(new byte[] { Convert.ToByte(_LengthText.Substring(0, 2), 16), Convert.ToByte(_LengthText.Substring(2, 2), 16), Convert.ToByte(_LengthText.Substring(4, 2), 16), Convert.ToByte(_LengthText.Substring(6, 2), 16) }, 0);
                _Index += 10;

                string _Head = base.SelectedRtf.Substring(_Index, 8);
                if (_Head.ToUpper() == "7A676B65")
                {
                    _Index += 40;
                    _Length -= 20;
                    int _EndIndex = base.SelectedRtf.IndexOf("01050000", _Index);
                    int _ReadIndex = 0;
                    _FileList.Add(LoadMemoryStream(base.SelectedRtf.Substring(_Index, _EndIndex - _Index), ref _ReadIndex, _Length));
                    _Index = _EndIndex;
                }
                _Index = base.SelectedRtf.IndexOf(@"{\*\objdata", _Index);
            }
            return _FileList;
        }

        /// <summary>
        /// 获取图形或则改动PictureBox的位置
        /// </summary>
        /// <param name="p_Rtf"></param>
        private void PointFile(string p_Rtf, Point p_StarPoint, int p_Width, int p_Height)
        {
            int _Index = p_Rtf.IndexOf(@"{\*\objdata");
            if (_Index == -1) return;
            _Index += 80;
            string _LengthText = p_Rtf.Substring(_Index, 8);

            int _Length = BitConverter.ToInt32(new byte[] { Convert.ToByte(_LengthText.Substring(0, 2), 16), Convert.ToByte(_LengthText.Substring(2, 2), 16), Convert.ToByte(_LengthText.Substring(4, 2), 16), Convert.ToByte(_LengthText.Substring(6, 2), 16) }, 0);
            _Index += 10;

            string _Head = p_Rtf.Substring(_Index, 8);
            if (_Head.ToUpper() != "7A676B65") return;   //如果不是标记出来的 就不生成PictureBox
            _Index += 8;

            string _Guid = p_Rtf.Substring(_Index, 32);

            Control _Controls = base.Controls[_Guid];
            if (_Controls == null)
            {
                PictureBox _PictureBox = new PictureBox();
                _PictureBox.Name = _Guid;
                _PictureBox.Tag = "0";
                _PictureBox.Location = p_StarPoint;
                _PictureBox.Size = new Size(p_Width, p_Height);

                _Index += 32;
                _Length -= 20;

                _PictureBox.Image = Image.FromStream(LoadMemoryStream(p_Rtf, ref _Index, _Length));

                base.Controls.Add(_PictureBox);
            }
            else
            {
                _Controls.Location = p_StarPoint;
                _Controls.Size = new Size(p_Width, p_Height);
                _Controls.Tag = "0";
            }
        }

        /// <summary>
        /// 根据RTF保存的内容获取内存流
        /// </summary>
        /// <param name="p_Text">RTF</param>
        /// <param name="p_Index">开始位置</param>
        /// <param name="p_Count">读取数量</param>
        /// <returns>内存流</returns>
        private MemoryStream LoadMemoryStream(string p_Text, ref int p_Index, int p_Count)
        {
            MemoryStream _File = new MemoryStream();
            char[] _Text = p_Text.ToCharArray();
            for (int i = 0; i != p_Count; i++)
            {
                if (_Text[p_Index] == '\r' && _Text[p_Index + 1] == '\n')
                {
                    i--;
                }
                else
                {
                    _File.WriteByte(Convert.ToByte(_Text[p_Index].ToString() + _Text[p_Index + 1].ToString(), 16));
                }
                p_Index += 2;
            }
            return _File;
        }

        /// <summary>
        /// 获取RICHTEXTBOX所有图形的位置
        /// </summary>
        /// <param name="p_RichTextBox">RICHTEXTBOX</param>
        /// <returns>位置信息</returns>
        private void GetRichTextObjRectangle()
        {
            RichTextBox _RichText = new RichTextBox();
            _RichText.Rtf = base.Rtf;
            int _Count = base.Text.Length;

            for (int i = 0; i != _Count; i++)
            {
                if (base.Text[i] == ' ')
                {
                    _RichText.Select(i, 1);

                    if (_RichText.SelectionType.ToString() == "Object")
                    {
                        Point _StarPoint = base.GetPositionFromCharIndex(i);

                        System.Text.RegularExpressions.Regex _RegexWidth = new System.Text.RegularExpressions.Regex(@"(?<=\\objw)[^\\]+");
                        System.Text.RegularExpressions.Regex _RegexHeight = new System.Text.RegularExpressions.Regex(@"(?<=\\objh)[^{]+");

                        int _Width = 0;
                        int _Height = 0;

                        if (int.TryParse(_RegexWidth.Match(_RichText.SelectedRtf).Value, out _Width) && int.TryParse(_RegexHeight.Match(_RichText.SelectedRtf).Value, out _Height))
                        {
                            _Width = _Width / 15;
                            _Height = _Height / 15;
                            PointFile(_RichText.SelectedRtf, _StarPoint, _Width, _Height);
                        }
                    }
                }
            }
            _RichText.Dispose();
        }
    }


    public class UserRichTexBox : UserControl
    {
        public UserRichTexBox()
        {
            //为用户控制启用双缓冲等控件样式，否则RichTextBox输入时，会有残影  
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
        }

        /// <summary>   
        /// Required designer variable.  
        /// </summary>  
        private System.ComponentModel.IContainer components = null;

        /// <summary>   
        /// Clean up any resources being used.  
        /// </summary>  
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>  
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>   
        /// Required method for Designer support - do not modify   
        /// the contents of this method with the code editor.  
        /// </summary>  
        private void InitializeComponent()
        {
            this.RichTextBox = new RichTextBoxEx();
            this.SuspendLayout();
            //   
            // alphaRichTextBox1  
            //   
            this.RichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RichTextBox.Location = new System.Drawing.Point(0, 0);
            // this.alphaRichTextBox1.Name = "alphaRichTextBox1";
            this.RichTextBox.Size = new System.Drawing.Size(150, 150);
            this.RichTextBox.TabIndex = 0;
            this.RichTextBox.Text = "";
            this.RichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            //   
            // UserRichTexBox  
            //   
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RichTextBox);
            this.ResumeLayout(false);

        }

        #endregion

        public RichTextBoxEx RichTextBox;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        public void SetBackGroundImage(Image img, Point point, Size formSize)
        {
            Image transImg = img.GetThumbnailImage(formSize.Width, formSize.Height, null, this.Handle);

            Bitmap result = new Bitmap(this.Width, this.Height);

            Graphics grp = Graphics.FromImage(result);
            grp.DrawImage(transImg, new Rectangle(0, 0, this.Width, this.Height), new Rectangle(0, point.Y, this.Width, this.Height), GraphicsUnit.Pixel);
            grp.Dispose();
            this.BackgroundImage = result;
        }

        public override string Text
        {
            get
            {
                return RichTextBox.Text;
            }
            set
            {
                RichTextBox.Text = value;
            }
        }
    }
}
