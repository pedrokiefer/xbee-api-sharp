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

        public SerialConnection(string port, int baudRate)
        {
            serialPort = new SerialPort(port, baudRate);
        }

        public void Write(byte[] data)
        {
            serialPort.Write(data, 0, data.Length);
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
