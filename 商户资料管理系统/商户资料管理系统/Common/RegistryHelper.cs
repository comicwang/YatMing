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

        private static readonly string section = "Setting";
        private static readonly string autoRun = "AutoRun";

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
                SettingHelper.WriteBool(section, autoRun, Started);
            }
            catch
            {

            }
        }

        #endregion

        private static readonly string ieEmulation = "IeEmulation";

        private static readonly string isSetEmulation = "IsOpenEnulation";

        public static void SetWebbrowserEmulation(int ie,bool set)
        {
            string path = Application.ExecutablePath;
            string name = path.Substring(path.LastIndexOf(@"\") + 1);
            try
            {
                RegistryKey regedit = Registry.LocalMachine;
                RegistryKey Run = regedit.CreateSubKey("Software\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION");
                if (set)
                {
                    Run.SetValue(name, ie);
                    regedit.Close();
                }
                else
                {
                    Run.DeleteValue(name);
                }
                SettingHelper.WriteBool(section, isSetEmulation, set);
                SettingHelper.WriteInteger(section, ieEmulation, ie);
            }
            catch
            {

            }
        }

        public static void InitilizeWebbrowser()
        {
            //读取配置文件，是否打开IE内核设置
            bool isopen = true;
            if (SettingHelper.ValueExists(section, isSetEmulation))
            {
                isopen = SettingHelper.ReadBool(section, isSetEmulation, true);
            }
            else
            {
                SettingHelper.WriteBool(section, isSetEmulation, isopen);
            }

            int ie = 9999;
            if (SettingHelper.ValueExists(section, ieEmulation))
            {
                ie = SettingHelper.ReadInteger(section, ieEmulation, 0);
            }
            else
            {
                SettingHelper.WriteInteger(section, ieEmulation, ie);
            }

            if (isopen)
            {
                SetWebbrowserEmulation(ie, isopen);
            }
        }

        #region 新增系统文件右键菜单

        public static void AddFileContextMenuItem(string itemName, string associatedProgramFullPath)
        {
            //创建项：shell 
            RegistryKey shellKey = Registry.ClassesRoot.OpenSubKey(@"*\shell", true);
            if (shellKey == null)
            {
                shellKey = Registry.ClassesRoot.CreateSubKey(@"*\shell");
            }

            //创建项：右键显示的菜单名称
            RegistryKey rightCommondKey = shellKey.CreateSubKey(itemName);
            RegistryKey associatedProgramKey = rightCommondKey.CreateSubKey("command");

            //创建默认值：关联的程序
            associatedProgramKey.SetValue(string.Empty, associatedProgramFullPath);

            //刷新到磁盘并释放资源
            associatedProgramKey.Close();
            rightCommondKey.Close();
            shellKey.Close();
        }

        #endregion

        #region 新增文件夹右键菜单

        public static void AddDirectoryContextMenuItem(string itemName, string associatedProgramFullPath)
        {
            //创建项：shell 
            RegistryKey shellKey = Registry.ClassesRoot.OpenSubKey(@"directory\shell", true);
            if (shellKey == null)
            {
                shellKey = Registry.ClassesRoot.CreateSubKey(@"*\shell");
            }

            //创建项：右键显示的菜单名称
            RegistryKey rightCommondKey = shellKey.CreateSubKey(itemName);
            RegistryKey associatedProgramKey = rightCommondKey.CreateSubKey("command");

            //创建默认值：关联的程序
            associatedProgramKey.SetValue("", associatedProgramFullPath);


            //刷新到磁盘并释放资源
            associatedProgramKey.Close();
            rightCommondKey.Close();
            shellKey.Close();
        }

        #endregion

    }
}
