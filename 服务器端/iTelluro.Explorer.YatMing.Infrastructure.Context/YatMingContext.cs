namespace iTelluro.Explorer.YatMing.Infrastructure.Context
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Collections.Generic;

    using iTelluro.Explorer.YatMing.Infrastructure.Context.Map;
    using iTelluro.Explorer.Infrastruct.CodeFirst.Seedwork;
    using iTelluro.Explorer.Domain.CodeFirst.Seedwork;
    using System.Data;
    using System.Data.SqlClient;
    using System;
    using System.Data.Common;

    public partial class YatMingContext : DbContext, IQueryableUnitOfWork
    {
        public string DBSchema { get; set; }

        public YatMingContext(string dbSchema)
            : base("name=YatMingContext")
        {
            DBSchema = dbSchema;
        }

        public YatMingContext(string nameOrConnectionString, string dbSchema)
            : base(nameOrConnectionString)
        {
            DBSchema = dbSchema;
        }

        public YatMingContext(DbConnection existingConnection, string dbSchema)
            : base(existingConnection, true)
        {
            DBSchema = dbSchema;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MetaDataSqlContext>());
            modelBuilder.Conventions.Remove<ModelNamespaceConvention>();
            modelBuilder.Conventions.Remove<ModelContainerConvention>();
            modelBuilder.Configurations.Add(new TLoginMap(DBSchema));


            modelBuilder.Configurations.Add(new TCheckMap(DBSchema));


            modelBuilder.Configurations.Add(new TBaseInfoMap(DBSchema));


            modelBuilder.Configurations.Add(new TMerchantTypeMap(DBSchema));


            modelBuilder.Configurations.Add(new TDetailInfoMap(DBSchema));

            modelBuilder.Configurations.Add(new TDataInfoMap(DBSchema));


            modelBuilder.Configurations.Add(new TPromotionMap(DBSchema));


            modelBuilder.Configurations.Add(new TPlatformMap(DBSchema));


            modelBuilder.Configurations.Add(new TShopDataMap(DBSchema));


            modelBuilder.Configurations.Add(new TPriceMap(DBSchema));


            modelBuilder.Configurations.Add(new TPackageMap(DBSchema));


            modelBuilder.Configurations.Add(new THardwareMap(DBSchema));


            modelBuilder.Configurations.Add(new TContractMap(DBSchema));


            modelBuilder.Configurations.Add(new TSubmitMap(DBSchema));


            modelBuilder.Configurations.Add(new TServerMap(DBSchema));


            modelBuilder.Configurations.Add(new TTrainMap(DBSchema));


            modelBuilder.Configurations.Add(new TEmployeeMap(DBSchema));



            base.OnModelCreating(modelBuilder);
        }
    }
}
