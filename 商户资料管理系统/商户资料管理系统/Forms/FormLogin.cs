using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LayeredSkin.Forms;
using 商户资料管理系统.Properties;
using 商户资料管理系统.Common;
using 商户资料管理系统.YatServer;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace 商户资料管理系统
{
    public partial class FormLogin : LayeredForm
    {
        private YatMingServiceClient _client = ServiceProvider.Clent;
        private Image Cloud = Resources.cloud;
        private float cloudX = 0;
        private Image yezi = null;
        private float angle = 10;
        private bool RotationDirection = true;//是否为顺时针
        private FormMain main = null;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void layeredButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void FormLogin_Load(object sender, EventArgs e)
        {
            yezi = new Bitmap(90, 80);//先把叶子画在稍微大一点的画布上，这样叶子旋转的时候才不会被裁掉一部分
            using (Graphics g = Graphics.FromImage(yezi))
            {
                g.DrawImage(Resources.yezi3, 10, 0);
            }
            timer1.Start();
            //读取账户信息
            string result = AccountHelper.ReadAccount();
            if (string.IsNullOrEmpty(result) == false)
            {
                string[] temp = result.Split(',');
                if (temp != null && temp.Length == 2)
                {
                    txtAccount.Text = temp[0];
                    txtPassword.Text = temp[1];
                }
            }
        }

        private void layeredButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMoveMouseDown(object sender, MouseEventArgs e)
        {
            LayeredSkin.NativeMethods.MouseToMoveControl(this.Handle);
        }

        protected override void OnLayeredPaint(LayeredSkin.LayeredEventArgs e)
        {
            Graphics g = e.Graphics;
            if (cloudX > this.Width - Cloud.Width)
            {//云的飘动
                cloudX = 0;
            }
            else
            {
                cloudX += 0.5f;
            }
            g.DrawImage(Cloud, cloudX, 0);//把云绘制上去

            if (angle > 10)
            {//控制旋转方向
                RotationDirection = false;
            }
            if (angle < -10)
            {
                RotationDirection = true;
            }
            if (RotationDirection)
            {
                angle += 1;
            }
            else
            {
                angle -= 1;
            }
            using (Image temp = LayeredSkin.ImageEffects.RotateImage(yezi, angle, new Point(25, 3)))
            {
                g.DrawImage(temp, 140, 70);//绘制叶子
            }
            base.OnLayeredPaint(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LayeredPaint();
            GC.Collect();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                layeredLabel5.Text = "";
                if (string.IsNullOrEmpty(txtAccount.Text))
                {
                    layeredLabel5.Text = "用户名不能为空！";
                    layeredLabel5.ForeColor = Color.Red;
                    txtAccount.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    layeredLabel5.Text = "密码不能为空！";
                    layeredLabel5.ForeColor = Color.Red;
                    txtPassword.Focus();
                    return;
                }
                TLoginDTO dto = null;
                string message = string.Empty;
                bool result = _client.TLoginCheckLogin(out message, out dto, txtAccount.Text, txtPassword.Text);
                layeredLabel5.Text = message;
                if (!result)
                {
                    layeredLabel5.ForeColor = Color.Red;
                    return;
                }
                //保存账号信息
                if (cbRemind.Checked)
                    AccountHelper.WriteAccount(txtAccount.Text, txtPassword.Text);
                //检查版本更新
                string version = Application.ProductVersion.ToString();
                bool update = _client.TLoginCheckUpdate(version);
                if (update)
                {
                    DialogResult dialogResult = MessageBox.Show("系统存在更新,是否现在升级？", "升级提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(Path.Combine(Application.StartupPath, "Update.exe"), "true");
                        Application.Exit();
                    }
                }

                layeredLabel5.ForeColor = Color.Green;
                if (main == null)
                {
                    main = new FormMain(this);
                    this.Tag = dto;
                }
                main.Show();
                this.Hide();
            }
            catch (Exception)
            {
                layeredLabel5.ForeColor = Color.Red;
                layeredLabel5.Text = "远程服务器连接失败";
            }

        }

        private void btnRegist_Click(object sender, EventArgs e)
        {
            FormRegist form = new FormRegist();
            if (DialogResult.OK == form.ShowDialog())
            {
                string[] result = form.Account.Split(',');
                txtAccount.Text = result[0];
                txtPassword.Text = result[1];
            }
        }

        private void FormLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnLogin_Click(null, EventArgs.Empty);
            }
        }

    }
}
