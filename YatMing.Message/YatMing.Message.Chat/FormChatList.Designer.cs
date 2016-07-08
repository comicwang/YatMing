namespace YatMing.Message.Chat
{
    partial class FormChatList
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
            this.lstFriend = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstFriend
            // 
            this.lstFriend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFriend.FormattingEnabled = true;
            this.lstFriend.ItemHeight = 12;
            this.lstFriend.Location = new System.Drawing.Point(0, 0);
            this.lstFriend.Name = "lstFriend";
            this.lstFriend.Size = new System.Drawing.Size(617, 479);
            this.lstFriend.TabIndex = 0;
            this.lstFriend.DoubleClick += new System.EventHandler(this.lstFriend_DoubleClick);
            // 
            // FormChatList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 479);
            this.Controls.Add(this.lstFriend);
            this.Name = "FormChatList";
            this.Text = "FormChatList";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormChatList_FormClosing);
            this.Load += new System.EventHandler(this.FormChatList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstFriend;
    }
}