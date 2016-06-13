using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace iTelluro.Explorer.YatMing.Application.DTO
{
    [DataContract]
    public class TPriceDTO
    {

        [DataMember]
        public string MerchantPriceId { get; set; }
        [DataMember]
        public string PackageId { get; set; }
        [DataMember]
        public int? ExtraPrice { get; set; }
        [DataMember]
        public string ExtraDes { get; set; }
        [DataMember]
        public int? ServerPrice { get; set; }
        [DataMember]
        public string ServerDes { get; set; }
        [DataMember]
        public string HardwareId { get; set; }
    }
}
