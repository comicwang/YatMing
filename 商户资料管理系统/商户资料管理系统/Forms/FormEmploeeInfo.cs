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
    public partial class FormEmploeeInfo : Form
    {
        public FormEmploeeInfo()
        {
            InitializeComponent();
        }

        public FormEmploeeInfo(TEmployeeDTO dto)
            : this()
        {
            lblAge.Text = dto.EmployeeAge.ToString();
            lblIdcard.Text = dto.IdCard;
            lblName.Text = dto.EmployeeName;
            lblSex.Text = dto.EmployeeSex;
            lblTel.Text = dto.EmployeePhone;
            lblEntra.Text = dto.EntryData.ToString();
            pictureStreamBox1.SetPicture(dto.EntryImage);
        }
    }
}
