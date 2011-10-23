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
    class ATCommandTest
    {
        [Test]
        public void TestATCommandND()
        {
            var cmd = new ATCommand(AT.ND);
            Assert.AreEqual(new byte[] { 0x08, 0x00, (byte)'N', (byte)'D' }, cmd.ToByteArray());
        }

        [Test]
        public void TestATCommandDH()
        {
            var cmd = new ATCommand(AT.DH);
            cmd.SetValue(0x11223300);
            Assert.AreEqual(new byte[] { 0x08, 0x00, (byte)'D', (byte)'H', 0x11, 0x22, 0x33, 0x00 }, cmd.ToByteArray());
        }

        [Test]
        public void TestATCommandDHwithFrameId()
        {
            var cmd = new ATCommand(AT.DH);
            cmd.FrameId = 0x02;
            Assert.AreEqual(new byte[] { 0x08, 0x02, (byte)'D', (byte)'H' }, cmd.ToByteArray());
        }

        [Test]
        public void TestATQueueCommandDH()
        {
            var cmd = new ATQueueCommand(AT.DH);
            cmd.SetValue(0x11223300);
            Assert.AreEqual(new byte[] { 0x09, 0x00, (byte)'D', (byte)'H', 0x11, 0x22, 0x33, 0x00 }, cmd.ToByteArray());
        }
    }
}
