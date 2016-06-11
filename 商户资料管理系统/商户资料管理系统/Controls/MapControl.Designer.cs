namespace 商户资料管理系统
{
    partial class MapControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapControl));
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnFly = new System.Windows.Forms.Button();
            this.txtLat = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.searchTextBox1 = new 商户资料管理系统.SearchTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 38);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(489, 384);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.searchTextBox1);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.btnFly);
            this.panel1.Controls.Add(this.txtLat);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtLon);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(489, 38);
            this.panel1.TabIndex = 1;
            // 
            // btnReset
            // 
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Location = new System.Drawing.Point(271, 10);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(62, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnFly
            // 
            this.btnFly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFly.Location = new System.Drawing.Point(205, 10);
            this.btnFly.Name = "btnFly";
            this.btnFly.Size = new System.Drawing.Size(61, 23);
            this.btnFly.TabIndex = 2;
            this.btnFly.Text = "定位";
            this.btnFly.UseVisualStyleBackColor = true;
            this.btnFly.Click += new System.EventHandler(this.btnFly_Click);
            // 
            // txtLat
            // 
            this.txtLat.Location = new System.Drawing.Point(143, 11);
            this.txtLat.Name = "txtLat";
            this.txtLat.Size = new System.Drawing.Size(56, 21);
            this.txtLat.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "纬度";
            // 
            // txtLon
            // 
            this.txtLon.Location = new System.Drawing.Point(42, 11);
            this.txtLon.Name = "txtLon";
            this.txtLon.Size = new System.Drawing.Size(56, 21);
            this.txtLon.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "经度";
            // 
            // searchTextBox1
            // 
            this.searchTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox1.ForeColor = System.Drawing.Color.Gray;
            this.searchTextBox1.Location = new System.Drawing.Point(339, 11);
            this.searchTextBox1.Name = "searchTextBox1";
            this.searchTextBox1.PresetText = "请输入地名";
            this.searchTextBox1.SearchImage = ((System.Drawing.Image)(resources.GetObject("searchTextBox1.SearchImage")));
            this.searchTextBox1.Size = new System.Drawing.Size(147, 21);
            this.searchTextBox1.TabIndex = 3;
            this.searchTextBox1.Text = "请输入地名";
            this.searchTextBox1.OnSearch += new 商户资料管理系统.SearchTextBox.OnSearchHander(this.searchTextBox1_OnSearch);
            // 
            // MapControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.panel1);
            this.Name = "MapControl";
            this.Size = new System.Drawing.Size(489, 422);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtLat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFly;
        private System.Windows.Forms.Button btnReset;
        private SearchTextBox searchTextBox1;
    }
}
