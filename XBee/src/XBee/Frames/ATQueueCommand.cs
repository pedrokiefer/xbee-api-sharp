using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace XBee.Frames
{
    public class ATQueueCommand : ATCommand
    {
        public ATQueueCommand(AT atCommand) : base(atCommand)
        {
            this.CommandId = XBeeAPICommandId.AT_COMMAND_QUEUE_REQUEST;
        }

        public override void Parse(MemoryStream data)
        {
            throw new NotImplementedException();
        }
    }
}
