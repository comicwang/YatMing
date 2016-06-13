using System;
using System.Collections.Generic;
using iTelluro.Explorer.Domain.CodeFirst.Seedwork;

namespace iTelluro.Explorer.YatMing.Domain.Entities
{
    public class T_DetailInfo : Entity
    {
        private string _detailid;
        public string DetailId { get { return _detailid; } set { this.Id = value; this._detailid = value; } }  // DetailId (Primary key)

        public string BaseInfoId { get; set; } // BaseInfoId
        public string IntentionPackId { get; set; } // IntentionPackId
        public string DataId { get; set; } // DataId
        public string MerchantPriceId { get; set; } // MerchantPriceId
        public string MerchantReq { get; set; } // MerchantReq
        public byte[] MerchantReqP { get; set; } // MerchantReqP
        public string SubmitId { get; set; } // SubmitId
        public string ContractId { get; set; } // ContractId
        public virtual T_Contract TContract { get; set; } // FK_T_DetailInfo_T_Contract
        public virtual T_Package TPackage { get; set; } // FK_T_DetailInfo_T_Package
        public virtual T_Price TPrice { get; set; } // FK_T_DetailInfo_T_Price
        public virtual T_ShopData TShopData { get; set; } // FK_T_DetailInfo_T_ShopData
        public virtual T_Submit TSubmit { get; set; } // FK_T_DetailInfo_T_Submit

    }
}
