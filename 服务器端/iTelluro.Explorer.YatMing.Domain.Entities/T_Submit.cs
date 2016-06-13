using System;
using System.Collections.Generic;
using iTelluro.Explorer.Domain.CodeFirst.Seedwork;

namespace iTelluro.Explorer.YatMing.Domain.Entities
{
    public class T_Submit : Entity
    {
        private string _submitid;
        public string SubmitId { get { return _submitid; } set { this.Id = value; this._submitid = value; } }  // SubmitId (Primary key)

        public string SubmitContent { get; set; } // SubmitContent
        public DateTime? SubmitDate { get; set; } // SubmitDate
        public bool? Hardware { get; set; } // Hardware
        public bool? Platform { get; set; } // Platform
        public bool? Train { get; set; } // Train
        public string SubmitPeople { get; set; } // SubmitPeople
        public virtual ICollection<T_DetailInfo> TDetailInfoes { get; set; } // T_DetailInfo.FK_T_DetailInfo_T_Submit
        public T_Submit()
        {
            TDetailInfoes = new List<T_DetailInfo>();
        }

    }
}
