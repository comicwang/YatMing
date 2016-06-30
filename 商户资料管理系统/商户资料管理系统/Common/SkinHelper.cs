using Sunisoft.IrisSkin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace 商户资料管理系统
{
    public static class SkinHelper
    {
        private static string _Path = "Skin.ini";
        private static SkinEngine _skin = null;
        private static ToolStripDropDownButton _btn = null;
        public static void BindSkin(this FormMain form, ToolStripDropDownButton btn)
        {
            //初始化所有皮肤
            string[] skinFiles = Directory.GetFiles(Path.Combine(Application.StartupPath, "Data/Skins"));
            Array.ForEach(skinFiles, s =>
            {
                btn.DropDownItems.Add(Path.GetFileNameWithoutExtension(s), null, btn_Click);
            });
            _btn = btn;
            _skin = new Sunisoft.IrisSkin.SkinEngine();
            _skin.AddForm(form);
            _skin.Active = true;
            _skin.SkinAllForm = true;
            string configPath = Path.Combine(Application.StartupPath, "Data", _Path);
            string skinName = string.Empty;
            if (File.Exists(configPath))
            {
                skinName = File.ReadAllText(configPath);
                if (string.IsNullOrEmpty(skinName))
                {
                    skinName = "DeepCyan";
                    File.WriteAllText(Path.Combine(Application.StartupPath, "Data", _Path), skinName);
                }
                string skinFilePath = Path.Combine(Application.StartupPath, "Data/Skins", skinName + ".ssk");
                if (File.Exists(skinFilePath))
                    _skin.SkinFile = skinFilePath;
                else
                    MessageBox.Show("皮肤文件缺失,请选择其他皮肤");
            }
            else
            {
                skinName = "DeepCyan";
                string skinFilePath = Path.Combine(Application.StartupPath, "Data/Skins", skinName + ".ssk");
                _skin.SkinFile = skinFilePath;
                File.WriteAllText(Path.Combine(Application.StartupPath, "Data", _Path), skinName);
            }
            _btn.Text = skinName;
        }

        public static void SetSkinEnable(this FormMain form, ToolStripDropDownButton btn,bool enable)
        {
            _skin.Active = enable;
            btn.Enabled = enable;
          //  _skin.Dispose();          
        }

        private static void btn_Click(object sender, EventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;
            _skin.SkinFile = Path.Combine(Application.StartupPath, "Data/Skins", item.Text + ".ssk");
            File.WriteAllText(Path.Combine(Application.StartupPath, "Data", _Path), item.Text);
            _btn.Text = item.Text;
        }
    }
}
