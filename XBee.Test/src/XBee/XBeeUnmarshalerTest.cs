using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NUnit.Framework;
using XBee;
using XBee.Frames;
using XBee.Exceptions;

namespace XBee.Test
{
    [TestFixture]
    class XBeeUnmarshalerTest
    {

        public class NotXBeeFrame
        {
            public NotXBeeFrame() { }
        }

        public class XBeeUnknownFrame : XBeeFrame
        {
            public XBeeUnknownFrame() { }

            public override byte[] ToByteArray()
            {
                return new byte[] { };
            }

            public override void Parse(MemoryStream data)
            {
                throw new NotImplementedException();
            }
        }

        [Test]
        [ExpectedException(typeof(XBeeException), ExpectedMessage = "Invalid Frame Handler")]
        public void TestXBeeUnmarshalerRegisterWrong()
        {
            XBeePacketUnmarshaler.registerResponseHandler(XBeeAPICommandId.REMOTE_AT_REQUEST, typeof(NotXBeeFrame));
        }

        [Test]
        public void TestXBeeUnmarshalerRegister()
        {
            XBeePacketUnmarshaler.registerResponseHandler(XBeeAPICommandId.UNKNOWN, typeof(XBeeUnknownFrame));
        }

        [Test]
        public void TestXBeeUnmarshalerATCommandWrongLength()
        {
            var packetData = new byte[] { 0x00, 0x08, 0x08, 0x01, (byte) 'D', (byte) 'H' };
            Assert.Throws<XBeeFrameException>(delegate { XBeeFrame frame = XBeePacketUnmarshaler.Unmarshal(packetData); });
        }

        [Test]
        public void TestXBeeUnmarshalerATCommandNoData()
        {
            var packetData = new byte[] { 0x00, 0x04, 0x08, 0x01, (byte) 'D', (byte) 'H' };

            XBeeFrame frame = XBeePacketUnmarshaler.Unmarshal(packetData);
            Assert.That(frame, Is.InstanceOf<ATCommand>());
            ATCommand cmd = (ATCommand) frame;
            Assert.That(cmd.FrameId, Is.EqualTo(0x01));
            Assert.That(cmd.Command, Is.EqualTo(AT.DH));
        }

        [Test]
        public void TestXBeeUnmarshalerATCommand()
        {
            var packetData = new byte[] { 0x00, 0x08, 0x08, 0x01, (byte) 'D', (byte) 'H', 0x11, 0x22, 0x33, 0x00 };

            XBeeFrame frame = XBeePacketUnmarshaler.Unmarshal(packetData);
            Assert.That(frame, Is.InstanceOf<ATCommand>());
            ATCommand cmd = (ATCommand) frame;
            Assert.That(cmd.FrameId, Is.EqualTo(0x01));
            Assert.That(cmd.Command, Is.EqualTo(AT.DH));
        }
    }
}
