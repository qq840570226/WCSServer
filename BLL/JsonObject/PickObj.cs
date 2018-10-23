using System;
using System.Collections.Generic;
using System.Text;
using BLL.CommunicationFormat;
using BLL.Utils;

namespace BLL.JsonObject
{
    /// <summary>
    /// 拣货单发送Data
    /// </summary>
    public class PickOrderSendData
    {
        public int? taskId { get; set; }
        public string wrhNo { get; set; }
        public int? wrhId { get; set; }
        public string wrlWorkingPosition { get; set; }
        public string wrlWorkingPositionPoint { get; set; }
        public string wrlRackCode { get; set; }
        public char? wrlRackSide { get; set; }
        public int? wrhTotalQty { get; set; }
        public int? wrlRackTotalQty { get; set; }
        public PickOrderSendDetail detail { get; set; }
    }

    /// <summary>
    /// 拣货单发送Detail
    /// </summary>
    public class PickOrderSendDetail
    {
        public int? wrlId { get; set; }
        public string wrlLocationCode { get; set; }
        public string wrlMatCode { get; set; }
        public string wrlMatName { get; set; }
        public string wrlMatBarcode { get; set; }
        public string wrlMatStatusCode { get; set; }
        public int? wrlExpectQty { get; set; }
        public string onhWaveAssortCellNo { get; set; }
        public string ptlLotNo { get; set; }
        public string ptlManufDate { get; set; }
        public string ptlExpiryDate { get; set; }
        public string ptlRecvDate { get; set; }
    }

    /// <summary>
    /// 拣货单发送ResponseData
    /// </summary>
    public class PickOrderSendResponseData : IWCSToWMSBySocket
    {
        public int? taskId { get; set; }

        public string ToSocketString()
        {
            return $"{SocketToWMSFormat.Start}{EnumFormat.ToFormatted(SocketMsgType.PickOrderSendConfirm)}{taskId}{SocketToWMSFormat.End}";
        }
    }

    /// <summary>
    /// (拣货单)货架到达Data
    /// </summary>
    public class PickArriveData
    {
        public int? taskId { get; set; }
    }

    /// <summary>
    /// (拣货单)货架到达ResponseData
    /// </summary>
    public class PickArriveResponseData : IWCSToWMSBySocket
    {
        public int? taskId { get; set; }

        public string ToSocketString()
        {
            return $"{SocketToWMSFormat.Start}{EnumFormat.ToFormatted(SocketMsgType.PickRackArriveConfirm)}{taskId}{SocketToWMSFormat.End}";
        }
    }

    /// <summary>
    /// 拣货完成通知Data
    /// </summary>
    public class PickFinishData : IWCSToWMSBySocket, ISubWCSToWMSBySocket
    {
        public int? taskId { get; set; }
        public List<PickFinishDetail> detail { get; set; }

        public string ToSocketString()
        {
            return $"{SocketToWMSFormat.Start}{EnumFormat.ToFormatted(SocketMsgType.PickFinish)}{taskId}{ToSubSocketString()}{SocketToWMSFormat.End}";
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
                stringBuilder.Append(property.wrlId);
                stringBuilder.Append(SocketToWMSFormat.Split);
                stringBuilder.Append(property.wrlActureQty);
            }
            return stringBuilder.ToString();
        }
    }

    /// <summary>
    /// 拣货完成通知Detail
    /// </summary>
    public class PickFinishDetail
    {
        public int? wrlId { get; set; }
        public int? wrlActureQty { get; set; }
    }
}
