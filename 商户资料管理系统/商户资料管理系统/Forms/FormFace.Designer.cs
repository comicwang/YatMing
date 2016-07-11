namespace 商户资料管理系统
{
    partial class FormFace
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
            this.picView = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picView)).BeginInit();
            this.SuspendLayout();
            // 
            // picView
            // 
            this.picView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picView.Location = new System.Drawing.Point(500, 0);
            this.picView.Name = "picView";
            this.picView.Size = new System.Drawing.Size(30, 30);
            this.picView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picView.TabIndex = 0;
            this.picView.TabStop = false;
            this.picView.Visible = false;
            this.picView.Click += new System.EventHandler(this.picView_Click);
            this.picView.Paint += new System.Windows.Forms.PaintEventHandler(this.picView_Paint);
            // 
            // FormFace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 358);
            this.Controls.Add(this.picView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFace";
            this.Text = "FormFace";
            this.Deactivate += new System.EventHandler(this.FormFace_Deactivate);
            this.Load += new System.EventHandler(this.FormFace_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picView;

    }
}