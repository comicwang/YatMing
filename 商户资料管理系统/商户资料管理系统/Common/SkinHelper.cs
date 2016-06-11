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
            _skin.SkinAllForm = true;
            _skin.SkinFile = Path.Combine(Application.StartupPath, "Data/Skins/Vista.ssk");
        }

        private static void btn_Click(object sender, EventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;
            _skin.SkinFile = Path.Combine(Application.StartupPath, "Data/Skins", item.Text + ".ssk");
            _btn.Text = item.Text;
        }
    }
}
