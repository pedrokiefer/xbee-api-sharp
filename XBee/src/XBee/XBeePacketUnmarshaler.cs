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
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static Dictionary<XBeeAPICommandId, Type> framesMap = createFramesMap();

        public static XBeeFrame Unmarshal(XBeePacket packet)
        {
            return new TransmitDataRequest(new XBeeNode());
        }

        private static Dictionary<XBeeAPICommandId, Type> createFramesMap()
        {
            Dictionary<XBeeAPICommandId, Type> map = new Dictionary<XBeeAPICommandId, Type>();

            map.Add(XBeeAPICommandId.AT_COMMAND_REQUEST, typeof(ATCommand));
            map.Add(XBeeAPICommandId.AT_COMMAND_QUEUE_REQUEST, typeof(ATQueueCommand));
            map.Add(XBeeAPICommandId.TRANSMIT_DATA_REQUEST, typeof(TransmitDataRequest));
            map.Add(XBeeAPICommandId.EXPLICIT_ADDR_REQUEST, typeof(ExplicitAddressingTransmit));
            map.Add(XBeeAPICommandId.REMOTE_AT_COMMAND_REQUEST, typeof(RemoteATCommand));
            map.Add(XBeeAPICommandId.CREATE_SOURCE_ROUTE, typeof(CreateSourceRoute));
            map.Add(XBeeAPICommandId.AT_COMMAND_RESPONSE, typeof(ATCommandResponse));
            map.Add(XBeeAPICommandId.MODEM_STATUS_RESPONSE, typeof(ModemStatus));
            map.Add(XBeeAPICommandId.TRANSMIT_STATUS_RESPONSE, typeof(ZigBeeTransmitStatus));
            map.Add(XBeeAPICommandId.RECEIVE_PACKET_RESPONSE, typeof(ZigBeeReceivePacket));
            map.Add(XBeeAPICommandId.EXPLICIT_RX_INDICATOR_RESPONSE, typeof(ZigBeeExplicitRXIndicator));
            map.Add(XBeeAPICommandId.IO_SAMPLE_RESPONSE, typeof(ZigBeeIODataSample));
            map.Add(XBeeAPICommandId.SENSOR_READ_INDICATOR, typeof(SensorReadIndicator));
            map.Add(XBeeAPICommandId.NODE_IDENTIFIER_RESPONSE, typeof(NodeIdentification));
            map.Add(XBeeAPICommandId.REMOTE_AT_COMMAND_RESPONSE, typeof(RemoteCommandResponse));
            map.Add(XBeeAPICommandId.FIRMWARE_UPDATE_STATUS, typeof(OverAirUpdateStatus));
            map.Add(XBeeAPICommandId.ROUTE_RECORD_INDICATOR, typeof(RouteRecordIndicator));
            map.Add(XBeeAPICommandId.MANYTOONE_ROUTE_REQUEST_INDICATOR, typeof(ManyToOneRouteRequest));

            return map;
        }

        public static XBeeFrame Unmarshal(byte[] packetData)
        {
            MemoryStream dataStream = new MemoryStream(packetData);
            return Unmarshal(dataStream);
        }

        public static XBeeFrame Unmarshal(MemoryStream dataStream)
        {
            XBeeFrame frame;
            uint length = (uint) (dataStream.ReadByte() << 8 | dataStream.ReadByte());

            if ((length == 0) || (length > 0xFFFF))
                throw new XBeeFrameException("Invalid Frame Lenght");

            if (length != dataStream.Length - 2)
                throw new XBeeFrameException("Invalid Frame Lenght");

            XBeeAPICommandId cmd = (XBeeAPICommandId) dataStream.ReadByte();

            if (framesMap.ContainsKey(cmd)) {
                frame = (XBeeFrame) Activator.CreateInstance(framesMap[cmd]);

                frame.FrameId = (byte) dataStream.ReadByte();
                frame.Parse(dataStream);

            } else {
                throw new XBeeFrameException(String.Format("Unsupported Command Id 0x{0:X2}", cmd));
            }

            return frame;
        }

        public static void RegisterResponseHandler(XBeeAPICommandId commandId, Type typeHandler)
        {
            if (!typeHandler.IsSubclassOf(typeof(XBeeFrame)))
                throw new XBeeException("Invalid Frame Handler");

            if (framesMap.ContainsKey(commandId)) {
                logger.Info(String.Format("Overriding Frame Handler: {0} with {1} for API Id: 0x{2:x2}", framesMap[commandId].Name, typeHandler.Name, (byte)commandId));
                framesMap[commandId] = typeHandler;
            } else {
                logger.Info(String.Format("Adding Frame Handler: {0} for API Id: 0x{1:x2}", typeHandler.Name, (byte)commandId));
                framesMap.Add(commandId, typeHandler);
            }
        }
    }
}
