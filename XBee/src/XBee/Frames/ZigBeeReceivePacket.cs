using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XBee.Frames
{
    public class ZigBeeReceivePacket : XBeeFrame
    {
        public ZigBeeReceivePacket()
        {
            this.CommandId = XBeeAPICommandId.RECEIVE_PACKET_RESPONSE;
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
