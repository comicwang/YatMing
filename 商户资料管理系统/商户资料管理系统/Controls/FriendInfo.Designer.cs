namespace 商户资料管理系统
{
    partial class FriendInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FriendInfo));
            this.lblName = new System.Windows.Forms.Label();
            this.picImage = new 商户资料管理系统.PictureStreamBox();
            this.lblEmotion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(44, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 12);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "label1";
            // 
            // picImage
            // 
            this.picImage.Image = ((System.Drawing.Image)(resources.GetObject("picImage.Image")));
            this.picImage.Location = new System.Drawing.Point(7, 6);
            this.picImage.Name = "picImage";
            this.picImage.ReadOnly = false;
            this.picImage.Size = new System.Drawing.Size(30, 30);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 2;
            this.picImage.TabStop = false;
            // 
            // lblEmotion
            // 
            this.lblEmotion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEmotion.AutoSize = true;
            this.lblEmotion.ForeColor = System.Drawing.Color.Gray;
            this.lblEmotion.Location = new System.Drawing.Point(102, 16);
            this.lblEmotion.Name = "lblEmotion";
            this.lblEmotion.Size = new System.Drawing.Size(41, 12);
            this.lblEmotion.TabIndex = 1;
            this.lblEmotion.Text = "label1";
            // 
            // FriendInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.lblEmotion);
            this.Controls.Add(this.lblName);
            this.Name = "FriendInfo";
            this.Size = new System.Drawing.Size(197, 40);
            this.Click += new System.EventHandler(this.FriendInfo_Click);
            this.MouseEnter += new System.EventHandler(this.FriendInfo_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.FriendInfo_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private PictureStreamBox picImage;
        private System.Windows.Forms.Label lblEmotion;
    }
}
