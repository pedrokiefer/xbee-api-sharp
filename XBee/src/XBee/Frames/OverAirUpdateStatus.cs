using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XBee.Frames
{
    public class OverAirUpdateStatus : XBeeFrame
    {
        public OverAirUpdateStatus()
        {
            this.CommandId = XBeeAPICommandId.FIRMWARE_UPDATE_STATUS;
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
