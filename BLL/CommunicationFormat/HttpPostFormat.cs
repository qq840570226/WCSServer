using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.CommunicationFormat
{
    /// <summary>
    /// 对象--字符格式转换
    /// </summary>
    public static class HttpPostFormat
    {
        /// <summary>
        /// 转化为Post格式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpRequest"></param>
        /// <returns></returns>
        public static string ConvertToPost<T>(IWCSHttpRequest<T> httpRequest) where T : class
        {
            return $"action={httpRequest.action}&version={httpRequest.version}&appver={httpRequest.appver}&req_time={Utils.TimeStamp.ConvertLocalToTimestamp(DateTime.Now)}&data={JsonConvert.SerializeObject(httpRequest.data)}";
        }
    }
}
