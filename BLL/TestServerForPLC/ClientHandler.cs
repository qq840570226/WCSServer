using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DotNetty.Buffers;
using DotNetty.Transport.Channels;
using BLL.JsonObject;
using BLL.PLCStruct;

namespace BLL.TestServerForPLC
{
    public class ClientHandler : ChannelHandlerAdapter
    {
        public ClientHandler() { }

        /// <summary>
        /// 激活
        /// </summary>
        /// <param name="context"></param>
        public override void ChannelActive(IChannelHandlerContext context)
        {
            DataCache.CallbackQueue.Enqueue(context.Channel.RemoteAddress.ToString() + "已连接!");
        }

        /// <summary>
        /// 断开
        /// </summary>
        /// <param name="context"></param>
        public override void ChannelInactive(IChannelHandlerContext context)
        {
            DataCache.CallbackQueue.Enqueue(context.Channel.RemoteAddress.ToString() + "已断开!");
        }

        /// <summary>
        /// 接收
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        public override void ChannelRead(IChannelHandlerContext context, object message)
        {
            if (!(message is IByteBuffer buffer))
            {
                return;
            }
            try
            {
                byte[] vs = new byte[0x0d];
                buffer.GetBytes(0, vs);
                BLL.JsonObject.ProvideGoods temp = new BLL.JsonObject.ProvideGoods(vs);
                DataCache.ReceiveQueue.Enqueue(temp);
            }
            catch
            {

            }
            finally
            {
                buffer.Clear();
            }
        }

        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)
        {
            DataCache.CallbackQueue.Enqueue("因" + exception.ToString() + "原因" + context.Channel.RemoteAddress.ToString() + "断开!");
        }
    }
}
