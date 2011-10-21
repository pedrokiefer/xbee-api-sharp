using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XBee.Frames
{
    public class RemoteCommandResponse : XBeeFrame
    {
        public RemoteCommandResponse()
        {
            this.CommandId = XBeeAPICommandId.REMOTE_AT_COMMAND_RESPONSE;
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
