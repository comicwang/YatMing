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
    internal class TLoginMap : EntityTypeConfiguration<T_Login>
    {
        public TLoginMap(string schema = "dbo")
        {
            ToTable("T_Login", schema);
            HasKey(x => x.LoginId);
            Property(x => x.LoginId).HasColumnName("LoginId").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(36).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.LoginName).HasColumnName("LoginName").IsRequired().IsUnicode(false).HasMaxLength(30);
            Property(x => x.LoginPsw).HasColumnName("LoginPsw").IsRequired().IsUnicode(false).HasMaxLength(20);
            Property(x => x.Role).HasColumnName("Role").IsRequired().IsUnicode(false).HasMaxLength(20);
            Property(x => x.EmployeeId).HasColumnName("EmployeeId").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(36);
            Property(x => x.State).HasColumnName("State").IsOptional();
            HasRequired(a => a.TEmployee).WithMany(b => b.TLogins).HasForeignKey(c => c.EmployeeId).WillCascadeOnDelete(true); // FK_T_Login_T_Employee

        }
    }
}
