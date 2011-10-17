using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using XBee;

namespace XBee.Test
{
    [TestFixture]
    class XBeeChecksumTest
    {
        [Test]
        public void TestXBeeChecksumCalculate()
        {
            byte[] packet = new byte[] { 0x83, 0x56, 0x78, 0x24, 0x00, 0x01, 0x02, 0x00, 0x03, 0xff };
            Assert.AreEqual((byte)0x85, XBeeChecksum.Calculate(packet));
        }

        [Test]
        public void TestXBeeChecksumVerify()
        {
            byte[] packet = new byte[] { 0x83, 0x56, 0x78, 0x24, 0x00, 0x01, 0x02, 0x00, 0x03, 0xff, 0x85 };
            Assert.IsTrue(XBeeChecksum.Verify(packet));
        }

        [Test]
        public void TestXBeeChecksumVerifyFail()
        {
            byte[] packet = new byte[] { 0x83, 0x56, 0x78, 0x24, 0x00, 0x01, 0x02, 0x00, 0x03, 0xff, 0x83 };
            Assert.IsFalse(XBeeChecksum.Verify(packet));
        }

    }
}
