using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace iTelluro.Explorer.YatMing.Application.DTO
{
    [DataContract]
    public class TTrainDTO
    {

        [DataMember]
        public string TrainId { get; set; }
        [DataMember]
        public DateTime? TrainDate { get; set; }
        [DataMember]
        public string TrainPeople { get; set; }
        [DataMember]
        public byte[] TrainContent { get; set; }
        [DataMember]
        public string TrainType { get; set; }
    }
}
