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

        [Test]
        public void TestXBeeAddressZNetBroadcast16ToString()
        {
            Assert.That(XBeeAddress16.ZNET_BROADCAST.ToString(), Is.EqualTo("0xFF 0xFE"));
        }

        [Test]
        public void TestXBeeAddressBroadcast64ToString()
        {
            Assert.That(XBeeAddress64.BROADCAST.ToString(), Is.EqualTo("0x00 0x00 0x00 0x00 0x00 0x00 0xFF 0xFF"));
        }

        [Test]
        public void TestXBeeAddress16IsEqualSame()
        {
            XBeeAddress16 localAddress = new XBeeAddress16(0xAABB);
            Assert.That(localAddress.Equals(localAddress), Is.True);
        }

        [Test]
        public void TestXBeeAddress16IsEqualObject()
        {
            XBeeAddress16 localAddress = new XBeeAddress16(0xAABB);
            Assert.That(localAddress.Equals(new Object()), Is.False);
        }

        [Test]
        public void TestXBeeAddress16IsEqual()
        {
            XBeeAddress16 localAddress = new XBeeAddress16(0xFFFE);
            Assert.That(localAddress.Equals(XBeeAddress16.ZNET_BROADCAST), Is.True);
        }

        [Test]
        public void TestXBeeAddress16IsNotEqual()
        {
            XBeeAddress16 localAddress1 = new XBeeAddress16(0xFFFE);
            XBeeAddress16 localAddress2 = new XBeeAddress16(0xAABB);
            Assert.That(localAddress1.Equals(localAddress2), Is.False);
        }

        [Test]
        public void TestXBeeAddress64IsEqualSame()
        {
            XBeeAddress64 localAddress = new XBeeAddress64(0xAABB);
            Assert.That(localAddress.Equals(localAddress), Is.True);
        }

        [Test]
        public void TestXBeeAddress64IsEqualObject()
        {
            XBeeAddress64 localAddress = new XBeeAddress64(0xAABB);
            Assert.That(localAddress.Equals(new Object()), Is.False);
        }

        [Test]
        public void TestXBeeAddress64IsEqual()
        {
            XBeeAddress64 localAddress = new XBeeAddress64(0xFFFF);
            Assert.That(localAddress.Equals(XBeeAddress64.BROADCAST), Is.True);
        }

        [Test]
        public void TestXBeeAddress64IsNotEqual()
        {
            XBeeAddress64 localAddress1 = new XBeeAddress64(0xFFFE);
            XBeeAddress64 localAddress2 = new XBeeAddress64(0xAABB);
            Assert.That(localAddress1.Equals(localAddress2), Is.False);
        }
    }
}
