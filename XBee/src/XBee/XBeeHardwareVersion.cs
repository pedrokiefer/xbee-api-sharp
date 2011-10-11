using System;
using NLog;

namespace XBee
{
    using System;
    using NLog;

    public enum XBeeSeriesId : byte
    {
        XBEE_SERIES_1 = 0x17,
        XBEE_SERIES_1_PRO = 0x18,
        XBEE_SERIES_2 = 0x19,
        XBEE_SERIES_2_PRO = 0x1A,
        XBEE_SERIES_2B_PRO = 0x1E,
        XBEE_SERIES_UNKNOWN = 0xFF
    };

    public class XbeeHardwareVersion
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private static String xbeeSeries1 = "XBee Series 1";
        private static String xbeeSeries1Pro = "XBee Series 1 Pro";
        private static String xbeeSeries2 = "XBee Series 2";
        private static String xbeeSeries2Pro = "XBee Series 2 Pro";
        private static String xbeeSeries2BPro = "XBee Series 2B Pro";
        private static String xbeeUnknown = "XBee Unknown";

        public static XBeeSeriesId GetHardwareVersion(byte version) 
        {
            switch ((XBeeSeriesId)version)
            {
                case XBeeSeriesId.XBEE_SERIES_1:
                    return XBeeSeriesId.XBEE_SERIES_1;
                case XBeeSeriesId.XBEE_SERIES_1_PRO:
                    return XBeeSeriesId.XBEE_SERIES_1_PRO;
                case XBeeSeriesId.XBEE_SERIES_2:
                    return XBeeSeriesId.XBEE_SERIES_2;
                case XBeeSeriesId.XBEE_SERIES_2_PRO:
                    return XBeeSeriesId.XBEE_SERIES_2_PRO;
                case XBeeSeriesId.XBEE_SERIES_2B_PRO:
                    return XBeeSeriesId.XBEE_SERIES_2B_PRO;
                default:
                    return XBeeSeriesId.XBEE_SERIES_UNKNOWN;
            }
        }

        public static String GetHardwareVersionDescription(XBeeSeriesId version)
        {
            switch ((XBeeSeriesId)version)
            {
                case XBeeSeriesId.XBEE_SERIES_1:
                    return xbeeSeries1;
                case XBeeSeriesId.XBEE_SERIES_1_PRO:
                    return xbeeSeries1Pro;
                case XBeeSeriesId.XBEE_SERIES_2:
                    return xbeeSeries2;
                case XBeeSeriesId.XBEE_SERIES_2_PRO:
                    return xbeeSeries2Pro;
                case XBeeSeriesId.XBEE_SERIES_2B_PRO:
                    return xbeeSeries2BPro;
                default:
                    return xbeeUnknown;
            }
        }

    }
}
