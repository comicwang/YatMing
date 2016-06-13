using System;
using System.Collections.Generic;
using iTelluro.Explorer.Domain.CodeFirst.Seedwork;

namespace iTelluro.Explorer.YatMing.Domain.Entities
{
    public class T_Train : Entity
    {
        private string _submitid;
        public string TrainId { get { return _submitid; } set { this.Id = value; this._submitid = value; } }
        public DateTime? TrainDate { get; set; } // TrainDate
        public string TrainPeople { get; set; } // TrainPeople
        public byte[] TrainContent { get; set; } // TrainContent
        public string TrainType { get; set; } // TrainType

    }
}
