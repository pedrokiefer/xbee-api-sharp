using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace XBee.Frames
{
    public class OverAirUpdateStatus : XBeeFrame
    {
        public OverAirUpdateStatus()
        {
            this.commandId = XBeeAPICommandId.FIRMWARE_UPDATE_STATUS;
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
