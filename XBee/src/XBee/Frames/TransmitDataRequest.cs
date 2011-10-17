using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XBee.Frames
{
    public class TransmitDataRequest : XBeeFrame
    {

        public override byte[] ToByteArray()
        {
            return new byte[] { };
        }
    }
}
