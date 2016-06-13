using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace iTelluro.Explorer.YatMing.Application.DTO
{
    [DataContract]
    public class TPlatformDTO
    {

        [DataMember]
        public string PlatformId { get; set; }
        [DataMember]
        public string PlatformName { get; set; }
        [DataMember]
        public string Account { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string MerchantId { get; set; }
        [DataMember]
        public string PlatformUri { get; set; }
    }
}
