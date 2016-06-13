using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Dispatcher;
using System.Web;
using Microsoft.Practices.Unity;
using iTelluro.Explorer.Infrastructure.CrossCutting.SSO;
using iTelluro.Explorer.Infrastructure.CrossCutting.NetFramework.SSO;
using iTelluro.Explorer.Infrastructure.CrossCutting.Logging;
using iTelluro.Explorer.Infrastructure.CrossCutting.NetFramework.Logging;
using iTelluro.Explorer.Infrastructure.CrossCutting.NetFramework.Caching;
using iTelluro.Explorer.Infrastructure.CrossCutting.Caching;
namespace iTelluro.Explorer.YatMing.Service.InstanceProviders
{
    public class UnityInstanceProvider : IInstanceProvider
    {
        #region 成员

        Type _serviceType;
        IUnityContainer _container;

        #endregion

        #region Constructor

        public UnityInstanceProvider(Type serviceType)
        {
            if (serviceType == null)
                throw new ArgumentNullException("serviceType");

            _serviceType = serviceType;
            _container = Container.Current;
        }

        #endregion


        #region IInstanceProvider 成员

        public object GetInstance(System.ServiceModel.InstanceContext instanceContext, System.ServiceModel.Channels.Message message)
        {

            //var sso = _container.Resolve<ISSO>();
            //sso.Cache = _container.Resolve<ICache>();
            //int index = message.Headers.FindHeader("SSOToken", "http://www.infoearth.com");
            //if (index >= 0)
            //{
            //    string token = message.Headers.GetHeader<string>(index);
            //    sso.Token = token;
            //   // LoggerFactory.CreateLog().LogInfo(string.Format
            //       // ("用户访问token:{0}  ; 访问的servcie:{1}", token, _serviceType.FullName));
            //}
            //else
            //{
            //    //LoggerFactory.CreateLog().LogError(string.Format("出错啦，没有找到sso的token。访问的service:{0}", _serviceType.FullName));

            //   // sso.Token = "5c96EAf1-b7Eb-4bF9-a4A8-4b2ABa283F8d,admin";
            //    return _container.Resolve(_serviceType);

            //    throw new Exception("出错啦，没有找到sso的token。(UnityInstanceProvider.cs GetInstance方法)");
            //}
            return _container.Resolve(_serviceType);
        }

        public object GetInstance(System.ServiceModel.InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        public void ReleaseInstance(System.ServiceModel.InstanceContext instanceContext, object instance)
        {
            if (instance is IDisposable)
                ((IDisposable)instance).Dispose();
        }

        #endregion
    }
}
