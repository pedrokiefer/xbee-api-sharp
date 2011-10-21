using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XBee.Frames
{
    public class ZigBeeTransmitStatus : XBeeFrame
    {
        public ZigBeeTransmitStatus()
        {
            this.CommandId = XBeeAPICommandId.TRANSMIT_STATUS_RESPONSE;
        }

        public override byte[] ToByteArray()
        {
            return new byte[] { };
        }

        public override void Parse()
        {
            throw new NotImplementedException();
        }
    }
}
