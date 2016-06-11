using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using 商户资料管理系统.Common;
using 商户资料管理系统.YatServer;

namespace 商户资料管理系统
{
    public partial class FormRegist : Form
    {
        private YatMingServiceClient _client = ServiceProvider.Clent;
        public FormRegist()
        {
            InitializeComponent();
        }

        private string _account = string.Empty;

        public string Account
        {
            get { return _account; }
            set { _account = value; }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            bool result = _client.TLoginCheckAccountExits(e.Argument.ToString());
            e.Result = result;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((bool)e.Result)
            {
                lblAcountMessage.ForeColor = Color.Red;
                lblAcountMessage.Text = string.Format("账号{0}已经被注册", txtAccount.Text);               
            }
            else
            {
                lblAcountMessage.ForeColor = Color.Green;
                lblAcountMessage.Text = string.Format("恭喜你，账号{0}可以使用", txtAccount.Text);
            }
            txtAccount.Tag = e.Result;
        }

        private void FormRegist_Load(object sender, EventArgs e)
        {
            txtAccount.LostFocus += txtAccount_LostFocus;
            dmpAge.Items.AddRange(new List<int> { 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40 });
            dmpAge.SelectedIndex = 4;
            coboSex.SelectedIndex = 1;
            coboRole.SelectedIndex = 1;
        }

        void txtAccount_LostFocus(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy == false)
            {
                backgroundWorker1.RunWorkerAsync(txtAccount.Text);
            }
        }

        private bool ConfirmNull(out string message)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                message = "员工姓名不能为空！";
                return false;
            }
            else if (string.IsNullOrEmpty(txtTel.Text))
            {
                message = "手机号不能为空！";
                return false;
            }
            else if (string.IsNullOrEmpty(txtPsw.Text))
            {
                message = "密码不能为空！";
                return false;
            }
            else if (string.IsNullOrEmpty(txtConfirm.Text))
            {
                message = "确认密码不能为空！";
                return false;
            }
            else if (string.Equals(txtConfirm.Text, txtPsw.Text) == false)
            {
                message = "确认密码和密码不相符，请重新输入！";
                return false;
            }
            else if (txtTel.Text.Length != 11)
            {
                message = "请填写正确的手机号码！";
                return false;
            }
            message = "资料符合！";
            return true;
        }

        private void btnRegist_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            if (!ConfirmNull(out message))
            {
                labelWarning.Text = message;
                labelWarning.ForeColor = Color.Red;
                return;
            }

            if ((bool)txtAccount.Tag == false)
            {
                TEmployeeDTO emp = new TEmployeeDTO();
                emp.EmployeeId = Guid.NewGuid().ToString();
                emp.EmployeeName = txtName.Text;
                emp.EmployeePhone = txtTel.Text;
                emp.EmployeeSex = coboSex.Text;
                emp.EntryData = dateTimePicker1.Value;
                emp.IdCard = txtIdCard.Text.Replace("-", "");
                emp.EmployeeAge = int.Parse(dmpAge.Text);
                emp.EntryImage = pictureStreamBox1.GetPictureStream();
                bool result = _client.TEmployeeAdd(emp);

                TLoginDTO login = new TLoginDTO();
                login.EmployeeId = emp.EmployeeId;
                login.LoginId = Guid.NewGuid().ToString();
                login.LoginName = txtAccount.Text;
                login.LoginPsw = txtPsw.Text;
                login.Role = coboRole.Text;
                result &= _client.TLoginAdd(login);
                if (result)
                {
                    labelWarning.ForeColor = Color.Green;
                    labelWarning.Text = "注册成功！";
                    _account = login.LoginName + "," + login.LoginPsw;
                    Thread.Sleep(2000);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    labelWarning.Text = "注册失败！";
                    labelWarning.ForeColor = Color.Red;
                }
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
