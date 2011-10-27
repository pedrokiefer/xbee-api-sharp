using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NLog;
using XBee.Exceptions;
using XBee.Frames;

namespace XBee
{
    public enum ApiTypeValue : byte
    {
        Disabled = 0x00,
        Enabled = 0x01,
        EnabledWithEscape = 0x02,
        Unknown = 0xFF
    }

    public class XBee
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private IXBeeConnection connection;

        private bool frameReceived = false;
        private XBeeFrame lastFrame = null;
        private IPacketReader reader;
        private ApiTypeValue apiType;


        public ApiTypeValue ApiType
        {
            get { return apiType; }
            set
            {
                apiType = value;
                reader = PacketReaderFactory.GetReader(apiType);
                reader.FrameReceived += FrameReceivedEvent;
            }
        }

        public void SetConnection(IXBeeConnection connection)
        {
            this.connection = connection;
            this.connection.Open();
            this.connection.SetPacketReader(reader);
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

            lastFrame = null;
            frameReceived = false;
            while (!frameReceived)
            {
                Thread.Sleep(10);
            }

            return lastFrame;
        }

        private void FrameReceivedEvent(object sender, FrameReceivedArgs args)
        {
            frameReceived = true;
            lastFrame = args.Response;
            logger.Debug(args.Response);
        }
    }
}
