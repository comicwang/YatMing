using System;
using System.Collections.Generic;
using iTelluro.Explorer.Domain.CodeFirst.Seedwork;

namespace iTelluro.Explorer.YatMing.Domain.Entities
{
    public class T_Server : Entity
    {
        private string _serverid;
        public string ServerId { get { return _serverid; } set { this.Id = value; this._serverid = value; } }  // ServerId (Primary key)

        public string ServerContent { get; set; } // ServerContent
        public DateTime? ServerDate { get; set; } // ServerDate
        public string MerchantId { get; set; } // MerchantId
        public int? ServerPrice { get; set; } // ServerPrice
        public string ServerNote { get; set; } // ServerNote
        public virtual T_BaseInfo TBaseInfo { get; set; } // FK_T_Server_T_BaseInfo

    }
}
