using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace BLL.TestServerForPLC
{
    public static class DataCache
    {
        public static ConcurrentQueue<JsonObject.ProvideGoods> ReceiveQueue { get; set; }
        public static ConcurrentQueue<string> CallbackQueue { get; set; }

        static DataCache()
        {
            ReceiveQueue = new ConcurrentQueue<JsonObject.ProvideGoods>();
            CallbackQueue = new ConcurrentQueue<string>();
        }
    }
}
