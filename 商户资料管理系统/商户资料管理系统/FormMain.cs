using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using 商户资料管理系统.Common;
using 商户资料管理系统.Properties;
using 商户资料管理系统.YatServer;

namespace 商户资料管理系统
{
    public partial class FormMain : Form
    {
        private YatMingServiceClient _client = ServiceProvider.Clent;
        private bool _isAdd = false;
        private bool _worned = false;
        private bool _openSkin = true;
        //图标可用事件
        private delegate void CanOparateChanged(object sender, OparateEventArgs e);
        private event CanOparateChanged OnCanOparateChanged;
        //图标闪烁事件
        public delegate void CanBlinkChanged(object sender, OparateEventArgs e);
        public event CanBlinkChanged OnCanBlinkChanged;

        //主线程窗体
        private FormLogin _loginForm = null;

        public FormLogin LoginForm
        {
            get { return _loginForm; }
            set { _loginForm = value; }
        }

        public TEmployeeDTO _employee = null;

        public FormNotify _notifyForm = null;

        private DataManageControl _dataMangeControl = null;
        private MessageRecorder _recorderControl = null;

        public FormMain()
        {
            InitializeComponent();           
        }

        public FormMain(FormLogin loginForm)
            : this()
        {
            _loginForm = loginForm;
            this.BindNotify(tmBlink);
            this.BindSkin(tsbSkin);

            _dataMangeControl = new DataManageControl();
            _dataMangeControl.Dock = DockStyle.Fill;
            tabPage7.Controls.Add(_dataMangeControl);

            _recorderControl = new MessageRecorder();
            _recorderControl.Dock = DockStyle.Fill;
            tabPage4.Controls.Add(_recorderControl);
        }   

        #region 热键注册

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers fsModifiers, Keys vk);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private const int Hot_Key = 0x0312;

        private void RegistAllHotkey()
        {
            RegisterHotKey(Handle, 101, KeyModifiers.Ctrl, Keys.F);  //搜索
            RegisterHotKey(Handle, 102, KeyModifiers.Ctrl, Keys.S);  //保存
            RegisterHotKey(Handle, 103, KeyModifiers.Ctrl, Keys.D);  //删除
            RegisterHotKey(Handle, 104, KeyModifiers.Ctrl, Keys.E);  //编辑
            RegisterHotKey(Handle, 105, KeyModifiers.Ctrl, Keys.N);  //新建
        }

        private void UnRegistAllHotkey()
        {
            UnregisterHotKey(Handle, 101);  //搜索
            UnregisterHotKey(Handle, 102);  //保存
            UnregisterHotKey(Handle, 103);  //删除
            UnregisterHotKey(Handle, 104);  //编辑
            UnregisterHotKey(Handle, 105);  //新建
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {
            RegistAllHotkey();
        }

        private void FormMain_Deactivate(object sender, EventArgs e)
        {
            UnRegistAllHotkey();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Hot_Key)
            {
                if (m.WParam.ToInt32() == 101)
                {
                    //tsbSearchData_Click(null, null);
                }
                else if (m.WParam.ToInt32() == 102)
                {
                    //保存
                    if (btnSave.Enabled)
                        btnSave_Click(null, null);
                }
                else if (m.WParam.ToInt32() == 103)
                {
                    //删除
                    if (btnDelete.Enabled)
                        btnDelete_Click(null, null);
                }
                else if (m.WParam.ToInt32() == 104)
                {
                    //编辑
                    if (btnEdit.Enabled)
                        btnEdit_Click(null, null);
                }
                else if (m.WParam.ToInt32() == 105)
                {
                    //新建
                    if (btnNew.Enabled)
                        btnNew_Click(null, null);
                }
            }

            base.WndProc(ref m);
        }

        #endregion

        #region 初始化界面

        private void InitializeCombox()
        {
            TMerchantTypeDTO[] result = _client.TMerchantTypeQueryAll().Where(t => string.IsNullOrWhiteSpace(t.ParentId)).ToArray();
            List<TMerchantTypeDTO> source = new List<TMerchantTypeDTO>();
            source.Add(new TMerchantTypeDTO() { MerchatType = "请选择" });
            source.AddRange(result);
            coboPType.DataSource = source;
            coboPType.DisplayMember = "MerchatType";
            coboPType.ValueMember = "MerchantId";
        }

        /// <summary>
        /// 商户类型关联
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void coboPType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<TMerchantTypeDTO> source = new List<TMerchantTypeDTO>();
                source.Add(new TMerchantTypeDTO() { MerchatType = "未知类型" });
                TMerchantTypeDTO dto = coboPType.SelectedItem as TMerchantTypeDTO;
                if (dto != null)
                {
                    string pid = dto.MerchantId;
                    TMerchantTypeDTO[] result = _client.TMerchantTypeGetByPid(pid);
                    source.AddRange(result);
                }
                coboType.DataSource = source;
                coboType.DisplayMember = "MerchatType";
                coboType.ValueMember = "MerchantId";
            }
            catch (Exception ex)
            {
                warningBox1.ShowMessage(ex.Message, MessageType.Error, 3000, Color.Red);
            }
        }

        /// <summary>
        /// 初始化商户界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //初始化商户树节点
            TreeNode root = TreeNodeHelper.InitializeTree("");
            TreeNodeHelper.InitializeMerchant(ref root);
            e.Result = root;
            if (_loginForm != null)
            {
                TLoginDTO loginInfo = _loginForm.Tag as TLoginDTO;
                if(loginInfo!=null)
                {
                    _employee = _client.TEmployeeQueryById(loginInfo.EmployeeId);
                }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            treeView1.Nodes.Clear();
            TreeNode result = e.Result as TreeNode;
            foreach (TreeNode item in result.Nodes)
            {
                treeView1.Nodes.Add(item);
            }
            treeView1.ExpandAll();

            InitializeCombox();
            mapControl1.InitializeMap();

            OnCanOparateChanged += FormMain_OnCanOparateChanged;
            CallOparateHander(btnNew, true);
            CallOparateHander(btnEdit, false);
            CallOparateHander(btnSave, false);
            CallOparateHander(btnPrint, false);
            CallOparateHander(btnDelete, false);
            CallOparateHander(btnCancel, false);
            SetEnable(false);
            if (_employee != null)
            {
                CommonData.LoginInfo = _employee;
                tslUser.Image = _employee.EmployeeSex == "男" ? Resources.man : Resources.woman;
                tslUser.Text = _employee.EmployeeName;
                tslUser.SetTips(new FormEmploeeInfo(_employee));

                _notifyForm = new FormNotify(_employee.EmployeeName);
                _notifyForm.InitializeNotify();
            }

            label1.Visible = false;
        }

        /// <summary>
        /// 窗体入口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {               
                label1.Visible = true;
                backgroundWorker1.RunWorkerAsync();
                tmTime.Start();
             
                //开一个检测系统更新的线程
                Thread thread = new Thread(new ParameterizedThreadStart(delegate
                {
                    while (true)
                    {
                        bool result = _client.TLoginCheckUpdate(Application.ProductVersion.ToString());
                        if (result && OnCanBlinkChanged != null && _worned == false)
                        {
                            Action actionDelegate = () =>
                            {
                               OnCanBlinkChanged(this, new OparateEventArgs(true));
                            };
                            this.Invoke(actionDelegate);
                            _worned = true;
                        }
                    }
                }));
                thread.IsBackground = true;
                thread.Start();
            }
            catch (Exception ex)
            {
                warningBox1.ShowMessage(ex.Message, MessageType.Error, 3000, Color.Red);
            }
        }

        /// <summary>
        /// 设置按钮状态
        /// </summary>
        /// <param name="button"></param>
        /// <param name="canOparate"></param>
        private void CallOparateHander(ToolStripButton button, bool canOparate)
        {
            if (OnCanOparateChanged != null)
                OnCanOparateChanged(button, new OparateEventArgs(canOparate));
        }

        private void FormMain_OnCanOparateChanged(object sender, OparateEventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            button.Enabled = e.CanOparate;
        }

        #endregion

        #region 逻辑操作

        #region 保存

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = true;
                if (_isAdd)
                {
                    //新增
                    result &= _client.TBaseInfoAdd(BaseInfo);
                    result &= _client.TShopDataAdd(ShopDataDTO); //开店资料
                    result &= _client.TDetailInfoAdd(DetailInfo); //详细信息
                    _isAdd = false;
                }
                else
                {
                    //保存
                    result &= _client.TBaseInfoUpdate(BaseInfo);
                    result &= _client.TShopDataUpdate(ShopDataDTO);
                    result &= _client.TDetailInfoUpdate(DetailInfo);
                }
                if (result)
                {
                    CallOparateHander(btnEdit, true);
                    CallOparateHander(btnNew, true);
                    CallOparateHander(btnSave, false);
                    CallOparateHander(btnDelete, true);
                    CallOparateHander(btnCancel, false);
                    SetEnable(false);

                    //刷新
                    label1.Visible = true;
                    backgroundWorker1.RunWorkerAsync();
                    warningBox1.ShowMessage("保存成功！", MessageType.Info, 1500, Color.Black);
                }
                else
                {
                    warningBox1.ShowMessage("保存失败！", MessageType.Warning, 3000, Color.Red);
                }
            }
            catch (Exception ex)
            {
                warningBox1.ShowMessage(ex.Message, MessageType.Error, 3000, Color.Red);
            }
        }

        #endregion

        #region 新建

        /// <summary>
        /// 新建触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            Clear();
            _isAdd = true;
            SetEnable(true);
            CallOparateHander(btnSave, true);
            CallOparateHander(btnNew, false);
            CallOparateHander(btnEdit, false);
            CallOparateHander(btnDelete, false);
            CallOparateHander(btnCancel, true);

            //如果选中节点新建，则Combox跳到相应节点
            TreeNode node = treeView1.SelectedNode;
            if (node == null)
                return;
            if (node.Level == 0)
            {
                coboPType.SelectedValue = node.Name;
            }
            else
            {
                string id = string.Empty;
                string pid = string.Empty;
                if (node.Level == 1)
                {
                    id = node.Name;
                    pid = node.Parent.Name;

                }
                else
                {
                    id = node.Parent.Name;
                    pid = node.Parent.Parent.Name;
                }
                coboPType.SelectedValue = pid;
                coboType.SelectedValue = id;
            }
        }

        #endregion

        #region 编辑

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            CallOparateHander(btnSave, true);
            CallOparateHander(btnNew, false);
            CallOparateHander(btnEdit, false);
            CallOparateHander(btnDelete, true);
            CallOparateHander(btnCancel, true);
            SetEnable(true);
        }

        #endregion

        #region 查询

        /// <summary>
        /// 触发查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.Tag == null)
                    return;
                if (backgroundWorker2.IsBusy == false)
                {
                    backgroundWorker2.RunWorkerAsync(e.Node.Tag);
                    pnlWait.Visible = true;
                }
                _dataMangeControl.InitializeContent(e.Node.Tag.ToString());
                _recorderControl.InitializeRecorder(e.Node.Tag.ToString());

            }
            catch (Exception ex)
            {
                warningBox1.ShowMessage(ex.Message, MessageType.Error, 3000, Color.Red);
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument == null)
            {
                e.Result = null;
                return;
            }
            string id = e.Argument.ToString();
            //查询商户信息
            TBaseInfoDTO result = _client.TBaseInfoQueryById(id);  //基本信息
            TPlatformDTO[] result1 = _client.TPlatformGetByForignKey(id); //平台信息
            TDetailInfoDTO result2 = _client.TDetailInfoGetByForignKey(id);//详细信息
            TShopDataDTO result3 = null;
            if (result2 != null)
            {
                result3 = _client.TShopDataQueryById(result2.DataId); //开店资料信息
            }
            TDataInfoDTO[] result4 = _client.TDataInGetByForginKey(id); //资料信息
            e.Result = new object[] { result, result1, result2, result3, result4 };
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pnlWait.Visible = false;
            CallOparateHander(btnEdit, true);
            CallOparateHander(btnSave, false);
            CallOparateHander(btnNew, true);
            CallOparateHander(btnDelete, true);
            CallOparateHander(btnCancel, false);
            SetEnable(false);
            if (e.Result != null)
            {
                object[] result = e.Result as object[];
                //设置基本信息
                BaseInfo = result[0] as TBaseInfoDTO;
                //设置详细信息
                DetailInfo = result[2] as TDetailInfoDTO;
                //设置平台信息
                dgvPlatform.Rows.Clear();
                Array.ForEach(result[1] as TPlatformDTO[], t => { AddPlatformRow(t); });
                //设置开店资料信息
                ShopDataDTO = result[3] as TShopDataDTO;
                //设置资料信息
              //  dgvDataInfo.Rows.Clear();
              //  Array.ForEach(result[4] as TDataInfoDTO[], t => { AddOtherData(t); });
            }
        }

        #endregion

        #region 搜索

        private void searchTextBox1_OnSearch(object sender, SearchEventArgs e)
        {
            try
            {
                string keyword = e.SearchText;
                //如果查询文字为空，则回复到树节点显示状态
                if (string.IsNullOrEmpty(keyword))
                {
                    label1.Text = "加载中...";
                    label1.Visible = true;
                    listBox1.Visible = false;
                    backgroundWorker1.RunWorkerAsync();
                }
                //非空，显示查询的ListBox
                else
                {
                    label1.Text = "查询中...";
                    label1.Visible = true;
                    listBox1.Visible = true;
                    backgroundWorker3.RunWorkerAsync(keyword);
                }
            }
            catch (Exception ex)
            {
                warningBox1.ShowMessage(ex.Message, MessageType.Error, 3000, Color.Red);
            }
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            TBaseInfoDTO[] result = _client.TBaseInfoQueryByKeyword(e.Argument.ToString());

            e.Result = result;
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            listBox1.DataSource = e.Result as TBaseInfoDTO[];
            listBox1.DisplayMember = "MerchantName";
            listBox1.ValueMember = "BaseInfoId";
            label1.Visible = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TBaseInfoDTO selectDTO = listBox1.SelectedItem as TBaseInfoDTO;
            if (selectDTO == null || backgroundWorker2.IsBusy)
                return;
            backgroundWorker2.RunWorkerAsync(selectDTO.BaseInfoId);
        }

        #endregion

        #region 取消

        private void btnCancel_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            if (node == null || node.Tag == null)
            {
                CallOparateHander(btnNew, true);
                CallOparateHander(btnEdit, false);
                CallOparateHander(btnSave, false);
                CallOparateHander(btnPrint, false);
                CallOparateHander(btnDelete, false);
                CallOparateHander(btnCancel, false);
                SetEnable(false);
                return;
            }
            backgroundWorker2.RunWorkerAsync(node.Tag);
        }

        #endregion

        #region 删除

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode node = treeView1.SelectedNode;
                if (node.Tag == null)
                    return;
                DialogResult result = MessageBox.Show("是否删除本条商户记录？", "重要提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    bool success = _client.TBaseInfoDelete(node.Tag.ToString());
                    TDetailInfoDTO dto = _client.TDetailInfoGetByForignKey(node.Tag.ToString());
                    success &= _client.TDetailInfoDelete(dto.DetailId);
                    if (success)
                    {
                        //刷新界面
                        label1.Visible = true;
                        Clear();
                        backgroundWorker1.RunWorkerAsync();
                        warningBox1.ShowMessage("删除成功！", MessageType.Info, 2000);
                    }
                    else
                    {
                        warningBox1.ShowMessage("删除失败！", MessageType.Warning, 2000, Color.Red);
                    }
                }
            }
            catch (Exception ex)
            {
                warningBox1.ShowMessage(ex.Message, MessageType.Error, 3000, Color.Red);
            }
        }

        #endregion

        #endregion

        #region 控件值操作

        #region 基础信息

        public TBaseInfoDTO BaseInfo
        {
            get
            {
                TBaseInfoDTO result = new TBaseInfoDTO();
                result.BaseInfoId = CommomHelper.GuidGetter(txtMName.Tag);
                txtMName.Tag = result.BaseInfoId;
                result.MerchantName = txtMName.Text;
                result.MerchantBoss = txtBName.Text;
                result.MerchantTel = txtTel.Text;
                result.MerchantSex = coboSex.Text;
                result.MerchantId = (coboType.SelectedItem as TMerchantTypeDTO).MerchantId;
                result.MerchantAdd = txtAdd.Text;
                result.Feedback = txtDes.Text;
                PointF point= mapControl1.MapPoint;
                result.Lon = point.X;
                result.Lat = point.Y;
                result.Logo = pictureStreamBox1.GetPictureStream();
                return result;
            }
            set
            {
                if (value == null)
                {
                    ClearBaseInfo();
                    return;
                }
                txtMName.Tag = value.BaseInfoId;
                txtMName.Text = value.MerchantName;
                txtBName.Text = value.MerchantBoss;
                txtAdd.Text = value.MerchantAdd;
                txtDes.Text = value.Feedback;
                txtTel.Text = value.MerchantTel;
                coboSex.Text = value.MerchantSex;
                TMerchantTypeDTO result = _client.TMerchantTypeQueryById(value.MerchantId);
                coboPType.SelectedValue = result.ParentId;
                coboType.SelectedValue = value.MerchantId;
                mapControl1.MapPoint = new PointF(CommomHelper.ParseFloat(value.Lon),CommomHelper.ParseFloat(value.Lat));
                mapControl1.FlyTo();
                pictureStreamBox1.SetPicture(value.Logo);
            }
        }

        private void ClearBaseInfo()
        {
            txtMName.Tag = null;
            txtMName.Text = null;
            txtBName.Text = null;
            txtAdd.Text = null;
            txtDes.Text = null;
            txtTel.Text = null;
            coboSex.Text = null;
            coboPType.SelectedIndex = -1;
            coboType.SelectedIndex = -1;
            mapControl1.Clear();
        }

        private void SetBaseInfoEnabel(bool enable)
        {
            txtMName.ReadOnly = !enable;
            txtMName.ReadOnly = !enable;
            txtBName.ReadOnly = !enable;
            txtAdd.ReadOnly = !enable;
            txtDes.ReadOnly = !enable;
            txtTel.ReadOnly = !enable;
            coboSex.Enabled = enable;
            coboPType.Enabled = enable;
            coboType.Enabled = enable;
            mapControl1.SetEnable(enable);
            pictureStreamBox1.Enabled = enable;
        }

        #endregion

        #region 详细信息

        public TDetailInfoDTO DetailInfo
        {
            get
            {
                TDetailInfoDTO result = new TDetailInfoDTO();
                result.DetailId = CommomHelper.GuidGetter(grpDetail.Tag);
                grpDetail.Tag = result.DetailId;
                result.BaseInfoId = BaseInfo.BaseInfoId;
                result.DataId = ShopDataDTO.DataId;
                result.MerchantReq = txtReq.Text;
                result.MerchantReqP = rchboxReqP.GetStreamText();
                return result;
            }
            set
            {
                if (value == null)
                {
                    ClearDetailInfo();
                    return;
                }
                grpDetail.Tag = value.DetailId;
                txtReq.Text = value.MerchantReq;
                grpData.Tag = value.DataId;
                rchboxReqP.SetStreamText(value.MerchantReqP);
            }
        }

        private void ClearDetailInfo()
        {
            grpDetail.Tag = null;
            txtReq.Text = null;
            grpData.Tag = null;
            rchboxReqP.SetStreamText(new byte[0]);
        }

        private void SetDetailInfoEnable(bool enable)
        {
            txtReq.ReadOnly = !enable;
            rchboxReqP.ReadOnly = !enable;
        }

        #endregion

        #region 平台信息

        private void 新增AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtMName.Tag == null)
            {
                warningBox1.ShowMessage("请先填写基本信息，再添加平台信息！", MessageType.Warning, 3000, Color.Red);
                return;
            }
            //新增平台信息
            FormPlatform form = new FormPlatform();
            form.PlatformDTO = new TPlatformDTO()
            {
                MerchantId = txtMName.Tag.ToString()
            };
            if (DialogResult.OK == form.ShowDialog())
            {
                TPlatformDTO dto = form.PlatformDTO;
                bool result = _client.TPlatformAdd(dto);
                if (result)
                {
                    AddPlatformRow(dto);
                }
            }
        }

        private void dgvPlatform_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            //编辑
            if (e.ColumnIndex == DoLogin.Index)
            {
                FormPlatform form = new FormPlatform();
                form.PlatformDTO = GetPlatformDTO(e.RowIndex);
                if (DialogResult.OK == form.ShowDialog())
                {
                    TPlatformDTO dto = form.PlatformDTO;
                    bool result = _client.TPlatformUpdate(dto);
                    if (result)
                    {
                        UpdatePlatformRow(dto, e.RowIndex);
                    }
                }
            }
            //删除
            else if (e.ColumnIndex == PlatformDelete.Index)
            {
                if (DialogResult.Yes == MessageBox.Show("是否删除本条信息？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk))
                {
                    bool result = _client.TPlatformDelete(dgvPlatform[1, e.RowIndex].Value.ToString());
                    if (result)
                    {
                        dgvPlatform.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
            //登录
            else if (e.ColumnIndex == PlatformLogin.Index)
            {
                FormAutoLogin loginForm = new FormAutoLogin(GetPlatformDTO(e.RowIndex));
                loginForm.Show();
            }
        }

        private void AddPlatformRow(TPlatformDTO dto)
        {
            dgvPlatform.Rows.Add(dto.MerchantId, dto.PlatformId, dto.PlatformName, dto.Account, dto.Password, dto.PlatformUri, "登录", "编辑", "删除");
        }

        private void UpdatePlatformRow(TPlatformDTO dto, int rowIndex)
        {
            dgvPlatform.Rows[rowIndex].SetValues(dto.MerchantId, dto.PlatformId, dto.PlatformName, dto.Account, dto.Password, dto.PlatformUri, "登录", "编辑", "删除");
        }

        private TPlatformDTO GetPlatformDTO(int rowIndex)
        {
            TPlatformDTO result = new TPlatformDTO();
            result.MerchantId = dgvPlatform[0, rowIndex].Value.ToString();
            result.PlatformId = dgvPlatform[1, rowIndex].Value.ToString();
            result.PlatformName = dgvPlatform[2, rowIndex].Value.ToString();
            result.Account = dgvPlatform[3, rowIndex].Value.ToString();
            result.Password = dgvPlatform[4, rowIndex].Value.ToString();
            result.PlatformUri = dgvPlatform[5, rowIndex].Value.ToString();
            return result;
        }

        #endregion

        #region 开店资料

        public TShopDataDTO ShopDataDTO
        {
            get
            {
                TShopDataDTO result = new TShopDataDTO();
                result.DataId = CommomHelper.GuidGetter(grpData.Tag);
                grpData.Tag = result.DataId;
                result.Brand = txtPP.Text;
                result.MerchantName = txtSHJC.Text;
                result.TelPhone = txtMDDH.Text.Trim();
                result.PayeeMobile = txtSKTXH.Text;
                result.BusinessHourS = CommomHelper.IntGetter(dudYYKS.Text);
                result.BusinessHourE = CommomHelper.IntGetter(dudYYJS.Text);
                result.CPP = CommomHelper.IntGetter(txtRJXF.Text);
                result.WIFI = radioButton1.Checked;
                result.WifiAccount = txtWIFIZH.Text;
                result.WifiPsw = txtWIFIMM.Text;
                result.ActionInfo = txtZCHD.Text;
                result.BusinessLicN = txtYYZZH.Text;
                result.BusinessName = txtSHQC.Text;
                result.BusinessAdd = txtZZDZ.Text;
                result.BusinessLicP = rcbZZZP.GetStreamText();
                result.OtherLicN = txtQTZZH.Text;
                result.OtherLicP = rcbQTZZH.GetStreamText();
                result.IdCardN = txtSFZH.Text;
                result.IdCardP1 = rcbZMZ.GetStreamText();
                result.IdCardP2 = rcbFMZ.GetStreamText();
                result.Email = txtZCYX.Text;
                result.BankInfo = txtKHXX.Text;
                result.BankNum = txtKH.Text;
                result.BankP = rcbKZP.GetStreamText();
                return result;
            }
            set
            {
                if (value == null)
                {
                    ClearShopData();
                    return;
                }
                grpData.Tag = value.DataId;
                txtPP.Text = value.Brand;
                txtSHJC.Text = value.MerchantName;
                txtMDDH.Text = value.TelPhone;
                txtSKTXH.Text = value.PayeeMobile;
                dudYYKS.Text = value.BusinessHourS.Value.ToString();
                dudYYJS.Text = value.BusinessHourE.Value.ToString();
                txtRJXF.Text = value.CPP.Value.ToString();
                radioButton1.Checked = value.WIFI.Value;
                txtWIFIZH.Text = value.WifiAccount;
                txtWIFIMM.Text = value.WifiPsw;
                txtZCHD.Text = value.ActionInfo;
                txtYYZZH.Text = value.BusinessLicN;
                txtSHQC.Text = value.BusinessName;
                txtZZDZ.Text = value.BusinessAdd;
                rcbZZZP.SetStreamText(value.BusinessLicP);
                txtQTZZH.Text = value.OtherLicN;
                rcbQTZZH.SetStreamText(value.OtherLicP);
                txtSFZH.Text = value.IdCardN;
                rcbZMZ.SetStreamText(value.IdCardP1);
                rcbFMZ.SetStreamText(value.IdCardP2);
                txtZCYX.Text = value.Email;
                txtKHXX.Text = value.BankInfo;
                txtKH.Text = value.BankNum;
                rcbKZP.SetStreamText(value.BankP);
            }
        }

        private void ClearShopData()
        {
            grpData.Tag = null;
            txtPP.Clear();
            txtSHJC.Clear();
            txtMDDH.Clear();
            txtSKTXH.Clear();
            dudYYKS.Text = "00";
            dudYYJS.Text = "00";
            txtRJXF.Clear();
            radioButton1.Checked = false;
            txtWIFIZH.Clear();
            txtWIFIMM.Clear();
            txtZCHD.Clear();
            txtYYZZH.Clear();
            txtSHQC.Clear();
            txtZZDZ.Clear();
            rcbZZZP.SetStreamText(new byte[0]);
            txtQTZZH.Clear();
            rcbQTZZH.SetStreamText(new byte[0]);
            txtSFZH.Clear();
            rcbZMZ.SetStreamText(new byte[0]);
            rcbFMZ.SetStreamText(new byte[0]);
            txtZCYX.Clear();
            txtKHXX.Clear();
            txtKH.Clear();
            rcbKZP.SetStreamText(new byte[0]);
        }

        private void SetShopDataEnable(bool enable)
        {
            txtPP.ReadOnly = !enable;
            txtSHJC.ReadOnly = !enable;
            txtMDDH.ReadOnly = !enable;
            txtSKTXH.ReadOnly = !enable;
            dudYYKS.ReadOnly = !enable;
            dudYYJS.ReadOnly = !enable;
            txtRJXF.ReadOnly = !enable;
            radioButton1.Enabled = enable;
            radioButton2.Enabled = enable;
            txtWIFIZH.ReadOnly = !enable;
            txtWIFIMM.ReadOnly = !enable;
            txtZCHD.ReadOnly = !enable;
            txtYYZZH.ReadOnly = !enable;
            txtSHQC.ReadOnly = !enable;
            txtZZDZ.ReadOnly = !enable;
            rcbZZZP.ReadOnly = !enable;
            txtQTZZH.ReadOnly = !enable;
            rcbQTZZH.ReadOnly = !enable;
            txtSFZH.ReadOnly = !enable;
            rcbZMZ.ReadOnly = !enable;
            rcbFMZ.ReadOnly = !enable;
            txtZCYX.ReadOnly = !enable;
            txtKHXX.ReadOnly = !enable;
            txtKH.ReadOnly = !enable;
            rcbKZP.ReadOnly = !enable;
        }

        #endregion

        //#region 资料信息

        ///// <summary>
        ///// 新增资料文件
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void toolStripMenuItem2_Click(object sender, EventArgs e)
        //{
        //   //新增
        //    FormDataInfo form = new FormDataInfo();
        //    form.DataInfo = new TDataInfoDTO() { BaseInfoId = BaseInfo.BaseInfoId, UploadPeople = _employee.EmployeeName };
        //    if (form.ShowDialog() == DialogResult.OK)
        //    {
        //        TDataInfoDTO temp = form.DataInfo;
        //        //大文件分布上传
        //        if (temp.DataContent.Length > 40960000 * 21)  //800M
        //        {
        //            warningBox1.ShowMessage("超过最大上传文件限制！", MessageType.Error, 3000, Color.Red);
        //            return;
        //        }
        //        TDataInfoDTO dto = new TDataInfoDTO()
        //        {
        //            BaseInfoId = temp.BaseInfoId,
        //            CreateTime = temp.CreateTime,
        //            DataContent = new byte[0],
        //            DataDescription = temp.DataDescription,
        //            DataName = temp.DataName,
        //            DownloadTimes = temp.DownloadTimes,
        //            LastModifyTime = temp.LastModifyTime,
        //            MetaDataId = temp.MetaDataId,
        //            UploadPeople = temp.UploadPeople,
        //            FileSize = temp.FileSize
        //        };
        //        bool success = _client.TDataInfoAdd(dto);
        //        if (success)
        //        {
        //            backgroundWorker4.RunWorkerAsync(new object[] { temp.DataContent, temp.MetaDataId });
        //            AddOtherData(dto);
        //        }
        //    }
        //}

        ///// <summary>
        ///// 资料文件操作
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void dgvDataInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex < 0)
        //        return;
        //    string metaId=dgvDataInfo[MetaDataId.Index, e.RowIndex].Value.ToString();
        //    //查看
        //    if (e.ColumnIndex == DataInfoView.Index)
        //    {
        //        //FormDataInfo form = new FormDataInfo();
        //        //form.DataInfo = GetOtherDataInfo(e.RowIndex);
        //        //form.ShowDialog();
        //        FormView view = new FormView();
        //        view.Show();
        //        view.View(metaId);
        //    }
        //    //删除
        //    else if (e.ColumnIndex == DataInfoDelete.Index)
        //    {
        //        if (DialogResult.Yes == MessageBox.Show("是否删除本条信息？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk))
        //        {
        //            bool success = _client.TDataInfoDelete(metaId);
        //            if (success)
        //            {
        //                dgvDataInfo.Rows.RemoveAt(e.RowIndex);
        //            }
        //        }
        //    }
        //    //下载
        //    else if (e.ColumnIndex == DataInfoDownload.Index)
        //    {
        //        SaveFileDialog dialog = new SaveFileDialog();
        //        dialog.Filter = "所有文件|*.*";
        //        TDataInfoDTO dto = _client.TDataInfoQueryById(metaId);
        //        dialog.FileName = dto.DataName;
        //        if (dialog.ShowDialog() == DialogResult.OK)
        //        {
        //            if (backgroundWorker5.IsBusy == false)
        //                backgroundWorker5.RunWorkerAsync(new object[] { dto, dialog.FileName });
        //        }
        //    }
        //    //编辑
        //    else if (e.ColumnIndex == DataInfoEdit.Index)
        //    {
        //        TDataInfoDTO result = _client.TDataInfoQueryById(metaId);
        //        if (result == null)
        //            return;
        //        FormDataInfo form = new FormDataInfo();
        //        form.DataInfo = result;
        //        if (form.ShowDialog() == DialogResult.OK)
        //        {
        //            bool success = _client.TDataInfoUpdate(form.DataInfo);
        //            if (success)
        //            {
        //                UpdateOtherDataRow(form.DataInfo, e.RowIndex);
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// 新增资料文件行
        ///// </summary>
        ///// <param name="dto"></param>
        //private void AddOtherData(TDataInfoDTO dto)
        //{
        //    int index = dgvDataInfo.Rows.Add();
        //    UpdateOtherDataRow(dto, index);
        //}

        ///// <summary>
        ///// 更新资料文件行
        ///// </summary>
        ///// <param name="dto"></param>
        ///// <param name="index"></param>
        //private void UpdateOtherDataRow(TDataInfoDTO dto, int index)
        //{
        //    dgvDataInfo[MetaDataId.Index, index].Value = dto.MetaDataId;
        //    dgvDataInfo[DataName.Index, index].Value = dto.DataName;
        //    dgvDataInfo[CreateTime.Index, index].Value = CommomHelper.ParseDateTime(dto.CreateTime); ;
        //    dgvDataInfo[LastModifyTime.Index, index].Value = CommomHelper.ParseDateTime(dto.LastModifyTime);
        //    dgvDataInfo[DataDescription.Index, index].Value = dto.DataDescription;
        //    dgvDataInfo[UploadPeople.Index, index].Value = dto.UploadPeople;
        //    dgvDataInfo[DownloadTimes.Index, index].Value = dto.DownloadTimes;
        //    dgvDataInfo[DataInfoDelete.Index, index].Value = "删除";
        //    dgvDataInfo[DataInfoEdit.Index, index].Value = "编辑";
        //    dgvDataInfo[DataInfoView.Index, index].Value = "预览";
        //    dgvDataInfo[DataInfoDownload.Index, index].Value = "下载";
        //}

        ///// <summary>
        ///// 根据行数返回资料信息
        ///// </summary>
        ///// <param name="index"></param>
        ///// <returns></returns>
        //private TDataInfoDTO GetOtherDataInfo(int index)
        //{
        //    TDataInfoDTO result = new TDataInfoDTO();
        //    result.BaseInfoId = BaseInfo.BaseInfoId;
        //    result.MetaDataId = dgvDataInfo[MetaDataId.Index, index].Value.ToString();
        //    result.DataName = dgvDataInfo[DataName.Index, index].Value.ToString();
        //    result.CreateTime = CommomHelper.ParseDateTime(dgvDataInfo[CreateTime.Index, index].Value);
        //    result.LastModifyTime = CommomHelper.ParseDateTime(dgvDataInfo[LastModifyTime.Index, index].Value);
        //    result.DataDescription = dgvDataInfo[DataDescription.Index, index].Value.ToString();
        //    result.UploadPeople = dgvDataInfo[UploadPeople.Index, index].Value.ToString();
        //    result.DownloadTimes = CommomHelper.IntGetter(dgvDataInfo[DownloadTimes.Index, index].Value.ToString());
        //    return result;
        //}

        ///// <summary>
        ///// 搜索资料文件
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void tsbSearchData_Click(object sender, EventArgs e)
        //{
        //    FormSearchData form = new FormSearchData();
        //    if (DialogResult.OK == form.ShowDialog())
        //    {
        //        TDataInfoDTO[] result = null;

        //        if (form.LimitTime == false && string.IsNullOrEmpty(form.Keyword))
        //            result = _client.TDataInGetByForginKey(BaseInfo.BaseInfoId);
        //        else
        //            result = _client.TDataInQuery(form.LimitTime, form.StartTime, form.EndTime, form.Keyword, BaseInfo.BaseInfoId);
        //        dgvDataInfo.Rows.Clear();
        //        Array.ForEach(result, t =>
        //        {
        //            AddOtherData(t);
        //        });
        //    }
        //}

        //#endregion

        #endregion

        #region 其他控件逻辑

        /// <summary>
        /// 商户类型管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 粘贴PToolStripButton_Click(object sender, EventArgs e)
        {
            //商户类型管理
            FormMerchantType form = new FormMerchantType();
            form.Show();
        }

        /// <summary>
        /// 是否开启WIFI输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            bool readOnly = radioButton1.Checked == false || btnSave.Enabled == false;
            txtWIFIZH.ReadOnly = readOnly;
            txtWIFIMM.ReadOnly = readOnly;
        }

        //设置开店资料控件居中
        private void panel4_SizeChanged(object sender, EventArgs e)
        {
            grpData.Location = new Point((panel4.Width - grpData.Width) / 2, 0);
        }

        private void tabPage1_SizeChanged(object sender, EventArgs e)
        {
            panel10.Location = new Point((tabPage1.Width - panel10.Width) / 2, 0);
            panel10.Height = tabPage1.Height;
        }

        private void panel2_SizeChanged(object sender, EventArgs e)
        {
            panel2.Location = new Point((tabPage2.Width - panel2.Width) / 2, 0);
            panel2.Height = tabPage2.Height;
        }

        private void pnlWait_SizeChanged(object sender, EventArgs e)
        {
            picWait.Location = new Point((pnlWait.Width - picWait.Width) / 2, (pnlWait.Height - picWait.Height) / 2);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //激活滚动条
            if (tabControl1.SelectedIndex == 2)
            {
                txtSHJC.Focus();
            }
        }

        private void 帮助LToolStripButton_Click(object sender, EventArgs e)
        {
            FormAboutUs form = new FormAboutUs();
            form.ShowDialog();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        /// <summary>
        /// 时间显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            tslTimer.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
        }

        private void tsbRefreash_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        #endregion

        #region 控件状态

        private void SetEnable(bool enable)
        {
            SetBaseInfoEnabel(enable);
            SetDetailInfoEnable(enable);
            SetShopDataEnable(enable);
            tsbAddDataInfo.Enabled = enable;
            tsbAddplatform.Enabled = enable;
            tsbAddMoreData.Enabled = enable;
        }

        private void Clear()
        {
            BaseInfo = null;
            DetailInfo = null;
            ShopDataDTO = null;
            dgvPlatform.Rows.Clear();
            //dgvDataInfo.Rows.Clear();
        }

        #endregion

        #region 打印

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void tsbOpenSkin_Click(object sender, EventArgs e)
        {
            _openSkin = !_openSkin;
            if (_openSkin)
            {
                tsbOpenSkin.Image = Resources.on;
                tsbOpenSkin.ToolTipText = "关闭皮肤";
            }
            else
            {
                tsbOpenSkin.Image = Resources.off;
                tsbOpenSkin.ToolTipText = "打开皮肤";
            }
            this.SetSkinEnable(tsbSkin, _openSkin);
            this.Refresh();
        }

        //#region 文件上传

        //private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    object[] arg = e.Argument as object[];
        //    byte[] total = arg[0] as byte[];
        //    string id = arg[1].ToString();
        //    byte[] buffer = new byte[4096000]; //4M
        //    int percent = total.Length / buffer.Length;
        //    for (long index = 0; index < percent; index++)
        //    {
        //        buffer = total.Skip((int)index * buffer.Length).Take(buffer.Length).ToArray();
        //        bool result = _client.TDataInfoUploadFile(buffer, id, (int)(index * buffer.Length / 40960000));
        //        if (result == false)
        //        {
        //            e.Result = false;
        //            return;
        //        }
        //        backgroundWorker4.ReportProgress((int)((index + 1) * buffer.Length * 100 / total.Length));
        //    }
        //    int left = total.Length % buffer.Length;
        //    if (left > 0)
        //    {
        //        byte[] leftBuffer = total.Skip(percent * buffer.Length).Take(left).ToArray();
        //        bool result = _client.TDataInfoUploadFile(leftBuffer, id, total.Length / 40960000);
        //        if (result == false)
        //        {
        //            e.Result = false;
        //            return;
        //        }
        //        backgroundWorker4.ReportProgress(100);

        //    }
        //    e.Result = true;
        //}

        //private void backgroundWorker4_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{
        //    int index = e.ProgressPercentage;
        //    warningBox1.ShowMessage(string.Format("当前上传百分比{0}%", index), MessageType.Info);
        //}

        //private void backgroundWorker4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    if ((bool)e.Result)
        //        warningBox1.ShowMessage("上传完成", MessageType.Info, 2000);
        //    else
        //        warningBox1.ShowMessage("上传失败", MessageType.Info, 2000, Color.Red);
        //}

        //private void tsbAddMoreData_Click(object sender, EventArgs e)
        //{
        //    FormDataInfoEx form = new FormDataInfoEx(BaseInfo.BaseInfoId, _employee.EmployeeName);
        //    if (form.ShowDialog() == DialogResult.OK)
        //    {
        //        backgroundWorker2.RunWorkerAsync(BaseInfo.BaseInfoId);
        //    }
        //}

        //#endregion

        //#region 文件下载

        //private void backgroundWorker5_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    try
        //    {
        //        object[] obj = e.Argument as object[];
        //        TDataInfoDTO dto = obj[0] as TDataInfoDTO;
        //        long totalSize = long.Parse(dto.FileSize);
        //        if (dto == null)
        //        {
        //            e.Result = null;
        //            return;
        //        }

        //        long total = 0;
        //        byte[] buffer = null;
        //        bool success = true;
        //        while (success)
        //        {
        //            using (FileStream stream = new FileStream(obj[1].ToString(), FileMode.Append))
        //            {
        //                success = _client.TDataInfoDownloadFile(out buffer, total, dto.MetaDataId);
        //                if (success == false)
        //                {
        //                    break;
        //                }
        //                total += buffer.Length;
        //                backgroundWorker5.ReportProgress((int)(total * 100 / totalSize));
        //                stream.Write(buffer, 0, buffer.Length);
        //            }
        //        }
        //        e.Result = dto;
        //    }
        //    catch (Exception)
        //    {
        //        e.Result = null;
        //    }
        //}

        //private void backgroundWorker5_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{
        //    int index = e.ProgressPercentage;
        //    warningBox1.ShowMessage(string.Format("当前下载百分比{0}%", index), MessageType.Info);
        //}

        //private void backgroundWorker5_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    TDataInfoDTO dto = (TDataInfoDTO)e.Result;
        //    if (dto != null)
        //    {
        //        //下载次数+1
        //        dto.DownloadTimes = dto.DownloadTimes.Value + 1;
        //        bool success = _client.TDataInfoUpdate(dto);
        //        if (success)
        //        {
        //            UpdateOtherDataRow(dto, dgvDataInfo.SelectedRows[0].Index);
        //            warningBox1.ShowMessage("下载完成", MessageType.Info, 2000);
        //        }             
        //    }
        //    else
        //        warningBox1.ShowMessage("下载失败", MessageType.Info, 2000, Color.Red);
        //}

        //#endregion
    }

    public class OparateEventArgs : EventArgs
    {
        public bool CanOparate { get; set; }

        public OparateEventArgs(bool canOparate)
        {
            CanOparate = canOparate;
        }
    }
}
