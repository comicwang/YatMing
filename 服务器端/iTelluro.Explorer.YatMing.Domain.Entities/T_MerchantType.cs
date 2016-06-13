using System;
using System.Collections.Generic;
using iTelluro.Explorer.Domain.CodeFirst.Seedwork;

namespace iTelluro.Explorer.YatMing.Domain.Entities
{
    public class T_MerchantType : Entity
    {
        private string _merchantid;
        public string MerchantId { get { return _merchantid; } set { this.Id = value; this._merchantid = value; } }  // MerchantId (Primary key)

        public string ParentId { get; set; } // ParentId
        public string MerchatType { get; set; } // MerchatType
        public string MerchantDes { get; set; } // MerchantDes
        public virtual ICollection<T_BaseInfo> TBaseInfoes { get; set; } // T_BaseInfo.FK_T_BaseInfo_T_MerchantType
        public T_MerchantType()
        {
            TBaseInfoes = new List<T_BaseInfo>();
        }

    }
}
