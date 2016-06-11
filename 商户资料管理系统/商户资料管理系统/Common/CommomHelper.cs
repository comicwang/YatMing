using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 商户资料管理系统.Common
{
    public class CommomHelper
    {
        public static string GuidGetter(object obj)
        {
            return obj == null ? Guid.NewGuid().ToString() : obj.ToString();
        }

        public static string NullGetter(object obj)
        {
            return obj == null ? null : obj.ToString();
        }

        public static int IntGetter(string obj)
        {
            int result=0;
            bool success= int.TryParse(obj, out result);
            return result;
        }

        public static float ParseFloat(double flo)
        {
            return (float)flo;
        }

        public static object ParseDateTime(DateTime? dt)
        {
            if (dt == null)
                return string.Empty;
            return dt.Value;
        }

        public static DateTime ParseDateTime(object obj)
        {
             DateTime result=DateTime.MinValue;
             if (obj != null)
             {
                 bool success = DateTime.TryParse(obj.ToString(), out result);
             }
             return result;
        }

        public static double ParseMB(string b)
        {
            double result=0;
            bool success = double.TryParse(b, out result);
            if (success)
                result = Math.Round(result / 1024 / 1024, 2);
            return result;
        }
    }
}
