using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XBee.Frames
{
    public class ZigBeeIODataSample : XBeeFrame
    {
        public ZigBeeIODataSample()
        {
            this.CommandId = XBeeAPICommandId.IO_SAMPLE_RESPONSE;
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
