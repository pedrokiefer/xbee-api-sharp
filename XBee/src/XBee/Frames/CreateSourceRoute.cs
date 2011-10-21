using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XBee.Frames
{
    public class CreateSourceRoute : XBeeFrame
    {

        private XBeeNode destination;
        private readonly PacketParser parser;

        public CreateSourceRoute(PacketParser parser)
        {
            this.parser = parser;
            this.CommandId = XBeeAPICommandId.CREATE_SOURCE_ROUTE;
        }

        public CreateSourceRoute()
        {
            this.CommandId = XBeeAPICommandId.CREATE_SOURCE_ROUTE;
        }

        public override byte[] ToByteArray()
        {
            return new byte[] { };
        }

        public override void Parse()
        {
            destination = new XBeeNode { Address64 = parser.ReadAddress64(), Address16 = parser.ReadAddress16() };

        }
    }
}
