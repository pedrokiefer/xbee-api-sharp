using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace XBee.Frames
{
    public class CreateSourceRoute : XBeeFrame
    {
        public CreateSourceRoute()
        {
            this.CommandId = XBeeAPICommandId.CREATE_SOURCE_ROUTE;
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
