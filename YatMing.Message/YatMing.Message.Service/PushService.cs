using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using YatMing.Message.Contracts;

namespace YatMing.Message.Service
{
    /// <summary>
    /// 服务的实现
    /// Tips：
    /// 实现发布订阅,要注意：每个信道在调用后不要回收，否则会在回调时报错
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class PushService : IPushService
    {
        public void Regist(string Id)
        {
            IPushCallback callbackChannel = OperationContext.Current.GetCallbackChannel<IPushCallback>();
            //添加到管理列表中
            ChannelManager.Instance.Add(callbackChannel,Id);
        }

        public void UnRegist(string Id)
        {
            IPushCallback callbackChannel = OperationContext.Current.GetCallbackChannel<IPushCallback>();
            //从管理列表中移除
            ChannelManager.Instance.Remove(callbackChannel,Id);
        }
    }
}
