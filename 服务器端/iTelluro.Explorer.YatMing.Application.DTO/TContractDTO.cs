using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace iTelluro.Explorer.YatMing.Application.DTO
{
    [DataContract]
    public class TContractDTO
    {

        [DataMember]
        public string ContractId { get; set; }
        [DataMember]
        public DateTime? SignDate { get; set; }
        [DataMember]
        public DateTime? ExpireDate { get; set; }
        [DataMember]
        public byte[] ContractInfo { get; set; }
        [DataMember]
        public byte[] ContractP { get; set; }
        [DataMember]
        public byte[] ContractP1 { get; set; }
        [DataMember]
        public byte[] ContractP2 { get; set; }
        [DataMember]
        public byte[] ContractP3 { get; set; }
        [DataMember]
        public byte[] ContractP4 { get; set; }
        [DataMember]
        public string ContractPeople { get; set; }
    }
}
