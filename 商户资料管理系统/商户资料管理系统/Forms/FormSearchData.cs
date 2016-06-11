using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 商户资料管理系统.Properties;

namespace 商户资料管理系统
{
    public partial class FormSearchData : Form
    {
        private bool _more = false;

        public FormSearchData()
        {
            InitializeComponent();
        }

        [Category("行为"),Description("搜索关键字"),DefaultValue("")]
        public string Keyword
        {
            get { return txtKeyword.Text; }
            set { txtKeyword.Text = value; }
        }

        [Category("行为"), Description("是否在指定时间内搜索"), DefaultValue(false)]
        public bool LimitTime
        {
            get { return chbTime.Checked; }
            set { chbTime.Checked = value; }
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime
        {
            get { return dtpStart.Value; }
            set { dtpStart.Value = value; }
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime
        {
            get { return dtpEnd.Value; }
            set { dtpEnd.Value = value; }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void picMore_Click(object sender, EventArgs e)
        {
            picMore.Image = _more ? Resources.up : Resources.down;
            this.Height = _more ? 70 : 110;
            chbTime.Checked = !_more;
            _more = !_more;
        }
    }
}
