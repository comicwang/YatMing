using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 商户资料管理系统
{
    public class RegistryHelper
    {
        #region 设置开机是否启动

        public static void AutoRunWhenStrat(bool Started)
        {
            string path = Application.ExecutablePath;
            string name = path.Substring(path.LastIndexOf(@"\") + 1);
            try
            {
                RegistryKey regedit = Registry.LocalMachine;
                RegistryKey Run = regedit.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                if (Started)
                {
                    try
                    {
                        //添加该启动项
                        Run.SetValue(name, path);
                        regedit.Close();
                    }
                    catch
                    { }

                }
                else
                {
                    Run.DeleteValue(name);
                    //或者设为空即删除该启动项
                    // Run.SetValue(name, "");
                }
            }
            catch
            {

            }
        }

        #endregion
    }
}
