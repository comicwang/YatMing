using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace iTelluro.Explorer.YatMing.Application.DTO
{
    [DataContract]
    public class TLoginDTO
    {

        [DataMember]
        public string LoginId { get; set; }
        [DataMember]
        public string LoginName { get; set; }
        [DataMember]
        public string LoginPsw { get; set; }
        [DataMember]
        public string Role { get; set; }
        [DataMember]
        public string EmployeeId { get; set; }
        [DataMember]
        public int State { get; set; }
    }
}
