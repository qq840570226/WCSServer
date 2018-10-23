using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.JsonObject
{
    /// <summary>
    /// WCS--> PLC(供件台扫描数据后发送供件命令)
    /// </summary>
    public class ProvideGoods
    {
        public byte? CommandNo { get; set; }
        public byte? LineNo { get; set; }
        public byte? TableNo { get; set; }
        public int? Index { get; set; }
        public byte? BlockNo { get; set; }

        public byte[] Msg { get; set; } = new byte[0x0d];

        public ProvideGoods() { }

        /// <summary>
        /// 字符数组型消息
        /// </summary>
        /// <param name="msg"></param>
        public ProvideGoods(byte[] msg)
        {
            if (msg.Length != 0x0d)
            {
                CommandNo = 1;
                LineNo = 0;
                TableNo = 0;
                Index = 0;
                BlockNo = 0;
            }
            else
            {
                Span<byte> span = msg;
                CommandNo = msg[3];
                LineNo = msg[4];
                TableNo = msg[5];
                var temp = span.Slice(6, 4);
                temp.Reverse();
                Index = BitConverter.ToInt32(temp.ToArray(), 0);
                BlockNo = msg[11];
                Msg = msg;
            }
        }

        /// <summary>
        /// 结构型消息
        /// </summary>
        /// <param name="msgStruct"></param>
        public ProvideGoods(PLCStruct.ProvideGoods msgStruct)
        {
            byte[] msg = msgStruct.ToByteArray();
            if (msg.Length != 0x0d)
            {
                CommandNo = 1;
                LineNo = 0;
                TableNo = 0;
                Index = 0;
                BlockNo = 0;
            }
            else
            {
                Span<byte> span = msg;
                CommandNo = msg[3];
                LineNo = msg[4];
                TableNo = msg[5];
                var temp = span.Slice(6, 4);
                temp.Reverse();
                Index = BitConverter.ToInt32(temp.ToArray(), 0);
                BlockNo = msg[11];
                Msg = msg;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in Msg)
            {
                stringBuilder.Append(Convert.ToString(item, 16).PadLeft(2, '0'));
            }
            return stringBuilder.ToString();
        }
    }
}
