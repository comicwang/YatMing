using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace iTelluro.Explorer.YatMing.Application.DTO
{
    [DataContract]
    public class TPromotionDTO
    {

        [DataMember]
        public string PromotionId { get; set; }
        [DataMember]
        public string PainSpot { get; set; }
        [DataMember]
        public string Question { get; set; }
        [DataMember]
        public int? PromotionTimes { get; set; }
        [DataMember]
        public DateTime? PromotionTime { get; set; }
        [DataMember]
        public string Solution { get; set; }
        [DataMember]
        public DateTime? NextTime { get; set; }
        [DataMember]
        public string MerchantId { get; set; }
    }
}
