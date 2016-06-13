using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace iTelluro.Explorer.YatMing.Application.DTO
{
    [DataContract]
    public class TServerDTO
    {

        [DataMember]
        public string ServerId { get; set; }
        [DataMember]
        public string ServerContent { get; set; }
        [DataMember]
        public DateTime? ServerDate { get; set; }
        [DataMember]
        public string MerchantId { get; set; }
        [DataMember]
        public int? ServerPrice { get; set; }
        [DataMember]
        public string ServerNote { get; set; }
    }
}
