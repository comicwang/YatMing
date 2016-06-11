namespace 商户资料管理系统
{
    partial class FormSearchData
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
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.chbTime = new System.Windows.Forms.CheckBox();
            this.picMore = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picMore)).BeginInit();
            this.SuspendLayout();
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(9, 8);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(228, 21);
            this.txtKeyword.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(243, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(8, 41);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(121, 21);
            this.dtpStart.TabIndex = 2;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(162, 41);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(121, 21);
            this.dtpEnd.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "——";
            // 
            // chbTime
            // 
            this.chbTime.AutoSize = true;
            this.chbTime.Location = new System.Drawing.Point(290, 44);
            this.chbTime.Name = "chbTime";
            this.chbTime.Size = new System.Drawing.Size(48, 16);
            this.chbTime.TabIndex = 4;
            this.chbTime.Text = "时间";
            this.chbTime.UseVisualStyleBackColor = true;
            // 
            // picMore
            // 
            this.picMore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMore.Image = global::商户资料管理系统.Properties.Resources.up;
            this.picMore.Location = new System.Drawing.Point(324, 12);
            this.picMore.Name = "picMore";
            this.picMore.Size = new System.Drawing.Size(16, 16);
            this.picMore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picMore.TabIndex = 5;
            this.picMore.TabStop = false;
            this.picMore.Click += new System.EventHandler(this.picMore_Click);
            // 
            // FormSearchData
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 37);
            this.Controls.Add(this.picMore);
            this.Controls.Add(this.chbTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtKeyword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSearchData";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "搜索资料文件";
            ((System.ComponentModel.ISupportInitialize)(this.picMore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chbTime;
        private System.Windows.Forms.PictureBox picMore;

    }
}