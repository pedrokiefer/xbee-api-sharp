using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace XBee
{
    public interface IXBeeConnection
    {
        void Write(byte[] data);
        Stream GetStream();
        void Open();
        void Close();
        void SetPacketReader(IPacketReader reader);
    }
}
