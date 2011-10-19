using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace XBee.Frames
{
    public class RemoteCommandResponse : XBeeFrame
    {
        public RemoteCommandResponse()
        {
            this.commandId = XBeeAPICommandId.REMOTE_AT_COMMAND_RESPONSE;
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
