using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace iTelluro.Explorer.YatMing.Application.DTO
{
    [DataContract]
    public class TPackageDTO
    {

        [DataMember]
        public string PackageId { get; set; }
        [DataMember]
        public string PackageName { get; set; }
        [DataMember]
        public int? Price { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}
