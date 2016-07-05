namespace YatMing.Message.Chat
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            System.Drawing.Imaging.ImageAttributes imageAttributes5 = new System.Drawing.Imaging.ImageAttributes();
            System.Drawing.Imaging.ImageAttributes imageAttributes1 = new System.Drawing.Imaging.ImageAttributes();
            System.Drawing.Imaging.ImageAttributes imageAttributes2 = new System.Drawing.Imaging.ImageAttributes();
            System.Drawing.Imaging.ImageAttributes imageAttributes3 = new System.Drawing.Imaging.ImageAttributes();
            System.Drawing.Imaging.ImageAttributes imageAttributes4 = new System.Drawing.Imaging.ImageAttributes();
            this.layeredPanel1 = new LayeredSkin.Controls.LayeredPanel();
            this.lylblName = new LayeredSkin.Controls.LayeredLabel();
            this.layeredPictureBox1 = new LayeredSkin.Controls.LayeredPictureBox();
            this.layeredButton2 = new LayeredSkin.Controls.LayeredButton();
            this.layeredButton1 = new LayeredSkin.Controls.LayeredButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userRichTexBox2 = new RichTextBoxBackPicture.UserRichTexBox();
            this.userRichTexBox1 = new RichTextBoxBackPicture.UserRichTexBox();
            this.layeredPanel1.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // layeredPanel1
            // 
            this.layeredPanel1.BackColor = System.Drawing.Color.Transparent;
            this.layeredPanel1.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredPanel1.Canvas")));
            this.layeredPanel1.Controls.Add(this.lylblName);
            this.layeredPanel1.Controls.Add(this.layeredPictureBox1);
            this.layeredPanel1.Controls.Add(this.layeredButton2);
            this.layeredPanel1.Controls.Add(this.layeredButton1);
            this.layeredPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layeredPanel1.ForeColor = System.Drawing.Color.Gray;
            this.layeredPanel1.ImageAttribute = imageAttributes5;
            this.layeredPanel1.Location = new System.Drawing.Point(0, 0);
            this.layeredPanel1.Name = "layeredPanel1";
            this.layeredPanel1.Size = new System.Drawing.Size(450, 112);
            this.layeredPanel1.TabIndex = 0;
            // 
            // lylblName
            // 
            this.lylblName.BackColor = System.Drawing.Color.Transparent;
            this.lylblName.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("lylblName.Canvas")));
            this.lylblName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lylblName.HaloSize = 5;
            this.lylblName.ImageAttribute = imageAttributes1;
            this.lylblName.Location = new System.Drawing.Point(80, 4);
            this.lylblName.Name = "lylblName";
            this.lylblName.Size = new System.Drawing.Size(75, 23);
            this.lylblName.TabIndex = 6;
            this.lylblName.Text = "昵称";
            // 
            // layeredPictureBox1
            // 
            this.layeredPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.layeredPictureBox1.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredPictureBox1.Canvas")));
            this.layeredPictureBox1.Image = null;
            this.layeredPictureBox1.ImageAttribute = imageAttributes2;
            this.layeredPictureBox1.Images = null;
            this.layeredPictureBox1.Interval = 100;
            this.layeredPictureBox1.Location = new System.Drawing.Point(3, 3);
            this.layeredPictureBox1.MultiImageAnimation = false;
            this.layeredPictureBox1.Name = "layeredPictureBox1";
            this.layeredPictureBox1.Size = new System.Drawing.Size(70, 70);
            this.layeredPictureBox1.TabIndex = 5;
            this.layeredPictureBox1.Text = "layeredPictureBox1";
            // 
            // layeredButton2
            // 
            this.layeredButton2.AdaptImage = true;
            this.layeredButton2.BackColor = System.Drawing.Color.Transparent;
            this.layeredButton2.BaseColor = System.Drawing.Color.Wheat;
            this.layeredButton2.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredButton2.Canvas")));
            this.layeredButton2.ControlState = LayeredSkin.Controls.ControlStates.Normal;
            this.layeredButton2.HaloColor = System.Drawing.Color.White;
            this.layeredButton2.HaloSize = 5;
            this.layeredButton2.HoverImage = ((System.Drawing.Image)(resources.GetObject("layeredButton2.HoverImage")));
            this.layeredButton2.ImageAttribute = imageAttributes3;
            this.layeredButton2.Location = new System.Drawing.Point(425, 3);
            this.layeredButton2.Name = "layeredButton2";
            this.layeredButton2.NormalImage = ((System.Drawing.Image)(resources.GetObject("layeredButton2.NormalImage")));
            this.layeredButton2.PressedImage = null;
            this.layeredButton2.Size = new System.Drawing.Size(22, 22);
            this.layeredButton2.TabIndex = 3;
            this.layeredButton2.TabStop = false;
            this.layeredButton2.TextLocationOffset = new System.Drawing.Point(0, 0);
            this.layeredButton2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.layeredButton2.TextShowMode = LayeredSkin.TextShowModes.Halo;
            this.layeredButton2.Click += new System.EventHandler(this.layeredButton2_Click);
            // 
            // layeredButton1
            // 
            this.layeredButton1.AdaptImage = true;
            this.layeredButton1.BackColor = System.Drawing.Color.Transparent;
            this.layeredButton1.BaseColor = System.Drawing.Color.Wheat;
            this.layeredButton1.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredButton1.Canvas")));
            this.layeredButton1.ControlState = LayeredSkin.Controls.ControlStates.Normal;
            this.layeredButton1.HaloColor = System.Drawing.Color.White;
            this.layeredButton1.HaloSize = 5;
            this.layeredButton1.HoverImage = ((System.Drawing.Image)(resources.GetObject("layeredButton1.HoverImage")));
            this.layeredButton1.ImageAttribute = imageAttributes4;
            this.layeredButton1.Location = new System.Drawing.Point(397, 3);
            this.layeredButton1.Name = "layeredButton1";
            this.layeredButton1.NormalImage = ((System.Drawing.Image)(resources.GetObject("layeredButton1.NormalImage")));
            this.layeredButton1.PressedImage = null;
            this.layeredButton1.Size = new System.Drawing.Size(22, 22);
            this.layeredButton1.TabIndex = 4;
            this.layeredButton1.TabStop = false;
            this.layeredButton1.TextLocationOffset = new System.Drawing.Point(0, 0);
            this.layeredButton1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.layeredButton1.TextShowMode = LayeredSkin.TextShowModes.Halo;
            this.layeredButton1.Click += new System.EventHandler(this.layeredButton1_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 112);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 2);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(288, 573);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(367, 573);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "发送";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.Color.Gray;
            this.panel2.Location = new System.Drawing.Point(0, 477);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(450, 1);
            this.panel2.TabIndex = 7;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenu.Controls.Add(this.menuStrip1);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Location = new System.Drawing.Point(0, 478);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(450, 26);
            this.pnlMenu.TabIndex = 8;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(450, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(28, 21);
            this.aToolStripMenuItem.Text = "A";
            // 
            // userRichTexBox2
            // 
            this.userRichTexBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.userRichTexBox2.Location = new System.Drawing.Point(0, 504);
            this.userRichTexBox2.Name = "userRichTexBox2";
            this.userRichTexBox2.Size = new System.Drawing.Size(450, 61);
            this.userRichTexBox2.TabIndex = 6;
            // 
            // userRichTexBox1
            // 
            this.userRichTexBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.userRichTexBox1.Location = new System.Drawing.Point(0, 114);
            this.userRichTexBox1.Name = "userRichTexBox1";
            this.userRichTexBox1.Size = new System.Drawing.Size(450, 363);
            this.userRichTexBox1.TabIndex = 5;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::YatMing.Message.Chat.Properties.Resources.d8ffa25210f6ab3bf7923ca55fb03b56;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(450, 600);
            this.Controls.Add(this.userRichTexBox2);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.userRichTexBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.layeredPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Opacity = 0.3D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.layeredPanel1.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private LayeredSkin.Controls.LayeredPanel layeredPanel1;
        private System.Windows.Forms.Panel panel1;
        private LayeredSkin.Controls.LayeredButton layeredButton2;
        private LayeredSkin.Controls.LayeredButton layeredButton1;
        private LayeredSkin.Controls.LayeredLabel lylblName;
        private LayeredSkin.Controls.LayeredPictureBox layeredPictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private RichTextBoxBackPicture.UserRichTexBox userRichTexBox1;
        private RichTextBoxBackPicture.UserRichTexBox userRichTexBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
    }
}

