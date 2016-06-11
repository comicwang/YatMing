using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Update
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] arg)
        {
            if (arg == null || arg.Length == 0 || arg[0] != "true")
                return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormUpdate());
        }
    }
}
