using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace iTelluro.Explorer.YatMing.Application.DTO
{
    [DataContract]
    public class TBaseInfoDTO
    {

        [DataMember]
        public string BaseInfoId { get; set; }
        [DataMember]
        public string MerchantName { get; set; }
        [DataMember]
        public string MerchantBoss { get; set; }
        [DataMember]
        public string MerchantSex { get; set; }
        [DataMember]
        public string MerchantTel { get; set; }
        [DataMember]
        public string MerchantAdd { get; set; }
        [DataMember]
        public string MerchantId { get; set; }
        [DataMember]
        public string Feedback { get; set; }
        [DataMember]
        public double Lon { get; set; }
        [DataMember]
        public double Lat { get; set; }
         [DataMember]
        public byte[] Logo { get; set; }
    }
}
