using System;
using System.Text;
using XBee.Utils;

namespace XBee.Frames
{
    public class ATCommandResponse : XBeeFrame
    {
        private readonly PacketParser parser;

        public AT Command { get; private set; }
        public ATValue Value { get; private set; }
        public byte CommandStatus { get; private set; }

        public ATCommandResponse(PacketParser parser)
        {
            this.parser = parser;
            CommandId = XBeeAPICommandId.AT_COMMAND_RESPONSE;
        }

        public ATCommandResponse()
        {
            CommandId = XBeeAPICommandId.AT_COMMAND_RESPONSE;
        }

        public override byte[] ToByteArray()
        {
            return new byte[] { };
        }

        public override void Parse()
        {
            FrameId = (byte)parser.ReadByte();
            Command = parser.ReadATCommand();
            CommandStatus = (byte)parser.ReadByte();

            if (Command == AT.ND)
                ParseNetworkDiscovery();

            var type = ((ATAttribute)Command.GetAttr()).ValueType;

            if ((type != ATValueType.None) && parser.HasMoreData()) {
                switch (type) {
                    case ATValueType.Number:
                        var vData = parser.ReadData();
                        Value = new ATLongValue().FromByteArray(vData);
                        break;
                    case ATValueType.HexString:
                        var hexData = parser.ReadData();
                        Value = new ATStringValue(ByteUtils.toBase16(hexData));
                        break;
                    case ATValueType.String:
                        var str = parser.ReadData();
                        Value = new ATStringValue(Encoding.UTF8.GetString(str));
                        break;
                }
            }
        }

        private void ParseNetworkDiscovery()
        {
            throw new NotImplementedException();
        }
    }
}
