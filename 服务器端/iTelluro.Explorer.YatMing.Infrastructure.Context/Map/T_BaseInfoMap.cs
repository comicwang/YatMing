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
    internal class TBaseInfoMap : EntityTypeConfiguration<T_BaseInfo>
    {
        public TBaseInfoMap(string schema = "dbo")
        {
            ToTable("T_BaseInfo", schema);
            HasKey(x => x.BaseInfoId);
            Property(x => x.BaseInfoId).HasColumnName("BaseInfoId").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(36).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.MerchantName).HasColumnName("MerchantName").IsRequired().IsUnicode(false).HasMaxLength(50);
            Property(x => x.MerchantBoss).HasColumnName("MerchantBoss").IsOptional().IsUnicode(false).HasMaxLength(10);
            Property(x => x.MerchantSex).HasColumnName("MerchantSex").IsOptional().IsFixedLength().IsUnicode(false).HasMaxLength(2);
            Property(x => x.MerchantTel).HasColumnName("MerchantTel").IsOptional().IsUnicode(false).HasMaxLength(13);
            Property(x => x.MerchantAdd).HasColumnName("MerchantAdd").IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.MerchantId).HasColumnName("MerchantId").IsOptional().IsFixedLength().IsUnicode(false).HasMaxLength(36);
            Property(x => x.Feedback).HasColumnName("Feedback").IsOptional().IsUnicode(false).HasMaxLength(500);
            Property(x => x.Lon).HasColumnName("Lon").IsOptional();
            Property(x => x.Lat).HasColumnName("Lat").IsOptional();
            Property(x => x.Logo).HasColumnName("Logo").IsOptional().HasMaxLength(2147483647);
            HasOptional(a => a.TMerchantType).WithMany(b => b.TBaseInfoes).HasForeignKey(c => c.MerchantId).WillCascadeOnDelete(true); // FK_T_BaseInfo_T_MerchantType

        }
    }
}
