using System;
using System.Collections.Generic;
using System.Text;
using BLL.CommunicationFormat;
using BLL.Utils;

namespace BLL.JsonObject
{
    /// <summary>
    /// 耗材移位补货移位单发起确认Data
    /// </summary>
    public class SpMoveConfirmData
    {
        public string pctMvhNo { get; set; }
        public int? pctMvhId { get; set; }
        public string pctDwstDackCodes { get; set; }
        public SpMoveConfirmDetail detail { get; set; }
    }

    /// <summary>
    /// 耗材移位补货移位单发起确认Detail
    /// </summary>
    public class SpMoveConfirmDetail
    {
        public int? pctMvlId { get; set; }
        public string pctMvlSrcRackCode { get; set; }
        public char? pctMvlSrcRackSide { get; set; }
        public string pctMvlSrcLocation { get; set; }
        public string pctMvlDestRackCode { get; set; }
        public char? pctMvlDestRackSide { get; set; }
        public string pctMvlDestLocation { get; set; }
        public string pctMvlMatCode { get; set; }
        public string pctMvlMatName { get; set; }
        public string pctMvllMatBarcode { get; set; }
        public string pctMvlMatStatus { get; set; }
        public int? pctMvlExpectQty { get; set; }
    }

    /// <summary>
    /// 耗材移位补货移位单发起确认ResponseData
    /// </summary>
    public class SpMoveConfirmResponseData: IWCSToWMSBySocket
    {
        public int? pctMvhId { get; set; }

        public string ToSocketString()
        {
            return $"{SocketToWMSFormat.Start}{EnumFormat.ToFormatted(SocketMsgType.SpMoveConfirmResponse)}{pctMvhId}{SocketToWMSFormat.End}";
        }
    }

    /// <summary>
    /// 耗材位移许可注册Data
    /// </summary>
    public class SpMoveRegisterData
    {
        public int? pctMvhId { get; set; }
        public SpMoveRegisterDetail detail { get; set; }
    }

    /// <summary>
    /// 耗材位移许可注册Detail
    /// </summary>
    public class SpMoveRegisterDetail
    {
        public int? pctMvlId { get; set; }
        public string pctMvlDestRackCode { get; set; }
    }

    /// <summary>
    /// 耗材位移许可注册ResponseData
    /// </summary>
    public class SpMoveRegisterResponseData: IWCSToWMSBySocket
    {
        public int? pctMvhId { get; set; }

        public string ToSocketString()
        {
            return $"{SocketToWMSFormat.Start}{EnumFormat.ToFormatted(SocketMsgType.SpMoveRegisterConfirm)}{pctMvhId}{SocketToWMSFormat.End}";
        }
    }

    /// <summary>
    /// 耗材位移单发送Data
    /// </summary>
    public class SpMoveOrderSendData
    {
        public int? taskId { get; set; }
        public string pctMvhNo { get; set; }
        public int? pctMvhId { get; set; }
        public string pctMvhWorkingPosition { get; set; }
        public int? pctMvlTotalQty { get; set; }
        public int? pctMvlCurrentQty { get; set; }
        public object detail { get; set; }
    }

    /// <summary>
    /// 耗材位移单发送Detail
    /// </summary>
    public class SpMoveOrderSendDetail
    {
        public int? pctMvlId { get; set; }
        public string pctMvlSrcRackCode { get; set; }
        public char? pctMvlSrcRackSide { get; set; }
        public string pctMvlSrcLocation { get; set; }
        public string pctMvlDestRackCode { get; set; }
        public char? pctMvlDestRackSide { get; set; }
        public string pctMvlDestLocation { get; set; }
        public string pctMvlMatCode { get; set; }
        public string pctMvlMatName { get; set; }
        public string pctMvllMatBarcode { get; set; }
        public string pctMvlMatStatus { get; set; }
        public int? pctMvlExpectQty { get; set; }
    }

    /// <summary>
    /// 耗材位移单发送ResponseData
    /// </summary>
    public class SpMoveOrderSendResponseData:IWCSToWMSBySocket
    {
        public int? taskId { get; set; }

        public string ToSocketString()
        {
            return $"{SocketToWMSFormat.Start}{EnumFormat.ToFormatted(SocketMsgType.SpMoveOrderSendConfirm)}{taskId}{SocketToWMSFormat.End}";
        }
    }

    /// <summary>
    /// (耗材单)货架到达Data
    /// </summary>
    public class SpMoveArriveData
    {
        public int? taskId { get; set; }
    }

    /// <summary>
    /// (耗材单)货架到达ResponseData
    /// </summary>
    public class SpMoveArriveResponseData:IWCSToWMSBySocket
    {
        public int? taskId { get; set; }

        public string ToSocketString()
        {
            return $"{SocketToWMSFormat.Start}{EnumFormat.ToFormatted(SocketMsgType.SpMoveRackArriveConfirm)}{taskId}{SocketToWMSFormat.End}";
        }
    }

    /// <summary>
    /// 位移完成通知Data
    /// </summary>
    public class SpMoveFinishData:IWCSToWMSBySocket, ISubWCSToWMSBySocket
    {
        public int? taskId { get; set; }
        public List<SpMoveFinishDetail> detail { get; set; }

        public string ToSocketString()
        {
            return $"{SocketToWMSFormat.Start}{EnumFormat.ToFormatted(SocketMsgType.SpMoveFinish)}{taskId}{ToSubSocketString()}{SocketToWMSFormat.End}";
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
                stringBuilder.Append(property.pctMvlId);
                stringBuilder.Append(SocketToWMSFormat.Split);
                stringBuilder.Append(property.pctMvlActureQty);
            }
            return stringBuilder.ToString();
        }
    }

    /// <summary>
    /// 位移完成通知Detail
    /// </summary>
    public class SpMoveFinishDetail
    {
        public int? pctMvlId { get; set; }
        public int? pctMvlActureQty { get; set; }
    }

    /// <summary>
    /// 位移完成通知ResponseData
    /// </summary>
    public class SpMoveFinishResponseData
    {
        public int? taskId { get; set; }
    }
}
