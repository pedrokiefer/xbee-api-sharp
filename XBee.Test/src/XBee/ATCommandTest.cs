using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using XBee;
using XBee.Frames;

namespace XBee.Test
{
    [TestFixture]
    class ATCommandTest
    {
        [Test]
        public void TestATCommandDH()
        {
            ATCommand cmd = new ATCommand(AT.DH);
            cmd.SetValue(0x11223300);
            Assert.AreEqual(new byte[] { 0x08, 0x00, (byte) 'D', (byte) 'H', 0x11, 0x22 }, cmd.ToByteArray());
        }

        [Test]
        public void TestATCommandDHwithFrameId()
        {
            ATCommand cmd = new ATCommand(AT.DH);
            cmd.FrameId = 0x02;
            Assert.AreEqual(new byte[] { 0x08, 0x02, (byte) 'D', (byte) 'H'}, cmd.ToByteArray());
        }

        [Test]
        public void TestATQueueCommandDH()
        {
            ATCommand cmd = new ATQueueCommand(AT.DH);
            cmd.SetValue(0x11223300);
            Assert.AreEqual(new byte[] { 0x09, 0x00, (byte) 'D', (byte) 'H', 0x11, 0x22 }, cmd.ToByteArray());
        }
    }
}
