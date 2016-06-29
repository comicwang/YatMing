namespace YatMing.Message.Service
{
    partial class FormPublish
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
            this.txtText = new System.Windows.Forms.TextBox();
            this.btnSendText = new System.Windows.Forms.Button();
            this.rtbText = new System.Windows.Forms.RichTextBox();
            this.btnSendMedia = new System.Windows.Forms.Button();
            this.lstChannel = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lklblNum = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(2, 0);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(323, 142);
            this.txtText.TabIndex = 0;
            // 
            // btnSendText
            // 
            this.btnSendText.Location = new System.Drawing.Point(6, 148);
            this.btnSendText.Name = "btnSendText";
            this.btnSendText.Size = new System.Drawing.Size(319, 41);
            this.btnSendText.TabIndex = 1;
            this.btnSendText.Text = "SendText";
            this.btnSendText.UseVisualStyleBackColor = true;
            this.btnSendText.Click += new System.EventHandler(this.btnSendText_Click);
            // 
            // rtbText
            // 
            this.rtbText.Location = new System.Drawing.Point(2, 195);
            this.rtbText.Name = "rtbText";
            this.rtbText.Size = new System.Drawing.Size(323, 198);
            this.rtbText.TabIndex = 2;
            this.rtbText.Text = "";
            // 
            // btnSendMedia
            // 
            this.btnSendMedia.Location = new System.Drawing.Point(10, 399);
            this.btnSendMedia.Name = "btnSendMedia";
            this.btnSendMedia.Size = new System.Drawing.Size(312, 41);
            this.btnSendMedia.TabIndex = 1;
            this.btnSendMedia.Text = "SendMedia";
            this.btnSendMedia.UseVisualStyleBackColor = true;
            this.btnSendMedia.Click += new System.EventHandler(this.btnSendMedia_Click);
            // 
            // lstChannel
            // 
            this.lstChannel.FormattingEnabled = true;
            this.lstChannel.ItemHeight = 12;
            this.lstChannel.Location = new System.Drawing.Point(677, 24);
            this.lstChannel.Name = "lstChannel";
            this.lstChannel.Size = new System.Drawing.Size(170, 424);
            this.lstChannel.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(338, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Console:";
            // 
            // txtConsole
            // 
            this.txtConsole.Location = new System.Drawing.Point(335, 25);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.Size = new System.Drawing.Size(335, 413);
            this.txtConsole.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(679, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Online:";
            // 
            // lklblNum
            // 
            this.lklblNum.AutoSize = true;
            this.lklblNum.Location = new System.Drawing.Point(730, 7);
            this.lklblNum.Name = "lklblNum";
            this.lklblNum.Size = new System.Drawing.Size(11, 12);
            this.lklblNum.TabIndex = 6;
            this.lklblNum.TabStop = true;
            this.lklblNum.Text = "0";
            // 
            // FormPublish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 450);
            this.Controls.Add(this.lklblNum);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstChannel);
            this.Controls.Add(this.rtbText);
            this.Controls.Add(this.btnSendMedia);
            this.Controls.Add(this.btnSendText);
            this.Controls.Add(this.txtText);
            this.Name = "FormPublish";
            this.Text = "FormPublish";
            this.Load += new System.EventHandler(this.FormPublish_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Button btnSendText;
        private System.Windows.Forms.RichTextBox rtbText;
        private System.Windows.Forms.Button btnSendMedia;
        private System.Windows.Forms.ListBox lstChannel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lklblNum;
    }
}

