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

namespace 商户资料管理系统
{
    public partial class DataManageControl : UserControl
    {
        private static YatMingServiceClient _client = ServiceProvider.Clent;
        private string _baseInfoId = string.Empty;
        private string _currentId = string.Empty;
        private string _oldText = string.Empty;
        private ProgressBar _pb = null;
    
        public DataManageControl()
        {
            InitializeComponent();
        }

        public WarningBox warningBox1 { get; set; }

        public string uploadPeople { get; set; }

        public void InitializeContent(string id)
        {
            _baseInfoId = id;
            //初始化界面
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
            ListViewItem lvi = new ListViewItem();
            lvi.Text = dto.DataName;
            lvi.Tag = dto;
            if (dto.IsForlder == false)
            {
                string[] arrtempFileName = dto.DataName.Split(new char[] { '.' });
                string tempFileExtension = "." + arrtempFileName[arrtempFileName.Length - 1];
                //get imageindex from imagelist according to the file extension  
                if (!imageList1.Images.Keys.Contains(tempFileExtension))
                    imageList1.Images.Add(tempFileExtension, IconsExtention.IconFromExtension(tempFileExtension, IconsExtention.SystemIconSize.Large));
                lvi.ImageIndex = imageList1.Images.Keys.IndexOf(tempFileExtension);
                lvi.ToolTipText = string.Format("文件名称:{0}\r\n文件大小:{1}\r\n上传时间:{2}\r\n上传人:{3}\r\n修改时间:{4}\r\n下载次数:{5}\r\n文件描述:{6}", dto.DataName, dto.FileSize, dto.CreateTime, dto.UploadPeople, dto.LastModifyTime, dto.DownloadTimes, dto.DataDescription);
                LvDataContent.Items.Add(lvi);
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

        private void UpdateViewItem(TDataInfoDTO dto, ListViewItem lvi)
        {
            lvi.Text = dto.DataName;
            lvi.Tag = dto;
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
            dto.UploadPeople = uploadPeople;
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
                    TDataInfoDTO dto = item.Tag as TDataInfoDTO;
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

        private void tsbDownload_Click(object sender, EventArgs e)
        {

        }

        private void tsbUpload_Click(object sender, EventArgs e)
        {
            //新增
            FormDataInfo form = new FormDataInfo();
            form.DataInfo = new TDataInfoDTO() { BaseInfoId = _baseInfoId, UploadPeople = uploadPeople };
            if (form.ShowDialog() == DialogResult.OK)
            {
                TDataInfoDTO temp = form.DataInfo;
                //大文件分布上传
                if (temp.DataContent.Length > 40960000 * 21)  //800M
                {
                    warningBox1.ShowMessage("超过最大上传文件限制！", MessageType.Error, 3000, Color.Red);
                    return;
                }
                TDataInfoDTO dto = new TDataInfoDTO()
                {
                    BaseInfoId = temp.BaseInfoId,
                    CreateTime = temp.CreateTime,
                    DataContent = new byte[0],
                    DataDescription = temp.DataDescription,
                    DataName = temp.DataName,
                    DownloadTimes = temp.DownloadTimes,
                    LastModifyTime = temp.LastModifyTime,
                    MetaDataId = temp.MetaDataId,
                    UploadPeople = temp.UploadPeople,
                    FileSize = temp.FileSize,
                    ParentId = _currentId,
                    IsForlder = false
                };
                bool success = _client.TDataInfoAdd(dto);
                if (success)
                {
                    CreateViewItem(dto);
                    ListViewItem item = LvDataContent.Items[LvDataContent.Items.Count - 1];
                    Rectangle rct = item.Bounds;
                    _pb = new ProgressBar();
                    _pb.Height = 10;
                 //   _pb.BackColor=Color.FromArgb(
                    _pb.Width = rct.Width;
                    _pb.Location = new Point(rct.Left, rct.Top + (rct.Height - _pb.Height) / 2);
                    LvDataContent.Controls.Add(_pb);
                    backgroundWorker4.RunWorkerAsync(new object[] { temp.DataContent, temp.MetaDataId });
                }
            }
        }

        #region 编辑

        private void LvDataContent_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            string newText = e.Label;
            if (string.IsNullOrEmpty(newText) || newText == _oldText)
            {
                e.CancelEdit = true;
                return;
            }
            TDataInfoDTO dto = LvDataContent.Items[e.Item].Tag as TDataInfoDTO;
            dto.DataName = newText;
            dto.LastModifyTime = DateTime.Now;
            bool success = _client.TDataInfoUpdate(dto);
            if (success)
                UpdateViewItem(dto, LvDataContent.Items[e.Item]);
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
            ListViewItem draggedItem = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
            Point ptScreen = new Point(e.X, e.Y);
            Point pt = LvDataContent.PointToClient(ptScreen);
            ListViewItem TargetItem = LvDataContent.GetItemAt(pt.X, pt.Y);//拖动的项将放置于该项之前   
            if (null == TargetItem)
                return;
            TDataInfoDTO targetDto = TargetItem.Tag as TDataInfoDTO;
            if (targetDto.IsForlder)
            {
                TDataInfoDTO sourceDTO = draggedItem.Tag as TDataInfoDTO;
                sourceDTO.ParentId = targetDto.MetaDataId;
                bool success= _client.TDataInfoUpdate(sourceDTO);
                if (success)
                {
                    LvDataContent.Items.Remove(draggedItem);
                }
            }
            else
            {
                LvDataContent.Items.Insert(TargetItem.Index, (ListViewItem)draggedItem.Clone());
                LvDataContent.Items.Remove(draggedItem);
            }           
        }

        #endregion

        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {
            object[] arg = e.Argument as object[];
            byte[] total = arg[0] as byte[];
            string id = arg[1].ToString();
            byte[] buffer = new byte[4096000]; //4M
            int percent = total.Length / buffer.Length;
            for (long index = 0; index < percent; index++)
            {
                buffer = total.Skip((int)index * buffer.Length).Take(buffer.Length).ToArray();
                bool result = _client.TDataInfoUploadFile(buffer, id, (int)(index * buffer.Length / 40960000));
                if (result == false)
                {
                    e.Result = false;
                    return;
                }
                backgroundWorker4.ReportProgress((int)((index + 1) * buffer.Length * 100 / total.Length));
            }
            int left = total.Length % buffer.Length;
            if (left > 0)
            {
                byte[] leftBuffer = total.Skip(percent * buffer.Length).Take(left).ToArray();
                bool result = _client.TDataInfoUploadFile(leftBuffer, id, total.Length / 40960000);
                if (result == false)
                {
                    e.Result = false;
                    return;
                }
                backgroundWorker4.ReportProgress(100);

            }
            e.Result = true;
        }

        private void backgroundWorker4_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int index = e.ProgressPercentage;
            _pb.Value = index;
           // warningBox1.ShowMessage(string.Format("当前上传百分比{0}%", index), MessageType.Info);
        }

        private void backgroundWorker4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((bool)e.Result)
            {
                warningBox1.ShowMessage("上传完成", MessageType.Info, 2000);
                LvDataContent.Controls.Remove(_pb);
            }
            else
                warningBox1.ShowMessage("上传失败", MessageType.Info, 2000, Color.Red);
        }

        private void LvDataContent_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (LvDataContent.SelectedItems.Count == 1)
                {
                    TDataInfoDTO dto = LvDataContent.SelectedItems[0].Tag as TDataInfoDTO;
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
    }
}
