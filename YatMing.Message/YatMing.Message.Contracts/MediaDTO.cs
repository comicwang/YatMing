using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace YatMing.Message.Contracts
{
    [DataContract]
    public class MediaDTO
    {
        [DataMember]
        public byte[] MediaContent { get; set; }
    }
}
