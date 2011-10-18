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
            this.commandId = XBeeAPICommandId.RECEIVE_PACKET_RESPONSE;
        }

        public override byte[] ToByteArray()
        {
            return new byte[] { };
        }
    }
}
