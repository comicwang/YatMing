using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace iTelluro.Explorer.YatMing.Application.DTO
{
    [DataContract]
    public class TShopDataDTO
    {

        [DataMember]
        public string DataId { get; set; }
        [DataMember]
        public string Brand { get; set; }
        [DataMember]
        public string MerchantName { get; set; }
        [DataMember]
        public string TelPhone { get; set; }
        [DataMember]
        public string PayeeMobile { get; set; }
        [DataMember]
        public int? BusinessHourS { get; set; }
        [DataMember]
        public int? BusinessHourE { get; set; }
        [DataMember]
        public int? CPP { get; set; }
        [DataMember]
        public bool? WIFI { get; set; }
        [DataMember]
        public string WifiAccount { get; set; }
        [DataMember]
        public string WifiPsw { get; set; }
        [DataMember]
        public string ActionInfo { get; set; }
        [DataMember]
        public string BusinessLicN { get; set; }
        [DataMember]
        public string BusinessName { get; set; }
        [DataMember]
        public string BusinessAdd { get; set; }
        [DataMember]
        public byte[] BusinessLicP { get; set; }
        [DataMember]
        public string OtherLicN { get; set; }
        [DataMember]
        public byte[] OtherLicP { get; set; }
        [DataMember]
        public string IdCardN { get; set; }
        [DataMember]
        public byte[] IdCardP1 { get; set; }
        [DataMember]
        public byte[] IdCardP2 { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string BankInfo { get; set; }
        [DataMember]
        public string BankNum { get; set; }
        [DataMember]
        public byte[] BankP { get; set; }
    }
}
