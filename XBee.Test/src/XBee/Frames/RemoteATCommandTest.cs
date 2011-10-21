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
    class RemoteATCommandTest
    {
        [Test]
        public void TestRemoteATCommandND()
        {
            var broadcast = new XBeeNode();
            broadcast.Address16 = XBeeAddress16.ZNET_BROADCAST;
            broadcast.Address64 = XBeeAddress64.BROADCAST;

            var cmd = new RemoteATCommand(AT.ND, broadcast);
            cmd.FrameId = 1;

            Assert.AreEqual(new byte[] { 0x17, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFE, 0x00, (byte)'N', (byte)'D' }, cmd.ToByteArray());
        }

        [Test]
        public void TestRemoteATCommandDH()
        {
            var broadcast = new XBeeNode();
            broadcast.Address16 = XBeeAddress16.ZNET_BROADCAST;
            broadcast.Address64 = XBeeAddress64.BROADCAST;

            var cmd = new RemoteATCommand(AT.DH, broadcast);
            cmd.FrameId = 1;

            Assert.AreEqual(new byte[] { 0x17, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFE, 0x00, (byte)'D', (byte)'H', 0x11, 0x22, 0x33, 0x00 }, cmd.ToByteArray());
        }
    }
}
