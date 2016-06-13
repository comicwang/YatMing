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
    internal class TPlatformMap : EntityTypeConfiguration<T_Platform>
    {
        public TPlatformMap(string schema = "dbo")
        {
            ToTable("T_Platform", schema);
            HasKey(x => x.PlatformId);
            Property(x => x.PlatformId).HasColumnName("PlatformId").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(36).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PlatformName).HasColumnName("PlatformName").IsRequired().IsUnicode(false).HasMaxLength(20);
            Property(x => x.Account).HasColumnName("Account").IsOptional().IsUnicode(false).HasMaxLength(30);
            Property(x => x.Password).HasColumnName("Password").IsOptional().IsUnicode(false).HasMaxLength(30);
            Property(x => x.MerchantId).HasColumnName("MerchantId").IsOptional().IsFixedLength().IsUnicode(false).HasMaxLength(36);
            Property(x => x.PlatformUri).HasColumnName("PlatformUri").IsOptional().IsUnicode(false).HasMaxLength(100);
            HasRequired(a => a.TBaseInfo).WithOptional(b => b.TPlatform).WillCascadeOnDelete(true); // FK_T_Platform_T_BaseInfo

        }
    }
}
