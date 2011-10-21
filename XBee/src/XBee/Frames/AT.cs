using System;
using XBee.Utils;

namespace XBee.Frames
{

    public class ATAttr : EnumAttribute
    {
        public ATAttr(string atCommand, string description)
        {
            this.ATCommand = atCommand;
            this.Description = description;
        }

        public ATAttr(string atCommand, string description, ulong maxValue)
        {
            this.ATCommand = atCommand;
            this.Description = description;
            this.MaximumValue = maxValue;
        }

        public string ATCommand { get; private set; }
        public string Description { get; private set; }
        public ulong MaximumValue { get; private set; }
    }

    public class ATUtil
    {
        public static AT Parse(string value)
        {
            var atCommands = (AT[]) Enum.GetValues(typeof(AT));
            AT cmd = Array.Find(atCommands, at => ((ATAttr)at.GetAttr()).ATCommand == value);

            if (cmd == 0)
                return AT.UNKNOWN;

            return cmd;
        }
    }

    public enum AT
    {
        [ATAttr("DH", "Destination Address High", 0xFFFFFFFF)]
        DH = 0x10000,
        [ATAttr("DL", "Destination Address Low", 0xFFFFFFFF)]
        DL,
        [ATAttr("MY", "16-bit Network Address", 0xFFFE)]
        MY,
        [ATAttr("MP", "16-bit Parent Network Address", 0xFFFE)]
        MP,
        [ATAttr("NC", "Number of Remaining Children", 0)]
        NC,
        [ATAttr("SH", "Serial Number High", 0xFFFFFFFF)]
        SH,
        [ATAttr("SL", "Serial Number Low", 0xFFFFFFFF)]
        SL,
        [ATAttr("NI", "Node Identifier", 20)]
        NI,
        [ATAttr("SE", "Source Endpoint", 0xFF)]
        SE,
        [ATAttr("DE", "Destination Endpoint", 0xFF)]
        DE,
        [ATAttr("CI", "Cluster Identifier", 0xFFFF)]
        CI,
        [ATAttr("NP", "Maximum RF Payload Bytes", 0xFFFF)]
        NP,
        [ATAttr("DD", "Device Type Identifier", 0xFFFFFFFF)]
        DD,
        [ATAttr("CH", "Operating Channel")]
        CH,
        [ATAttr("ID", "Extended PAN ID", 0xFFFFFFFFFFFFFFFF)]
        ID,
        [ATAttr("OP", "Operating Extended PAN ID", 0xFFFFFFFFFFFFFFFF)]
        OP,
        [ATAttr("NH", "Maximum Unicast Hops", 0xFF)]
        NH,
        [ATAttr("BH", "Broadcast Hops", 0x1E)]
        BH,
        [ATAttr("OI", "Operating 16-bit PAN ID", 0xFFFF)]
        OI,
        [ATAttr("NT", "Node Discovery Timeout", 0xFF)]
        NT,
        [ATAttr("NO", "Network Discovery options", 0x03)]
        NO,
        [ATAttr("SC", "Scan Channel", 0x7FFF)]
        SC,
        [ATAttr("SD", "Scan Duration", 7)]
        SD,
        [ATAttr("ZS", "ZigBee Stack Profile", 2)]
        ZS,
        [ATAttr("NJ", "Node Join Time", 0xFF)]
        NJ,
        [ATAttr("JV", "Channel Verification")]
        JV,
        [ATAttr("NW", "Network Watchdog Timeout", 0x64FF)]
        NW,
        [ATAttr("JN", "Join Notification", 1)]
        JN,
        [ATAttr("AR", "Aggregate Routing Notification", 0xFF)]
        AR,

        [ATAttr("EE", "Encryption Enable", 1)]
        EE,
        [ATAttr("EO", "Encryption Options", 0xFF)]
        EO,
        [ATAttr("NK", "Network Encryption Key", 0)]
        NK,
        [ATAttr("KY", "Link Key", 0)]
        KY,

        [ATAttr("PL", "Power Level", 4)]
        PL,
        [ATAttr("PM", "Power Mode", 1)]
        PM,
        [ATAttr("DB", "Received Signal Strength", 0xFF)]
        DB,
        [ATAttr("PP", "Peak Power", 0x12)]
        PP,

        [ATAttr("AP", "API Enable", 2)]
        AP,
        [ATAttr("AO", "API Options", 3)]
        AO,
        [ATAttr("BD", "Interface Data Rate", 0xE1000)]
        BD,
        [ATAttr("NB", "Serial Parity", 3)]
        NB,
        [ATAttr("SB", "Stop Bits", 1)]
        SB,
        [ATAttr("RO", "Packetization Timeout", 0xFF)]
        RO,
        [ATAttr("D7", "DIO7 Configuration", 7)]
        D7,
        [ATAttr("D6", "DIO6 Configuration", 5)]
        D6,

        [ATAttr("IR", "IO Sample Rate", 0xFFFF)]
        IR,
        [ATAttr("IC", "IO Digital Change Detection", 0xFFFF)]
        IC,
        [ATAttr("P0", "PWM0 Configuration", 5)]
        P0,
        [ATAttr("P1", "DIO11 Configuration", 5)]
        P1,
        [ATAttr("P2", "DIO12 Configuration", 5)]
        P2,
        [ATAttr("P3", "DIO13 Configuration", 5)]
        P3,
        [ATAttr("D0", "AD0/DIO0 Configuration", 5)]
        D0,
        [ATAttr("D1", "AD1/DIO1 Configuration", 5)]
        D1,
        [ATAttr("D2", "AD2/DIO2 Configuration", 5)]
        D2,


        [ATAttr("D3", "AD3/DIO3 Configuration", 5)]
        D3,
        [ATAttr("D4", "DIO4 Configuration", 5)]
        D4,
        [ATAttr("D5", "DIO5 Configuration", 5)]
        D5,
        [ATAttr("D8", "DIO8 Configuration", 5)]
        D8,
        [ATAttr("LT", "Assoc LED Blink Time", 0xFF)]
        LT,
        [ATAttr("PR", "Pull-up Resistor", 0x3FFF)]
        PR,
        [ATAttr("RP", "RSSI PWM Timer", 0xFF)]
        RP,
        [ATAttr("%V", "Supply Voltage", 0xFFFF)]
        SUPPLY_VOLTAGE,
        [ATAttr("V+", "Voltage Supply Monitoring", 0xFFFF)]
        VOLTAGE_MONITORING,
        [ATAttr("TP", "Reads the module temperature in Degrees Celsius", 0xFFFF)]
        TP,

        [ATAttr("VR", "Firmware Version", 0xFFFF)]
        VR,
        [ATAttr("HV", "Hardware Version", 0xFFFF)]
        HV,
        [ATAttr("AI", "Association Indication", 0xFF)]
        AI,

        [ATAttr("CT", "Command Mode Timeout", 0x028F)]
        CT,
        [ATAttr("CN", "Exit Command Mode")]
        CN,
        [ATAttr("GT", "Guard Times", 0x0CE4)]
        GT,
        [ATAttr("CC", "Command Sequence Character", 0xFF)]
        CC,

        [ATAttr("SM", "Sleep Mode", 5)]
        SM,
        [ATAttr("SN", "Number of Sleep Periods", 0xFFFF)]
        SN,
        [ATAttr("SP", "Sleep Period", 0xAF0)]
        SP,
        [ATAttr("ST", "Time Before Sleep", 0xFFFE)]
        ST,
        [ATAttr("SO", "Sleep Options", 0xFF)]
        SO,
        [ATAttr("WH", "Wake Host", 0xFFFF)]
        WH,
        [ATAttr("PO", "Polling Rate", 0x3E8)]
        PO,

        [ATAttr("AC", "Apply Changes")]
        AC,
        [ATAttr("WR", "Write")]
        WR,
        [ATAttr("RE", "Restore Defaults")]
        RE,
        [ATAttr("FR", "Software Reset")]
        FR,
        [ATAttr("NR", "Network Reset", 1)]
        NR,
        [ATAttr("SI", "Sleep Immediately")]
        SI,
        [ATAttr("CB", "Commissioning Pushbutton")]
        CB,

        [ATAttr("ND", "Node Discover")]
        ND,
        [ATAttr("DN", "Destination Node")]
        DN,
        [ATAttr("IS", "Force Sample")]
        IS,
        [ATAttr("1S", "XBee Sensor Sample")]
        SENSOR_SAMPLE,

        [ATAttr("", "Unknown AT Command")]
        UNKNOWN
    }
}
