using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.CommunicationFormat
{
    /// <summary>
    /// 通用请求格式
    /// </summary>
    public interface IWCSHttpRequest<T>
    {
        /// <summary>
        /// 请求名称
        /// </summary>
        string action { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        string version { get; set; }

        /// <summary>
        /// App版本号
        /// </summary>
        string appver { get; set; }

        /// <summary>
        /// 请求时间戳
        /// </summary>
        string req_time { get; set; }

        /// <summary>
        /// 请求数据
        /// </summary>
        T data { get; set; }
    }

    /// <summary>
    /// 泛型请求类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HttpRequest<T> : IWCSHttpRequest<T>
    {
        /// <summary>
        /// 请求名称
        /// </summary>
        public string action { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public string version { get; set; }

        /// <summary>
        /// App版本号
        /// </summary>
        public string appver { get; set; }

        /// <summary>
        /// 请求时间戳
        /// </summary>
        public string req_time { get; set; }

        /// <summary>
        /// 请求数据
        /// </summary>
        public T data { get; set; }
    }
}
