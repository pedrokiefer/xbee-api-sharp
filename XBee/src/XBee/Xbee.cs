using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;
using XBee.Exceptions;
using XBee.Frames;

namespace XBee
{
    public class XBee
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private XBeeConnection connection;

        public void SetConnection(XBeeConnection connection)
        {
            this.connection = connection;
        }

        public void SendRequest(XBeeFrame frame)
        {
            var packet = new XBeePacket(frame);
            packet.Assemble();
            connection.Write(packet.Data);
        }

        public XBeeFrame SendSynchronous(XBeeFrame frame, int timeout)
        {
            if (frame.FrameId == 0)
                throw new XBeeFrameException("FrameId cannot be zero on a synchronous request.");

            lock (this) {
                SendRequest(frame);
            }

            return new ATCommandResponse();
        }
    }
}
