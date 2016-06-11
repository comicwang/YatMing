using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 商户资料管理系统.Common;
using 商户资料管理系统.YatServer;
using 商户资料管理系统.Properties;
using System.IO;

namespace 商户资料管理系统
{
    public partial class DataManageControl : UserControl
    {
        private static YatMingServiceClient _client = ServiceProvider.Clent;
        private string _baseInfoId = string.Empty;
        private string _currentId = string.Empty;
        private string _oldText = string.Empty;
       
        public DataManageControl()
        {
            InitializeComponent();
        }

        public void InitializeContent(string id)
        {
            _baseInfoId = id;
            IniliazeListView(null);
        }

        private void IniliazeListView(string pid)
        {
            TDataInfoDTO[] allResult = null;
            LvDataContent.Items.Clear();
            _currentId = pid;
            //跟节点
            if (string.IsNullOrWhiteSpace(pid))
            {
                allResult = _client.TDataInGetByForginKey(_baseInfoId).Where(t => string.IsNullOrWhiteSpace(t.ParentId)).ToArray();
                tsbReturn.Enabled = false;
            }
            else
            {
                tsbReturn.Enabled = true;
                allResult = _client.TDataInGetByParentKey(pid);              
            }
            Array.ForEach(allResult, d =>
            {
                CreateViewItem(d);
            });
        }

        private void CreateViewItem(TDataInfoDTO dto)
        {
            ListViewItemEx lvi = new ListViewItemEx();
            lvi.ItemData = dto;
            lvi.Text = dto.DataName;
            if (dto.IsForlder == false)
            {
                string[] arrtempFileName = dto.DataName.Split(new char[] { '.' });
                string tempFileExtension = "." + arrtempFileName[arrtempFileName.Length - 1];
                if (!imageList1.Images.Keys.Contains(tempFileExtension))
                    imageList1.Images.Add(tempFileExtension, IconsExtention.IconFromExtension(tempFileExtension, IconsExtention.SystemIconSize.Large));
                lvi.ImageIndex = imageList1.Images.Keys.IndexOf(tempFileExtension);
                lvi.ToolTipText = string.Format("文件名称:{0}\r\n文件大小:{1}M\r\n上传时间:{2}\r\n上传人:{3}\r\n修改时间:{4}\r\n下载次数:{5}\r\n文件描述:{6}", dto.DataName,CommomHelper.ParseMB(dto.FileSize), dto.CreateTime, dto.UploadPeople, dto.LastModifyTime, dto.DownloadTimes, dto.DataDescription);
                LvDataContent.Items.Add(lvi);
                lvi.SetOtherControl();
            }
            else
            {
                if (!imageList1.Images.Keys.Contains("Folder"))
                    imageList1.Images.Add("Folder", Resources.folder);
                lvi.ImageIndex = imageList1.Images.Keys.IndexOf("Folder");
                string.Format("文件名称:{0}\r\n上传时间:{1}\r\n上传人:{2}\r\n修改时间:{3}\r\n文件描述:{4}", dto.DataName, dto.CreateTime, dto.UploadPeople, dto.LastModifyTime, dto.DataDescription);
                LvDataContent.Items.Add(lvi);
            }
        }

        private void UpdateViewItem(TDataInfoDTO dto, ListViewItemEx lvi)
        {
            lvi.Text = dto.DataName;
            lvi.ItemData = dto;
            if (dto.IsForlder == false)
            {
                string[] arrtempFileName = dto.DataName.Split(new char[] { '.' });
                string tempFileExtension = "." + arrtempFileName[arrtempFileName.Length - 1];
                //get imageindex from imagelist according to the file extension  
                if (!imageList1.Images.Keys.Contains(tempFileExtension))
                    imageList1.Images.Add(tempFileExtension, IconsExtention.IconFromExtension(tempFileExtension, IconsExtention.SystemIconSize.Large));
                lvi.ImageIndex = imageList1.Images.Keys.IndexOf(tempFileExtension);
                lvi.ToolTipText = string.Format("文件名称:{0}\r\n文件大小:{1}\r\n上传时间:{2}\r\n上传人:{3}\r\n修改时间:{4}\r\n下载次数:{5}\r\n文件描述:{6}", dto.DataName, dto.FileSize, dto.CreateTime, dto.UploadPeople, dto.LastModifyTime, dto.DownloadTimes, dto.DataDescription);
            }
            else
            {
                if (!imageList1.Images.Keys.Contains("Folder"))
                    imageList1.Images.Add("Folder", Resources.folder);
                lvi.ImageIndex = imageList1.Images.Keys.IndexOf("Folder");
                string.Format("文件名称:{0}\r\n上传时间:{1}\r\n上传人:{2}\r\n修改时间:{3}\r\n文件描述:{4}", dto.DataName, dto.CreateTime, dto.UploadPeople, dto.LastModifyTime, dto.DataDescription);
            }
        }

        private void tsbReturn_Click(object sender, EventArgs e)
        {
            TDataInfoDTO dto = _client.TDataInfoQueryById(_currentId);
            string parentId = dto.ParentId;
            IniliazeListView(parentId);
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            IniliazeListView(_currentId);
        }

        private void tsbNewForlder_Click(object sender, EventArgs e)
        {
            TDataInfoDTO dto = new TDataInfoDTO();
            dto.BaseInfoId = _baseInfoId;
            dto.CreateTime = DateTime.Now;
            dto.DataName = "新建文件夹";
            dto.UploadPeople = CommonData.LoginInfo.EmployeeName;
            dto.IsForlder = true;
            dto.DownloadTimes = 0;
            dto.LastModifyTime = DateTime.Now;
            dto.MetaDataId = Guid.NewGuid().ToString();
            dto.ParentId = _currentId;
            bool result = _client.TDataInfoAdd(dto);
            if (result)
                CreateViewItem(dto);
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection lstSelected = LvDataContent.SelectedItems;
            if (lstSelected.Count > 0)
            {
                foreach (ListViewItem item in LvDataContent.SelectedItems)
                {
                    TDataInfoDTO dto = (item as ListViewItemEx).ItemData;
                    //删除文件夹
                    if (dto.IsForlder)
                    {
                        TDataInfoDTO[] result = _client.TDataInGetByParentKey(dto.MetaDataId);
                        if (result != null && result.Length > 0)
                            Array.ForEach(result, t => { _client.TDataInfoDelete(t.MetaDataId); });
                    }
                    bool success = _client.TDataInfoDelete(dto.MetaDataId);
                    if (success)
                        LvDataContent.Items.Remove(item);
                }
            }
        }

        private void tsbMoveTo_Click(object sender, EventArgs e)
        {

        }

        #region 下载

        private void tsbDownload_Click(object sender, EventArgs e)
        {
             ListView.SelectedListViewItemCollection lstSelected = LvDataContent.SelectedItems;
             if (lstSelected.Count > 0)
             {
                 foreach (ListViewItem item in lstSelected)
                 {
                     ListViewItemEx ctr = item as ListViewItemEx;
                     if (!ctr.ItemData.IsForlder)
                         ctr.DownLoadFile();
                 }
             }
        }

        #endregion

        #region 编辑

        private void LvDataContent_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            string newText = e.Label;
            if (string.IsNullOrEmpty(newText) || newText == _oldText)
            {
                e.CancelEdit = true;
                return;
            }
            TDataInfoDTO dto = (LvDataContent.Items[e.Item] as ListViewItemEx).ItemData;
            dto.DataName = newText;
            dto.LastModifyTime = DateTime.Now;
            dto.ParentId = dto.ParentId == null ? string.Empty : dto.ParentId;
            bool success = _client.TDataInfoUpdate(dto);
            if (success)
                UpdateViewItem(dto, LvDataContent.Items[e.Item] as ListViewItemEx);
        }

        private void LvDataContent_BeforeLabelEdit(object sender, LabelEditEventArgs e)
        {
            _oldText = e.Label;
        }

        #endregion

        #region 拖拽

        /// <summary>
        /// 当拖动某项时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            LvDataContent.DoDragDrop(e.Item, DragDropEffects.Move);
        }

        /// <summary>
        /// 鼠标拖动某项至该控件的区域
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        /// <summary>
        /// 拖动时拖着某项置于某行上方时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_DragOver(object sender, DragEventArgs e)
        {
            Point ptScreen = new Point(e.X, e.Y);
            Point pt = LvDataContent.PointToClient(ptScreen);
            ListViewItem item = LvDataContent.GetItemAt(pt.X, pt.Y);
            if (item != null)
                item.Selected = true;
        }

        /// <summary>
        /// 结束拖动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            ListViewItemEx draggedItem = (ListViewItemEx)e.Data.GetData(typeof(ListViewItemEx));
            Point ptScreen = new Point(e.X, e.Y);
            Point pt = LvDataContent.PointToClient(ptScreen);
            ListViewItemEx TargetItem = LvDataContent.GetItemAt(pt.X, pt.Y) as ListViewItemEx;//拖动的项将放置于该项之前   
            if (null == TargetItem)
                return;
            TDataInfoDTO targetDto = TargetItem.ItemData;
            if (targetDto.IsForlder)
            {
                TDataInfoDTO sourceDTO = draggedItem.ItemData;
                sourceDTO.ParentId = targetDto.MetaDataId;
                bool success= _client.TDataInfoUpdate(sourceDTO);
                if (success)
                {
                    LvDataContent.Items.Remove(draggedItem);
                }
            }
            else
            {
                LvDataContent.Items.Insert(TargetItem.Index, (ListViewItemEx)draggedItem.Clone());
                LvDataContent.Items.Remove(draggedItem);
            }           
        }

        #endregion

        #region 上传

        private void tsbUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "所有文件|*.*";
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Array.ForEach(dialog.FileNames, t => {
                    ListViewItemEx ctr = new ListViewItemEx(_baseInfoId);
                    ctr.Text = Path.GetFileName(t);
                    string tempFileExtension = Path.GetExtension(t);
                    //get imageindex from imagelist according to the file extension  
                    if (!imageList1.Images.Keys.Contains(tempFileExtension))
                        imageList1.Images.Add(tempFileExtension, IconsExtention.IconFromExtension(tempFileExtension, IconsExtention.SystemIconSize.Large));
                    ctr.ImageIndex = imageList1.Images.Keys.IndexOf(tempFileExtension);

                    LvDataContent.Items.Add(ctr);
                    ctr.SetOtherControl();

                    ctr.UploadFile(t);
                });            
            }
        }

        #endregion

        #region 打开

        private void LvDataContent_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (LvDataContent.SelectedItems.Count == 1)
                {
                    TDataInfoDTO dto = (LvDataContent.SelectedItems[0] as ListViewItemEx).ItemData;
                    if (dto.IsForlder)
                    {
                        IniliazeListView(dto.MetaDataId);
                    }
                    else
                    {
                        //打开
                        FormView view = new FormView();
                        view.Show();
                        view.View(dto.MetaDataId);
                    }
                }
            }
        }

        #endregion

        #region 搜索

        private void searchTextBox1_OnSearch(object sender, SearchEventArgs e)
        {
            TDataInfoDTO[] result = null;

            if (string.IsNullOrEmpty(e.SearchText))
                result = _client.TDataInGetByForginKey(_baseInfoId);
            else
                result = _client.TDataInQuery(false, DateTime.Now, DateTime.Now, e.SearchText, _baseInfoId);
            LvDataContent.Items.Clear();
            Array.ForEach(result, t =>
            {
                CreateViewItem(t);
            });
        }

        #endregion
    }
}
