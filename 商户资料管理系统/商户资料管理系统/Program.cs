using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace 商户资料管理系统
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();                       //样式设置
            Application.SetCompatibleTextRenderingDefault(false); 
            Application.Run(new FormLogin());
        }
    }

}
