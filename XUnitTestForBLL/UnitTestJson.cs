using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using BLL.JsonObject;

namespace XUnitTestForBLL
{
    public class UnitTestJson
    {
        [Fact(DisplayName = "创建同WMS的连接格式测试")]
        public void TestForCreateCommunication()
        {
            var actual = new CreateCommunication().ToSocketString();
            var expected = "STX010025QTX";
            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "上架单发送确认格式测试")]
        public void TestForPutOnOrderSendConfirm()
        {
            var actual = new PutOnOrderSendResponseData() { taskId = 999 }.ToSocketString();
            var expected = "STX0201999QTX";
            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "上架货架到达上架工位格式测试")]
        public void TestForPutOnArriveConfirm()
        {
            var actual = new PutOnArriveResponseData() { taskId = 888 }.ToSocketString();
            var expected = "STX0202888QTX";
            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "上架完成通知格式测试")]
        public void TestForPutOnFinishConfirm()
        {
            PutOnFinishData temp = new PutOnFinishData() { taskId = 1 };
            temp.detail = new List<PutOnFinishDetail>() { new PutOnFinishDetail() { ptlId = 11, ptlActureQty = 5 } };

            var actual = temp.ToSocketString();
            var expected = "STX02031|11|5QTX";
            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "商品移位发起确认格式测试")]
        public void TestForMoveConfirm()
        {
            var actual = new MoveConfirmResponseData() { mvhId = 555 }.ToSocketString();
            var expected = "STX0212555QTX";
            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "商品移位可移位格式测试")]
        public void TestForMoveRegisterConfirm()
        {
            var actual = new MoveRegisterResponseData() { mvhId = 222 }.ToSocketString();
            var expected = "STX0113222QTX";
            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "移位单发送格式测试")]
        public void TestForMoveOrderSendConfirm()
        {
            var actual = new MoveOrderSendResponseData() { taskId = 989 }.ToSocketString();
            var expected = "STX0204989QTX";
            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "移位单货架到了格式测试")]
        public void TestForMoveArriveConfirm()
        {
            var actual = new MoveArriveResponseData() { taskId = 99 }.ToSocketString();
            var expected = "STX020599QTX";
            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "位移完成通知格式测试")]
        public void TestForMoveFinishConfirm()
        {
            MoveFinishData temp = new MoveFinishData() { taskId = 12 };
            temp.detail = new List<MoveFinishDetail>() { new MoveFinishDetail() { mvlId = 11, mvlActureQty = 5 } };

            var actual = temp.ToSocketString();
            var expected = "STX020612|11|5QTX";
            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "拣货单发送确认格式测试")]
        public void TestForPickOrderSendConfirm()
        {
            var actual = new PickOrderSendResponseData() { taskId = 656 }.ToSocketString();
            var expected = "STX0207656QTX";
            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "拣货货架到达上架工位格式测试")]
        public void TestForPickArriveConfirm()
        {
            var actual = new PickArriveResponseData() { taskId = 777 }.ToSocketString();
            var expected = "STX0208777QTX";
            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "拣货完成通知格式测试")]
        public void TestForPickFinishConfirm()
        {
            PickFinishData temp = new PickFinishData() { taskId = 1 };
            temp.detail = new List<PickFinishDetail>() { new PickFinishDetail() { wrlId = 11, wrlActureQty = 5 } };

            var actual = temp.ToSocketString();
            var expected = "STX02091|11|5QTX";
            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "包装单发送确认格式测试")]
        public void TestForPackOrderSendConfirm()
        {
            var actual = new PackOrderSendResponseData() { onhExpressNo = "656" }.ToSocketString();
            var expected = "STX0210656QTX";
            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "包装完成通知格式测试")]
        public void TestForPackFinishConfirm()
        {
            PackFinishData temp = new PackFinishData() { onhExpressNo = "500" };
            temp.matDetail = new List<PackFinishMatDetail>() { new PackFinishMatDetail() { onlMatCode = "123", onlActureQty = 10 } };
            temp.packDetail = new List<PackFinishPackDetail>() { new PackFinishPackDetail() { packCaseCode = "13579", onlActureQty = 1 } };

            var actual = temp.ToSocketString();
            var expected = "STX0211500|123|10|13579|1QTX";
            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "耗材移位发起确认格式测试")]
        public void TestForSpMoveConfirm()
        {
            var actual = new SpMoveConfirmResponseData() { pctMvhId = 555 }.ToSocketString();
            var expected = "STX0250555QTX";
            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "耗材移位可移位格式测试")]
        public void TestForSpMoveRegisterConfirm()
        {
            var actual = new SpMoveRegisterResponseData() { pctMvhId = 222 }.ToSocketString();
            var expected = "STX0151222QTX";
            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "耗材单发送格式测试")]
        public void TestForSpMoveOrderSendConfirm()
        {
            var actual = new SpMoveOrderSendResponseData() { taskId = 989 }.ToSocketString();
            var expected = "STX0252989QTX";
            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "耗材单货架到了格式测试")]
        public void TestForSpMoveArriveConfirm()
        {
            var actual = new SpMoveArriveResponseData() { taskId = 99 }.ToSocketString();
            var expected = "STX025399QTX";
            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "耗材完成通知格式测试")]
        public void TestForSpMoveFinishConfirm()
        {
            SpMoveFinishData temp = new SpMoveFinishData() { taskId = 12 };
            temp.detail = new List<SpMoveFinishDetail>() { new SpMoveFinishDetail() { pctMvlId = 11, pctMvlActureQty = 5 } };

            var actual = temp.ToSocketString();
            var expected = "STX025412|11|5QTX";
            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "PLC/服务器 --> WCS(回应供件命令)")]
        public void TestForPLCProvideGoods()
        {
            var actual = new ProvideGoods(new byte[13] { 0x0c, 0x01, 0x02, 0x01, 0x02, 0x01, 0x00, 0x00, 0x00, 0x01, 0x7c, 0x05, 0x01 });
            Assert.Equal<byte?>(1, actual.CommandNo);
            Assert.Equal<byte?>(2, actual.LineNo);
            Assert.Equal<byte?>(1, actual.TableNo);
            Assert.Equal(1, actual.Index);
            Assert.Equal<byte?>(5, actual.BlockNo);
        }

    }
}
