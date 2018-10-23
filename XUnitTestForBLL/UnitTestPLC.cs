using System;
using Xunit;
using BLL.PLCStruct;

namespace XUnitTestForBLL
{
    public class UnitTestPLC
    {
        [Fact(DisplayName = "PLC供件命令压缩至字符数组")]
        public void TestForPLCProvideGoods()
        {
            var actual = new ProvideGoods(2, 1, 1, 5).ToByteArray();
            byte[] expected = new byte[13] { 0x0c, 0x01, 0x02, 0x01, 0x02, 0x01, 0x00, 0x00, 0x00, 0x01, 0x7c, 0x05, 0x01 };
            Assert.Equal(expected, actual);
        }


    }
}
