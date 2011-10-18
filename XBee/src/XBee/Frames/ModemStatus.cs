using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XBee.Frames
{
    public class ModemStatus : XBeeFrame
    {
        public ModemStatus()
        {
            this.commandId = XBeeAPICommandId.MODEM_STATUS_RESPONSE;
        }

        public override byte[] ToByteArray()
        {
            return new byte[] { };
        }
    }
}
