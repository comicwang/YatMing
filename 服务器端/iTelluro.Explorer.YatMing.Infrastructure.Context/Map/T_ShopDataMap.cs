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
    internal class TShopDataMap : EntityTypeConfiguration<T_ShopData>
    {
        public TShopDataMap(string schema = "dbo")
        {
            ToTable("T_ShopData", schema);
            HasKey(x => x.DataId);
            Property(x => x.DataId).HasColumnName("DataId").IsRequired().IsFixedLength().IsUnicode(false).HasMaxLength(36).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Brand).HasColumnName("Brand").IsOptional().IsUnicode(false).HasMaxLength(20);
            Property(x => x.MerchantName).HasColumnName("MerchantName").IsOptional().IsUnicode(false).HasMaxLength(20);
            Property(x => x.TelPhone).HasColumnName("TelPhone").IsOptional().IsUnicode(false).HasMaxLength(20);
            Property(x => x.PayeeMobile).HasColumnName("PayeeMobile").IsOptional().IsFixedLength().IsUnicode(false).HasMaxLength(12);
            Property(x => x.BusinessHourS).HasColumnName("BusinessHourS").IsOptional();
            Property(x => x.BusinessHourE).HasColumnName("BusinessHourE").IsOptional();
            Property(x => x.CPP).HasColumnName("CPP").IsOptional();
            Property(x => x.WIFI).HasColumnName("WIFI").IsOptional();
            Property(x => x.WifiAccount).HasColumnName("WifiAccount").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.WifiPsw).HasColumnName("WifiPsw").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.ActionInfo).HasColumnName("ActionInfo").IsOptional().IsUnicode(false).HasMaxLength(200);
            Property(x => x.BusinessLicN).HasColumnName("BusinessLicN").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.BusinessName).HasColumnName("BusinessName").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.BusinessAdd).HasColumnName("BusinessAdd").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.BusinessLicP).HasColumnName("BusinessLicP").IsOptional().HasMaxLength(2147483647);
            Property(x => x.OtherLicN).HasColumnName("OtherLicN").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.OtherLicP).HasColumnName("OtherLicP").IsOptional().HasMaxLength(2147483647);
            Property(x => x.IdCardN).HasColumnName("IdCardN").IsOptional().IsUnicode(false).HasMaxLength(18);
            Property(x => x.IdCardP1).HasColumnName("IdCardP1").IsOptional().HasMaxLength(2147483647);
            Property(x => x.IdCardP2).HasColumnName("IdCardP2").IsOptional().HasMaxLength(2147483647);
            Property(x => x.Email).HasColumnName("Email").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.BankInfo).HasColumnName("BankInfo").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.BankNum).HasColumnName("BankNum").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.BankP).HasColumnName("BankP").IsOptional().HasMaxLength(2147483647);

        }
    }
}
