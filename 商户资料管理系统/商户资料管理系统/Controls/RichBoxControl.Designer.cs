namespace 商户资料管理系统
{
    partial class RichBoxControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbFont = new 商户资料管理系统.ToolStripFontComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbFontSize = new 商户资料管理系统.ToolStripFontSizeComboBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbBlod = new System.Windows.Forms.ToolStripButton();
            this.tsbItali = new System.Windows.Forms.ToolStripButton();
            this.tsbUnderline = new System.Windows.Forms.ToolStripButton();
            this.tsbFull = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbLeft = new System.Windows.Forms.ToolStripButton();
            this.tsbCenter = new System.Windows.Forms.ToolStripButton();
            this.tsbRight = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbBackColor = new 商户资料管理系统.ToolStripColorPicker();
            this.tsbForeColor = new 商户资料管理系统.ToolStripColorPicker();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCreateLink = new System.Windows.Forms.ToolStripButton();
            this.tsbInsertImg = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbUnlink = new System.Windows.Forms.ToolStripButton();
            this.tsbClearStyle = new System.Windows.Forms.ToolStripButton();
            this.tsbClearAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.tsbDownload = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.richTextBox1 = new 商户资料管理系统.RichTextBoxEx();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LightBlue;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbFont,
            this.toolStripSeparator4,
            this.tsbFontSize,
            this.toolStripSeparator5,
            this.tsbBlod,
            this.tsbItali,
            this.tsbUnderline,
            this.tsbFull,
            this.toolStripSeparator1,
            this.tsbLeft,
            this.tsbCenter,
            this.tsbRight,
            this.toolStripSeparator2,
            this.tsbBackColor,
            this.tsbForeColor,
            this.toolStripSeparator3,
            this.tsbCreateLink,
            this.tsbInsertImg,
            this.toolStripSeparator6,
            this.tsbUnlink,
            this.tsbClearStyle,
            this.tsbClearAll,
            this.toolStripSeparator7,
            this.toolStripProgressBar1,
            this.tsbDownload});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(727, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbFont
            // 
            this.tsbFont.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.tsbFont.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tsbFont.AutoSize = false;
            this.tsbFont.InternalCall = false;
            this.tsbFont.Name = "tsbFont";
            this.tsbFont.SelectedFontItem = null;
            this.tsbFont.SelectedFontNameItem = "";
            this.tsbFont.Size = new System.Drawing.Size(60, 22);
            this.tsbFont.Text = "宋体";
            this.tsbFont.ToolTipText = "字体";
            this.tsbFont.DropDown += new System.EventHandler(this.tsbFont_DropDown);
            this.tsbFont.SelectedIndexChanged += new System.EventHandler(this.tsbFont_SelectedIndexChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbFontSize
            // 
            this.tsbFontSize.AutoSize = false;
            this.tsbFontSize.DropDownWidth = 30;
            this.tsbFontSize.Name = "tsbFontSize";
            this.tsbFontSize.Size = new System.Drawing.Size(50, 25);
            this.tsbFontSize.Text = "12";
            this.tsbFontSize.ToolTipText = "字体大小";
            this.tsbFontSize.DropDown += new System.EventHandler(this.tsbFontSize_DropDown);
            this.tsbFontSize.SelectedIndexChanged += new System.EventHandler(this.tsbFontSize_SelectedIndexChanged);
            this.tsbFontSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tsbFontSize_KeyPress);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbBlod
            // 
            this.tsbBlod.CheckOnClick = true;
            this.tsbBlod.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBlod.Image = global::商户资料管理系统.Properties.Resources.Bold;
            this.tsbBlod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBlod.Name = "tsbBlod";
            this.tsbBlod.Size = new System.Drawing.Size(23, 22);
            this.tsbBlod.Text = "toolStripButton6";
            this.tsbBlod.ToolTipText = "加粗";
            this.tsbBlod.Click += new System.EventHandler(this.tsbBlod_Click);
            // 
            // tsbItali
            // 
            this.tsbItali.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbItali.Image = global::商户资料管理系统.Properties.Resources.Italic;
            this.tsbItali.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbItali.Name = "tsbItali";
            this.tsbItali.Size = new System.Drawing.Size(23, 22);
            this.tsbItali.Text = "toolStripButton7";
            this.tsbItali.ToolTipText = "斜体";
            this.tsbItali.Click += new System.EventHandler(this.tsbItali_Click);
            // 
            // tsbUnderline
            // 
            this.tsbUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUnderline.Image = global::商户资料管理系统.Properties.Resources.Underline;
            this.tsbUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUnderline.Name = "tsbUnderline";
            this.tsbUnderline.Size = new System.Drawing.Size(23, 22);
            this.tsbUnderline.Text = "toolStripButton8";
            this.tsbUnderline.ToolTipText = "下划线";
            this.tsbUnderline.Click += new System.EventHandler(this.tsbUnderline_Click);
            // 
            // tsbFull
            // 
            this.tsbFull.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbFull.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFull.Image = global::商户资料管理系统.Properties.Resources.full_screen;
            this.tsbFull.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFull.Name = "tsbFull";
            this.tsbFull.Size = new System.Drawing.Size(23, 22);
            this.tsbFull.Text = "toolStripButton2";
            this.tsbFull.ToolTipText = "全屏";
            this.tsbFull.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbLeft
            // 
            this.tsbLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLeft.Image = global::商户资料管理系统.Properties.Resources.JustifyLeft;
            this.tsbLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLeft.Name = "tsbLeft";
            this.tsbLeft.Size = new System.Drawing.Size(23, 22);
            this.tsbLeft.Text = "toolStripButton3";
            this.tsbLeft.ToolTipText = "左对齐";
            this.tsbLeft.Click += new System.EventHandler(this.tsbLeft_Click);
            // 
            // tsbCenter
            // 
            this.tsbCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCenter.Image = global::商户资料管理系统.Properties.Resources.JustifyCenter;
            this.tsbCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCenter.Name = "tsbCenter";
            this.tsbCenter.Size = new System.Drawing.Size(23, 22);
            this.tsbCenter.Text = "toolStripButton3";
            this.tsbCenter.ToolTipText = "居中对齐";
            this.tsbCenter.Click += new System.EventHandler(this.tsbCenter_Click);
            // 
            // tsbRight
            // 
            this.tsbRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRight.Image = global::商户资料管理系统.Properties.Resources.JustifyRight;
            this.tsbRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRight.Name = "tsbRight";
            this.tsbRight.Size = new System.Drawing.Size(23, 22);
            this.tsbRight.Text = "toolStripButton4";
            this.tsbRight.ToolTipText = "右对齐";
            this.tsbRight.Click += new System.EventHandler(this.tsbRight_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbBackColor
            // 
            this.tsbBackColor.AutoSize = false;
            this.tsbBackColor.ButtonDisplayStyle = 商户资料管理系统.ToolStripColorPickerDisplayType.UnderLineAndImage;
            this.tsbBackColor.Color = System.Drawing.Color.Black;
            this.tsbBackColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBackColor.Image = global::商户资料管理系统.Properties.Resources.background;
            this.tsbBackColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBackColor.Name = "tsbBackColor";
            this.tsbBackColor.Size = new System.Drawing.Size(32, 22);
            this.tsbBackColor.Text = "toolStripButton3";
            this.tsbBackColor.ToolTipText = "填充色";
            this.tsbBackColor.SelectedColorChanged += new System.EventHandler(this.tsbBackColor_SelectedColorChanged);
            this.tsbBackColor.ButtonClick += new System.EventHandler(this.tsbBackColor_ButtonClick);
            // 
            // tsbForeColor
            // 
            this.tsbForeColor.AutoSize = false;
            this.tsbForeColor.ButtonDisplayStyle = 商户资料管理系统.ToolStripColorPickerDisplayType.UnderLineAndImage;
            this.tsbForeColor.Color = System.Drawing.Color.Black;
            this.tsbForeColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbForeColor.Image = global::商户资料管理系统.Properties.Resources.forecolor;
            this.tsbForeColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbForeColor.Name = "tsbForeColor";
            this.tsbForeColor.Size = new System.Drawing.Size(32, 22);
            this.tsbForeColor.Text = "toolStripButton4";
            this.tsbForeColor.ToolTipText = "前景色";
            this.tsbForeColor.SelectedColorChanged += new System.EventHandler(this.tsbForeColor_SelectedColorChanged);
            this.tsbForeColor.ButtonClick += new System.EventHandler(this.tsbForeColor_ButtonClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbCreateLink
            // 
            this.tsbCreateLink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCreateLink.Image = global::商户资料管理系统.Properties.Resources.CreateLink;
            this.tsbCreateLink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCreateLink.Name = "tsbCreateLink";
            this.tsbCreateLink.Size = new System.Drawing.Size(23, 22);
            this.tsbCreateLink.Text = "toolStripButton5";
            this.tsbCreateLink.ToolTipText = "超链接";
            this.tsbCreateLink.Click += new System.EventHandler(this.tsbCreateLink_Click);
            // 
            // tsbInsertImg
            // 
            this.tsbInsertImg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbInsertImg.Image = global::商户资料管理系统.Properties.Resources.InsertImage;
            this.tsbInsertImg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInsertImg.Name = "tsbInsertImg";
            this.tsbInsertImg.Size = new System.Drawing.Size(23, 22);
            this.tsbInsertImg.Text = "toolStripButton1";
            this.tsbInsertImg.ToolTipText = "插入图片";
            this.tsbInsertImg.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbUnlink
            // 
            this.tsbUnlink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUnlink.Enabled = false;
            this.tsbUnlink.Image = global::商户资料管理系统.Properties.Resources.Unlink;
            this.tsbUnlink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUnlink.Name = "tsbUnlink";
            this.tsbUnlink.Size = new System.Drawing.Size(23, 22);
            this.tsbUnlink.Text = "toolStripButton1";
            this.tsbUnlink.ToolTipText = "取消链接";
            this.tsbUnlink.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // tsbClearStyle
            // 
            this.tsbClearStyle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClearStyle.Image = global::商户资料管理系统.Properties.Resources.clear;
            this.tsbClearStyle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClearStyle.Name = "tsbClearStyle";
            this.tsbClearStyle.Size = new System.Drawing.Size(23, 22);
            this.tsbClearStyle.Text = "toolStripButton1";
            this.tsbClearStyle.ToolTipText = "清除格式";
            this.tsbClearStyle.Click += new System.EventHandler(this.tsbClearStyle_Click);
            // 
            // tsbClearAll
            // 
            this.tsbClearAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClearAll.Image = global::商户资料管理系统.Properties.Resources.clearAll;
            this.tsbClearAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClearAll.Name = "tsbClearAll";
            this.tsbClearAll.Size = new System.Drawing.Size(23, 22);
            this.tsbClearAll.Text = "toolStripButton2";
            this.tsbClearAll.ToolTipText = "清空文本";
            this.tsbClearAll.Click += new System.EventHandler(this.tsbClearAll_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 22);
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.toolStripProgressBar1.Visible = false;
            // 
            // tsbDownload
            // 
            this.tsbDownload.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbDownload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDownload.Image = global::商户资料管理系统.Properties.Resources.download;
            this.tsbDownload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDownload.Name = "tsbDownload";
            this.tsbDownload.Size = new System.Drawing.Size(23, 22);
            this.tsbDownload.Text = "下载";
            this.tsbDownload.Click += new System.EventHandler(this.tsbDownload_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "图片文件|*.png;*.jpg;*.bmp";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // richTextBox1
            // 
            this.richTextBox1.DetectUrls = true;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 25);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(727, 332);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            this.richTextBox1.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox1_LinkClicked);
            this.richTextBox1.SelectionChanged += new System.EventHandler(this.richTextBox1_SelectionChanged);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "新建文件";
            this.saveFileDialog1.Filter = "图文文件|*.rtf";
            // 
            // RichBoxControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "RichBoxControl";
            this.Size = new System.Drawing.Size(727, 357);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbInsertImg;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripButton tsbFull;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbLeft;
        private System.Windows.Forms.ToolStripButton tsbRight;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsbCenter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbCreateLink;
        private System.Windows.Forms.ToolStripButton tsbBlod;
        private System.Windows.Forms.ToolStripButton tsbItali;
        private System.Windows.Forms.ToolStripButton tsbUnderline;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private RichTextBoxEx richTextBox1;
        private System.Windows.Forms.ToolStripButton tsbClearStyle;
        private System.Windows.Forms.ToolStripButton tsbClearAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private ToolStripFontComboBox tsbFont;
        private ToolStripFontSizeComboBox tsbFontSize;
        private ToolStripColorPicker tsbBackColor;
        private ToolStripColorPicker tsbForeColor;
        private System.Windows.Forms.ToolStripButton tsbUnlink;
        private System.Windows.Forms.ToolStripButton tsbDownload;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
