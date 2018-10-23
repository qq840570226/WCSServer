using System;
using System.Collections.Generic;
using System.Text;
using DotNetty.Buffers;
using DotNetty.Codecs.Http;
using DotNetty.Common.Utilities;
using DotNetty.Transport.Channels;
using DotNetty.Common;
using BLL.CommunicationFormat;


namespace BLL.Handler
{
    public class WMSHandler : ChannelHandlerAdapter
    {
        public override void ChannelRead(IChannelHandlerContext context, object message)
        {
            var buffer = message as IByteBuffer;
            if (buffer != null)
            {
                RoutingProtocol(buffer);
            }
            context.Flush();
        }

        /// <summary>
        /// 路由
        /// </summary>
        /// <param name="WMSMsg"></param>
        public void RoutingProtocol(IByteBuffer WMSMsg)
        {
            // IByteBuffer --> enum
            byte[] msgTypeByteArray = new byte[4];
            WMSMsg.GetBytes(3, msgTypeByteArray, 0, 4);
            string msgTypeString = Encoding.UTF8.GetString(msgTypeByteArray);
            int msgTypeInt = Convert.ToInt32(msgTypeString);
            SocketMsgType socketMsgType;
            try
            {
                socketMsgType = (SocketMsgType)msgTypeInt;
            }
            catch (Exception)
            {
                socketMsgType = SocketMsgType.NotAEnum;
            }
            
            // 开始路由选择
            switch (socketMsgType)
            {
                case SocketMsgType.CreateCommunication:
                    break;
                case SocketMsgType.CreateCommunicationConfirm:
                    break;
                case SocketMsgType.PutOnOrderSend:
                    break;
                case SocketMsgType.PutOnOrderSendConfirm:
                    break;
                case SocketMsgType.PutOnRackArrive:
                    break;
                case SocketMsgType.PutOnRackArriveConfirm:
                    break;
                case SocketMsgType.PutOnFinish:
                    break;
                case SocketMsgType.PutOnFinishConfirm:
                    break;
                case SocketMsgType.MoveConfirm:
                    break;
                case SocketMsgType.MoveConfirmResponse:
                    break;
                case SocketMsgType.MoveRegister:
                    break;
                case SocketMsgType.MoveRegisterConfirm:
                    break;
                case SocketMsgType.MoveOrderSend:
                    break;
                case SocketMsgType.MoveOrderSendConfirm:
                    break;
                case SocketMsgType.MoveRackArrive:
                    break;
                case SocketMsgType.MoveRackArriveConfirm:
                    break;
                case SocketMsgType.MoveFinish:
                    break;
                case SocketMsgType.MoveFinishConfirm:
                    break;
                case SocketMsgType.PickOrderSend:
                    break;
                case SocketMsgType.PickOrderSendConfirm:
                    break;
                case SocketMsgType.PickRackArrive:
                    break;
                case SocketMsgType.PickRackArriveConfirm:
                    break;
                case SocketMsgType.PickFinish:
                    break;
                case SocketMsgType.PickFinishConfirm:
                    break;
                case SocketMsgType.PackOrderSend:
                    break;
                case SocketMsgType.PackOrderSendConfirm:
                    break;
                case SocketMsgType.PackFinish:
                    break;
                case SocketMsgType.PackFinishConfirm:
                    break;
                case SocketMsgType.SpMoveConfirm:
                    break;
                case SocketMsgType.SpMoveConfirmResponse:
                    break;
                case SocketMsgType.SpMoveRegister:
                    break;
                case SocketMsgType.SpMoveRegisterConfirm:
                    break;
                case SocketMsgType.SpMoveOrderSend:
                    break;
                case SocketMsgType.SpMoveOrderSendConfirm:
                    break;
                case SocketMsgType.SpMoveRackArrive:
                    break;
                case SocketMsgType.SpMoveRackArriveConfirm:
                    break;
                case SocketMsgType.SpMoveFinish:
                    break;
                case SocketMsgType.SpMoveFinishConfirm:
                    break;
                case SocketMsgType.NotAEnum:
                    break;
                default:
                    break;
            }
        }
    }
}
