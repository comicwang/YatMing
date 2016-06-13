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
using System.Collections;

namespace 商户资料管理系统
{
    public partial class DataManageControl : UserControl
    {
        private static YatMingServiceClient _client = ServiceProvider.Clent;
        private string _baseInfoId = string.Empty;
        private string _currentId = string.Empty;
        private string _oldText = string.Empty;
        private ToolStripMenuItem _selectedItem = null;
        private bool _des = false;
       
        public DataManageControl()
        {
            InitializeComponent();
            _selectedItem = tsmNameSort;
            LvDataContent.ListViewItemSorter = new ListViewNameComparer();
        }

        #region 初始化

        /// <summary>
        /// 初始化控件
        /// </summary>
        /// <param name="id">控件对应的商户Id</param>
        public void InitializeContent(string id)
        {
            LvDataContent.InsertionMark.Color = Color.Red;           
            _baseInfoId = id;
            IniliazeListView(null);
        }

        /// <summary>
        /// 初始化ListView
        /// </summary>
        /// <param name="pid">父节点（为空就是根节点）</param>
        private void IniliazeListView(string pid)
        {
            TDataInfoDTO[] allResult = null;
            LvDataContent.Items.Clear();
            _currentId = pid;
            //根节点
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
                CreateViewItem(d, LvDataContent.Items.Count);
            });
        }

        #endregion

        #region 操作Listview

        private void CreateViewItem(TDataInfoDTO dto, int index, bool edit = false)
        {
            ListViewItemEx lvi = new ListViewItemEx();
            lvi.ItemData = dto;
            lvi.Text = dto.DataName;
            if (dto.IsForlder == false)
            {
                lvi.ImageIndex = CommomHelper.GetImageIndex(dto, imageList1);
                lvi.ToolTipText = string.Format("文件名称:{0}\r\n文件大小:{1}M\r\n上传时间:{2}\r\n上传人:{3}\r\n修改时间:{4}\r\n下载次数:{5}\r\n文件描述:{6}", dto.DataName, CommomHelper.ParseMB(dto.FileSize), dto.CreateTime, dto.UploadPeople, dto.LastModifyTime, dto.DownloadTimes, dto.DataDescription);
                LvDataContent.Items.Insert(index, lvi);
                //lvi.SetOtherControl();
            }
            else
            {
                if (!imageList1.Images.Keys.Contains("Folder"))
                    imageList1.Images.Add("Folder", Resources.folder);
                lvi.ImageIndex = imageList1.Images.Keys.IndexOf("Folder");
                string.Format("文件名称:{0}\r\n上传时间:{1}\r\n上传人:{2}\r\n修改时间:{3}\r\n文件描述:{4}", dto.DataName, dto.CreateTime, dto.UploadPeople, dto.LastModifyTime, dto.DataDescription);
                LvDataContent.Items.Insert(index, lvi);
            }
            if (edit)
                lvi.BeginEdit();
        }

        private void UpdateViewItem(TDataInfoDTO dto, ListViewItemEx lvi)
        {
            lvi.Text = dto.DataName;
            lvi.ItemData = dto;
            if (dto.IsForlder == false)
            {
                string tempFileExtension = Path.GetExtension(dto.DataName);
                lvi.ImageIndex = CommomHelper.GetImageIndex(dto, imageList1);
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

        #endregion

        #region Menu操作

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbReturn_Click(object sender, EventArgs e)
        {
            TDataInfoDTO dto = _client.TDataInfoQueryById(_currentId);
            string parentId = dto.ParentId;
            IniliazeListView(parentId);
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            IniliazeListView(_currentId);
        }

        private void tsmRefresh_Click(object sender, EventArgs e)
        {
            IniliazeListView(_currentId);
        }

        /// <summary>
        /// 新建文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            {
                CreateViewItem(dto, LvDataContent.Items.Count,true);
                //LvDataContent.Items[LvDataContent.Items.Count - 1].BeginEdit();
            }
        }

        private void tsmNewForlder_Click(object sender, EventArgs e)
        {
            tsbNewForlder_Click(sender, e);
        }

        /// <summary>
        /// 删除文件或者文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            tsbDelete_Click(sender, e);
        }

        /// <summary>
        /// 移动到
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbMoveTo_Click(object sender, EventArgs e)
        {

        }

        #endregion

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

        private void tsmDownload_Click(object sender, EventArgs e)
        {
            tsbDownload_Click(sender, e);
        }

        #endregion

        #region 编辑

        private void tsmModify_Click(object sender, EventArgs e)
        {
            LvDataContent.SelectedItems[0].BeginEdit();
        }

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
            Dictionary<ListViewItemEx, int> itemsCopy = new Dictionary<ListViewItemEx, int>();
            foreach (ListViewItemEx item in LvDataContent.SelectedItems)
                itemsCopy.Add(item, item.Index);
            LvDataContent.DoDragDrop(itemsCopy, DragDropEffects.Move);
        }

        private void LvDataContent_DragLeave(object sender, EventArgs e)
        {
            LvDataContent.InsertionMark.Index = -1;
        }

        /// <summary>
        /// 鼠标拖动某项至该控件的区域
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
            //if (e.AllowedEffect == DragDropEffects.Move)
            //    e.Effect = DragDropEffects.Move;
            //else
            //    e.Effect = DragDropEffects.Copy;
        }

        /// <summary>
        /// 拖动时拖着某项置于某行上方时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_DragOver(object sender, DragEventArgs e)
        {
            // 获得鼠标坐标
            Point point = LvDataContent.PointToClient(new Point(e.X, e.Y));
            // 返回离鼠标最近的项目的索引
            int index = LvDataContent.InsertionMark.NearestIndex(point);
            // 确定光标不在拖拽项目上
            if (index > -1)
            {
                Rectangle itemBounds = LvDataContent.GetItemRect(index);
                if (point.X > itemBounds.Left + (itemBounds.Width / 2))
                {
                    LvDataContent.InsertionMark.AppearsAfterItem = true;
                }
                else
                {
                    LvDataContent.InsertionMark.AppearsAfterItem = false;
                }
            }
            LvDataContent.InsertionMark.Index = index;
        }

        /// <summary>
        /// 结束拖动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            // 返回插入标记的索引值  
            int index = LvDataContent.InsertionMark.Index;
            // 如果插入标记不可见，则退出.  
            if (index == -1)
            {
                return;
            }
            // 如果插入标记在项目的右面，使目标索引值加一  
            if (LvDataContent.InsertionMark.AppearsAfterItem && index < LvDataContent.Items.Count - 1 && (LvDataContent.Items[index] as ListViewItemEx).ItemData.IsForlder == false)
            {
                index++;
            }
            ListViewItemEx target = LvDataContent.Items[index] as ListViewItemEx;
            //移动项
            if (e.Effect == DragDropEffects.Move)
            {
                // 返回拖拽项  
                Dictionary<ListViewItemEx, int> items = (Dictionary<ListViewItemEx, int>)e.Data.GetData(typeof(Dictionary<ListViewItemEx, int>));
                foreach (var item in items)
                {
                    if (target.ItemData.IsForlder == false)
                    {
                        CreateViewItem(item.Key.ItemData, index);
                        LvDataContent.Items.Remove(item.Key);
                        if (item.Value >= index) index++;
                    }
                    else
                    {
                        TDataInfoDTO sourceDTO = item.Key.ItemData;
                        sourceDTO.ParentId = target.ItemData.MetaDataId;
                        bool success = _client.TDataInfoUpdate(sourceDTO);
                        if (success)
                        {
                            LvDataContent.Items.Remove(item.Key);
                        }
                    }
                }
            }
            else if (e.Effect == (DragDropEffects.Copy | DragDropEffects.Link | DragDropEffects.Move))
            {
                if (target.ItemData.IsForlder)
                {
                    IniliazeListView(target.ItemData.MetaDataId);
                }
                //上传文件
                string[] result = e.Data.GetData(DataFormats.FileDrop) as string[];
                Array.ForEach(result, t =>
                {

                    ListViewItemEx ctr = new ListViewItemEx(_baseInfoId);
                    ctr.Text = Path.GetFileName(t);
                    string tempFileExtension = Path.GetExtension(t);
                   // CommomHelper.GetImageIndex(ctr.ItemData, imageList1);
                   // ctr.ImageIndex = imageList1.Images.Keys.IndexOf(tempFileExtension);
                    LvDataContent.Items.Add(ctr);
                    //ctr.SetOtherControl();
                    ctr.UploadFile(t, _currentId,imageList1);
                });
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
                Array.ForEach(dialog.FileNames, t =>
                {
                    ListViewItemEx ctr = new ListViewItemEx(_baseInfoId);
                    ctr.Text = Path.GetFileName(t);
                    string tempFileExtension = Path.GetExtension(t);
                    LvDataContent.Items.Add(ctr);
                   // ctr.SetOtherControl();
                    ctr.UploadFile(t, _currentId, imageList1);
                });
            }
        }

        private void tsmUpload_Click(object sender, EventArgs e)
        {
            tsbUpload_Click(sender, e);
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

        private void tsmOpen_Click(object sender, EventArgs e)
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
                CreateViewItem(t, LvDataContent.Items.Count);
            });
        }

        #endregion

        #region 控件菜单状态控制

        private void LvDataContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool result = LvDataContent.SelectedItems.Count > 0;
            tsbDelete.Enabled = result;
            tsbDownload.Enabled = result;
            tsmDelete.Visible = result;
            tsmDownload.Visible = result;
            tsmOpen.Visible = result;
            tsmModify.Visible = result;
            tsmUpload.Visible = !result;
            tsmSort.Visible = !result;
            tsmRefresh.Visible = !result;
            tsmNewForlder.Visible = !result;

            bool temp = LvDataContent.SelectedItems.Count == 1;
            tsmModify.Enabled = temp;
            tsmOpen.Enabled = temp;
            //文件夹去除下载
            if (temp && (LvDataContent.SelectedItems[0] as ListViewItemEx).ItemData.IsForlder)
            {
                tsmDownload.Visible = false;
                tsbDownload.Enabled = false;
            }
        }

        #endregion

        #region 排序

        private void tsmNameSort_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsm = sender as ToolStripMenuItem;
            if (_selectedItem.Name != tsm.Name)
            {
                _selectedItem.Image = Resources.empty;
                LvDataContent.ListViewItemSorter = new ListViewNameComparer();
                tsm.Image = Resources.selected;
                _selectedItem = tsm;
            }
            else
            {
                if(!_des)
                    LvDataContent.ListViewItemSorter = new ListViewNameComparerDes();
                else
                    LvDataContent.ListViewItemSorter = new ListViewNameComparer();
                _des = !_des;
            }
        }

        private void tsmTypeSort_Click(object sender, EventArgs e)
        {
             ToolStripMenuItem tsm = sender as ToolStripMenuItem;
             if (_selectedItem.Name != tsm.Name)
             {
                 _selectedItem.Image = Resources.empty;
                 LvDataContent.ListViewItemSorter = new ListViewTypeComparer();
                 tsm.Image = Resources.selected;
                 _selectedItem = tsm;
             }
             else
             {
                 if (!_des)
                     LvDataContent.ListViewItemSorter = new ListViewTypeComparerDes();
                 else
                     LvDataContent.ListViewItemSorter = new ListViewTypeComparer();
                 _des = !_des;
             }
        }

        private void tsbNumSort_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsm = sender as ToolStripMenuItem;
            if (_selectedItem.Name != tsm.Name)
            {
                _selectedItem.Image = Resources.empty;
                LvDataContent.ListViewItemSorter = new ListViewSizeComparer();
                tsm.Image = Resources.selected;
                _selectedItem = tsm;
            }
            else
            {
                if (!_des)
                    LvDataContent.ListViewItemSorter = new ListViewSizeComparerDes();
                else
                    LvDataContent.ListViewItemSorter = new ListViewSizeComparer();
                _des = !_des;
            }
        }

        private void tsbModifySort_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsm = sender as ToolStripMenuItem;
            if (_selectedItem.Name != tsm.Name)
            {
                _selectedItem.Image = Resources.empty;
                LvDataContent.ListViewItemSorter = new ListViewModifyComparer();
                tsm.Image = Resources.selected;
                _selectedItem = tsm;
            }
            else
            {
                if (!_des)
                    LvDataContent.ListViewItemSorter = new ListViewModifyComparerDes();
                else
                    LvDataContent.ListViewItemSorter = new ListViewModifyComparer();
                _des = !_des;
            }
        }

        #endregion

    }

    #region Sort Class Ascending

    public class ListViewNameComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            ListViewItemEx x1 = (ListViewItemEx)x;
            ListViewItemEx y1 = (ListViewItemEx)y;
            if (x1.ItemData == null || y1.ItemData == null)
                return 1;
            if (x1.ItemData.IsForlder)
                return -1;
            else if (y1.ItemData.IsForlder)
                return 1;
            else
                return string.CompareOrdinal(x1.ItemData.DataName, y1.ItemData.DataName);
        }
    }

    public class ListViewTypeComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            ListViewItemEx x1 = (ListViewItemEx)x;
            ListViewItemEx y1 = (ListViewItemEx)y;
            if (x1.ItemData == null || y1.ItemData == null)
                return 1;
            if (x1.ItemData.IsForlder)
                return -1;
            else if (y1.ItemData.IsForlder)
                return 1;
            else
                return string.CompareOrdinal(Path.GetExtension(x1.ItemData.DataName).Remove(0, 1), Path.GetExtension(y1.ItemData.DataName).Remove(0, 1));
        }
    }

    public class ListViewModifyComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            ListViewItemEx x1 = (ListViewItemEx)x;
            ListViewItemEx y1 = (ListViewItemEx)y;
            if (x1.ItemData == null || y1.ItemData == null)
                return 1;
            if (x1.ItemData.IsForlder)
                return -1;
            else if (y1.ItemData.IsForlder)
                return 1;
            else
                return DateTime.Compare(x1.ItemData.LastModifyTime.Value, y1.ItemData.LastModifyTime.Value);
        }
    }

    public class ListViewSizeComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            ListViewItemEx x1 = (ListViewItemEx)x;
            ListViewItemEx y1 = (ListViewItemEx)y;
            if (x1.ItemData == null || y1.ItemData == null)
                return 1;
            if (x1.ItemData.IsForlder)
                return -1;
            else if (y1.ItemData.IsForlder)
                return 1;
            else
                return (int)(CommomHelper.ParseMB(x1.ItemData.FileSize) - CommomHelper.ParseMB(y1.ItemData.FileSize));
        }
    }

    #endregion

    #region Sort Class Descending

    public class ListViewNameComparerDes : IComparer
    {
        public int Compare(object x, object y)
        {
            ListViewItemEx y1 = (ListViewItemEx)x;
            ListViewItemEx x1 = (ListViewItemEx)y;
            if (x1.ItemData == null || y1.ItemData == null)
                return 1;
            if (x1.ItemData.IsForlder)
                return -1;
            else if (y1.ItemData.IsForlder)
                return 1;
            else
                return string.CompareOrdinal(x1.ItemData.DataName, y1.ItemData.DataName);
        }
    }

    public class ListViewTypeComparerDes : IComparer
    {
        public int Compare(object x, object y)
        {
            ListViewItemEx y1 = (ListViewItemEx)x;
            ListViewItemEx x1 = (ListViewItemEx)y;
            if (x1.ItemData == null || y1.ItemData == null)
                return 1;
            if (x1.ItemData.IsForlder)
                return -1;
            else if (y1.ItemData.IsForlder)
                return 1;
            else
                return string.CompareOrdinal(Path.GetExtension(x1.ItemData.DataName).Remove(0, 1), Path.GetExtension(y1.ItemData.DataName).Remove(0, 1));
        }
    }

    public class ListViewModifyComparerDes : IComparer
    {
        public int Compare(object x, object y)
        {
            ListViewItemEx y1 = (ListViewItemEx)x;
            ListViewItemEx x1 = (ListViewItemEx)y;
            if (x1.ItemData == null || y1.ItemData == null)
                return 1;
            if (x1.ItemData.IsForlder)
                return -1;
            else if (y1.ItemData.IsForlder)
                return 1;
            else
                return DateTime.Compare(x1.ItemData.LastModifyTime.Value, y1.ItemData.LastModifyTime.Value);
        }
    }

    public class ListViewSizeComparerDes : IComparer
    {
        public int Compare(object x, object y)
        {
            ListViewItemEx y1 = (ListViewItemEx)x;
            ListViewItemEx x1 = (ListViewItemEx)y;
            if (x1.ItemData == null || y1.ItemData == null)
                return 1;
            if (x1.ItemData.IsForlder)
                return -1;
            else if (y1.ItemData.IsForlder)
                return 1;
            else
                return (int)(CommomHelper.ParseMB(x1.ItemData.FileSize) - CommomHelper.ParseMB(y1.ItemData.FileSize));
        }
    }

    #endregion
}
