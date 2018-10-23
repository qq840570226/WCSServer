using System;

namespace BLL.Utils
{
    /// <summary>
    /// 时间转换工具
    /// </summary>
    public static class TimeStamp
    {
        public static readonly DateTime UnixTimestampLocalZero = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), TimeZoneInfo.Local);
        public static readonly DateTime UnixTimestampUtcZero = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// 本地时间-->时间戳
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static long ConvertLocalToTimestamp(DateTime datetime)
        {
            return (long)(datetime - UnixTimestampLocalZero).TotalSeconds;
        }

        /// <summary>
        /// UTC时间-->时间戳
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static long ConvertUtcToTimestamp(DateTime datetime)
        {
            return (long)(datetime - UnixTimestampUtcZero).TotalSeconds;
        }

        /// <summary>
        /// 时间戳-->本地时间
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static DateTime ConvertLocalFromTimestamp(long timestamp)
        {
            return UnixTimestampLocalZero.AddSeconds(timestamp);
        }

        /// <summary>
        /// 时间戳-->UTC时间
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static DateTime ConvertUtcFromTimestamp(long timestamp)
        {
            return UnixTimestampUtcZero.AddSeconds(timestamp);
        }
    }
}
