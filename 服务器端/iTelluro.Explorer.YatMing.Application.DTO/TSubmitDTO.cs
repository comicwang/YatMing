using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace iTelluro.Explorer.YatMing.Application.DTO
{
    [DataContract]
    public class TSubmitDTO
    {

        [DataMember]
        public string SubmitId { get; set; }
        [DataMember]
        public string SubmitContent { get; set; }
        [DataMember]
        public DateTime? SubmitDate { get; set; }
        [DataMember]
        public bool? Hardware { get; set; }
        [DataMember]
        public bool? Platform { get; set; }
        [DataMember]
        public bool? Train { get; set; }
        [DataMember]
        public string SubmitPeople { get; set; }
    }
}
