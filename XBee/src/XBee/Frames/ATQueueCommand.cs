using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XBee.Frames
{
    public class ATQueueCommand : ATCommand
    {
        public ATQueueCommand(AT atCommand) : base(atCommand)
        {
            this.commandId = XBeeAPICommandId.AT_QUEUE_REQUEST;
        }
    }
}
