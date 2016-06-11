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
    public partial class FormPlatform : Form
    {
        public FormPlatform()
        {
            InitializeComponent();
        }

        public TPlatformDTO PlatformDTO
        {
            get
            {
                TPlatformDTO result = new TPlatformDTO();
                result.PlatformId = CommomHelper.GuidGetter(txtName.Tag);
                result.PlatformName = txtName.Text;
                result.Password = txtPassword.Text;
                result.Account = txtAccount.Text;
                result.PlatformUri = txtUri.Text;
                result.MerchantId = this.Tag.ToString();
                return result;
            }
            set
            {
                if (value == null)
                    return;
                txtName.Tag = value.PlatformId;
                txtName.Text = value.PlatformName;
                txtPassword.Text = value.Password;
                txtAccount.Text = value.Account;
                txtUri.Text = value.PlatformUri;
                Tag = value.MerchantId;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
