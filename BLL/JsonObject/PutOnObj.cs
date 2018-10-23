using System;
using System.Collections.Generic;
using System.Text;
using BLL.CommunicationFormat;
using BLL.Utils;

namespace BLL.JsonObject
{
    /// <summary>
    /// 上架单发送Data
    /// </summary>
    public class PutOnOrderSendData
    {
        public int? taskId { get; set; }
        public string pthNo { get; set; }
        public int? pthId { get; set; }
        public string ptlWorkingPosition { get; set; }
        public string ptlRackCode { get; set; }
        public char? ptlRackSide { get; set; }
        public PutOnOrderSendDetail detail { get; set; }
    }

    /// <summary>
    ///  上架单发送Detail
    /// </summary>
    public class PutOnOrderSendDetail
    {
        public int? ptlId { get; set; }
        public string ptlLocationCode { get; set; }
        public string ptlMatCode { get; set; }
        public string ptlMatName { get; set; }
        public string ptlMatBarcode { get; set; }
        public string ptlMatStatusCode { get; set; }
        public int? ptlExpectQty { get; set; }
        public string ptlLotNo { get; set; }
        public string ptlManufDate { get; set; }
        public string ptlExpiryDate { get; set; }
        public string ptlRecvDate { get; set; }
    }

    /// <summary>
    /// 上架单发送RespondData
    /// </summary>
    public class PutOnOrderSendResponseData : IWCSToWMSBySocket
    {
        public int? taskId { get; set; }

        public string ToSocketString()
        {
            return $"{SocketToWMSFormat.Start}{EnumFormat.ToFormatted(SocketMsgType.PutOnOrderSendConfirm)}{taskId}{SocketToWMSFormat.End}";
        }
    }

    /// <summary>
    /// (上架单)货架到达工位Data
    /// </summary>
    public class PutOnArriveData
    {
        public int? taskId { get; set; }
    }

    /// <summary>
    /// (上架单)货架到达工位ResponseData
    /// </summary>
    public class PutOnArriveResponseData : IWCSToWMSBySocket
    {
        public int? taskId { get; set; }

        public string ToSocketString()
        {
            return $"{SocketToWMSFormat.Start}{EnumFormat.ToFormatted(SocketMsgType.PutOnRackArriveConfirm)}{taskId}{SocketToWMSFormat.End}";
        }
    }

    /// <summary>
    /// 上架完成通知Data
    /// </summary>
    public class PutOnFinishData : IWCSToWMSBySocket, ISubWCSToWMSBySocket
    {
        public int? taskId { get; set; }
        public List<PutOnFinishDetail> detail { get; set; }

        public string ToSocketString()
        {
            return $"{SocketToWMSFormat.Start}{EnumFormat.ToFormatted(SocketMsgType.PutOnFinish)}{taskId}{ToSubSocketString()}{SocketToWMSFormat.End}";
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
                stringBuilder.Append(property.ptlId);
                stringBuilder.Append(SocketToWMSFormat.Split);
                stringBuilder.Append(property.ptlActureQty);
            }
            return stringBuilder.ToString();
        }
    }

    /// <summary>
    /// 上架完成通知Detail
    /// </summary>
    public class PutOnFinishDetail
    {
        public int? ptlId { get; set; }
        public int? ptlActureQty { get; set; }
    }
}
