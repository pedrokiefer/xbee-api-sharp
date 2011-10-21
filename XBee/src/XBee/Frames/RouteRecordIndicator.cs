using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XBee.Frames
{
    public class RouteRecordIndicator : XBeeFrame
    {
        public RouteRecordIndicator()
        {
            this.CommandId = XBeeAPICommandId.ROUTE_RECORD_INDICATOR;
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
