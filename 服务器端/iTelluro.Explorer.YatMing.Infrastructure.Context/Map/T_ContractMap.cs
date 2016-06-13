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
    internal class TContractMap : EntityTypeConfiguration<T_Contract>
    {
        public TContractMap(string schema = "dbo")
        {
            ToTable("T_Contract", schema);
            HasKey(x => x.ContractId);
            Property(x => x.ContractId).HasColumnName("ContractId").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(36).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.SignDate).HasColumnName("SignDate").IsOptional();
            Property(x => x.ExpireDate).HasColumnName("ExpireDate").IsOptional();
            Property(x => x.ContractInfo).HasColumnName("ContractInfo").IsOptional().HasMaxLength(2147483647);
            Property(x => x.ContractP).HasColumnName("ContractP").IsOptional().HasMaxLength(2147483647);
            Property(x => x.ContractP1).HasColumnName("ContractP1").IsOptional().HasMaxLength(2147483647);
            Property(x => x.ContractP2).HasColumnName("ContractP2").IsOptional().HasMaxLength(2147483647);
            Property(x => x.ContractP3).HasColumnName("ContractP3").IsOptional().HasMaxLength(2147483647);
            Property(x => x.ContractP4).HasColumnName("ContractP4").IsOptional().HasMaxLength(2147483647);
            Property(x => x.ContractPeople).HasColumnName("ContractPeople").IsOptional().IsUnicode(false).HasMaxLength(10);

        }
    }
}
