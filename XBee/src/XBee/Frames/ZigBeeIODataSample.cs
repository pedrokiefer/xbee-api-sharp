using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XBee.Frames
{
    public class ZigBeeIODataSample : XBeeFrame
    {
        private readonly PacketParser parser;

        public XBeeNode Source { get; private set; }
        public ReceiveOptionsType ReceiveOptions { get; private set; }

        public uint NumberOfSamples { get; private set; }
        public uint DigitalChannelMask { get; private set; }
        public uint AnalogChannelMask { get; private set; }
        public uint DigitalSamples { get; private set; }
        public uint[] AnalogSamples { get; private set; }

        public ZigBeeIODataSample(PacketParser parser)
        {
            this.parser = parser;
            this.CommandId = XBeeAPICommandId.IO_SAMPLE_RESPONSE;
        }

        public override byte[] ToByteArray()
        {
            return new byte[] { };
        }

        public override void Parse()
        {
            Source = new XBeeNode { Address64 = parser.ReadAddress64(), Address16 = parser.ReadAddress16() };
            ReceiveOptions = (ReceiveOptionsType) parser.ReadByte();
            NumberOfSamples = (uint) parser.ReadByte();
            DigitalChannelMask = parser.ReadUInt16();
            AnalogChannelMask = parser.ReadUInt16();
        }
    }
}
