using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Xml;

namespace 商户资料管理系统
{
    public partial class MapControl : UserControl
    {
        private static readonly PointF BasePoint = new PointF((float)113.834906, (float)30.652194);

        public MapControl()
        {
            InitializeComponent();
        }

        private PointF _mapPoint = BasePoint;

        public void Clear()
        {
            txtLon.Clear();
            txtLat.Clear();
        }

        public void SetEnable(bool enable)
        {
            txtLat.ReadOnly = !enable;
            txtLon.ReadOnly = !enable;
            //btnReset.Enabled = enable;         
        }

        [Category("数据"),Description("获取或者设置地图控件的坐标")]
        public PointF MapPoint
        {
            get
            {
                return _mapPoint;
            }

            set
            {
                _mapPoint = value;
                txtLon.Text = value.X.ToString();
                txtLat.Text = value.Y.ToString();
                //btnFly_Click(btnFly, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 飞行方法
        /// </summary>
        /// <param name="point">飞行到的经纬坐标</param>
        public void FlyTo(PointF point)
        {
            MapPoint = point;
            FlyTo();
        }

        /// <summary>
        /// 飞行到当前设置坐标
        /// </summary>
        public void FlyTo()
        {
            btnFly_Click(btnFly, EventArgs.Empty);
        }

        /// <summary>
        /// 初始化地图
        /// </summary>
        public void InitializeMap()
        {
            try
            {
                //这个文件于可执行文件放在同一目录
                webBrowser1.Url = new Uri(Path.Combine(Application.StartupPath,"Data", "GoogleMap.html"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlElement btn = webBrowser1.Document.GetElementById("allmap");
            if (btn == null)
            {
                MessageBox.Show("缺少地图文件,请联系管理员！", "重要漏洞", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            btn.Click += btn_Click;
        }

        private void btn_Click(object sender, HtmlElementEventArgs e)
        {
            var result = webBrowser1.Document.InvokeScript("getClickPoint");
            string point = result.ToString();
            if (string.IsNullOrEmpty(point))
                return;
            string[] points = point.Split(',');
            if (points == null || points.Length < 2)
                return ;
            float lon = 0;
            float lat = 0;
            if (!float.TryParse(points[0], out lon) || !float.TryParse(points[1], out lat))
                return ;
            MapPoint = new PointF(lon, lat);
        }

        private void btnFly_Click(object sender, EventArgs e)
        {
            float lon = 0;
            float lat = 0;
            if (float.TryParse(txtLon.Text, out lon) && float.TryParse(txtLat.Text, out lat))
            {
                webBrowser1.Document.InvokeScript("setLocation", new object[] { lon, lat });
                MapPoint = new PointF(lon, lat);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            FlyTo(BasePoint);
        }

        private void searchTextBox1_OnSearch(object sender, SearchEventArgs e)
        {
            webBrowser1.Document.InvokeScript("localSearch", new object[] { e.SearchText });
        }
    }
}
