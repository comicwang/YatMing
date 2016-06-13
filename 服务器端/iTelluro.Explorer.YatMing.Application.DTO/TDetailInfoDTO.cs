using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace iTelluro.Explorer.YatMing.Application.DTO
{
    [DataContract]
    public class TDetailInfoDTO
    {

        [DataMember]
        public string DetailId { get; set; }
        [DataMember]
        public string BaseInfoId { get; set; }
        [DataMember]
        public string IntentionPackId { get; set; }
        [DataMember]
        public string DataId { get; set; }
        [DataMember]
        public string MerchantPriceId { get; set; }
        [DataMember]
        public string MerchantReq { get; set; }
        [DataMember]
        public byte[] MerchantReqP { get; set; }
        [DataMember]
        public string SubmitId { get; set; }
        [DataMember]
        public string ContractId { get; set; }
    }
}
