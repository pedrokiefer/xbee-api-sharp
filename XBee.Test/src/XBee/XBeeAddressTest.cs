using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using XBee;

namespace XBee.Test
{
    [TestFixture]
    public class XBeeAddressTest
    {
        [Test]
        public void TestXBeeAddressBroadcast16()
        {
            Assert.AreEqual(new byte[] { 0xFF, 0xFF }, XBeeAddress16.BROADCAST.GetAddress());
        }

        [Test]
        public void TestXBeeAddressZNetBroadcast16()
        {
            Assert.AreEqual(new byte[] { 0xFF, 0xFE }, XBeeAddress16.ZNET_BROADCAST.GetAddress());
        }

        [Test]
        public void TestXBeeAddressBroadcast64()
        {
            Assert.AreEqual(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF }, XBeeAddress64.BROADCAST.GetAddress());
        }

        [Test]
        public void TestXBeeAddressZNetCoordinator64()
        {
            Assert.AreEqual(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, XBeeAddress64.ZNET_COORDINATOR.GetAddress());
        }

    }
}
