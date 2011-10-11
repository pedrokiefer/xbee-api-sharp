using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XBee
{
    public class XBeePacketMarshaler
    {

        public static XBeePacket Marshal(XBeeFrame frame)
        {
            return new XBeePacket(new byte[] {});
        }


    }
}
