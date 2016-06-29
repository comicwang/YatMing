using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace YatMing.Message.Contracts
{
    /// <summary>
    /// 回调接口 IOC思想的体现
    /// </summary>
    public interface IPushCallback
    {
        [OperationContract(IsOneWay = true)]
        void NotifyMessage(string message);

        [OperationContract(IsOneWay = true)]
        void NotifyMutimedia(MediaDTO medias);
    }
}
