using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace iTelluro.Explorer.YatMing.Application.DTO
{
    [DataContract]
    public class TRecorderDTO
    {
        [DataMember]
        public string RecorderId { get; set; }
         [DataMember]
        public string Title { get; set; }
         [DataMember]
        public string MerchartId { get; set; }
         [DataMember]
        public DateTime PublishDate { get; set; }
         [DataMember]
        public string Url { get; set; }
    }
}
