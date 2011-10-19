using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace XBee.Frames
{
    public class RouteRecordIndicator : XBeeFrame
    {
        public RouteRecordIndicator()
        {
            this.commandId = XBeeAPICommandId.ROUTE_RECORD_INDICATOR;
        }

        public override byte[] ToByteArray()
        {
            return new byte[] { };
        }

        public override void Parse(MemoryStream data)
        {
            throw new NotImplementedException();
        }
    }
}
