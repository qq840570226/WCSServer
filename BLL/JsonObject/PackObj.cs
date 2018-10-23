using System;
using System.Collections.Generic;
using System.Text;
using BLL.CommunicationFormat;
using BLL.Utils;

namespace BLL.JsonObject
{
    /// <summary>
    /// 包装单发送Data
    /// </summary>
    public class PackOrderSendData
    {
        public string onhExpressNo { get; set; }
        public string onhOrgCode { get; set; }
        public int? onhOwnerCode { get; set; }
        public string onhOwnerNo { get; set; }
        public string onhCarrierCode { get; set; }
        public string onhPrintType { get; set; }
        public string onhSender { get; set; }
        public string onhSenderTel { get; set; }
        public string onhSenderMobile { get; set; }
        public string onhSenderAddress { get; set; }
        public string onhSenderPostCode { get; set; }
        public string onhConsignee { get; set; }
        public string onhConsigneeTel { get; set; }
        public string onhConsigneeMobile { get; set; }
        public string onhConsAddressProvince { get; set; }
        public string onhConsAddressCity { get; set; }
        public string onhConsAddressDistrict { get; set; }
        public string onhConsAddress { get; set; }
        public string onhConsPostCode { get; set; }
        public string onhSetPackageDestination { get; set; }
        public decimal? onhActualToralAmount { get; set; }
        public string onhRemarks { get; set; }
        public string onhPlatformCode { get; set; }
        public string onhPlatformName { get; set; }
        public string onhShopName { get; set; }
        public string onhTransactionNo { get; set; }
        public string onhBuyerNickName { get; set; }
        public string onhBuyerMessage { get; set; }
        public string onhSellerMessage { get; set; }
        public char? onhIsCod { get; set; }
        public decimal? onhCodAmount { get; set; }
        public char? onhParcelInsurance { get; set; }
        public decimal? onhInsuranceAmount { get; set; }
        public string onhPkgWorkingPosition { get; set; }
        public string onhPackCaseCodeRecommend { get; set; }
        public string onhPackCaseCodeRange { get; set; }
        public int? onlTotalQty { get; set; }
        public int? onlCurrentQty { get; set; }
        public List<PackOrderSendDetail> detail { get; set; }
    }

    /// <summary>
    /// 包装单发送Detail
    /// </summary>
    public class PackOrderSendDetail
    {
        public int? onlId { get; set; }
        public string onlMatCode { get; set; }
        public string onlMatName { get; set; }
        public string onllMatBarcode { get; set; }
        public int? onlExpectQty { get; set; }
    }

    /// <summary>
    /// 包装单发送ResponseData
    /// </summary>
    public class PackOrderSendResponseData : IWCSToWMSBySocket
    {
        public string onhExpressNo { get; set; }

        public string ToSocketString()
        {
            return $"{SocketToWMSFormat.Start}{EnumFormat.ToFormatted(SocketMsgType.PackOrderSendConfirm)}{onhExpressNo}{SocketToWMSFormat.End}";
        }
    }

    /// <summary>
    /// 包装完成通知Data
    /// </summary>
    public class PackFinishData:IWCSToWMSBySocket, ISubWCSToWMSBySocket
    {
        public string onhExpressNo { get; set; }
        public List<PackFinishMatDetail> matDetail { get; set; }
        public List<PackFinishPackDetail> packDetail { get; set; }

        public string ToSocketString()
        {
            return $"{SocketToWMSFormat.Start}{EnumFormat.ToFormatted(SocketMsgType.PackFinish)}{onhExpressNo}{ToSubSocketString()}{SocketToWMSFormat.End}";
        }

        public string ToSubSocketString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (matDetail != null)
            {
                foreach (var property in matDetail)
                {
                    stringBuilder.Append(SocketToWMSFormat.Split);
                    stringBuilder.Append(property.onlMatCode);
                    stringBuilder.Append(SocketToWMSFormat.Split);
                    stringBuilder.Append(property.onlActureQty);
                }
            }

            if (packDetail != null)
            {
                foreach (var property in packDetail)
                {
                    stringBuilder.Append(SocketToWMSFormat.Split);
                    stringBuilder.Append(property.packCaseCode);
                    stringBuilder.Append(SocketToWMSFormat.Split);
                    stringBuilder.Append(property.onlActureQty);
                }
            }

            return stringBuilder.ToString();
        }
    }

    /// <summary>
    /// 包装完成通知matDetail
    /// </summary>
    public class PackFinishMatDetail
    {
        public string onlMatCode { get; set; }
        public int? onlActureQty { get; set; }
    }

    /// <summary>
    /// 包装完成通知packDetail
    /// </summary>
    public class PackFinishPackDetail
    {
        public string packCaseCode { get; set; }
        public int? onlActureQty { get; set; }
    }
}
