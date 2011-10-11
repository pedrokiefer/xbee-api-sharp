using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
