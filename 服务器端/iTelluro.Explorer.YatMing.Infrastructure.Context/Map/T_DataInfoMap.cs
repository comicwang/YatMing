using iTelluro.Explorer.YatMing.Domain.Entities;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity.ModelConfiguration;

namespace iTelluro.Explorer.YatMing.Infrastructure.Context.Map
{
    internal class TDataInfoMap : EntityTypeConfiguration<T_DataInfo>
    {
        public TDataInfoMap(string schema = "dbo")
        {
            ToTable("T_DataInfo", schema);
            HasKey(x => x.MetaDataId);
            Property(x => x.MetaDataId).HasColumnName("MetaDataId").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(36).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.BaseInfoId).HasColumnName("BaseInfoId").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(36);
            Property(x => x.ParentId).HasColumnName("ParentId").IsFixedLength().IsUnicode(false).HasMaxLength(36);
            Property(x => x.DataName).HasColumnName("DataName").IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.DataContent).HasColumnName("DataContent").IsOptional().HasMaxLength(2147483647);
            Property(x => x.DataContent1).HasColumnName("DataContent1").IsOptional().HasMaxLength(2147483647);
            Property(x => x.DataContent2).HasColumnName("DataContent2").IsOptional().HasMaxLength(2147483647);
            Property(x => x.DataContent3).HasColumnName("DataContent3").IsOptional().HasMaxLength(2147483647);
            Property(x => x.DataContent4).HasColumnName("DataContent4").IsOptional().HasMaxLength(2147483647);
            Property(x => x.DataContent5).HasColumnName("DataContent5").IsOptional().HasMaxLength(2147483647);
            Property(x => x.DataContent6).HasColumnName("DataContent6").IsOptional().HasMaxLength(2147483647);
            Property(x => x.DataContent7).HasColumnName("DataContent7").IsOptional().HasMaxLength(2147483647);
            Property(x => x.DataContent8).HasColumnName("DataContent8").IsOptional().HasMaxLength(2147483647);
            Property(x => x.DataContent9).HasColumnName("DataContent9").IsOptional().HasMaxLength(2147483647);
            Property(x => x.DataContent10).HasColumnName("DataContent10").IsOptional().HasMaxLength(2147483647);
            Property(x => x.DataContent11).HasColumnName("DataContent11").IsOptional().HasMaxLength(2147483647);
            Property(x => x.DataContent12).HasColumnName("DataContent12").IsOptional().HasMaxLength(2147483647);
            Property(x => x.DataContent13).HasColumnName("DataContent13").IsOptional().HasMaxLength(2147483647);
            Property(x => x.DataContent14).HasColumnName("DataContent14").IsOptional().HasMaxLength(2147483647);
            Property(x => x.DataContent15).HasColumnName("DataContent15").IsOptional().HasMaxLength(2147483647);
            Property(x => x.DataContent16).HasColumnName("DataContent16").IsOptional().HasMaxLength(2147483647);
            Property(x => x.DataContent17).HasColumnName("DataContent17").IsOptional().HasMaxLength(2147483647);
            Property(x => x.DataContent18).HasColumnName("DataContent18").IsOptional().HasMaxLength(2147483647);
            Property(x => x.DataContent19).HasColumnName("DataContent19").IsOptional().HasMaxLength(2147483647);
            Property(x => x.DataContent20).HasColumnName("DataContent20").IsOptional().HasMaxLength(2147483647);
            Property(x => x.CreateTime).HasColumnName("CreateTime").IsOptional().HasPrecision(3);
            Property(x => x.LastModifyTime).HasColumnName("LastModifyTime").IsOptional().HasPrecision(3);
            Property(x => x.DataDescription).HasColumnName("DataDescription").IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.UploadPeople).HasColumnName("UploadPeople").IsOptional().IsUnicode(false).HasMaxLength(10);
            Property(x => x.FileSize).HasColumnName("FileSize").IsOptional().IsUnicode(false).HasMaxLength(30);
            Property(x => x.DownloadTimes).HasColumnName("DownloadTimes").IsOptional();
            Property(x => x.IsForlder).HasColumnName("IsForlder").IsRequired();
            HasRequired(a => a.TBaseInfo).WithMany(b => b.TDataInfoes).HasForeignKey(c => c.BaseInfoId).WillCascadeOnDelete(true); // FK_T_DataInfo_T_BaseInfo

        }
    }
}
