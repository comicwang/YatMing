using System;
using System.Collections.Generic;
using iTelluro.Explorer.Domain.CodeFirst.Seedwork;

namespace iTelluro.Explorer.YatMing.Domain.Entities
{
    public class T_Employee : Entity
    {
        private string _employeeid;
        public string EmployeeId { get { return _employeeid; } set { this.Id = value; this._employeeid = value; } }  // EmployeeId (Primary key)

        public string EmployeeName { get; set; } // EmployeeName
        public string EmployeePhone { get; set; } // EmployeePhone
        public int EmployeeAge { get; set; } // EmployeeAge
        public string EmployeeSex { get; set; } // EmployeeSex
        public DateTime EntryData { get; set; } // EntryData
        public string IdCard { get; set; } // IdCard EntryImage
        public byte[] EntryImage { get; set; } // EntryImage
        public string Emotion { get; set; }
        public virtual ICollection<T_Check> TChecks { get; set; } // T_Check.FK_T_Check_T_Employee
        public virtual ICollection<T_Login> TLogins { get; set; } // T_Login.FK_T_Login_T_Employee
        public T_Employee()
        {
            TChecks = new List<T_Check>();
            TLogins = new List<T_Login>();
        }

    }
}
