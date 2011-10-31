using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NLog;
using XBee.Exceptions;
using XBee.Frames;
using XBee.Utils;

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

        private Thread receiveThread;
        private bool stopThread;

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

            /*
            receiveThread = new Thread(new ThreadStart(ReceiveData));
            receiveThread.Name = "Receive Data Thread";
            receiveThread.IsBackground = true;
            receiveThread.Start();
             */
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

            while (!frameReceived && timeout > 0) {
                Thread.Sleep(10);
                timeout -= 10;
            }

            return lastFrame;
        }

        public void StopReceiveDataThread()
        {
            try {
                if (receiveThread != null) {
                    stopThread = true;
                    receiveThread.Join(2000);
                    receiveThread.Abort();
                    receiveThread.Join(2000);
                }
            } catch (Exception e) {
                logger.Info(e);
            } finally {
                receiveThread = null;
            }
        }

        private void FrameReceivedEvent(object sender, FrameReceivedArgs args)
        {
            frameReceived = true;
            lastFrame = args.Response;
            logger.Debug(args.Response);
        }

        private void ReceiveData()
        {
            try {
                while (!stopThread) {

                }
            } catch {
            }
        }
    }
}
