using System;
using System.Collections.Generic;
using iTelluro.Explorer.Domain.CodeFirst.Seedwork;

namespace iTelluro.Explorer.YatMing.Domain.Entities
{
    public class T_BaseInfo : Entity
    {
        private string _baseinfoid;
        public string BaseInfoId { get { return _baseinfoid; } set { this.Id = value; this._baseinfoid = value; } }  // BaseInfoId (Primary key)

        public string MerchantName { get; set; } // MerchantName
        public string MerchantBoss { get; set; } // MerchantBoss
        public string MerchantSex { get; set; } // MerchantSex
        public string MerchantTel { get; set; } // MerchantTel
        public string MerchantAdd { get; set; } // MerchantAdd
        public string MerchantId { get; set; } // MerchantId
        public string Feedback { get; set; } // Feedback
        public double Lon { get; set; }
        public double Lat { get; set; }
        public byte[] Logo { get; set; }
        public virtual ICollection<T_Promotion> TPromotions { get; set; } // T_Promotion.FK_T_Promotion_T_BaseInfo
        public virtual ICollection<T_Server> TServers { get; set; } // T_Server.FK_T_Server_T_BaseInfo
        public virtual T_Platform TPlatform { get; set; } // T_Platform.FK_T_Platform_T_BaseInfo
        public virtual T_MerchantType TMerchantType { get; set; } // FK_T_BaseInfo_T_MerchantType
        public virtual ICollection<T_DataInfo> TDataInfoes { get; set; } // T_DataInfo.FK_T_DataInfo_T_BaseInfo
        public T_BaseInfo()
        {
            TPromotions = new List<T_Promotion>();
            TServers = new List<T_Server>();
        }

    }
}
