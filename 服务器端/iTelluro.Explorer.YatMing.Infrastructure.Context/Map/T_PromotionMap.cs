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
    internal class TPromotionMap : EntityTypeConfiguration<T_Promotion>
    {
        public TPromotionMap(string schema = "dbo")
        {
            ToTable("T_Promotion", schema);
            HasKey(x => x.PromotionId);
            Property(x => x.PromotionId).HasColumnName("PromotionId").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(36).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.PainSpot).HasColumnName("PainSpot").IsOptional().IsUnicode(false).HasMaxLength(200);
            Property(x => x.Question).HasColumnName("Question").IsOptional().IsUnicode(false).HasMaxLength(200);
            Property(x => x.PromotionTimes).HasColumnName("PromotionTimes").IsOptional();
            Property(x => x.PromotionTime).HasColumnName("PromotionTime").IsOptional();
            Property(x => x.Solution).HasColumnName("Solution").IsOptional().IsUnicode(false).HasMaxLength(200);
            Property(x => x.NextTime).HasColumnName("NextTime").IsOptional();
            Property(x => x.MerchantId).HasColumnName("MerchantId").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(36);
            HasRequired(a => a.TBaseInfo).WithMany(b => b.TPromotions).HasForeignKey(c => c.MerchantId).WillCascadeOnDelete(true); // FK_T_Promotion_T_BaseInfo

        }
    }
}
