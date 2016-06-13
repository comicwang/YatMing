using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace iTelluro.Explorer.YatMing.Application.DTO
{
    [DataContract]
    public class TDataInfoDTO
    {

        [DataMember]
        public string MetaDataId { get; set; }
        [DataMember]
        public string BaseInfoId { get; set; }
        [DataMember]
        public string DataName { get; set; }
        [DataMember]
        public byte[] DataContent { get; set; }
        [DataMember]
        public byte[] DataContent1 { get; set; }
        [DataMember]// DataContent
        public byte[] DataContent2 { get; set; }
        [DataMember]// DataContent
        public byte[] DataContent3 { get; set; }
        [DataMember]// DataContent
        public byte[] DataContent4 { get; set; } // DataContent
        [DataMember]// DataContent
        public byte[] DataContent5 { get; set; } // DataContent
        [DataMember]// DataContent
        public byte[] DataContent6 { get; set; } // DataContent
        [DataMember]// DataContent
        public byte[] DataContent7 { get; set; } // DataContent
        [DataMember]// DataContent
        public byte[] DataContent8 { get; set; } // DataContent
        [DataMember]// DataContent
        public byte[] DataContent9 { get; set; } // DataContent
        [DataMember]// DataContent
        public byte[] DataContent10 { get; set; } // DataContent
        [DataMember]// DataContent
        public byte[] DataContent11 { get; set; } // DataContent
        [DataMember]// DataContent
        public byte[] DataContent12 { get; set; } // DataContent
        [DataMember]// DataContent
        public byte[] DataContent13 { get; set; } // DataContent
        [DataMember]// DataContent
        public byte[] DataContent14 { get; set; } // DataContent
        [DataMember]// DataContent
        public byte[] DataContent15 { get; set; } // DataContent
        [DataMember]// DataContent
        public byte[] DataContent16 { get; set; } // DataContent
        [DataMember]// DataContent
        public byte[] DataContent17 { get; set; } // DataContent
        [DataMember]// DataContent
        public byte[] DataContent18 { get; set; } // DataContent
        [DataMember]// DataContent
        public byte[] DataContent19 { get; set; } // DataContent
        [DataMember]// DataContent
        public byte[] DataContent20 { get; set; } // DataContent// DataContent
        [DataMember]
        public DateTime? CreateTime { get; set; }
        [DataMember]
        public DateTime? LastModifyTime { get; set; }
        [DataMember]
        public string DataDescription { get; set; }
        [DataMember]
        public string UploadPeople { get; set; }
        [DataMember]
        public int? DownloadTimes { get; set; }
        [DataMember]
        public string FileSize { get; set; }
        [DataMember]
        public string ParentId { get; set; }
        [DataMember]
        public bool IsForlder { get; set; }
    }
}
