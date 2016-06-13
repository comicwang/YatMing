using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace iTelluro.Explorer.YatMing.Application.DTO
{
    [DataContract]
    public class THardwareDTO
    {

        [DataMember]
        public string HardwareId { get; set; }
        [DataMember]
        public string HardwareName { get; set; }
        [DataMember]
        public int? InPrice { get; set; }
        [DataMember]
        public int? OutPrice { get; set; }
        [DataMember]
        public string HFuction { get; set; }
    }
}
