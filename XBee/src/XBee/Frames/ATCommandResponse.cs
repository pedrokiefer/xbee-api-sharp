using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XBee.Frames
{
    public class ATCommandResponse : XBeeFrame
    {
        public ATCommandResponse()
        {
            this.CommandId = XBeeAPICommandId.AT_COMMAND_RESPONSE;
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
