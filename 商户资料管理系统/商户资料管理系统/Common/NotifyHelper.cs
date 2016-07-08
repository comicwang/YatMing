using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 商户资料管理系统.Properties;

namespace 商户资料管理系统
{
    public static class NotifyHelper
    {
        private static Form _form = null;
        private static NotifyIcon _notify = null;
        private static bool _blink = false;
        private static bool _recivedMessage = false;
        private static bool _autoRun = false;
        private static Timer _timer = null;
        private static readonly string section = "Setting";
        private static readonly string autoRun = "AutoRun";


        public static void BindNotify(this Form form, Timer timer)
        {
            //设置图标闪烁
            _timer = timer;
            _timer.Tick += timer_Tick;

            _form = form;
            FormMain main = _form as FormMain;
            if (main != null)
            {
                main.OnCanBlinkChanged += main_OnCanBlinkChanged;
            }
            _notify = new NotifyIcon();
            _notify.Icon = Resources.main;
            _notify.Text = "商户管理平台\r\n当前版本：" + Application.ProductVersion;
            _notify.MouseDoubleClick += notify_MouseDoubleClick;
            _notify.MouseClick += notify_MouseClick;
            ContextMenu menu = new ContextMenu();

            MenuItem itemStart = new MenuItem();
            bool isAutoRun = true;
            if (SettingHelper.ValueExists(section, autoRun))
            {
                isAutoRun = SettingHelper.ReadBool(section, autoRun, true);
            }
            else
            {
                SettingHelper.WriteBool(section, autoRun, isAutoRun);
            }
            itemStart.Text = isAutoRun ? "取消开机启动" : "设置开机启动";
            itemStart.Click += itemStart_Click;

            MenuItem itemShow = new MenuItem();
            itemShow.Text = "显示商户平台";
            itemShow.Click += itemShow_Click;

            MenuItem itemExit = new MenuItem();
            itemExit.Text = "退出平台";
            itemExit.Click += itemExit_Click;
            menu.MenuItems.AddRange(new MenuItem[] { itemStart, itemShow, itemExit });
            _notify.ContextMenu = menu;
            _notify.Visible = true;
        }

        private static void itemStart_Click(object sender, EventArgs e)
        {
            _autoRun = !_autoRun;
             RegistryHelper.AutoRunWhenStrat(_autoRun);
             MenuItem item = sender as MenuItem;
             item.Text = _autoRun ? "取消开机启动" : "设置开机启动";
        }

        private static void main_OnCanBlinkChanged(object sender, OparateEventArgs e)
        {
            if (e.CanOparate)
            {
                _recivedMessage = true;
                _notify.ShowBalloonTip(3000, "更新提醒", "系统出现了新版本", ToolTipIcon.Info);
                _timer.Start();
            }
        }

        private static void timer_Tick(object sender, EventArgs e)
        {
            if (!_blink)
            {
                _notify.Icon = Resources.main;
            }
            else
            {
                _notify.Icon = Resources.blank;
            }
            _blink = !_blink;  
        }



        #region notify

        private static void itemShow_Click(object sender, EventArgs e)
        {
            _form.Show();
            _form.WindowState = FormWindowState.Maximized;
            _form.Activate();//获得焦点
        }

        private static void itemExit_Click(object sender, EventArgs e)
        {
            _notify.Visible = false;
            //关闭主线程
            FormMain form = _form as FormMain;
            if (form != null)
            {
                form.LoginForm.Close();
                try
                {
                    form.ExitChat();
                    if (form._notifyForm != null && form._notifyForm._pushProxy != null)
                        form._notifyForm._pushProxy.UnRegist(form._employee.EmployeeName);                
                }
                catch { }
            }
            Application.Exit();
        }

        #endregion

        private static void notify_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MouseEventArgs arg = e as MouseEventArgs;
            if (arg.Button == System.Windows.Forms.MouseButtons.Left)
                itemShow_Click(null, null);
        }

        private static void notify_MouseClick(object sender, EventArgs e)
        {
            MouseEventArgs arg = e as MouseEventArgs;
            if (arg.Button == System.Windows.Forms.MouseButtons.Left)
            {
                _timer.Stop();
                _notify.Icon = Resources.main;
                //如果有更新,点击开始更新
                if (_recivedMessage)
                {
                    if (MessageBox.Show("是否开始更新？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(Path.Combine(Application.StartupPath, "Update.exe"), "true");
                        //关闭主线程
                        FormMain form = _form as FormMain;
                        if (form != null)
                            form.LoginForm.Close();
                        Application.Exit();
                    }
                    else
                    {
                        _recivedMessage = false;
                    }
                }
                else
                {
                    itemShow_Click(null, null);
                }
            }
        }
    }
}
