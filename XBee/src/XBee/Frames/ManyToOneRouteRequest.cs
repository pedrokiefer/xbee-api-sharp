using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XBee.Frames
{
    public class ManyToOneRouteRequest : XBeeFrame
    {
        public ManyToOneRouteRequest()
        {
            this.CommandId = XBeeAPICommandId.MANYTOONE_ROUTE_REQUEST_INDICATOR;
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
