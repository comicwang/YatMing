using System;
using System.Collections.Generic;
using iTelluro.Explorer.Domain.CodeFirst.Seedwork;

namespace iTelluro.Explorer.YatMing.Domain.Entities
{
    public class T_Package : Entity
    {
        private string _packageid;
        public string PackageId { get { return _packageid; } set { this.Id = value; this._packageid = value; } }  // PackageId (Primary key)

        public string PackageName { get; set; } // PackageName
        public int? Price { get; set; } // Price
        public string Description { get; set; } // Description
        public virtual ICollection<T_DetailInfo> TDetailInfoes { get; set; } // T_DetailInfo.FK_T_DetailInfo_T_Package
        public virtual ICollection<T_Price> TPrices { get; set; } // T_Price.FK_T_Price_T_Package
        public T_Package()
        {
            TDetailInfoes = new List<T_DetailInfo>();
            TPrices = new List<T_Price>();
        }

    }
}
