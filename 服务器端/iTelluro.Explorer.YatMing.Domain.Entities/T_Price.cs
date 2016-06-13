using System;
using System.Collections.Generic;
using iTelluro.Explorer.Domain.CodeFirst.Seedwork;

namespace iTelluro.Explorer.YatMing.Domain.Entities
{
    public class T_Price : Entity
    {
        private string _merchantpriceid;
        public string MerchantPriceId { get { return _merchantpriceid; } set { this.Id = value; this._merchantpriceid = value; } }  // MerchantPriceId (Primary key)

        public string PackageId { get; set; } // PackageId
        public int? ExtraPrice { get; set; } // ExtraPrice
        public string ExtraDes { get; set; } // ExtraDes
        public int? ServerPrice { get; set; } // ServerPrice
        public string ServerDes { get; set; } // ServerDes
        public string HardwareId { get; set; } // HardwareId
        public virtual ICollection<T_DetailInfo> TDetailInfoes { get; set; } // T_DetailInfo.FK_T_DetailInfo_T_Price
        public virtual T_Hardware THardware { get; set; } // FK_T_Price_T_Hardware
        public virtual T_Package TPackage { get; set; } // FK_T_Price_T_Package
        public T_Price()
        {
            TDetailInfoes = new List<T_DetailInfo>();
        }

    }
}
