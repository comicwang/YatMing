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
    internal class THardwareMap : EntityTypeConfiguration<T_Hardware>
    {
        public THardwareMap(string schema = "dbo")
        {
            ToTable("T_Hardware", schema);
            HasKey(x => x.HardwareId);
            Property(x => x.HardwareId).HasColumnName("HardwareId").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(36).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.HardwareName).HasColumnName("HardwareName").IsOptional().IsUnicode(false).HasMaxLength(30);
            Property(x => x.InPrice).HasColumnName("InPrice").IsOptional();
            Property(x => x.OutPrice).HasColumnName("OutPrice").IsOptional();
            Property(x => x.HFuction).HasColumnName("HFuction").IsOptional().IsUnicode(false).HasMaxLength(200);

        }
    }
}
