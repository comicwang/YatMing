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
    internal class TSubmitMap : EntityTypeConfiguration<T_Submit>
    {
        public TSubmitMap(string schema = "dbo")
        {
            ToTable("T_Submit", schema);
            HasKey(x => x.SubmitId);
            Property(x => x.SubmitId).HasColumnName("SubmitId").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(36).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.SubmitContent).HasColumnName("SubmitContent").IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.SubmitDate).HasColumnName("SubmitDate").IsOptional();
            Property(x => x.Hardware).HasColumnName("Hardware").IsOptional();
            Property(x => x.Platform).HasColumnName("Platform").IsOptional();
            Property(x => x.Train).HasColumnName("Train").IsOptional();
            Property(x => x.SubmitPeople).HasColumnName("SubmitPeople").IsOptional().IsUnicode(false).HasMaxLength(10);

        }
    }
}
