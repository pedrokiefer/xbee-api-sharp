using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XBee
{
    public abstract class XBeeFrame
    {
        protected XBeeAPICommandId commandId;
        protected byte FrameId { get; set; }

        public XBeeAPICommandId getCommandId()
        {
            return this.commandId;
        }

        public abstract byte[] ToByteArray();
    }
}
