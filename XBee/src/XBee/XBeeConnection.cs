using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace XBee.src.XBee
{
    public interface XBeeConnection
    {
        public Stream GetInputStream();
        public Stream GetOutputStream();
        public void close();
    }
}
