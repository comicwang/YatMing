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
    internal class TCheckMap : EntityTypeConfiguration<T_Check>
    {
        public TCheckMap(string schema = "dbo")
        {
            ToTable("T_Check", schema);
            HasKey(x => x.CheckId);
            Property(x => x.CheckId).HasColumnName("CheckId").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(36).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.CheckDate).HasColumnName("CheckDate").IsRequired();
            Property(x => x.CheckTime).HasColumnName("CheckTime").IsRequired().HasPrecision(7);
            Property(x => x.OnTime).HasColumnName("OnTime").IsRequired();
            Property(x => x.EmployeeId).HasColumnName("EmployeeId").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(36);
            HasRequired(a => a.TEmployee).WithMany(b => b.TChecks).HasForeignKey(c => c.EmployeeId).WillCascadeOnDelete(true); // FK_T_Check_T_Employee

        }
    }
}
