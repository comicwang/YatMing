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
    internal class TPriceMap : EntityTypeConfiguration<T_Price>
    {
        public TPriceMap(string schema = "dbo")
        {
            ToTable("T_Price", schema);
            HasKey(x => x.MerchantPriceId);
            Property(x => x.MerchantPriceId).HasColumnName("MerchantPriceId").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(36).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PackageId).HasColumnName("PackageId").IsOptional().IsFixedLength().IsUnicode(false).HasMaxLength(36);
            Property(x => x.ExtraPrice).HasColumnName("ExtraPrice").IsOptional();
            Property(x => x.ExtraDes).HasColumnName("ExtraDes").IsOptional().IsUnicode(false).HasMaxLength(200);
            Property(x => x.ServerPrice).HasColumnName("ServerPrice").IsOptional();
            Property(x => x.ServerDes).HasColumnName("ServerDes").IsOptional().IsUnicode(false).HasMaxLength(200);
            Property(x => x.HardwareId).HasColumnName("HardwareId").IsOptional().IsFixedLength().IsUnicode(false).HasMaxLength(36);
            HasOptional(a => a.TPackage).WithMany(b => b.TPrices).HasForeignKey(c => c.PackageId).WillCascadeOnDelete(false); // FK_T_Price_T_Package
            HasOptional(a => a.THardware).WithMany(b => b.TPrices).HasForeignKey(c => c.HardwareId).WillCascadeOnDelete(true); // FK_T_Price_T_Hardware

        }
    }
}
