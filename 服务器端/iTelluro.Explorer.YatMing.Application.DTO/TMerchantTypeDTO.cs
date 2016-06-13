using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace iTelluro.Explorer.YatMing.Application.DTO
{
    [DataContract]
    public class TMerchantTypeDTO
    {

        [DataMember]
        public string MerchantId { get; set; }
        [DataMember]
        public string ParentId { get; set; }
        [DataMember]
        public string MerchatType { get; set; }
        [DataMember]
        public string MerchantDes { get; set; }
    }
}
