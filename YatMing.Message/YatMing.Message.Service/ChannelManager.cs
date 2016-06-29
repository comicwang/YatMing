using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YatMing.Message.Contracts;

namespace YatMing.Message.Service
{
    /// <summary>
    /// 通道管理
    /// </summary>
    public class ChannelManager
    {
        #region Fields

        /// <summary>
        /// 回调通道列表
        /// </summary>
        public Dictionary<string, IPushCallback> callbackChannelList = new Dictionary<string, IPushCallback>();

        /// <summary>
        /// 用于互斥锁的对象
        /// </summary>
        public static readonly object SyncObj = new object();

        public delegate void OparateChannelHandler(object sender, ChannelEventArg e);

        public event OparateChannelHandler OnOparateChannel;

        #endregion

        #region Single

        private static readonly Lazy<ChannelManager> instance = new Lazy<ChannelManager>(() => new ChannelManager());

        public static ChannelManager Instance
        {
            get { return instance.Value; }
        }

        protected ChannelManager() { }

        #endregion

        #region Methods
        /// <summary>
        /// 将回调通道加入到通道列表中进行管理
        /// </summary>
        /// <param name="callbackChannel"></param>
        public void Add(IPushCallback callbackChannel,string Id)
        {
            if (callbackChannelList.ContainsKey(Id))
            {
                Console.WriteLine("已存在重复通道");
            }
            else
            {
                lock (SyncObj)
                {
                    callbackChannelList.Add(Id,callbackChannel);
                    if (OnOparateChannel != null)
                    {
                        OnOparateChannel(callbackChannel, new ChannelEventArg(OparateType.Add,Id));
                    }
                    //Console.WriteLine("添加了新的通道");
                }
            }
        }

        /// <summary>
        /// 从通道列表中移除对一个通道的管理
        /// </summary>
        /// <param name="callbackChannel"></param>
        public void Remove(IPushCallback callbackChannel,string Id)
        {
            if (!callbackChannelList.ContainsKey(Id))
            {
                Console.WriteLine("不存在待移除通道");
            }
            else
            {
                lock (SyncObj)
                {
                    callbackChannelList.Remove(Id);
                    if (OnOparateChannel != null)
                    {
                        OnOparateChannel(callbackChannel, new ChannelEventArg(OparateType.Remove,Id));
                    }
                   // Console.WriteLine("移除了一个通道");
                }
            }
        }

        /// <summary>
        /// 广播消息
        /// </summary>
        /// <param name="message"></param>
        public void NotifyMessage(string message)
        {
            if (callbackChannelList.Count > 0)
            {
                foreach (var channel in callbackChannelList)
                {
                    try
                    {
                        //广播消息
                        channel.Value.NotifyMessage(message);
                        if (OnOparateChannel != null)
                        {
                            OnOparateChannel(channel, new ChannelEventArg(OparateType.Notify, channel.Key));
                        }
                    }
                    catch
                    {
                        //对异常的通道进行处理
                        callbackChannelList.Remove(channel.Key);
                        if (OnOparateChannel != null)
                        {
                            OnOparateChannel(channel, new ChannelEventArg(OparateType.Remove, channel.Key));
                        }
                    }
                }
            }
        }

        public void NotifyMutiMedia(MediaDTO medias)
        {
            if (callbackChannelList.Count > 0)
            {
                //避免对callbackChannelList的更改对广播造成的影响
                //IPushCallback[] callbackChannels = callbackChannelList.ToArray();

                foreach (var channel in callbackChannelList)
                {
                    try
                    {
                        //广播消息
                        channel.Value.NotifyMutimedia(medias);
                        if (OnOparateChannel != null)
                        {
                            OnOparateChannel(channel, new ChannelEventArg(OparateType.Notify,channel.Key));
                        }
                    }
                    catch
                    {
                        //对异常的通道进行处理
                        callbackChannelList.Remove(channel.Key);
                        if (OnOparateChannel != null)
                        {
                            OnOparateChannel(channel, new ChannelEventArg(OparateType.Remove,channel.Key));
                        }
                    }
                }
            }
        }

        #endregion
    }

    public class ChannelEventArg : EventArgs
    {
        public ChannelEventArg(OparateType type, string Id)
        {
            this.Type = type;
            this.Id = Id;
        }

        public OparateType Type { get; set; }

        public string Id { get; set; }
    }

    public enum OparateType
    {
        Add,
        Remove,
        Notify
    }
}
