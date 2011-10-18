using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NUnit.Framework;
using XBee;
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

    }
}
