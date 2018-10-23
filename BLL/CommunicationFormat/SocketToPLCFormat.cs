using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.CommunicationFormat
{
    public interface IWCSToPLCBySocket
    {
        byte[] ToByteArray();
    }

    public interface IPLCToWCSBySocket<T> where T : struct
    {
        T ToStruct(byte[] input);
    }
}
