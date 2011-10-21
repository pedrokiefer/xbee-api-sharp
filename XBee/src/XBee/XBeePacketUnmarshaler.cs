using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NLog;
using XBee.Exceptions;
using XBee.Frames;

namespace XBee
{
    public class XBeePacketUnmarshaler
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private static readonly Dictionary<XBeeAPICommandId, Type> framesMap = createFramesMap();

        public static XBeeFrame Unmarshal(XBeePacket packet)
        {
            return new TransmitDataRequest(new XBeeNode());
        }

        private static Dictionary<XBeeAPICommandId, Type> createFramesMap()
        {
            var map = new Dictionary<XBeeAPICommandId, Type>
                {
                    {XBeeAPICommandId.AT_COMMAND_REQUEST, typeof (ATCommand)},
                    {XBeeAPICommandId.AT_COMMAND_QUEUE_REQUEST, typeof (ATQueueCommand)},
                    {XBeeAPICommandId.TRANSMIT_DATA_REQUEST, typeof (TransmitDataRequest)},
                    {XBeeAPICommandId.EXPLICIT_ADDR_REQUEST, typeof (ExplicitAddressingTransmit)},
                    {XBeeAPICommandId.REMOTE_AT_COMMAND_REQUEST, typeof (RemoteATCommand)},
                    {XBeeAPICommandId.CREATE_SOURCE_ROUTE, typeof (CreateSourceRoute)},
                    {XBeeAPICommandId.AT_COMMAND_RESPONSE, typeof (ATCommandResponse)},
                    {XBeeAPICommandId.MODEM_STATUS_RESPONSE, typeof (ModemStatus)},
                    {XBeeAPICommandId.TRANSMIT_STATUS_RESPONSE, typeof (ZigBeeTransmitStatus)},
                    {XBeeAPICommandId.RECEIVE_PACKET_RESPONSE, typeof (ZigBeeReceivePacket)},
                    {XBeeAPICommandId.EXPLICIT_RX_INDICATOR_RESPONSE, typeof (ZigBeeExplicitRXIndicator)},
                    {XBeeAPICommandId.IO_SAMPLE_RESPONSE, typeof (ZigBeeIODataSample)},
                    {XBeeAPICommandId.SENSOR_READ_INDICATOR, typeof (SensorReadIndicator)},
                    {XBeeAPICommandId.NODE_IDENTIFIER_RESPONSE, typeof (NodeIdentification)},
                    {XBeeAPICommandId.REMOTE_AT_COMMAND_RESPONSE, typeof (RemoteCommandResponse)},
                    {XBeeAPICommandId.FIRMWARE_UPDATE_STATUS, typeof (OverAirUpdateStatus)},
                    {XBeeAPICommandId.ROUTE_RECORD_INDICATOR, typeof (RouteRecordIndicator)},
                    {XBeeAPICommandId.MANYTOONE_ROUTE_REQUEST_INDICATOR, typeof (ManyToOneRouteRequest)}
                };

            return map;
        }

        public static XBeeFrame Unmarshal(byte[] packetData)
        {
            var dataStream = new MemoryStream(packetData);
            return Unmarshal(dataStream);
        }

        public static XBeeFrame Unmarshal(MemoryStream dataStream)
        {
            XBeeFrame frame;
            var length = (uint) (dataStream.ReadByte() << 8 | dataStream.ReadByte());

            if ((length == 0) || (length > 0xFFFF))
                throw new XBeeFrameException("Invalid Frame Lenght");

            if (length != dataStream.Length - 2)
                throw new XBeeFrameException("Invalid Frame Lenght");

            var cmd = (XBeeAPICommandId) dataStream.ReadByte();

            if (framesMap.ContainsKey(cmd)) {
                frame = (XBeeFrame) Activator.CreateInstance(framesMap[cmd], new PacketParser(dataStream));
                frame.Parse();
            } else {
                throw new XBeeFrameException(String.Format("Unsupported Command Id 0x{0:X2}", cmd));
            }

            return frame;
        }

        public static void RegisterFrameHandler(XBeeAPICommandId commandId, Type typeHandler)
        {
            if (!typeHandler.IsSubclassOf(typeof(XBeeFrame)))
                throw new XBeeException("Invalid Frame Handler");

            if (framesMap.ContainsKey(commandId)) {
                logger.Info(String.Format("Overriding Frame Handler: {0} with {1} for API Id: 0x{2:x2}", framesMap[commandId].Name, typeHandler.Name, (byte) commandId));
                framesMap[commandId] = typeHandler;
            } else {
                logger.Info(String.Format("Adding Frame Handler: {0} for API Id: 0x{1:x2}", typeHandler.Name, (byte) commandId));
                framesMap.Add(commandId, typeHandler);
            }
        }
    }
}
