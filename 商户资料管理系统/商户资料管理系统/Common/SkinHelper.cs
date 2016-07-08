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
       private static readonly  string section = "Skin";
       private static readonly string Id = "FormSkin";
       private static readonly string Open = "SkinOpen";
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
            //读取配置文件，是否打开皮肤
            bool isopen = true;
            if (SettingHelper.ValueExists(section, Open))
            {
                isopen = SettingHelper.ReadBool(section, Open, true);
            }
            else
            {
                SettingHelper.WriteBool(section, Open, isopen);
            }
            _skin.Active = isopen;
            _skin.SkinAllForm = false;
           
            string skinName = string.Empty;
            if (SettingHelper.ValueExists(section, Id))
            {
                skinName = SettingHelper.ReadString(section, Id, string.Empty);
                string skinFilePath = Path.Combine(Application.StartupPath, "Data/Skins", skinName + ".ssk");
                if (File.Exists(skinFilePath))
                    _skin.SkinFile = skinFilePath;
                else
                    MessageBox.Show("皮肤文件缺失,请选择其他皮肤");
            }
            else
            {
                skinName = "DeepCyan";
                SettingHelper.WriteString(section, Id, skinName);
                string skinFilePath = Path.Combine(Application.StartupPath, "Data/Skins", skinName + ".ssk");
                _skin.SkinFile = skinFilePath;
            }
            _btn.Text = skinName;
            SetSkinEnable(form, btn, isopen);
        }

        public static void SetSkinEnable(this FormMain form, ToolStripDropDownButton btn, bool enable)
        {
            _skin.Active = enable;
            btn.Enabled = enable;
            SettingHelper.WriteBool(section, Open, enable);
        }

        private static void btn_Click(object sender, EventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;
            _skin.SkinFile = Path.Combine(Application.StartupPath, "Data/Skins", item.Text + ".ssk");
            SettingHelper.WriteString(section, Id, item.Text);
            _btn.Text = item.Text;
        }
    }
}
