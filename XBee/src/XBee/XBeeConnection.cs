using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace XBee
{
    public interface XBeeConnection
    {
        Stream GetStream();
        void Close();
    }
}
