using System;
using System.Collections.Generic;
using iTelluro.Explorer.Domain.CodeFirst.Seedwork;

namespace iTelluro.Explorer.YatMing.Domain.Entities
{
    public class T_Check : Entity
    {
        private string _checkid;
        public string CheckId { get { return _checkid; } set { this.Id = value; this._checkid = value; } }  // CheckId (Primary key)

        public DateTime CheckDate { get; set; } // CheckDate
        public TimeSpan CheckTime { get; set; } // CheckTime
        public bool OnTime { get; set; } // OnTime
        public string EmployeeId { get; set; } // EmployeeId
        public virtual T_Employee TEmployee { get; set; } // FK_T_Check_T_Employee

    }
}
