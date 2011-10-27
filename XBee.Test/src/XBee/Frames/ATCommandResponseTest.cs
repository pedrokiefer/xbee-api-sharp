using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NUnit.Framework;
using XBee;
using XBee.Frames;

namespace XBee.Test.Frames
{
    [TestFixture]
    public class ATCommandResponseTest
    {
        [Test]
        public void TestATCommandResponseParse()
        {
            var packet = new byte[] { 0x00, 0x05, 0x88, 0x01, 0x42, 0x44, 0x00, 0xF0 };

            var frame = XBeePacketUnmarshaler.Unmarshal(packet);
            Assert.That(frame, Is.InstanceOf<ATCommandResponse>());

            var cmd = (ATCommandResponse) frame;
            Assert.That(cmd.FrameId, Is.EqualTo(0x01));
            Assert.That(cmd.Command, Is.EqualTo(AT.BaudRate));
            Assert.That(cmd.CommandStatus, Is.EqualTo(0));
        }
    }
}
