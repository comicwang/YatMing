using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace iTelluro.Explorer.YatMing.Application.DTO
{
    [DataContract]
    public class TCheckDTO
    {

        [DataMember]
        public string CheckId { get; set; }
        [DataMember]
        public DateTime CheckDate { get; set; }
        [DataMember]
        public TimeSpan CheckTime { get; set; }
        [DataMember]
        public bool OnTime { get; set; }
        [DataMember]
        public string EmployeeId { get; set; }
    }
}
