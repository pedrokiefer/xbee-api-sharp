using System;
using XBee.Utils;

namespace XBee.Frames
{

    public class ATAttribute : EnumAttribute
    {
        public ATAttribute(string atCommand, string description, ATValueType type)
        {
            ATCommand = atCommand;
            Description = description;
            ValueType = type;
        }

        public ATAttribute(string atCommand, string description, ATValueType type, ulong maxValue)
        {
            ATCommand = atCommand;
            Description = description;
            MaximumValue = maxValue;
            ValueType = type;
        }

        public string ATCommand { get; private set; }
        public string Description { get; private set; }
        public ATValueType ValueType { get; private set; }
        public ulong MaximumValue { get; private set; }
    }

    public class ATUtil
    {
        public static AT Parse(string value)
        {
            var atCommands = (AT[])Enum.GetValues(typeof(AT));
            var cmd = Array.Find(atCommands, at => ((ATAttribute)at.GetAttr()).ATCommand == value);

            if (cmd == 0)
                return AT.UNKNOWN;

            return cmd;
        }
    }

    public enum ATValueType
    {
        None,
        Number,
        String,
        HexString,
    }

    public enum AT
    {
        [AT("DH", "Destination Address High", ATValueType.Number, 0xFFFFFFFF)]
        DH = 0x10000,
        [AT("DL", "Destination Address Low", ATValueType.Number, 0xFFFFFFFF)]
        DL,
        [AT("MY", "16-bit Network Address", ATValueType.Number, 0xFFFE)]
        MY,
        [AT("MP", "16-bit Parent Network Address", ATValueType.Number, 0xFFFE)]
        MP,
        [AT("NC", "Number of Remaining Children", ATValueType.Number, 0)]
        NC,
        [AT("SH", "Serial Number High", ATValueType.Number, 0xFFFFFFFF)]
        SH,
        [AT("SL", "Serial Number Low", ATValueType.Number, 0xFFFFFFFF)]
        SL,
        [AT("NI", "Node Identifier", ATValueType.String, 20)]
        NI,
        [AT("SE", "Source Endpoint", ATValueType.Number, 0xFF)]
        SE,
        [AT("DE", "Destination Endpoint", ATValueType.Number, 0xFF)]
        DE,
        [AT("CI", "Cluster Identifier", ATValueType.Number, 0xFFFF)]
        CI,
        [AT("NP", "Maximum RF Payload Bytes", ATValueType.Number, 0xFFFF)]
        NP,
        [AT("DD", "Device Type Identifier", ATValueType.Number, 0xFFFFFFFF)]
        DD,
        [AT("CH", "Operating Channel", ATValueType.Number)]
        CH,
        [AT("ID", "Extended PAN ID", ATValueType.Number, 0xFFFFFFFFFFFFFFFF)]
        ID,
        [AT("OP", "Operating Extended PAN ID", ATValueType.Number, 0xFFFFFFFFFFFFFFFF)]
        OP,
        [AT("NH", "Maximum Unicast Hops", ATValueType.Number, 0xFF)]
        NH,
        [AT("BH", "Broadcast Hops", ATValueType.Number, 0x1E)]
        BH,
        [AT("OI", "Operating 16-bit PAN ID", ATValueType.Number, 0xFFFF)]
        OI,
        [AT("NT", "Node Discovery Timeout", ATValueType.Number, 0xFF)]
        NT,
        [AT("NO", "Network Discovery options", ATValueType.Number, 0x03)]
        NO,
        [AT("SC", "Scan Channel", ATValueType.Number, 0x7FFF)]
        SC,
        [AT("SD", "Scan Duration", ATValueType.Number, 7)]
        SD,
        [AT("ZS", "ZigBee Stack Profile", ATValueType.Number, 2)]
        ZS,
        [AT("NJ", "Node Join Time", ATValueType.Number, 0xFF)]
        NJ,
        [AT("JV", "Channel Verification", ATValueType.Number)]
        JV,
        [AT("NW", "Network Watchdog Timeout", ATValueType.Number, 0x64FF)]
        NW,
        [AT("JN", "Join Notification", ATValueType.Number, 1)]
        JN,
        [AT("AR", "Aggregate Routing Notification", ATValueType.Number, 0xFF)]
        AR,

        [AT("EE", "Encryption Enable", ATValueType.Number, 1)]
        EE,
        [AT("EO", "Encryption Options", ATValueType.Number, 0xFF)]
        EO,
        [AT("NK", "Network Encryption Key", ATValueType.HexString, 0)]
        NK,
        [AT("KY", "Link Key", ATValueType.HexString, 0)]
        KY,

        [AT("PL", "Power Level", ATValueType.Number, 4)]
        PL,
        [AT("PM", "Power Mode", ATValueType.Number, 1)]
        PM,
        [AT("DB", "Received Signal Strength", ATValueType.Number, 0xFF)]
        DB,
        [AT("PP", "Peak Power", ATValueType.Number, 0x12)]
        PP,

        [AT("AP", "API Enable", ATValueType.Number, 2)]
        AP,
        [AT("AO", "API Options", ATValueType.Number, 3)]
        AO,
        [AT("BD", "Interface Data Rate", ATValueType.Number, 0xE1000)]
        BD,
        [AT("NB", "Serial Parity", ATValueType.Number, 3)]
        NB,
        [AT("SB", "Stop Bits", ATValueType.Number, 1)]
        SB,
        [AT("RO", "Packetization Timeout", ATValueType.Number, 0xFF)]
        RO,
        [AT("D7", "DIO7 Configuration", ATValueType.Number, 7)]
        D7,
        [AT("D6", "DIO6 Configuration", ATValueType.Number, 5)]
        D6,

        [AT("IR", "IO Sample Rate", ATValueType.Number, 0xFFFF)]
        IR,
        [AT("IC", "IO Digital Change Detection", ATValueType.Number, 0xFFFF)]
        IC,
        [AT("P0", "PWM0 Configuration", ATValueType.Number, 5)]
        P0,
        [AT("P1", "DIO11 Configuration", ATValueType.Number, 5)]
        P1,
        [AT("P2", "DIO12 Configuration", ATValueType.Number, 5)]
        P2,
        [AT("P3", "DIO13 Configuration", ATValueType.Number, 5)]
        P3,
        [AT("D0", "AD0/DIO0 Configuration", ATValueType.Number, 5)]
        D0,
        [AT("D1", "AD1/DIO1 Configuration", ATValueType.Number, 5)]
        D1,
        [AT("D2", "AD2/DIO2 Configuration", ATValueType.Number, 5)]
        D2,


        [AT("D3", "AD3/DIO3 Configuration", ATValueType.Number, 5)]
        D3,
        [AT("D4", "DIO4 Configuration", ATValueType.Number, 5)]
        D4,
        [AT("D5", "DIO5 Configuration", ATValueType.Number, 5)]
        D5,
        [AT("D8", "DIO8 Configuration", ATValueType.Number, 5)]
        D8,
        [AT("LT", "Assoc LED Blink Time", ATValueType.Number, 0xFF)]
        LT,
        [AT("PR", "Pull-up Resistor", ATValueType.Number, 0x3FFF)]
        PR,
        [AT("RP", "RSSI PWM Timer", ATValueType.Number, 0xFF)]
        RP,
        [AT("%V", "Supply Voltage", ATValueType.Number, 0xFFFF)]
        SUPPLY_VOLTAGE,
        [AT("V+", "Voltage Supply Monitoring", ATValueType.Number, 0xFFFF)]
        VOLTAGE_MONITORING,
        [AT("TP", "Reads the module temperature in Degrees Celsius", ATValueType.Number, 0xFFFF)]
        TP,

        [AT("VR", "Firmware Version", ATValueType.Number, 0xFFFF)]
        VR,
        [AT("HV", "Hardware Version", ATValueType.Number, 0xFFFF)]
        HV,
        [AT("AI", "Association Indication", ATValueType.Number, 0xFF)]
        AI,

        [AT("CT", "Command Mode Timeout", ATValueType.Number, 0x028F)]
        CT,
        [AT("CN", "Exit Command Mode", ATValueType.Number)]
        CN,
        [AT("GT", "Guard Times", ATValueType.Number, 0x0CE4)]
        GT,
        [AT("CC", "Command Sequence Character", ATValueType.Number, 0xFF)]
        CC,

        [AT("SM", "Sleep Mode", ATValueType.Number, 5)]
        SM,
        [AT("SN", "Number of Sleep Periods", ATValueType.Number, 0xFFFF)]
        SN,
        [AT("SP", "Sleep Period", ATValueType.Number, 0xAF0)]
        SP,
        [AT("ST", "Time Before Sleep", ATValueType.Number, 0xFFFE)]
        ST,
        [AT("SO", "Sleep Options", ATValueType.Number, 0xFF)]
        SO,
        [AT("WH", "Wake Host", ATValueType.Number, 0xFFFF)]
        WH,
        [AT("PO", "Polling Rate", ATValueType.Number, 0x3E8)]
        PO,

        [AT("AC", "Apply Changes", ATValueType.None)]
        AC,
        [AT("WR", "Write", ATValueType.None)]
        WR,
        [AT("RE", "Restore Defaults", ATValueType.None)]
        RE,
        [AT("FR", "Software Reset", ATValueType.None)]
        FR,
        [AT("NR", "Network Reset", ATValueType.Number, 1)]
        NR,
        [AT("SI", "Sleep Immediately", ATValueType.None)]
        SI,
        [AT("CB", "Commissioning Pushbutton", ATValueType.None)]
        CB,

        [AT("ND", "Node Discover", ATValueType.Number)]
        ND,
        [AT("DN", "Destination Node", ATValueType.Number)]
        DN,
        [AT("IS", "Force Sample", ATValueType.None)]
        IS,
        [AT("1S", "XBee Sensor Sample", ATValueType.None)]
        SENSOR_SAMPLE,

        [AT("", "Unknown AT Command", ATValueType.None)]
        UNKNOWN
    }
}
