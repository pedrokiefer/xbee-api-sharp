using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XBee.Exceptions;

namespace XBee
{
    public class PacketReaderFactory
    {
        public static IPacketReader GetReader(ApiTypeValue apiType)
        {
            IPacketReader reader = null;
            switch(apiType)
            {
                case ApiTypeValue.Disabled:
                case ApiTypeValue.Enabled:
                    reader = new PacketReader();
                    break;
                case ApiTypeValue.EnabledWithEscape:
                    reader = new EscapedPacketReader();
                    break;
                default:
                    throw new XBeeException("Invalid API Type");
            }

            return reader;
        }
    }
}
