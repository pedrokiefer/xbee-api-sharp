using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace XBee.Frames
{
     public class ZigBeeExplicitRXIndicator : XBeeFrame
    {
        public ZigBeeExplicitRXIndicator()
        {
            this.CommandId = XBeeAPICommandId.EXPLICIT_RX_INDICATOR_RESPONSE;
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
