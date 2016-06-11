using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace 商户资料管理系统
{
    public partial class FormPromotionDetail : Form
    {
        public FormPromotionDetail()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Pen p = new Pen(Color.LightSeaGreen, 10);
            p.StartCap = LineCap.Round;
            p.EndCap = LineCap.ArrowAnchor;
            g.DrawLine(p, 0, 40, 100, 40);
            p.Dispose();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(500);
                Label label1 = new Label();
                label1.BackColor = System.Drawing.Color.LightSeaGreen;
                label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                label1.Font = new System.Drawing.Font("宋体", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                label1.ForeColor = System.Drawing.Color.White;
                label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                label1.ImageIndex = 0;
                label1.ImageList = this.imageList1;
                label1.Size = new System.Drawing.Size(100, 85);
                label1.Text = "首次会面";
                label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                //内容
                string demo = string.Format("我的内容{0},我的内容{0},我的内容{0}", i);

                backgroundWorker1.ReportProgress(0, new object[] { label1, demo });

                Thread.Sleep(500);
                Panel panel1 = new Panel();
                panel1.Size = new Size(150, 85);
                panel1.Paint += panel1_Paint;
                backgroundWorker1.ReportProgress(0, new object[] { panel1 });
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            object[] tempArr = e.UserState as object[];
            object temp = tempArr[0]; ;
            if (tempArr.Length > 1)
            {               
                string[] contents = tempArr[1].ToString().Split(',');
                textBox1.AppendText(contents[0] + "\r\n");
                textBox2.AppendText(contents[1] + "\r\n");
                textBox3.AppendText(contents[2] + "\r\n");
            }
            if (temp.GetType() == typeof(Label))
            {
                Label lbl = temp as Label;
                flowLayoutPanel1.Controls.Add(lbl);
            }
            else if (temp.GetType() == typeof(Panel))
            {
                Panel pnl = temp as Panel;
                flowLayoutPanel1.Controls.Add(pnl);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void FormPromotionDetail_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
    }
}
