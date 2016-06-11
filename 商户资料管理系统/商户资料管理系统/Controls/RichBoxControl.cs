using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;

namespace 商户资料管理系统
{
    public partial class RichBoxControl : UserControl
    {
        private static readonly Font Default_Font = new Font("宋体", 12);

        private Font oldFont = null;
        private Font newFont = null;

        public RichBoxControl()
        {
            InitializeComponent();
            richTextBox1.SelectionFont = Default_Font;
        }
     
        #region 插入图片

        /// <summary>
        /// 插入图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string path = openFileDialog1.FileName;
            toolStripProgressBar1.Visible = true;
            Clipboard.Clear(); 
            backgroundWorker1.RunWorkerAsync(path);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap bmp = new Bitmap(e.Argument.ToString());
            int width = this.Width;
            int height = bmp.Height * width / bmp.Width;
            Bitmap myBitmap = new Bitmap(width, height);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    myBitmap.SetPixel(i, j, bmp.GetPixel(i * bmp.Width / width, j * bmp.Height / height));
                }
            }
            e.Result = myBitmap;

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Clipboard.SetImage(e.Result as Bitmap);
            richTextBox1.Paste();
            Clipboard.Clear();
            toolStripProgressBar1.Visible = false;
        }

        #endregion

        #region 全屏与取消


        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        private void control_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (this != null)
                {
                    SetParent(this.Handle, this.Parent.Handle);
                    this.Dock = DockStyle.Fill;
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Dock = DockStyle.None;
            this.Left = 0;
            this.Top = 0;
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            AddEventKeyUp(this);
            this.Focus();// 获得焦点，否则也得不到按键
            SetParent(this.Handle, IntPtr.Zero);
        }

        private void AddEventKeyUp(Control control)
        {
            if (control != null)
            {
                control.KeyUp += new KeyEventHandler(control_KeyUp);
                foreach (Control c in control.Controls)
                {// 需要给子控件也添加上，否则有可能取不到。
                    AddEventKeyUp(c);
                }
            }
        }

        #endregion

        #region 读取与存储

        /// <summary>
        /// 获取文本内容
        /// </summary>
        /// <returns></returns>
        public byte[] GetStreamText()
        {
            return Encoding.Default.GetBytes(richTextBox1.Rtf);
        }

        /// <summary>
        /// 设置文本内容
        /// </summary>
        /// <param name="buffer">文本资源</param>
        public void SetStreamText(byte[] buffer)
        {
            richTextBox1.Rtf = Encoding.Default.GetString(buffer);
        }

        #endregion

        #region 特殊字形

        private void tsbBlod_Click(object sender, EventArgs e)
        {
            oldFont = this.richTextBox1.SelectionFont;
            if (oldFont.Bold)
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Bold);
            else
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Bold);
            tsbBlod.Checked = !oldFont.Bold;
            this.richTextBox1.SelectionFont = newFont;
            this.richTextBox1.Focus();
        }

        private void tsbItali_Click(object sender, EventArgs e)
        {
            oldFont = this.richTextBox1.SelectionFont;
            if (oldFont.Italic)
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Italic);
            else
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Italic);
            tsbItali.Checked = !oldFont.Italic;
            this.richTextBox1.SelectionFont = newFont;
            this.richTextBox1.Focus();
        }

        private void tsbUnderline_Click(object sender, EventArgs e)
        {
            oldFont = this.richTextBox1.SelectionFont;
            if (oldFont.Underline)
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Underline);
            else
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Underline);
            tsbUnderline.Checked = !oldFont.Underline;
            this.richTextBox1.SelectionFont = newFont;
            this.richTextBox1.Focus();
        }

        #endregion

        #region 排列

        private void tsbCenter_Click(object sender, EventArgs e)
        {
            if (this.richTextBox1.SelectionAlignment == HorizontalAlignment.Center)
                this.richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            else
                this.richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            this.richTextBox1.Focus();
        }

        private void tsbLeft_Click(object sender, EventArgs e)
        {
            if (this.richTextBox1.SelectionAlignment == HorizontalAlignment.Left)
                this.richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            else
                this.richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            this.richTextBox1.Focus();
        }

        private void tsbRight_Click(object sender, EventArgs e)
        {
            if (this.richTextBox1.SelectionAlignment == HorizontalAlignment.Right)
                this.richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            else
                this.richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
            this.richTextBox1.Focus();
        }

        #endregion

        #region 超链接(异常)

        private void tsbCreateLink_Click(object sender, EventArgs e)
        {
            FormLink form = new FormLink();
            if (form.ShowDialog() == DialogResult.OK)
                richTextBox1.InsertLink(richTextBox1.SelectedText, form.Uri, richTextBox1.SelectionStart);
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            string[] result = e.LinkText.Split('#');
            System.Diagnostics.Process.Start("IExplore.exe", result[1]);
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            richTextBox1.SetSelectionLink(false);
        }

        #endregion

        #region 清除

        private void tsbClearAll_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void tsbClearStyle_Click(object sender, EventArgs e)
        {
            tsbFontSize.Text = "12";
            tsbFont.Text = "宋体";
            richTextBox1.SelectionFont = Default_Font;          
            richTextBox1.SelectionColor = DefaultForeColor;
            richTextBox1.SelectionBackColor = this.richTextBox1.BackColor;
        }

        #endregion

        #region 字体

        /// <summary>
        /// 改变字体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tsbFontSize.Text))
                return;
            richTextBox1.SelectionFont = new Font(tsbFont.Text, GeneralUtil.ParseInt(tsbFontSize.Text));
            richTextBox1.Focus();
        }

        private void tsbFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(tsbFont.Text, GeneralUtil.ParseInt(tsbFontSize.Text));
            richTextBox1.Focus();
        }

        private void tsbFontSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                if (e.KeyChar <= '7' && e.KeyChar > '0')
                    tsbFontSize.SelectedIndex = GeneralUtil.ParseInt(e.KeyChar) - 1;
            }
            else if (!Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tsbFontSize_DropDown(object sender, EventArgs e)
        {
            if (tsbFontSize.Items.Count == 0)
                this.tsbFontSize.Items.AddRange(new object[] {
            "8",
            "10",
            "12",
            "14",
            "18",
            "24",
            "36"});
        }

        private void tsbFont_DropDown(object sender, EventArgs e)
        {
            tsbFont.LoadFontFamilies();
        }

        #endregion

        #region 颜色

        private void tsbBackColor_ButtonClick(object sender, EventArgs e)
        {
            richTextBox1.SelectionBackColor = tsbBackColor.Color;
        }

        private void tsbBackColor_SelectedColorChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionBackColor = tsbBackColor.Color;
        }

        private void tsbForeColor_ButtonClick(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = tsbForeColor.Color;
        }

        private void tsbForeColor_SelectedColorChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = tsbForeColor.Color;
        }

        #endregion

        #region 控制按钮

        private bool _showSimple = false;
        [Category("行为"), Description("是否简要显示工具"), DefaultValue(false)]
        public bool ShowSimple
        {
            get 
            { 
                return _showSimple;
            }
            set 
            { 
                _showSimple = value;
                foreach (ToolStripItem item in toolStrip1.Items)
                {
                    if (item.Name == "tsbInsertImg" || item.Name == "toolStripProgressBar1" ||item.Name=="tsbDownload"||item.Name == "tsbFull")
                        continue;
                    item.Visible = !value;
                }
            }
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                tsbBlod.Checked = richTextBox1.SelectionFont.Bold;
                tsbItali.Checked = richTextBox1.SelectionFont.Italic;
                tsbUnderline.Checked = richTextBox1.SelectionFont.Underline;
            }
            tsbUnlink.Enabled = (ReadOnly == false) && richTextBox1.GetSelectionLink() > 0;
        }

        [Category("行为"), Description("控件是否只读"), DefaultValue(false)]
        public bool ReadOnly
        {
            get { return richTextBox1.ReadOnly; }
            set
            {
                richTextBox1.ReadOnly = value;
                foreach (ToolStripItem item in toolStrip1.Items)
                {
                    if (item.Name == "tsbFull" || item.Name == "tsbUnlink" || item.Name == "tsbDownload")
                        continue;
                    item.Enabled = !value;
                }
            }
        }

        #endregion

        #region 打印

        public void Print(bool preview)
        {
            RichTextBoxPrintHelper helper = new RichTextBoxPrintHelper(this.richTextBox1);
            helper.PrintRTF(preview);
        }

        #endregion

        #region 下载

        private void tsbDownload_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] buffer = GetStreamText();
                if (buffer == null || buffer.Length == 0)
                    return;
                if (DialogResult.OK == saveFileDialog1.ShowDialog())
                {
                    using (FileStream stream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write))
                    {
                        stream.Write(buffer, 0, buffer.Length);
                    }

                    MessageBox.Show("下载完成");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("下载失败：" + ex.Message);
            }
        }

        #endregion   
    }
}
