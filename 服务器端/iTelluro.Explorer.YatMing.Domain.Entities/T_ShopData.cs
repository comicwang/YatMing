using System;
using System.Collections.Generic;
using iTelluro.Explorer.Domain.CodeFirst.Seedwork;

namespace iTelluro.Explorer.YatMing.Domain.Entities
{
    public class T_ShopData : Entity
    {
        private string _dataid;
        public string DataId { get { return _dataid; } set { this.Id = value; this._dataid = value; } }  // DataId (Primary key)

        public string Brand { get; set; } // Brand
        public string MerchantName { get; set; } // MerchantName
        public string TelPhone { get; set; } // TelPhone
        public string PayeeMobile { get; set; } // PayeeMobile
        public int? BusinessHourS { get; set; } // BusinessHourS
        public int? BusinessHourE { get; set; } // BusinessHourE
        public int? CPP { get; set; } // CPP
        public bool? WIFI { get; set; } // WIFI
        public string WifiAccount { get; set; } // WifiAccount
        public string WifiPsw { get; set; } // WifiPsw
        public string ActionInfo { get; set; } // ActionInfo
        public string BusinessLicN { get; set; } // BusinessLicN
        public string BusinessName { get; set; } // BusinessName
        public string BusinessAdd { get; set; } // BusinessAdd
        public byte[] BusinessLicP { get; set; } // BusinessLicP
        public string OtherLicN { get; set; } // OtherLicN
        public byte[] OtherLicP { get; set; } // OtherLicP
        public string IdCardN { get; set; } // IdCardN
        public byte[] IdCardP1 { get; set; } // IdCardP1
        public byte[] IdCardP2 { get; set; } // IdCardP2
        public string Email { get; set; } // Email
        public string BankInfo { get; set; } // BankInfo
        public string BankNum { get; set; } // BankNum
        public byte[] BankP { get; set; } // BankP
        public virtual ICollection<T_DetailInfo> TDetailInfoes { get; set; } // T_DetailInfo.FK_T_DetailInfo_T_ShopData
        public T_ShopData()
        {
            TDetailInfoes = new List<T_DetailInfo>();
        }

    }
}
