using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.CommunicationFormat
{
    public static class SocketToWMSFormat
    {
        public const string Start = "STX";
        public const string End = "QTX";
        public const char Split = '|';
    }

    public interface IWCSToWMSBySocket
    {
        /// <summary>
        /// 对象转化为socket字符串
        /// </summary>
        /// <returns></returns>
        string ToSocketString();
    }

    public interface ISubWCSToWMSBySocket
    {
        /// <summary>
        /// 将detail转化为Socket字符串
        /// </summary>
        /// <returns></returns>
        string ToSubSocketString();
    }

    public interface IEnumFormatSocket
    {
        string ToFormattedString();
    }

    /// <summary>
    /// 同WMS进行数据交换的格式
    /// </summary>
    public enum SocketMsgType
    {
        NotAEnum = 0,
        CreateCommunication = 0200,
        CreateCommunicationConfirm = 0100,
        PutOnOrderSend = 0101,
        PutOnOrderSendConfirm = 0201,
        PutOnRackArrive = 0102,
        PutOnRackArriveConfirm = 0202,
        PutOnFinish = 0203,
        PutOnFinishConfirm = 0103,
        MoveConfirm = 0112,
        MoveConfirmResponse = 0212,
        MoveRegister = 0213,
        MoveRegisterConfirm = 0113,
        MoveOrderSend = 0104,
        MoveOrderSendConfirm = 0204,
        MoveRackArrive = 0105,
        MoveRackArriveConfirm = 0205,
        MoveFinish = 0206,
        MoveFinishConfirm = 0106,
        PickOrderSend = 0107,
        PickOrderSendConfirm = 0207,
        PickRackArrive = 0108,
        PickRackArriveConfirm = 0208,
        PickFinish = 0209,
        PickFinishConfirm = 0109,
        PackOrderSend = 0110,
        PackOrderSendConfirm = 0210,
        PackFinish = 0211,
        PackFinishConfirm = 0111,
        SpMoveConfirm = 0150,
        SpMoveConfirmResponse = 0250,
        SpMoveRegister = 0251,
        SpMoveRegisterConfirm = 0151,
        SpMoveOrderSend = 0152,
        SpMoveOrderSendConfirm = 0252,
        SpMoveRackArrive = 0153,
        SpMoveRackArriveConfirm = 0253,
        SpMoveFinish = 0254,
        SpMoveFinishConfirm = 0154
    }
}
