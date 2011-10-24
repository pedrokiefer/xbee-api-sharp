using XBee.Utils;

namespace XBee
{

    public class XBeeHardwareAttribute : EnumAttribute
    {
        public string Name { get; private set; }

        public XBeeHardwareAttribute(string name)
        {
            Name = name;
        }
    }

    public enum XBeeSeriesId : byte
    {
        [XBeeHardware("XBee Series 1")]
        XBEE_SERIES_1 = 0x17,
        [XBeeHardware("XBee Series 1 Pro")]
        XBEE_SERIES_1_PRO = 0x18,
        [XBeeHardware("XBee Series 2")]
        XBEE_SERIES_2 = 0x19,
        [XBeeHardware("XBee Series 2 Pro")]
        XBEE_SERIES_2_PRO = 0x1A,
        [XBeeHardware("XBee Series 2B Pro")]
        XBEE_SERIES_2B_PRO = 0x1E,
        [XBeeHardware("XBee Unknown")]
        XBEE_SERIES_UNKNOWN = 0xFF
    };
}
