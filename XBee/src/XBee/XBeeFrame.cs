using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XBee
{
    public abstract class XBeeFrame
    {
        protected XBeeAPICommandId CommandId;
        public byte FrameId { get; set; }

        public XBeeAPICommandId GetCommandId()
        {
            return this.CommandId;
        }

        public abstract byte[] ToByteArray();
        public abstract void Parse();
    }
}
