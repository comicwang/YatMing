namespace 商户资料管理系统
{
    partial class FormSkin
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lvImage = new System.Windows.Forms.ListView();
            this.LstImage = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbRemove = new System.Windows.Forms.ToolStripButton();
            this.picView = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lvImage);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(80, 338);
            this.panel1.TabIndex = 2;
            // 
            // lvImage
            // 
            this.lvImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvImage.LargeImageList = this.LstImage;
            this.lvImage.Location = new System.Drawing.Point(0, 39);
            this.lvImage.Margin = new System.Windows.Forms.Padding(0);
            this.lvImage.MultiSelect = false;
            this.lvImage.Name = "lvImage";
            this.lvImage.ShowGroups = false;
            this.lvImage.ShowItemToolTips = true;
            this.lvImage.Size = new System.Drawing.Size(80, 299);
            this.lvImage.TabIndex = 1;
            this.lvImage.UseCompatibleStateImageBehavior = false;
            this.lvImage.SelectedIndexChanged += new System.EventHandler(this.lvImage_SelectedIndexChanged);
            this.lvImage.DoubleClick += new System.EventHandler(this.lvImage_DoubleClick);
            // 
            // LstImage
            // 
            this.LstImage.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.LstImage.ImageSize = new System.Drawing.Size(32, 32);
            this.LstImage.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbRemove});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(80, 39);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAdd
            // 
            this.tsbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAdd.Image = global::商户资料管理系统.Properties.Resources.addImage;
            this.tsbAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(36, 36);
            this.tsbAdd.Text = "toolStripButton1";
            this.tsbAdd.ToolTipText = "新增图片";
            this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
            // 
            // tsbRemove
            // 
            this.tsbRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRemove.Image = global::商户资料管理系统.Properties.Resources.removeImage;
            this.tsbRemove.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRemove.Name = "tsbRemove";
            this.tsbRemove.Size = new System.Drawing.Size(36, 36);
            this.tsbRemove.Text = "toolStripButton2";
            this.tsbRemove.ToolTipText = "移除图片";
            this.tsbRemove.Click += new System.EventHandler(this.tsbRemove_Click);
            // 
            // picView
            // 
            this.picView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picView.Location = new System.Drawing.Point(80, 0);
            this.picView.Name = "picView";
            this.picView.Size = new System.Drawing.Size(366, 338);
            this.picView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picView.TabIndex = 3;
            this.picView.TabStop = false;
            // 
            // FormSkin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 338);
            this.Controls.Add(this.picView);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSkin";
            this.Text = "FormSkin";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lvImage;
        private System.Windows.Forms.ImageList LstImage;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbRemove;
    }
}