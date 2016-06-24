using iTelluro.Explorer.Infrastruct.CodeFirst.Seedwork;
using iTelluro.Explorer.Infrastructure.CrossCutting.Adapter;
using iTelluro.Explorer.Infrastructure.CrossCutting.Caching;
using iTelluro.Explorer.Infrastructure.CrossCutting.Logging;
using iTelluro.Explorer.Infrastructure.CrossCutting.NetFramework.Adapter;
using iTelluro.Explorer.Infrastructure.CrossCutting.NetFramework.Logging;
using iTelluro.Explorer.Infrastructure.CrossCutting.NetFramework.SSO;
using iTelluro.Explorer.Infrastructure.CrossCutting.NetFramework.Caching;
using iTelluro.Explorer.Infrastructure.CrossCutting.SSO;
using iTelluro.Explorer.YatMing.Application;
using iTelluro.Explorer.YatMing.Domain.Context;
using iTelluro.Explorer.YatMing.IApplication;
using iTelluro.Explorer.YatMing.Infrastructure.Context;
using iTelluro.Explorer.YatMing.Infrastructure.Context.Repository;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace iTelluro.Explorer.YatMing.Service.InstanceProviders
{
    public static class Container
    {
        #region Properties

        static IUnityContainer _currentContainer;

        public static IUnityContainer Current
        {
            get { return _currentContainer; }
        }

        #endregion

        #region Constructor

        static Container()
        {
            ConfigureContainer();

            ConfigureFactories();
        }

        #endregion

        #region methods

        static void ConfigureContainer()
        {
            _currentContainer = new UnityContainer();

            string db = System.Configuration.ConfigurationManager.AppSettings["DBSchema"];
            _currentContainer.RegisterType<IQueryableUnitOfWork, YatMingContext>(new InjectionConstructor(db));
            _currentContainer.RegisterType<ITLoginRepository, TLoginRepository>();
            _currentContainer.RegisterType<ITLoginApp, TLoginApp>();


            _currentContainer.RegisterType<ITCheckRepository, TCheckRepository>();
            _currentContainer.RegisterType<ITCheckApp, TCheckApp>();


            _currentContainer.RegisterType<ITBaseInfoRepository, TBaseInfoRepository>();
            _currentContainer.RegisterType<ITBaseInfoApp, TBaseInfoApp>();


            _currentContainer.RegisterType<ITMerchantTypeRepository, TMerchantTypeRepository>();
            _currentContainer.RegisterType<ITMerchantTypeApp, TMerchantTypeApp>();


            _currentContainer.RegisterType<ITDetailInfoRepository, TDetailInfoRepository>();
            _currentContainer.RegisterType<ITDetailInfoApp, TDetailInfoApp>();

            _currentContainer.RegisterType<ITDataInfoRepository, TDataInfoRepository>();
            _currentContainer.RegisterType<ITDataInfoApp, TDataInfoApp>();

            _currentContainer.RegisterType<ITPromotionRepository, TPromotionRepository>();
            _currentContainer.RegisterType<ITPromotionApp, TPromotionApp>();


            _currentContainer.RegisterType<ITPlatformRepository, TPlatformRepository>();
            _currentContainer.RegisterType<ITPlatformApp, TPlatformApp>();


            _currentContainer.RegisterType<ITShopDataRepository, TShopDataRepository>();
            _currentContainer.RegisterType<ITShopDataApp, TShopDataApp>();


            _currentContainer.RegisterType<ITPriceRepository, TPriceRepository>();
            _currentContainer.RegisterType<ITPriceApp, TPriceApp>();


            _currentContainer.RegisterType<ITPackageRepository, TPackageRepository>();
            _currentContainer.RegisterType<ITPackageApp, TPackageApp>();


            _currentContainer.RegisterType<ITHardwareRepository, THardwareRepository>();
            _currentContainer.RegisterType<ITHardwareApp, THardwareApp>();


            _currentContainer.RegisterType<ITContractRepository, TContractRepository>();
            _currentContainer.RegisterType<ITContractApp, TContractApp>();


            _currentContainer.RegisterType<ITSubmitRepository, TSubmitRepository>();
            _currentContainer.RegisterType<ITSubmitApp, TSubmitApp>();


            _currentContainer.RegisterType<ITServerRepository, TServerRepository>();
            _currentContainer.RegisterType<ITServerApp, TServerApp>();


            _currentContainer.RegisterType<ITTrainRepository, TTrainRepository>();
            _currentContainer.RegisterType<ITTrainApp, TTrainApp>();


            _currentContainer.RegisterType<ITEmployeeRepository, TEmployeeRepository>();
            _currentContainer.RegisterType<ITEmployeeApp, TEmployeeApp>();

            _currentContainer.RegisterType<ITRecorderRepository, TRecorderRepository>();
            _currentContainer.RegisterType<ITRecorderApp, TRecorderApp>();

            _currentContainer.RegisterType<ITypeAdapterFactory, AutomapperTypeAdapterFactory>(new ContainerControlledLifetimeManager());
            _currentContainer.RegisterType<ICache, MemoryCache>(new ContainerControlledLifetimeManager());
            _currentContainer.RegisterType<ISSO, WebSSO>(new ContainerControlledLifetimeManager());
        }

        static void ConfigureFactories()
        {
            LoggerFactory.SetCurrent(new Log4netFactory());// π”√log4net
            var typeAdapterFactory = _currentContainer.Resolve<ITypeAdapterFactory>();
            TypeAdapterFactory.SetCurrent(typeAdapterFactory);
        }
        #endregion

    }
}
