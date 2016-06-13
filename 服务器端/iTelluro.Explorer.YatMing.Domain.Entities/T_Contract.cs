using System;
using System.Collections.Generic;
using iTelluro.Explorer.Domain.CodeFirst.Seedwork;

namespace iTelluro.Explorer.YatMing.Domain.Entities
{
    public class T_Contract : Entity
    {
        private string _contractid;
        public string ContractId { get { return _contractid; } set { this.Id = value; this._contractid = value; } }  // ContractId (Primary key)

        public DateTime? SignDate { get; set; } // SignDate
        public DateTime? ExpireDate { get; set; } // ExpireDate
        public byte[] ContractInfo { get; set; } // ContractInfo
        public byte[] ContractP { get; set; } // ContractP
        public byte[] ContractP1 { get; set; } // ContractP1
        public byte[] ContractP2 { get; set; } // ContractP2
        public byte[] ContractP3 { get; set; } // ContractP3
        public byte[] ContractP4 { get; set; } // ContractP4
        public string ContractPeople { get; set; } // ContractPeople
        public virtual ICollection<T_DetailInfo> TDetailInfoes { get; set; } // T_DetailInfo.FK_T_DetailInfo_T_Contract
        public T_Contract()
        {
            TDetailInfoes = new List<T_DetailInfo>();
        }

    }
}
