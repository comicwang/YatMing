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
    internal class TRecorderMap : EntityTypeConfiguration<T_Recorder>
    {
        public TRecorderMap(string schema = "dbo")
        {
            ToTable("T_Recorder", schema);
            HasKey(x => x.RecorderId);
            Property(x => x.RecorderId).HasColumnName("RecorderId").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(36).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Title).HasColumnName("Title").IsOptional().IsUnicode(false).HasMaxLength(60);
            Property(x => x.Url).HasColumnName("Url").IsOptional().IsUnicode(false).HasMaxLength(200);
            Property(x => x.PublishDate).HasColumnName("PublishDate").IsOptional();
            HasRequired(a => a.TBaseInfo).WithOptional(b => b.TRecorder).WillCascadeOnDelete(true); // 

        }
    }
}
