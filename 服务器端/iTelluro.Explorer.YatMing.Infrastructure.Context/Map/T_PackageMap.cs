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
    internal class TPackageMap : EntityTypeConfiguration<T_Package>
    {
        public TPackageMap(string schema = "dbo")
        {
            ToTable("T_Package", schema);
            HasKey(x => x.PackageId);
            Property(x => x.PackageId).HasColumnName("PackageId").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(36).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PackageName).HasColumnName("PackageName").IsOptional().IsUnicode(false).HasMaxLength(30);
            Property(x => x.Price).HasColumnName("Price").IsOptional();
            Property(x => x.Description).HasColumnName("Description").IsOptional().IsUnicode(false).HasMaxLength(200);

        }
    }
}
