using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace YatMing.Message.Contracts
{
    /// <summary>
    /// 推送服务契约
    /// 
    /// Tips：
    /// 契约提供两个服务，一个是订阅，一个是退订。
    /// 服务端会向订阅的客户端发布消息
    /// </summary>
    [ServiceContract(CallbackContract = typeof(IPushCallback))]
    public interface IPushService
    {
        /// <summary>
        /// 订阅服务
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void Regist(string Id);

        /// <summary>
        /// 退订服务
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void UnRegist(string Id);
    }
}
