using System;
using System.Collections.Generic;
using System.Text;
using BLL.CommunicationFormat;
using DotNetty.Buffers;

namespace BLL.PLCStruct
{
    /// <summary>
    /// WCS--> PLC(供件台扫描数据后发送供件命令)
    /// </summary>
    public struct ProvideGoods : IWCSToPLCBySocket
    {
        readonly byte[] Msg;
        readonly int Length;

        /// <summary>
        /// 供件台扫描数据后发送供件命令
        /// </summary>
        /// <param name="lineNo">线体号</param>
        /// <param name="tableNo">台号</param>
        /// <param name="index">索引(4个字节)</param>
        /// <param name="blockNo">格口号</param>
        public ProvideGoods(byte lineNo, byte tableNo, int index, byte blockNo)
        {
            byte[] temp;
            Length = 0x0c + 0x01;
            Msg = new byte[Length];
            Msg[0] = 0x0c;
            Msg[1] = 0x01;
            Msg[2] = 0x02;
            Msg[3] = 0x01;
            Msg[4] = lineNo;
            Msg[5] = tableNo;
            temp = BitConverter.GetBytes(index);
            Array.Reverse(temp);
            Buffer.BlockCopy(temp, 0, Msg, 6, temp.Length);
            //Msg[6] = temp[3];
            //Msg[7] = temp[2];
            //Msg[8] = temp[1];
            //Msg[9] = temp[0];
            Msg[10] = 0x7c;
            Msg[11] = blockNo;
            Msg[12] = 0x01;
        }

        public byte[] ToByteArray()
        {
            return Msg;
        }

        public IByteBuffer ToByteBuffer()
        {
            IByteBuffer byteBuffer = Unpooled.Buffer(Length);
            byteBuffer.WriteBytes(Msg);
            return byteBuffer;
        }
    }
}
