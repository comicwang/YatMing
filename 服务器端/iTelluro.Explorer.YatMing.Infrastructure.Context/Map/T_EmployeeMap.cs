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
    internal class TEmployeeMap : EntityTypeConfiguration<T_Employee>
    {
        public TEmployeeMap(string schema = "dbo")
        {
            ToTable("T_Employee", schema);
            HasKey(x => x.EmployeeId);
            Property(x => x.EmployeeId).HasColumnName("EmployeeId").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(36).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.EmployeeName).HasColumnName("EmployeeName").IsRequired().IsUnicode(false).HasMaxLength(10);
            Property(x => x.EmployeePhone).HasColumnName("EmployeePhone").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(11);
            Property(x => x.EmployeeAge).HasColumnName("EmployeeAge").IsRequired();
            Property(x => x.EmployeeSex).HasColumnName("EmployeeSex").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(2);
            Property(x => x.EntryData).HasColumnName("EntryData").IsRequired();
            Property(x => x.IdCard).HasColumnName("IdCard").IsOptional().IsUnicode(false).HasMaxLength(18);
            Property(x => x.EntryImage).HasColumnName("EntryImage").IsOptional().HasMaxLength(2147483647);
        }
    }
}
