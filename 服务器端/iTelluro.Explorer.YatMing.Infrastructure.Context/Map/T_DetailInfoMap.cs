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
    internal class TDetailInfoMap : EntityTypeConfiguration<T_DetailInfo>
    {
        public TDetailInfoMap(string schema = "dbo")
        {
            ToTable("T_DetailInfo", schema);
            HasKey(x => x.DetailId);
            Property(x => x.DetailId).HasColumnName("DetailId").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(36).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.BaseInfoId).HasColumnName("BaseInfoId").IsOptional().IsFixedLength().IsUnicode(false).HasMaxLength(36);
            Property(x => x.IntentionPackId).HasColumnName("IntentionPackId").IsOptional().IsFixedLength().IsUnicode(false).HasMaxLength(36);
            Property(x => x.DataId).HasColumnName("DataId").IsOptional().IsFixedLength().IsUnicode(false).HasMaxLength(36);
            Property(x => x.MerchantPriceId).HasColumnName("MerchantPriceId").IsOptional().IsFixedLength().IsUnicode(false).HasMaxLength(36);
            Property(x => x.MerchantReq).HasColumnName("MerchantReq").IsOptional().IsUnicode(false).HasMaxLength(200);
            Property(x => x.MerchantReqP).HasColumnName("MerchantReqP").IsOptional().HasMaxLength(2147483647);
            Property(x => x.SubmitId).HasColumnName("SubmitId").IsOptional().IsFixedLength().IsUnicode(false).HasMaxLength(36);
            Property(x => x.ContractId).HasColumnName("ContractId").IsOptional().IsFixedLength().IsUnicode(false).HasMaxLength(36);
            HasOptional(a => a.TPackage).WithMany(b => b.TDetailInfoes).HasForeignKey(c => c.IntentionPackId).WillCascadeOnDelete(true); // FK_T_DetailInfo_T_Package
            HasOptional(a => a.TShopData).WithMany(b => b.TDetailInfoes).HasForeignKey(c => c.DataId).WillCascadeOnDelete(true); // FK_T_DetailInfo_T_ShopData
            HasOptional(a => a.TPrice).WithMany(b => b.TDetailInfoes).HasForeignKey(c => c.MerchantPriceId).WillCascadeOnDelete(true); // FK_T_DetailInfo_T_Price
            HasOptional(a => a.TSubmit).WithMany(b => b.TDetailInfoes).HasForeignKey(c => c.SubmitId).WillCascadeOnDelete(true); // FK_T_DetailInfo_T_Submit
            HasOptional(a => a.TContract).WithMany(b => b.TDetailInfoes).HasForeignKey(c => c.ContractId).WillCascadeOnDelete(true); // FK_T_DetailInfo_T_Contract

        }
    }
}
