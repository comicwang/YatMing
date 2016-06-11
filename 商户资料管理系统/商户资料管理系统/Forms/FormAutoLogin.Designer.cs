namespace 商户资料管理系统
{
    partial class FormAutoLogin
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
            this.browserer = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // browserer
            // 
            this.browserer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserer.Location = new System.Drawing.Point(0, 0);
            this.browserer.MinimumSize = new System.Drawing.Size(20, 20);
            this.browserer.Name = "browserer";
            this.browserer.Size = new System.Drawing.Size(644, 505);
            this.browserer.TabIndex = 0;
            this.browserer.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // FormAutoLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 505);
            this.Controls.Add(this.browserer);
            this.Name = "FormAutoLogin";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动登录窗口";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser browserer;
    }
}