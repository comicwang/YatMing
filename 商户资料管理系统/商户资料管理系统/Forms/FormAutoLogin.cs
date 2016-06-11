using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 商户资料管理系统.Common;
using 商户资料管理系统.YatServer;

namespace 商户资料管理系统
{
    public partial class FormAutoLogin : Form
    {
        private string _userKey = string.Empty;

        private string _pswKey = string.Empty;

        private string _loginKey = string.Empty;

        private TPlatformDTO _platformDTO = null;

        public FormAutoLogin(TPlatformDTO dto)
        {
            InitializeComponent();
            _platformDTO = dto;
            Text = dto.PlatformName;
            string result = AutoLoginDataHelper.GetByKey(dto.PlatformUri);
            if (string.IsNullOrEmpty(result) || result.Split(';').Length < 3)
            {
                MessageBox.Show("登录字典不存在！");
                this.Close();
            }
            string[] strs = result.Split(';');
            _userKey = strs[0];
            _pswKey = strs[1];
            _loginKey = strs[2];
            browserer.Navigate(dto.PlatformUri);
        }

        private HtmlElement GetKeyElement(string key)
        {
            HtmlElement element = browserer.Document.GetElementById(key);
            if (element == null)
            {
                HtmlElementCollection coll = browserer.Document.GetElementsByTagName("input");
                foreach (HtmlElement ele in coll)
                {
                    if (ele.OuterHtml.ToLower().Contains(key.ToLower().Trim()))
                        return ele;
                }
            }

            if (element == null)
            {
                HtmlElementCollection coll = browserer.Document.GetElementsByTagName("div");
                foreach (HtmlElement ele in coll)
                {
                    if (ele.OuterHtml.ToLower().Contains(key.ToLower().Trim()))
                        return ele;
                }
            }
            return element;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlElement element = GetKeyElement(_userKey);
            if (element == null)
                return;
            element.SetAttribute("value", _platformDTO.Account);         
            HtmlElement element1 = GetKeyElement(_pswKey);
            if (element1 == null)
                return;
            element1.SetAttribute("value", _platformDTO.Password);

            HtmlElement submit = GetKeyElement(_loginKey);
            if (submit == null)
                return;
            submit.InvokeMember("click");
        }
    }
}
