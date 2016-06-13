using System;
using System.Collections.Generic;
using iTelluro.Explorer.Domain.CodeFirst.Seedwork;

namespace iTelluro.Explorer.YatMing.Domain.Entities
{
    public class T_Platform : Entity
    {
        private string _platformid;
        public string PlatformId { get { return _platformid; } set { this.Id = value; this._platformid = value; } }  // PlatformId (Primary key)

        public string PlatformName { get; set; } // PlatformName
        public string Account { get; set; } // Account
        public string Password { get; set; } // Password
        public string MerchantId { get; set; } // MerchantId
        public string PlatformUri { get; set; } // PlatformUri
        public virtual T_BaseInfo TBaseInfo { get; set; } // FK_T_Platform_T_BaseInfo

    }
}
