using System;
using System.Collections.Generic;
using iTelluro.Explorer.Domain.CodeFirst.Seedwork;

namespace iTelluro.Explorer.YatMing.Domain.Entities
{
    public class T_Login : Entity
    {
        private string _loginid;
        public string LoginId { get { return _loginid; } set { this.Id = value; this._loginid = value; } }  // LoginId (Primary key)

        public string LoginName { get; set; } // LoginName
        public string LoginPsw { get; set; } // LoginPsw
        public string Role { get; set; } // Role
        public string EmployeeId { get; set; } // EmployeeId
        public virtual T_Employee TEmployee { get; set; } // FK_T_Login_T_Employee

    }
}
