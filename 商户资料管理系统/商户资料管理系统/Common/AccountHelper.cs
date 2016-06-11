using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 商户资料管理系统
{
    public class AccountHelper
    {
        private static string _Path = Application.StartupPath + @"/Data/cc.dat";

        public static void WriteAccount(string account, string password)
        {
            StringBuilder builder = new StringBuilder();
            if (File.Exists(_Path) == false)
                using (File.Create(_Path))
                {
                }

            string[] result = File.ReadAllLines(_Path);
            bool exitAccount = false;
            foreach (string item in result)
            {
                string[] temp = item.Split(',');
                if (temp != null && temp.Length > 2)
                {
                    if (temp[0] == account)
                    {
                        exitAccount = true;
                        builder.AppendLine(account + "," + password);
                        continue;
                    }
                }
                builder.AppendLine(item);
            }
            if (exitAccount == false)
            {
                builder.AppendLine(account + "," + password);
            }
            File.WriteAllText(_Path, builder.ToString());
        }

        public static string ReadAccount()
        {
            if (File.Exists(_Path) == false)
            {
                return string.Empty;
            }
            string[] result = File.ReadAllLines(_Path);
            if (result != null && result.Length > 0)
            {
                return result[0];
            }
            return string.Empty;
        }
    }
}
