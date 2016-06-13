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
    internal class TServerMap : EntityTypeConfiguration<T_Server>
    {
        public TServerMap(string schema = "dbo")
        {
            ToTable("T_Server", schema);
            HasKey(x => x.ServerId);
            Property(x => x.ServerId).HasColumnName("ServerId").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(36).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.ServerContent).HasColumnName("ServerContent").IsOptional().IsUnicode(false).HasMaxLength(200);
            Property(x => x.ServerDate).HasColumnName("ServerDate").IsOptional();
            Property(x => x.MerchantId).HasColumnName("MerchantId").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(36);
            Property(x => x.ServerPrice).HasColumnName("ServerPrice").IsOptional();
            Property(x => x.ServerNote).HasColumnName("ServerNote").IsOptional().IsUnicode(false).HasMaxLength(200);
            HasRequired(a => a.TBaseInfo).WithMany(b => b.TServers).HasForeignKey(c => c.MerchantId).WillCascadeOnDelete(true); // FK_T_Server_T_BaseInfo

        }
    }
}
