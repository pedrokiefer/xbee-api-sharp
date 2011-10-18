using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XBee.Frames
{
    public class CreateSourceRoute : XBeeFrame
    {
        public CreateSourceRoute()
        {
            this.commandId = XBeeAPICommandId.CREATE_SOURCE_ROUTE;
        }

        public override byte[] ToByteArray()
        {
            return new byte[] { };
        }
    }
}
