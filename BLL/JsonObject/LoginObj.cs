using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using BLL.CommunicationFormat;
using BLL.Utils;

namespace BLL.JsonObject
{
    /// <summary>
    /// 连接WMS
    /// </summary>
    public class CreateCommunication : IWCSToWMSBySocket
    {
        public string orgId { get; set; } = "25";

        public string ToSocketString()
        {
            return $"{SocketToWMSFormat.Start}{EnumFormat.ToFormatted(SocketMsgType.CreateCommunicationConfirm)}{orgId}{SocketToWMSFormat.End}";
        }
    }
    
    /// <summary>
    /// 登录请求参数内容
    /// </summary>
    public class LoginData
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public string userId { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// 工位id
        /// </summary>
        public string stationId { get; set; }
    }
}
