using System;
using System.Collections.Generic;
using iTelluro.Explorer.Domain.CodeFirst.Seedwork;

namespace iTelluro.Explorer.YatMing.Domain.Entities
{
    public class T_Recorder : Entity
    {
        private string _recorderId;

        public string RecorderId
        {
            get { return _recorderId; }
            set { _recorderId = value; this.Id = value; }
        }

        public string Title { get; set; }

        public string MerchartId { get; set; }

        public DateTime PublishDate { get; set; }

        public string Url { get; set; }

        public virtual T_BaseInfo TBaseInfo { get; set; }
    }
}
