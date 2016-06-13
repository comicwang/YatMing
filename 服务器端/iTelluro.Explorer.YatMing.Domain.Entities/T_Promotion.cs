using System;
using System.Collections.Generic;
using iTelluro.Explorer.Domain.CodeFirst.Seedwork;

namespace iTelluro.Explorer.YatMing.Domain.Entities
{
    public class T_Promotion : Entity
    {
        private string _promotionid;
        public string PromotionId { get { return _promotionid; } set { this.Id = value; this._promotionid = value; } }  // PromotionId (Primary key)

        public string PainSpot { get; set; } // PainSpot
        public string Question { get; set; } // Question
        public int? PromotionTimes { get; set; } // PromotionTimes
        public DateTime? PromotionTime { get; set; } // PromotionTime
        public string Solution { get; set; } // Solution
        public DateTime? NextTime { get; set; } // NextTime
        public string MerchantId { get; set; } // MerchantId
        public virtual T_BaseInfo TBaseInfo { get; set; } // FK_T_Promotion_T_BaseInfo

    }
}
