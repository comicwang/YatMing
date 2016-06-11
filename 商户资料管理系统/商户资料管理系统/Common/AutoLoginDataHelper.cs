using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace 商户资料管理系统.Common
{
    public class AutoLoginDataHelper
    {
        private static readonly string DataPath = @"Data/AutoLoginData.xml";
        public static string GetByKey(string key)
        {
            XDocument doc = XDocument.Load(DataPath);
            XElement xn = doc.Root;

            var personNodes = xn.Elements();//获取person子节点集合  
            foreach (XElement node in personNodes)
            {
                if (node.Attribute("id").Value.ToLower().Contains(key.ToLower()))
                    return node.Value;
            }
            return string.Empty;
        }
    }
}
