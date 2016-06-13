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
    internal class TMerchantTypeMap : EntityTypeConfiguration<T_MerchantType>
    {
        public TMerchantTypeMap(string schema = "dbo")
        {
            ToTable("T_MerchantType", schema);
            HasKey(x => x.MerchantId);
            Property(x => x.MerchantId).HasColumnName("MerchantId").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(36).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.ParentId).HasColumnName("ParentId").IsOptional().IsFixedLength().IsUnicode(false).HasMaxLength(36);
            Property(x => x.MerchatType).HasColumnName("MerchatType").IsOptional().IsUnicode(false).HasMaxLength(20);
            Property(x => x.MerchantDes).HasColumnName("MerchantDes").IsOptional().IsUnicode(false).HasMaxLength(100);

        }
    }
}
