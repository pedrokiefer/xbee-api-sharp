using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XBee.Utils;

namespace XBee
{
    public abstract class XBeeAddress
    {
        public abstract byte[] GetAddress();

        public override string ToString()
        {
            return ByteUtils.toBase16(this.GetAddress());
        }
    }
}
