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
    internal class TTrainMap : EntityTypeConfiguration<T_Train>
    {
        public TTrainMap(string schema = "dbo")
        {
            ToTable("T_Train", schema);
            HasKey(x => x.TrainId);
            Property(x => x.TrainId).HasColumnName("TrainId").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(36);
            Property(x => x.TrainDate).HasColumnName("TrainDate").IsOptional();
            Property(x => x.TrainPeople).HasColumnName("TrainPeople").IsOptional().IsUnicode(false).HasMaxLength(10);
            Property(x => x.TrainContent).HasColumnName("TrainContent").IsOptional().HasMaxLength(2147483647);
            Property(x => x.TrainType).HasColumnName("TrainType").IsOptional().IsUnicode(false).HasMaxLength(20);

        }
    }
}
