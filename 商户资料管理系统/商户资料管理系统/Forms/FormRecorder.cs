using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 商户资料管理系统.YatServer;

namespace 商户资料管理系统
{
    public partial class FormRecorder : Form
    {
        public FormRecorder()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public TRecorderDTO Result
        {
            get
            {
                TRecorderDTO result = new TRecorderDTO();
                result.Url = txtUrl.Text;
                result.Title = txtTitle.Text;
                result.RecorderId = Guid.NewGuid().ToString();
                return result;
            }
            set
            {
                txtTitle.Text = value.Title;
                txtUrl.Text = value.Url;
            }
        }
    }
}
