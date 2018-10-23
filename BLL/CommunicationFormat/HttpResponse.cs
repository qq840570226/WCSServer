using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.CommunicationFormat
{
    /// <summary>
    /// 通用回应格式
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IHttpResponse<T> where T : class
    {
        /// <summary>
        /// 调用结果
        /// true：有合适的返回结果
        /// false：是接口调用失败
        /// </summary>
        bool success { get; set; }

        /// <summary>
        /// 服务器时间戳
        /// </summary>
        long req_time { get; set; }

        /// <summary>
        /// 服务返回结果
        /// </summary>
        T body { get; set; } 
    }

    /// <summary>
    /// 通用回应body格式
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IHttpResponseBody<T> where T : class
    {
        /// <summary>
        /// 响应结果
        /// true：有合适的返回结果
        /// false：没有合适的返回结果
        /// </summary>
        bool result { get; set; }

        /// <summary>
        /// 响应结果提示
        /// </summary>
        int msg { get; set; }

        /// <summary>
        /// 服务器操作时间
        /// </summary>
        string time { get; set; }

        /// <summary>
        /// 响应数据
        /// </summary>
        T data { get; set; }
    }

    /// <summary>
    /// 泛型回应类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HttpResponse<T> : IHttpResponse<T> where T : class
    {
        /// <summary>
        /// 调用结果
        /// true：有合适的返回结果
        /// false：是接口调用失败
        /// </summary>
        public bool success { get; set; }

        /// <summary>
        /// 服务器时间戳
        /// </summary>
        public long req_time { get; set; }

        /// <summary>
        /// 服务返回结果
        /// </summary>
        public T body { get; set; }
    }
}
