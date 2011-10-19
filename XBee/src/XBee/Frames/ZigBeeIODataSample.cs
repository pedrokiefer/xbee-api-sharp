using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace XBee.Frames
{
    public class ZigBeeIODataSample : XBeeFrame
    {
        public ZigBeeIODataSample()
        {
            this.commandId = XBeeAPICommandId.IO_SAMPLE_RESPONSE;
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
