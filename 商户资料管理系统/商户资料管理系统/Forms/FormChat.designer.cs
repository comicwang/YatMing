namespace 商户资料管理系统
{
    partial class FormChat
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChat));
            System.Drawing.Imaging.ImageAttributes imageAttributes5 = new System.Drawing.Imaging.ImageAttributes();
            System.Drawing.Imaging.ImageAttributes imageAttributes1 = new System.Drawing.Imaging.ImageAttributes();
            System.Drawing.Imaging.ImageAttributes imageAttributes2 = new System.Drawing.Imaging.ImageAttributes();
            System.Drawing.Imaging.ImageAttributes imageAttributes3 = new System.Drawing.Imaging.ImageAttributes();
            System.Drawing.Imaging.ImageAttributes imageAttributes4 = new System.Drawing.Imaging.ImageAttributes();
            this.layeredPanel1 = new LayeredSkin.Controls.LayeredPanel();
            this.picImage = new 商户资料管理系统.PictureStreamBox();
            this.lybtnSkin = new LayeredSkin.Controls.LayeredButton();
            this.lylblName = new LayeredSkin.Controls.LayeredLabel();
            this.lybtnClose = new LayeredSkin.Controls.LayeredButton();
            this.lybtnHide = new LayeredSkin.Controls.LayeredButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.menuWord = new System.Windows.Forms.MenuStrip();
            this.tsmFont = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFace = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmImage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCutScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlHistory = new System.Windows.Forms.Panel();
            this.warningBox1 = new 商户资料管理系统.WarningBox();
            this.rtbHistory = new 商户资料管理系统.UserRichTexBox();
            this.tsFont = new System.Windows.Forms.ToolStrip();
            this.tsbFont = new 商户资料管理系统.ToolStripFontComboBox();
            this.tsbSize = new 商户资料管理系统.ToolStripFontSizeComboBox();
            this.tsmColor = new 商户资料管理系统.ToolStripColorPicker();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbBold = new System.Windows.Forms.ToolStripButton();
            this.tsbItal = new System.Windows.Forms.ToolStripButton();
            this.tsbUnderline = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbLeft = new System.Windows.Forms.ToolStripButton();
            this.tsbCenter = new System.Windows.Forms.ToolStripButton();
            this.tsbRight = new System.Windows.Forms.ToolStripButton();
            this.tsbClear = new System.Windows.Forms.ToolStripButton();
            this.rtbSend = new 商户资料管理系统.UserRichTexBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.layeredPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.menuWord.SuspendLayout();
            this.pnlHistory.SuspendLayout();
            this.tsFont.SuspendLayout();
            this.SuspendLayout();
            // 
            // layeredPanel1
            // 
            this.layeredPanel1.BackColor = System.Drawing.Color.Transparent;
            this.layeredPanel1.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredPanel1.Canvas")));
            this.layeredPanel1.Controls.Add(this.picImage);
            this.layeredPanel1.Controls.Add(this.lybtnSkin);
            this.layeredPanel1.Controls.Add(this.lylblName);
            this.layeredPanel1.Controls.Add(this.lybtnClose);
            this.layeredPanel1.Controls.Add(this.lybtnHide);
            this.layeredPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layeredPanel1.ForeColor = System.Drawing.Color.Gray;
            this.layeredPanel1.ImageAttribute = imageAttributes5;
            this.layeredPanel1.Location = new System.Drawing.Point(0, 0);
            this.layeredPanel1.Name = "layeredPanel1";
            this.layeredPanel1.Size = new System.Drawing.Size(511, 75);
            this.layeredPanel1.TabIndex = 0;
            this.layeredPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.layeredPanel1_MouseDown);
            // 
            // picImage
            // 
            this.picImage.Image = ((System.Drawing.Image)(resources.GetObject("picImage.Image")));
            this.picImage.Location = new System.Drawing.Point(1, 3);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(70, 70);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage.TabIndex = 8;
            this.picImage.TabStop = false;
            // 
            // lybtnSkin
            // 
            this.lybtnSkin.AdaptImage = true;
            this.lybtnSkin.BackColor = System.Drawing.Color.Transparent;
            this.lybtnSkin.BaseColor = System.Drawing.Color.Wheat;
            this.lybtnSkin.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("lybtnSkin.Canvas")));
            this.lybtnSkin.ControlState = LayeredSkin.Controls.ControlStates.Normal;
            this.lybtnSkin.HaloColor = System.Drawing.Color.White;
            this.lybtnSkin.HaloSize = 5;
            this.lybtnSkin.HoverImage = global::商户资料管理系统.Properties.Resources.skinhover;
            this.lybtnSkin.ImageAttribute = imageAttributes1;
            this.lybtnSkin.Location = new System.Drawing.Point(428, 3);
            this.lybtnSkin.Name = "lybtnSkin";
            this.lybtnSkin.NormalImage = global::商户资料管理系统.Properties.Resources.Skin;
            this.lybtnSkin.PressedImage = null;
            this.lybtnSkin.Size = new System.Drawing.Size(24, 24);
            this.lybtnSkin.TabIndex = 7;
            this.lybtnSkin.TabStop = false;
            this.lybtnSkin.TextLocationOffset = new System.Drawing.Point(0, 0);
            this.lybtnSkin.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.lybtnSkin.TextShowMode = LayeredSkin.TextShowModes.Halo;
            this.lybtnSkin.Click += new System.EventHandler(this.lybtnSkin_Click);
            // 
            // lylblName
            // 
            this.lylblName.BackColor = System.Drawing.Color.Transparent;
            this.lylblName.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("lylblName.Canvas")));
            this.lylblName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lylblName.HaloSize = 5;
            this.lylblName.ImageAttribute = imageAttributes2;
            this.lylblName.Location = new System.Drawing.Point(80, 4);
            this.lylblName.Name = "lylblName";
            this.lylblName.Size = new System.Drawing.Size(75, 23);
            this.lylblName.TabIndex = 6;
            this.lylblName.Text = "昵称";
            // 
            // lybtnClose
            // 
            this.lybtnClose.AdaptImage = true;
            this.lybtnClose.BackColor = System.Drawing.Color.Transparent;
            this.lybtnClose.BaseColor = System.Drawing.Color.Wheat;
            this.lybtnClose.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("lybtnClose.Canvas")));
            this.lybtnClose.ControlState = LayeredSkin.Controls.ControlStates.Normal;
            this.lybtnClose.HaloColor = System.Drawing.Color.White;
            this.lybtnClose.HaloSize = 5;
            this.lybtnClose.HoverImage = ((System.Drawing.Image)(resources.GetObject("lybtnClose.HoverImage")));
            this.lybtnClose.ImageAttribute = imageAttributes3;
            this.lybtnClose.Location = new System.Drawing.Point(485, 4);
            this.lybtnClose.Name = "lybtnClose";
            this.lybtnClose.NormalImage = global::商户资料管理系统.Properties.Resources.close;
            this.lybtnClose.PressedImage = null;
            this.lybtnClose.Size = new System.Drawing.Size(22, 22);
            this.lybtnClose.TabIndex = 3;
            this.lybtnClose.TabStop = false;
            this.lybtnClose.TextLocationOffset = new System.Drawing.Point(0, 0);
            this.lybtnClose.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.lybtnClose.TextShowMode = LayeredSkin.TextShowModes.Halo;
            this.lybtnClose.Click += new System.EventHandler(this.layeredButton2_Click);
            // 
            // lybtnHide
            // 
            this.lybtnHide.AdaptImage = true;
            this.lybtnHide.BackColor = System.Drawing.Color.Transparent;
            this.lybtnHide.BaseColor = System.Drawing.Color.Wheat;
            this.lybtnHide.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("lybtnHide.Canvas")));
            this.lybtnHide.ControlState = LayeredSkin.Controls.ControlStates.Normal;
            this.lybtnHide.HaloColor = System.Drawing.Color.White;
            this.lybtnHide.HaloSize = 5;
            this.lybtnHide.HoverImage = ((System.Drawing.Image)(resources.GetObject("lybtnHide.HoverImage")));
            this.lybtnHide.ImageAttribute = imageAttributes4;
            this.lybtnHide.Location = new System.Drawing.Point(457, 4);
            this.lybtnHide.Name = "lybtnHide";
            this.lybtnHide.NormalImage = global::商户资料管理系统.Properties.Resources.hide;
            this.lybtnHide.PressedImage = null;
            this.lybtnHide.Size = new System.Drawing.Size(22, 22);
            this.lybtnHide.TabIndex = 4;
            this.lybtnHide.TabStop = false;
            this.lybtnHide.TextLocationOffset = new System.Drawing.Point(0, 0);
            this.lybtnHide.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.lybtnHide.TextShowMode = LayeredSkin.TextShowModes.Halo;
            this.lybtnHide.Click += new System.EventHandler(this.layeredButton1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.Gray;
            this.panel1.Location = new System.Drawing.Point(0, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(511, 1);
            this.panel1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(349, 520);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.BackColor = System.Drawing.Color.Transparent;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Location = new System.Drawing.Point(428, 520);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.Color.Gray;
            this.panel2.Location = new System.Drawing.Point(0, 380);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(511, 1);
            this.panel2.TabIndex = 7;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenu.Controls.Add(this.menuWord);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Location = new System.Drawing.Point(0, 381);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(511, 26);
            this.pnlMenu.TabIndex = 8;
            // 
            // menuWord
            // 
            this.menuWord.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFont,
            this.tsmFace,
            this.tsmImage,
            this.tsmCutScreen});
            this.menuWord.Location = new System.Drawing.Point(0, 0);
            this.menuWord.Name = "menuWord";
            this.menuWord.Size = new System.Drawing.Size(511, 24);
            this.menuWord.TabIndex = 0;
            this.menuWord.Text = "menuStrip1";
            // 
            // tsmFont
            // 
            this.tsmFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmFont.Image = global::商户资料管理系统.Properties.Resources.font;
            this.tsmFont.Name = "tsmFont";
            this.tsmFont.ShowShortcutKeys = false;
            this.tsmFont.Size = new System.Drawing.Size(28, 20);
            this.tsmFont.Text = "A";
            this.tsmFont.ToolTipText = "设计文字字体";
            this.tsmFont.Click += new System.EventHandler(this.tsmFont_Click);
            // 
            // tsmFace
            // 
            this.tsmFace.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmFace.Image = global::商户资料管理系统.Properties.Resources.smile;
            this.tsmFace.Name = "tsmFace";
            this.tsmFace.Size = new System.Drawing.Size(28, 20);
            this.tsmFace.Text = "1";
            this.tsmFace.ToolTipText = "表情";
            this.tsmFace.Click += new System.EventHandler(this.tsmFace_Click);
            // 
            // tsmImage
            // 
            this.tsmImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmImage.Image = global::商户资料管理系统.Properties.Resources.image;
            this.tsmImage.Name = "tsmImage";
            this.tsmImage.Size = new System.Drawing.Size(28, 20);
            this.tsmImage.Text = "1";
            this.tsmImage.ToolTipText = "插入图片";
            this.tsmImage.Click += new System.EventHandler(this.tsmImage_Click);
            // 
            // tsmCutScreen
            // 
            this.tsmCutScreen.AutoToolTip = true;
            this.tsmCutScreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmCutScreen.Image = global::商户资料管理系统.Properties.Resources.cutScreen;
            this.tsmCutScreen.Name = "tsmCutScreen";
            this.tsmCutScreen.Size = new System.Drawing.Size(28, 20);
            this.tsmCutScreen.Text = "截屏";
            this.tsmCutScreen.ToolTipText = "截屏";
            this.tsmCutScreen.Click += new System.EventHandler(this.tsmCutScreen_Click);
            // 
            // pnlHistory
            // 
            this.pnlHistory.Controls.Add(this.warningBox1);
            this.pnlHistory.Controls.Add(this.rtbHistory);
            this.pnlHistory.Controls.Add(this.tsFont);
            this.pnlHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHistory.Location = new System.Drawing.Point(0, 76);
            this.pnlHistory.Name = "pnlHistory";
            this.pnlHistory.Size = new System.Drawing.Size(511, 304);
            this.pnlHistory.TabIndex = 9;
            // 
            // warningBox1
            // 
            this.warningBox1.AutoCloseTime = 100;
            this.warningBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.warningBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.warningBox1.FontColor = System.Drawing.SystemColors.ControlText;
            this.warningBox1.Location = new System.Drawing.Point(0, 0);
            this.warningBox1.Name = "warningBox1";
            this.warningBox1.Size = new System.Drawing.Size(511, 31);
            this.warningBox1.TabIndex = 6;
            this.warningBox1.Visible = false;
            // 
            // rtbHistory
            // 
            this.rtbHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbHistory.Location = new System.Drawing.Point(0, 0);
            this.rtbHistory.Name = "rtbHistory";
            this.rtbHistory.Padding = new System.Windows.Forms.Padding(5);
            this.rtbHistory.Size = new System.Drawing.Size(511, 304);
            this.rtbHistory.TabIndex = 5;
            // 
            // tsFont
            // 
            this.tsFont.BackColor = System.Drawing.Color.Transparent;
            this.tsFont.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tsFont.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbFont,
            this.tsbSize,
            this.tsmColor,
            this.toolStripSeparator2,
            this.tsbBold,
            this.tsbItal,
            this.tsbUnderline,
            this.toolStripSeparator1,
            this.tsbLeft,
            this.tsbCenter,
            this.tsbRight,
            this.tsbClear});
            this.tsFont.Location = new System.Drawing.Point(0, 278);
            this.tsFont.Name = "tsFont";
            this.tsFont.Size = new System.Drawing.Size(511, 26);
            this.tsFont.TabIndex = 7;
            this.tsFont.Text = "toolStrip1";
            this.tsFont.Visible = false;
            // 
            // tsbFont
            // 
            this.tsbFont.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.tsbFont.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tsbFont.InternalCall = false;
            this.tsbFont.Name = "tsbFont";
            this.tsbFont.SelectedFontItem = null;
            this.tsbFont.SelectedFontNameItem = "";
            this.tsbFont.Size = new System.Drawing.Size(75, 26);
            this.tsbFont.Text = "宋体";
            this.tsbFont.ToolTipText = "字体类型";
            this.tsbFont.DropDown += new System.EventHandler(this.tsbFont_DropDown);
            this.tsbFont.SelectedIndexChanged += new System.EventHandler(this.tsbFont_SelectedIndexChanged);
            // 
            // tsbSize
            // 
            this.tsbSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.tsbSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tsbSize.AutoSize = false;
            this.tsbSize.DropDownWidth = 50;
            this.tsbSize.Name = "tsbSize";
            this.tsbSize.Size = new System.Drawing.Size(50, 25);
            this.tsbSize.Text = "12";
            this.tsbSize.ToolTipText = "字号";
            this.tsbSize.DropDown += new System.EventHandler(this.tsbSize_DropDown);
            this.tsbSize.SelectedIndexChanged += new System.EventHandler(this.tsbSize_SelectedIndexChanged);
            this.tsbSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tsbSize_KeyPress);
            // 
            // tsmColor
            // 
            this.tsmColor.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmColor.AutoSize = false;
            this.tsmColor.ButtonDisplayStyle = 商户资料管理系统.ToolStripColorPickerDisplayType.UnderLineAndImage;
            this.tsmColor.Color = System.Drawing.Color.Black;
            this.tsmColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.tsmColor.Image = global::商户资料管理系统.Properties.Resources.forecolor;
            this.tsmColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmColor.Name = "tsmColor";
            this.tsmColor.Size = new System.Drawing.Size(30, 23);
            this.tsmColor.Text = "toolStripColorPicker2";
            this.tsmColor.ToolTipText = "文字颜色";
            this.tsmColor.SelectedColorChanged += new System.EventHandler(this.tsmColor_SelectedColorChanged);
            this.tsmColor.ButtonClick += new System.EventHandler(this.tsmColor_ButtonClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 26);
            // 
            // tsbBold
            // 
            this.tsbBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBold.Image = global::商户资料管理系统.Properties.Resources.Bold;
            this.tsbBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBold.Name = "tsbBold";
            this.tsbBold.Size = new System.Drawing.Size(23, 23);
            this.tsbBold.Text = "toolStripButton1";
            this.tsbBold.ToolTipText = "加粗";
            this.tsbBold.Click += new System.EventHandler(this.tsbBold_Click);
            // 
            // tsbItal
            // 
            this.tsbItal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbItal.Image = global::商户资料管理系统.Properties.Resources.Italic;
            this.tsbItal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbItal.Name = "tsbItal";
            this.tsbItal.Size = new System.Drawing.Size(23, 23);
            this.tsbItal.Text = "toolStripButton2";
            this.tsbItal.ToolTipText = "斜体";
            this.tsbItal.Click += new System.EventHandler(this.tsbItal_Click);
            // 
            // tsbUnderline
            // 
            this.tsbUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUnderline.Image = global::商户资料管理系统.Properties.Resources.Underline;
            this.tsbUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUnderline.Name = "tsbUnderline";
            this.tsbUnderline.Size = new System.Drawing.Size(23, 23);
            this.tsbUnderline.Text = "toolStripButton3";
            this.tsbUnderline.ToolTipText = "下划线";
            this.tsbUnderline.Click += new System.EventHandler(this.tsbUnderline_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // tsbLeft
            // 
            this.tsbLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLeft.Image = global::商户资料管理系统.Properties.Resources.JustifyLeft;
            this.tsbLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLeft.Name = "tsbLeft";
            this.tsbLeft.Size = new System.Drawing.Size(23, 23);
            this.tsbLeft.Text = "toolStripButton4";
            this.tsbLeft.ToolTipText = "文字居左";
            this.tsbLeft.Click += new System.EventHandler(this.tsbLeft_Click);
            // 
            // tsbCenter
            // 
            this.tsbCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCenter.Image = global::商户资料管理系统.Properties.Resources.JustifyCenter;
            this.tsbCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCenter.Name = "tsbCenter";
            this.tsbCenter.Size = new System.Drawing.Size(23, 23);
            this.tsbCenter.Text = "toolStripButton5";
            this.tsbCenter.ToolTipText = "文字居中";
            this.tsbCenter.Click += new System.EventHandler(this.tsbCenter_Click);
            // 
            // tsbRight
            // 
            this.tsbRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRight.Image = global::商户资料管理系统.Properties.Resources.JustifyRight;
            this.tsbRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRight.Name = "tsbRight";
            this.tsbRight.Size = new System.Drawing.Size(23, 23);
            this.tsbRight.Text = "toolStripButton6";
            this.tsbRight.ToolTipText = "文字居右";
            this.tsbRight.Click += new System.EventHandler(this.tsbRight_Click);
            // 
            // tsbClear
            // 
            this.tsbClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClear.Image = global::商户资料管理系统.Properties.Resources.clear;
            this.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClear.Name = "tsbClear";
            this.tsbClear.Size = new System.Drawing.Size(23, 23);
            this.tsbClear.Text = "toolStripButton1";
            this.tsbClear.ToolTipText = "清除格式";
            this.tsbClear.Click += new System.EventHandler(this.tsbClear_Click);
            // 
            // rtbSend
            // 
            this.rtbSend.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtbSend.Location = new System.Drawing.Point(0, 407);
            this.rtbSend.Name = "rtbSend";
            this.rtbSend.Padding = new System.Windows.Forms.Padding(5);
            this.rtbSend.Size = new System.Drawing.Size(511, 106);
            this.rtbSend.TabIndex = 6;
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::商户资料管理系统.Properties.Resources.d8ffa25210f6ab3bf7923ca55fb03b56;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(511, 547);
            this.Controls.Add(this.rtbSend);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlHistory);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.layeredPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuWord;
            this.Name = "FormChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Activated += new System.EventHandler(this.FormMain_Activated);
            this.Deactivate += new System.EventHandler(this.FormMain_Deactivate);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.layeredPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.menuWord.ResumeLayout(false);
            this.menuWord.PerformLayout();
            this.pnlHistory.ResumeLayout(false);
            this.pnlHistory.PerformLayout();
            this.tsFont.ResumeLayout(false);
            this.tsFont.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private LayeredSkin.Controls.LayeredPanel layeredPanel1;
        private LayeredSkin.Controls.LayeredButton lybtnSkin;
        private LayeredSkin.Controls.LayeredLabel lylblName;
        private LayeredSkin.Controls.LayeredButton lybtnClose;
        private LayeredSkin.Controls.LayeredButton lybtnHide;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.MenuStrip menuWord;
        private System.Windows.Forms.ToolStripMenuItem tsmFont;
        private System.Windows.Forms.ToolStripMenuItem tsmFace;
        private System.Windows.Forms.ToolStripMenuItem tsmImage;
        private UserRichTexBox rtbSend;
        private UserRichTexBox rtbHistory;
        private System.Windows.Forms.Panel pnlHistory;
        private WarningBox warningBox1;
        private System.Windows.Forms.ToolStripMenuItem tsmCutScreen;
        private PictureStreamBox picImage;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStrip tsFont;
        private ToolStripFontComboBox tsbFont;
        private ToolStripFontSizeComboBox tsbSize;
        private ToolStripColorPicker tsmColor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbBold;
        private System.Windows.Forms.ToolStripButton tsbItal;
        private System.Windows.Forms.ToolStripButton tsbUnderline;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbLeft;
        private System.Windows.Forms.ToolStripButton tsbCenter;
        private System.Windows.Forms.ToolStripButton tsbRight;
        private System.Windows.Forms.ToolStripButton tsbClear;
    }
}

