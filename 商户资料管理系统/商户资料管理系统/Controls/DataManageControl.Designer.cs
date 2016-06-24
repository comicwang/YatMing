namespace 商户资料管理系统
{
    partial class DataManageControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataManageControl));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbReturn = new System.Windows.Forms.ToolStripButton();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbUpload = new System.Windows.Forms.ToolStripButton();
            this.tsbDownload = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbNewForlder = new System.Windows.Forms.ToolStripButton();
            this.tsbMoveTo = new System.Windows.Forms.ToolStripButton();
            this.ctmContent = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmUpload = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmViewIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmViewDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSort = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmNameSort = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTypeSort = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbNumSort = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbModifySort = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmModify = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmNewForlder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.LvDataContent = new 商户资料管理系统.ListviewEx();
            this.colHeadIcon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadModify = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadUploadBy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.searchTextBox1 = new 商户资料管理系统.SearchTextBox();
            this.toolStrip1.SuspendLayout();
            this.ctmContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbReturn,
            this.tsbRefresh,
            this.toolStripSeparator1,
            this.tsbUpload,
            this.tsbDownload,
            this.tsbDelete,
            this.tsbNewForlder,
            this.tsbMoveTo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(688, 38);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbReturn
            // 
            this.tsbReturn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbReturn.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.tsbReturn.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tsbReturn.Image = global::商户资料管理系统.Properties.Resources._return;
            this.tsbReturn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbReturn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReturn.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tsbReturn.Name = "tsbReturn";
            this.tsbReturn.Size = new System.Drawing.Size(34, 38);
            this.tsbReturn.Text = "返回";
            this.tsbReturn.Click += new System.EventHandler(this.tsbReturn_Click);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefresh.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.tsbRefresh.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tsbRefresh.Image = global::商户资料管理系统.Properties.Resources.refresh;
            this.tsbRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(31, 38);
            this.tsbRefresh.Text = "刷新";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // tsbUpload
            // 
            this.tsbUpload.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.tsbUpload.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tsbUpload.Image = global::商户资料管理系统.Properties.Resources.upload;
            this.tsbUpload.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbUpload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpload.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tsbUpload.Name = "tsbUpload";
            this.tsbUpload.Size = new System.Drawing.Size(67, 38);
            this.tsbUpload.Text = "上传";
            this.tsbUpload.Click += new System.EventHandler(this.tsbUpload_Click);
            // 
            // tsbDownload
            // 
            this.tsbDownload.Enabled = false;
            this.tsbDownload.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.tsbDownload.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tsbDownload.Image = global::商户资料管理系统.Properties.Resources.download;
            this.tsbDownload.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDownload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDownload.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tsbDownload.Name = "tsbDownload";
            this.tsbDownload.Size = new System.Drawing.Size(67, 38);
            this.tsbDownload.Text = "下载";
            this.tsbDownload.Click += new System.EventHandler(this.tsbDownload_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Enabled = false;
            this.tsbDelete.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.tsbDelete.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tsbDelete.Image = global::商户资料管理系统.Properties.Resources.dustbin;
            this.tsbDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(63, 38);
            this.tsbDelete.Text = "删除";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tsbNewForlder
            // 
            this.tsbNewForlder.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.tsbNewForlder.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tsbNewForlder.Image = global::商户资料管理系统.Properties.Resources.folderNew;
            this.tsbNewForlder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbNewForlder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewForlder.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tsbNewForlder.Name = "tsbNewForlder";
            this.tsbNewForlder.Size = new System.Drawing.Size(107, 38);
            this.tsbNewForlder.Text = "新建文件夹";
            this.tsbNewForlder.Click += new System.EventHandler(this.tsbNewForlder_Click);
            // 
            // tsbMoveTo
            // 
            this.tsbMoveTo.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.tsbMoveTo.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tsbMoveTo.Image = global::商户资料管理系统.Properties.Resources.MoveTo;
            this.tsbMoveTo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbMoveTo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMoveTo.Name = "tsbMoveTo";
            this.tsbMoveTo.Size = new System.Drawing.Size(79, 35);
            this.tsbMoveTo.Text = "移动到";
            this.tsbMoveTo.Visible = false;
            this.tsbMoveTo.Click += new System.EventHandler(this.tsbMoveTo_Click);
            // 
            // ctmContent
            // 
            this.ctmContent.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmOpen,
            this.tsmUpload,
            this.tsmView,
            this.tsmSort,
            this.tsmRefresh,
            this.tsmModify,
            this.tsmNewForlder,
            this.tsmDownload,
            this.tsmDelete});
            this.ctmContent.Name = "ctmContent";
            this.ctmContent.Size = new System.Drawing.Size(155, 202);
            // 
            // tsmOpen
            // 
            this.tsmOpen.Name = "tsmOpen";
            this.tsmOpen.Size = new System.Drawing.Size(154, 22);
            this.tsmOpen.Text = "打开(&O)";
            this.tsmOpen.Visible = false;
            this.tsmOpen.Click += new System.EventHandler(this.tsmOpen_Click);
            // 
            // tsmUpload
            // 
            this.tsmUpload.Image = global::商户资料管理系统.Properties.Resources.upload;
            this.tsmUpload.Name = "tsmUpload";
            this.tsmUpload.Size = new System.Drawing.Size(154, 22);
            this.tsmUpload.Text = "上传(&U)";
            this.tsmUpload.Click += new System.EventHandler(this.tsmUpload_Click);
            // 
            // tsmView
            // 
            this.tsmView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmViewIcon,
            this.tsmViewDetail});
            this.tsmView.Name = "tsmView";
            this.tsmView.Size = new System.Drawing.Size(154, 22);
            this.tsmView.Text = "查看(&V)";
            // 
            // tsmViewIcon
            // 
            this.tsmViewIcon.Image = global::商户资料管理系统.Properties.Resources.selected;
            this.tsmViewIcon.Name = "tsmViewIcon";
            this.tsmViewIcon.Size = new System.Drawing.Size(100, 22);
            this.tsmViewIcon.Text = "图标";
            this.tsmViewIcon.Click += new System.EventHandler(this.tsmViewIcon_Click);
            // 
            // tsmViewDetail
            // 
            this.tsmViewDetail.Name = "tsmViewDetail";
            this.tsmViewDetail.Size = new System.Drawing.Size(100, 22);
            this.tsmViewDetail.Text = "详情";
            this.tsmViewDetail.Click += new System.EventHandler(this.tsmViewDetail_Click);
            // 
            // tsmSort
            // 
            this.tsmSort.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmNameSort,
            this.tsmTypeSort,
            this.tsbNumSort,
            this.tsbModifySort});
            this.tsmSort.Name = "tsmSort";
            this.tsmSort.Size = new System.Drawing.Size(154, 22);
            this.tsmSort.Text = "排序(&S)";
            // 
            // tsmNameSort
            // 
            this.tsmNameSort.Image = global::商户资料管理系统.Properties.Resources.selected;
            this.tsmNameSort.Name = "tsmNameSort";
            this.tsmNameSort.Size = new System.Drawing.Size(124, 22);
            this.tsmNameSort.Text = "文件名称";
            this.tsmNameSort.Click += new System.EventHandler(this.tsmNameSort_Click);
            // 
            // tsmTypeSort
            // 
            this.tsmTypeSort.Name = "tsmTypeSort";
            this.tsmTypeSort.Size = new System.Drawing.Size(124, 22);
            this.tsmTypeSort.Text = "文件类型";
            this.tsmTypeSort.Click += new System.EventHandler(this.tsmTypeSort_Click);
            // 
            // tsbNumSort
            // 
            this.tsbNumSort.Name = "tsbNumSort";
            this.tsbNumSort.Size = new System.Drawing.Size(124, 22);
            this.tsbNumSort.Text = "文件大小";
            this.tsbNumSort.Click += new System.EventHandler(this.tsbNumSort_Click);
            // 
            // tsbModifySort
            // 
            this.tsbModifySort.Name = "tsbModifySort";
            this.tsbModifySort.Size = new System.Drawing.Size(124, 22);
            this.tsbModifySort.Text = "修改时间";
            this.tsbModifySort.Click += new System.EventHandler(this.tsbModifySort_Click);
            // 
            // tsmRefresh
            // 
            this.tsmRefresh.Name = "tsmRefresh";
            this.tsmRefresh.Size = new System.Drawing.Size(154, 22);
            this.tsmRefresh.Text = "刷新(&R)";
            this.tsmRefresh.Click += new System.EventHandler(this.tsmRefresh_Click);
            // 
            // tsmModify
            // 
            this.tsmModify.Name = "tsmModify";
            this.tsmModify.Size = new System.Drawing.Size(154, 22);
            this.tsmModify.Text = "重命名";
            this.tsmModify.Visible = false;
            this.tsmModify.Click += new System.EventHandler(this.tsmModify_Click);
            // 
            // tsmNewForlder
            // 
            this.tsmNewForlder.Name = "tsmNewForlder";
            this.tsmNewForlder.Size = new System.Drawing.Size(154, 22);
            this.tsmNewForlder.Text = "新建文件夹(&N)";
            this.tsmNewForlder.Click += new System.EventHandler(this.tsmNewForlder_Click);
            // 
            // tsmDownload
            // 
            this.tsmDownload.Image = global::商户资料管理系统.Properties.Resources.download;
            this.tsmDownload.Name = "tsmDownload";
            this.tsmDownload.Size = new System.Drawing.Size(154, 22);
            this.tsmDownload.Text = "下载(&L)";
            this.tsmDownload.Visible = false;
            this.tsmDownload.Click += new System.EventHandler(this.tsmDownload_Click);
            // 
            // tsmDelete
            // 
            this.tsmDelete.Image = global::商户资料管理系统.Properties.Resources.delete;
            this.tsmDelete.Name = "tsmDelete";
            this.tsmDelete.Size = new System.Drawing.Size(154, 22);
            this.tsmDelete.Text = "删除(&D)";
            this.tsmDelete.Visible = false;
            this.tsmDelete.Click += new System.EventHandler(this.tsmDelete_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "fenxiao.jpg");
            // 
            // LvDataContent
            // 
            this.LvDataContent.AllowColumnReorder = true;
            this.LvDataContent.AllowDrop = true;
            this.LvDataContent.AutoArrange = false;
            this.LvDataContent.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeadIcon,
            this.colHeadName,
            this.colHeadSize,
            this.colHeadModify,
            this.colHeadUploadBy});
            this.LvDataContent.ContextMenuStrip = this.ctmContent;
            this.LvDataContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LvDataContent.LabelEdit = true;
            this.LvDataContent.LargeImageList = this.imageList1;
            this.LvDataContent.Location = new System.Drawing.Point(0, 38);
            this.LvDataContent.Name = "LvDataContent";
            this.LvDataContent.ShowItemToolTips = true;
            this.LvDataContent.Size = new System.Drawing.Size(688, 331);
            this.LvDataContent.SmallImageList = this.imageList1;
            this.LvDataContent.TabIndex = 2;
            this.LvDataContent.UseCompatibleStateImageBehavior = false;
            this.LvDataContent.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.LvDataContent_AfterLabelEdit);
            this.LvDataContent.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.LvDataContent_BeforeLabelEdit);
            this.LvDataContent.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView1_ItemDrag);
            this.LvDataContent.SelectedIndexChanged += new System.EventHandler(this.LvDataContent_SelectedIndexChanged);
            this.LvDataContent.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView1_DragDrop);
            this.LvDataContent.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView1_DragEnter);
            this.LvDataContent.DragOver += new System.Windows.Forms.DragEventHandler(this.listView1_DragOver);
            this.LvDataContent.DragLeave += new System.EventHandler(this.LvDataContent_DragLeave);
            this.LvDataContent.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LvDataContent_MouseDoubleClick);
            // 
            // colHeadIcon
            // 
            this.colHeadIcon.DisplayIndex = 4;
            this.colHeadIcon.Text = "图标";
            // 
            // colHeadName
            // 
            this.colHeadName.DisplayIndex = 0;
            this.colHeadName.Text = "名称";
            this.colHeadName.Width = 450;
            // 
            // colHeadSize
            // 
            this.colHeadSize.DisplayIndex = 1;
            this.colHeadSize.Text = "文件大小";
            this.colHeadSize.Width = 150;
            // 
            // colHeadModify
            // 
            this.colHeadModify.DisplayIndex = 2;
            this.colHeadModify.Text = "修改时间";
            this.colHeadModify.Width = 200;
            // 
            // colHeadUploadBy
            // 
            this.colHeadUploadBy.DisplayIndex = 3;
            this.colHeadUploadBy.Text = "上传人";
            this.colHeadUploadBy.Width = 80;
            // 
            // searchTextBox1
            // 
            this.searchTextBox1.ForeColor = System.Drawing.Color.Gray;
            this.searchTextBox1.Location = new System.Drawing.Point(411, 10);
            this.searchTextBox1.Name = "searchTextBox1";
            this.searchTextBox1.PresetText = "搜索商户文件";
            this.searchTextBox1.SearchImage = ((System.Drawing.Image)(resources.GetObject("searchTextBox1.SearchImage")));
            this.searchTextBox1.Size = new System.Drawing.Size(153, 21);
            this.searchTextBox1.TabIndex = 1;
            this.searchTextBox1.Text = "搜索商户文件";
            this.searchTextBox1.OnSearch += new 商户资料管理系统.SearchTextBox.OnSearchHander(this.searchTextBox1_OnSearch);
            // 
            // DataManageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LvDataContent);
            this.Controls.Add(this.searchTextBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "DataManageControl";
            this.Size = new System.Drawing.Size(688, 369);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ctmContent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbMoveTo;
        private System.Windows.Forms.ToolStripButton tsbUpload;
        private System.Windows.Forms.ToolStripButton tsbDownload;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbNewForlder;
        private System.Windows.Forms.ToolStripButton tsbReturn;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private SearchTextBox searchTextBox1;
        private ListviewEx LvDataContent;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip ctmContent;
        private System.Windows.Forms.ToolStripMenuItem tsmSort;
        private System.Windows.Forms.ToolStripMenuItem tsmNameSort;
        private System.Windows.Forms.ToolStripMenuItem tsmTypeSort;
        private System.Windows.Forms.ToolStripMenuItem tsbNumSort;
        private System.Windows.Forms.ToolStripMenuItem tsbModifySort;
        private System.Windows.Forms.ToolStripMenuItem tsmRefresh;
        private System.Windows.Forms.ToolStripMenuItem tsmModify;
        private System.Windows.Forms.ToolStripMenuItem tsmDownload;
        private System.Windows.Forms.ToolStripMenuItem tsmUpload;
        private System.Windows.Forms.ToolStripMenuItem tsmDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmOpen;
        private System.Windows.Forms.ToolStripMenuItem tsmNewForlder;
        private System.Windows.Forms.ColumnHeader colHeadName;
        private System.Windows.Forms.ColumnHeader colHeadSize;
        private System.Windows.Forms.ColumnHeader colHeadModify;
        private System.Windows.Forms.ColumnHeader colHeadUploadBy;
        private System.Windows.Forms.ToolStripMenuItem tsmView;
        private System.Windows.Forms.ToolStripMenuItem tsmViewIcon;
        private System.Windows.Forms.ToolStripMenuItem tsmViewDetail;
        private System.Windows.Forms.ColumnHeader colHeadIcon;
    }
}
