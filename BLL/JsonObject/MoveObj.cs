using System;
using System.Collections.Generic;
using System.Text;
using BLL.CommunicationFormat;
using BLL.Utils;

namespace BLL.JsonObject
{
    /// <summary>
    /// 商品位移发起确认Data
    /// </summary>
    public class MoveConfirmData
    {
        public int? mvhId { get; set; }
        public string mvhNo { get; set; }
        public MoveConfirmDetail detail { get; set; }
    }

    /// <summary>
    /// 商品位移发起确认Detail
    /// </summary>
    public class MoveConfirmDetail
    {
        public int? mvlId { get; set; }
        public string mvlSrcRackCode { get; set; }
        public char? mvlSrcRackSide { get; set; }
        public string mvlSrcLocation { get; set; }
        public string mvlDestRackCode { get; set; }
        public char? mvlDestRackSide { get; set; }
        public string mvlDestLocation { get; set; }
        public string mvlMatCode { get; set; }
        public string mvlMatName { get; set; }
        public string mvllMatBarcode { get; set; }
        public string mvlMatStatus { get; set; }
        public int? mvlExpectQty { get; set; }
        public string mvlLotNo { get; set; }
        public string mvlManufDate { get; set; }
        public string mvlExpiryDate { get; set; }
        public string mvlRecvDate { get; set; }
    }

    /// <summary>
    /// 商品位移发起确认ResponseData
    /// </summary>
    public class MoveConfirmResponseData : IWCSToWMSBySocket
    {
        public int? mvhId { get; set; }

        public string ToSocketString()
        {
            return $"{SocketToWMSFormat.Start}{EnumFormat.ToFormatted(SocketMsgType.MoveConfirmResponse)}{mvhId}{SocketToWMSFormat.End}";
        }
    }

    /// <summary>
    /// 商品位移许可注册Data
    /// </summary>
    public class MoveRegisterData
    {
        public int? mvhId { get; set; }
    }

    /// <summary>
    /// 商品位移许可注册ResponseData
    /// </summary>
    public class MoveRegisterResponseData : IWCSToWMSBySocket
    {
        public int? mvhId { get; set; }

        public string ToSocketString()
        {
            return $"{SocketToWMSFormat.Start}{EnumFormat.ToFormatted(SocketMsgType.MoveRegisterConfirm)}{mvhId}{SocketToWMSFormat.End}";
        }
    }

    /// <summary>
    /// 位移单发送Data
    /// </summary>
    public class MoveOrderSendData
    {
        public string mvhNo { get; set; }
        public int? mvhId { get; set; }
        public MoveOrderSendDetail detail { get; set; }
    }

    /// <summary>
    /// 位移单发送Detail
    /// </summary>
    public class MoveOrderSendDetail
    {
        public int? mvlId { get; set; }
        public string mvlSrcRackCode { get; set; }
        public char? mvlSrcRackSide { get; set; }
        public string mvlSrcLocation { get; set; }
        public string mvlDestRackCode { get; set; }
        public char? mvlDestRackSide { get; set; }
        public string mvlDestLocation { get; set; }
        public string mvlMatCode { get; set; }
        public string mvlMatName { get; set; }
        public string mvllMatBarcode { get; set; }
        public string mvlMatStatus { get; set; }
        public int? mvlExpectQty { get; set; }
        public string mvlLotNo { get; set; }
        public string mvlManufDate { get; set; }
        public string mvlExpiryDate { get; set; }
        public string mvlRecvDate { get; set; }
    }

    /// <summary>
    /// 位移单发送ResponseData
    /// </summary>
    public class MoveOrderSendResponseData : IWCSToWMSBySocket
    {
        public int? taskId { get; set; }

        public string ToSocketString()
        {
            return $"{SocketToWMSFormat.Start}{EnumFormat.ToFormatted(SocketMsgType.MoveOrderSendConfirm)}{taskId}{SocketToWMSFormat.End}";
        }
    }

    /// <summary>
    /// (位移单)货架到达Data
    /// </summary>
    public class MoveArriveData
    {
        public int? taskId { get; set; }
    }

    /// <summary>
    /// (位移单)货架到达ResponseData
    /// </summary>
    public class MoveArriveResponseData : IWCSToWMSBySocket
    {
        public int? taskId { get; set; }

        public string ToSocketString()
        {
            return $"{SocketToWMSFormat.Start}{EnumFormat.ToFormatted(SocketMsgType.MoveRackArriveConfirm)}{taskId}{SocketToWMSFormat.End}";
        }
    }

    /// <summary>
    /// 位移完成通知Data
    /// </summary>
    public class MoveFinishData : IWCSToWMSBySocket, ISubWCSToWMSBySocket
    {
        public int? taskId { get; set; }
        public List<MoveFinishDetail> detail { get; set; }

        public string ToSocketString()
        {
            return $"{SocketToWMSFormat.Start}{EnumFormat.ToFormatted(SocketMsgType.MoveFinish)}{taskId}{ToSubSocketString()}{SocketToWMSFormat.End}";
        }

        public string ToSubSocketString()
        {
            if (detail == null || detail?.Count == 0)
            {
                return "";
            }

            StringBuilder stringBuilder = new StringBuilder();
            foreach (var property in detail)
            {
                stringBuilder.Append(SocketToWMSFormat.Split);
                stringBuilder.Append(property.mvlId);
                stringBuilder.Append(SocketToWMSFormat.Split);
                stringBuilder.Append(property.mvlActureQty);
            }
            return stringBuilder.ToString();
        }
    }

    public class MoveFinishDetail
    {
        public int? mvlId { get; set; }
        public int? mvlActureQty { get; set; }
    }
}