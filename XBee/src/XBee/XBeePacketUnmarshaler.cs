using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            map.Add(XBeeAPICommandId.AT_REQUEST, typeof(ATCommand));
            map.Add(XBeeAPICommandId.AT_QUEUE_REQUEST, typeof(ATQueueCommand));
            map.Add(XBeeAPICommandId.TRANSMIT_DATA_REQUEST, typeof(TransmitDataRequest));

            return map;
        }

        public static void registerResponseHandler(XBeeAPICommandId commandId, Type typeHandler)
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
