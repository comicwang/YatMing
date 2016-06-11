using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 商户资料管理系统.Common;
using 商户资料管理系统.YatServer;

namespace 商户资料管理系统
{
    public partial class FormMerchantType : Form
    {

        private YatMingServiceClient _client = ServiceProvider.Clent;

        public FormMerchantType()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //初始化商户树节点
            TreeNode root = TreeNodeHelper.InitializeTree("");
            e.Result = root;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TreeNode result = e.Result as TreeNode;
            treeView1.Nodes.Clear();
            foreach (TreeNode item in result.Nodes)
            {
                treeView1.Nodes.Add(item);
            }
            label4.Visible = false;
        }

        private void FormMerchantType_Load(object sender, EventArgs e)
        {
            label1.Visible = true;
            InitializeCombox();
            backgroundWorker1.RunWorkerAsync();
        }

        private void InitializeCombox()
        {
            TMerchantTypeDTO[] result = _client.TMerchantTypeQueryAll().Where(t => string.IsNullOrWhiteSpace(t.ParentId)).ToArray();
            List<TMerchantTypeDTO> source = new List<TMerchantTypeDTO>();
            source.Add(new TMerchantTypeDTO() { MerchatType = "请选择" });
            source.AddRange(result);
            comboBox1.DataSource = source;
            comboBox1.DisplayMember = "MerchatType";
            comboBox1.ValueMember = "MerchantId";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<TMerchantTypeDTO> source = new List<TMerchantTypeDTO>();
            source.Add(new TMerchantTypeDTO() { MerchatType = "未知类型" });

            TMerchantTypeDTO dto = comboBox1.SelectedItem as TMerchantTypeDTO;
            if (dto != null)
            {
                string pid = dto.MerchantId;
                TMerchantTypeDTO[] result = _client.TMerchantTypeGetByPid(pid);
                source.AddRange(result);
            }
            comboBox2.DataSource = source;
            comboBox2.DisplayMember = "MerchatType";
            comboBox2.ValueMember = "MerchantId";
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            if (node.Level == 0)
                comboBox1.SelectedValue = node.Name;
            else if (node.Level == 1)
            {
                TreeNode pnode = e.Node.Parent;
                comboBox1.SelectedValue = pnode.Name;
                comboBox2.SelectedValue = node.Name;
            }
        }

        private void 新增AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            if (node == null)
            {
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
            }
            //父节点
            else if (node.Level == 0)
            {
                comboBox1.SelectedValue = node.Name;
            }
            else
            {
                comboBox1.SelectedValue = node.Parent.Name;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TMerchantTypeDTO sDto = comboBox2.SelectedItem as TMerchantTypeDTO;
            if (string.IsNullOrEmpty(sDto.MerchantId) == false)
            {
                bool result = _client.TMerchantTypeDelete(sDto.MerchantId);
                if (result)
                {
                    //更新
                    backgroundWorker1.RunWorkerAsync();
                    MessageBox.Show("删除成功！");
                }
            }
            else
            {
                TMerchantTypeDTO dto = comboBox1.SelectedItem as TMerchantTypeDTO;
                if (string.IsNullOrEmpty(dto.MerchantId) == false)
                {
                    //删除所有节点
                    TMerchantTypeDTO[] result = _client.TMerchantTypeGetByPid(dto.MerchantId);
                    foreach (var item in result)
                    {
                        _client.TMerchantTypeDelete(item.MerchantId);
                    }
                    bool result1 = _client.TMerchantTypeDelete(dto.MerchantId);
                    if (result1)
                    {
                        //更新
                        backgroundWorker1.RunWorkerAsync();
                        InitializeCombox();
                        MessageBox.Show("删除成功！");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool result = true;
            TMerchantTypeDTO sDto = comboBox2.SelectedItem as TMerchantTypeDTO;
            //新增
            if (sDto == null)
            {
                string pid = string.Empty;
                TMerchantTypeDTO dto = comboBox1.SelectedItem as TMerchantTypeDTO;
                if (dto != null && string.IsNullOrEmpty(dto.MerchantId) == false)
                {
                    pid = dto.MerchantId;
                }
                sDto = new TMerchantTypeDTO()
                {
                    MerchantId = Guid.NewGuid().ToString(),
                    MerchatType = comboBox2.Text,
                    MerchantDes = textBox1.Text,
                    ParentId = pid
                };
                result = _client.TMerchantTypeAdd(sDto);
            }
            else
            {
                result = _client.TMerchantTypeUpdate(sDto);
            }
            if (result)
            {
                //更新
                backgroundWorker1.RunWorkerAsync();
                InitializeCombox();
                MessageBox.Show("保存成功！");
            }
        }
    }
}
