using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace iTelluro.Explorer.YatMing.Application.DTO
{
    [DataContract]
    public class TEmployeeDTO
    {

        [DataMember]
        public string EmployeeId { get; set; }
        [DataMember]
        public string EmployeeName { get; set; }
        [DataMember]
        public string EmployeePhone { get; set; }
        [DataMember]
        public int EmployeeAge { get; set; }
        [DataMember]
        public string EmployeeSex { get; set; }
        [DataMember]
        public DateTime EntryData { get; set; }
        [DataMember]
        public string IdCard { get; set; }
        [DataMember]
        public byte[] EntryImage { get; set; }
        [DataMember]
        public string Emotion { get; set; }
    }
}
