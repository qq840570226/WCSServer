using System;
using System.Collections.Generic;
using System.Text;
using BLL.CommunicationFormat;

namespace BLL.Utils
{
    public static class EnumFormat
    {
        /// <summary>
        /// 转换WMS枚举信息为补位字符串
        /// </summary>
        /// <param name="socketMsgType"></param>
        /// <returns></returns>
        public static string ToFormatted(SocketMsgType socketMsgType)
        {
            return Convert.ToString((int)socketMsgType, 10).PadLeft(4, '0');
        }
    }
}
