using System;
using System.Collections.Generic;
using iTelluro.Explorer.Domain.CodeFirst.Seedwork;

namespace iTelluro.Explorer.YatMing.Domain.Entities
{
    public class T_Hardware : Entity
    {
        private string _hardwareid;
        public string HardwareId { get { return _hardwareid; } set { this.Id = value; this._hardwareid = value; } }  // HardwareId (Primary key)

        public string HardwareName { get; set; } // HardwareName
        public int? InPrice { get; set; } // InPrice
        public int? OutPrice { get; set; } // OutPrice
        public string HFuction { get; set; } // HFuction
        public virtual ICollection<T_Price> TPrices { get; set; } // T_Price.FK_T_Price_T_Hardware
        public T_Hardware()
        {
            TPrices = new List<T_Price>();
        }

    }
}
