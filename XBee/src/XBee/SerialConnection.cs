using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;

namespace XBee
{
    public class SerialConnection : XBeeConnection
    {
        private SerialPort serialPort;

        public SerialConnection()
        {
            serialPort = new SerialPort();
        }

        public Stream GetStream()
        {
            return serialPort.BaseStream;
        }

        public void Close()
        {
            serialPort.Close();
        }
    }
}
