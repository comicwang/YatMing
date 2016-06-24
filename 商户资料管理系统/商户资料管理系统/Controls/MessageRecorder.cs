using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using 商户资料管理系统.YatServer;
using 商户资料管理系统.Common;

namespace 商户资料管理系统
{
    public partial class MessageRecorder : UserControl
    {
        private static YatMingServiceClient _client = ServiceProvider.Clent;
        private string _merchartId = string.Empty;
        private Dictionary<DateTime, TRecorderDTO> _dicAll = new Dictionary<DateTime, TRecorderDTO>();
       
        public MessageRecorder()
        {
            InitializeComponent();
        }

        public void InitializeRecorder(string id)
        {
            _merchartId = id;
            TRecorderDTO[] result = _client.TRecorderGetByForignKey(id);
            List<DateTime> dts = new List<DateTime>();
            _dicAll.Clear();
            Array.ForEach(result, t => { dts.Add(t.PublishDate); _dicAll.Add(t.PublishDate, t); });
            mcMain.BoldedDates = dts.ToArray();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            DrawDataInfo(e.Start);
            if (mcMain.BoldedDates.Contains(e.Start))
            {
                TRecorderDTO dto = _dicAll[e.Start];
                lblTitle.Text = dto.Title;
                webBrowser1.Navigate(dto.Url);
            }
        }

        private void DrawDataInfo(DateTime dtInfo)
        {
            ChineseCalendar cc = new ChineseCalendar(dtInfo);
            string dateString = cc.DateString; //阳历
            string chineseDateString = cc.ChineseDateString; //农历
            string dateHoliday = cc.DateHoliday; //阳历节日
            string chineseTwentyFourDay = cc.ChineseTwentyFourDay; //农历节日
            string constellation = cc.Constellation; //星座
            string weekDayString = cc.WeekDayStr; //星期
            string ganZhiDateString = cc.GanZhiDateString;
            string animalString = cc.AnimalString;
            string chineseConstellation = cc.ChineseConstellation;

            if (panelDateInfo != null)
            {
                Graphics g = panelDateInfo.CreateGraphics();
                g.Clear(panelDateInfo.BackColor);
                if (dateString != null)
                    g.DrawString(dateString + " " + weekDayString, new Font("", 9), new SolidBrush(Color.Gray), 7, 10);
                g.DrawString(dtInfo.Day.ToString(CultureInfo.InvariantCulture), new Font("", 45, FontStyle.Bold),

                             new SolidBrush(Color.Gainsboro), 50, 30);
                var family = new FontFamily("宋体");
                g.DrawString(chineseDateString.Substring(7, chineseDateString.Length - 7), new Font(family, 10),

                             new SolidBrush(Color.Goldenrod), 50, 100);
                g.DrawString(ganZhiDateString.Substring(0, 3) + " 【" + animalString + "年】", new Font(family, 10),

                             new SolidBrush(Color.Goldenrod), 30, 120);

                g.DrawString(ganZhiDateString.Substring(3, ganZhiDateString.Length - 3), new Font(family, 10),

                             new SolidBrush(Color.Goldenrod), 40, 140);

                g.DrawString(constellation + "   " + chineseConstellation, new Font(family, 10),

                             new SolidBrush(Color.Goldenrod), 30, 160);
                g.DrawString(chineseTwentyFourDay, new Font(family, 10), new SolidBrush(Color.Goldenrod), 40, 200);

            }

        }

        private void tsmAdd_Click(object sender, EventArgs e)
        {
            FormRecorder form = new FormRecorder();
            if (form.ShowDialog() == DialogResult.OK)
            {
                TRecorderDTO dto = form.Result;
                dto.PublishDate = mcMain.SelectionStart;
                dto.MerchartId = _merchartId;
                bool success = _client.TRecorderAdd(dto);
                if (success)
                {
                    InitializeRecorder(_merchartId);
                }
            }
        }

        private void tsmRefreash_Click(object sender, EventArgs e)
        {
            InitializeRecorder(_merchartId);
        }
    }
}
