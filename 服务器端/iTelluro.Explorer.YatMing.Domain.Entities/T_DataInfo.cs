using System;
using System.Collections.Generic;
using iTelluro.Explorer.Domain.CodeFirst.Seedwork;

namespace iTelluro.Explorer.YatMing.Domain.Entities
{
    public class T_DataInfo : Entity
    {
        private string _metadataid;
        public string MetaDataId { get { return _metadataid; } set { this.Id = value; this._metadataid = value; } }  // MetaDataId (Primary key)

        public string BaseInfoId { get; set; } // BaseInfoId
        public string DataName { get; set; } // DataName
        public byte[] DataContent { get; set; } // DataContent
        public byte[] DataContent1 { get; set; } // DataContent
        public byte[] DataContent2 { get; set; } // DataContent
        public byte[] DataContent3 { get; set; } // DataContent
        public byte[] DataContent4 { get; set; } // DataContent
        public byte[] DataContent5 { get; set; } // DataContent
        public byte[] DataContent6 { get; set; } // DataContent
        public byte[] DataContent7 { get; set; } // DataContent
        public byte[] DataContent8 { get; set; } // DataContent
        public byte[] DataContent9 { get; set; } // DataContent
        public byte[] DataContent10 { get; set; } // DataContent
        public byte[] DataContent11 { get; set; } // DataContent
        public byte[] DataContent12 { get; set; } // DataContent
        public byte[] DataContent13 { get; set; } // DataContent
        public byte[] DataContent14 { get; set; } // DataContent
        public byte[] DataContent15 { get; set; } // DataContent
        public byte[] DataContent16 { get; set; } // DataContent
        public byte[] DataContent17 { get; set; } // DataContent
        public byte[] DataContent18 { get; set; } // DataContent
        public byte[] DataContent19 { get; set; } // DataContent
        public byte[] DataContent20 { get; set; } // DataContent
        public DateTime? CreateTime { get; set; } // CreateTime
        public DateTime? LastModifyTime { get; set; } // LastModifyTime
        public string DataDescription { get; set; } // DataDescription
        public string UploadPeople { get; set; } // UploadPeople
        public int? DownloadTimes { get; set; } // DownloadTimes
        public virtual T_BaseInfo TBaseInfo { get; set; } // FK_T_DataInfo_T_BaseInfo
        public string FileSize { get; set; }
        public string ParentId { get; set; }
        public bool IsForlder { get; set; }
    }
}
