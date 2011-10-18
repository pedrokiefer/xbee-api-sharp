using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using XBee;
using XBee.Frames;

namespace XBee.Test.Frames
{
    [TestFixture]
    class TransmitDataRequestTest
    {
        [Test]
        public void TestTransmitDataRequestBroadcast()
        {
            XBeeNode broadcast = new XBeeNode();
            broadcast.Address16 = XBeeAddress16.ZNET_BROADCAST;
            broadcast.Address64 = XBeeAddress64.BROADCAST;

            TransmitDataRequest frame = new TransmitDataRequest(broadcast);
            Assert.AreEqual(new byte[] { 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFE, 0x00, 0x00 }, frame.ToByteArray());
        }

        [Test]
        public void TestTransmitDataRequestBroadcastFrameId()
        {
            XBeeNode broadcast = new XBeeNode();
            broadcast.Address16 = XBeeAddress16.ZNET_BROADCAST;
            broadcast.Address64 = XBeeAddress64.BROADCAST;

            TransmitDataRequest frame = new TransmitDataRequest(broadcast);
            frame.FrameId = 1;
            Assert.AreEqual(new byte[] { 0x10, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFE, 0x00, 0x00 }, frame.ToByteArray());
        }

        [Test]
        public void TestTransmitDataRequestBroadcastRadius()
        {
            XBeeNode broadcast = new XBeeNode();
            broadcast.Address16 = XBeeAddress16.ZNET_BROADCAST;
            broadcast.Address64 = XBeeAddress64.BROADCAST;

            TransmitDataRequest frame = new TransmitDataRequest(broadcast);
            frame.BroadcastRadius = 2;
            Assert.AreEqual(new byte[] { 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFE, 0x02, 0x00 }, frame.ToByteArray());
        }

        [Test]
        public void TestTransmitDataRequestBroadcastRadiusOptions()
        {
            XBeeNode broadcast = new XBeeNode();
            broadcast.Address16 = XBeeAddress16.ZNET_BROADCAST;
            broadcast.Address64 = XBeeAddress64.BROADCAST;

            TransmitDataRequest frame = new TransmitDataRequest(broadcast);
            frame.BroadcastRadius = 2;
            frame.Options = TransmitDataRequest.OptionValues.DISABLE_ACK | TransmitDataRequest.OptionValues.EXTENDED_TIMEOUT;
            Assert.AreEqual(new byte[] { 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFE, 0x02, 0x41 }, frame.ToByteArray());
        }

        [Test]
        public void TestTransmitDataRequestBroadcastRadiusOptionsData()
        {
            XBeeNode broadcast = new XBeeNode();
            broadcast.Address16 = XBeeAddress16.ZNET_BROADCAST;
            broadcast.Address64 = XBeeAddress64.BROADCAST;

            TransmitDataRequest frame = new TransmitDataRequest(broadcast);
            frame.BroadcastRadius = 2;
            frame.Options = TransmitDataRequest.OptionValues.DISABLE_ACK | TransmitDataRequest.OptionValues.EXTENDED_TIMEOUT;
            frame.SetRFData(new byte[] { 0x11, 0x22, 0x33, 0x00 });
            Assert.AreEqual(new byte[] { 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFE, 0x02, 0x41, 0x11, 0x22, 0x33, 0x00 }, frame.ToByteArray());
        }
    }
}
