namespace XBee
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public enum XBeeSpecialBytes : byte
    {
        StartByte = 0x7E,
        EscapeByte = 0x7D,
        Xon = 0x11,
        Xoff = 0x13
    };

    public class XBeePacket
    {
        private readonly byte[] frameData;
        public byte[] Data { get; private set; }

        public XBeePacket(XBeeFrame frame)
        {
            frameData = frame.ToByteArray();
        }

        public XBeePacket(byte[] frameData)
        {
            this.frameData = frameData;
        }

        public void Assemble()
        {
            var data = new MemoryStream();

            data.WriteByte((byte) XBeeSpecialBytes.StartByte);

            var packetLength = BitConverter.GetBytes((ushort)frameData.Length);
            Array.Reverse(packetLength);

            data.WriteByte(packetLength[0]);
            data.WriteByte(packetLength[1]);

            data.Write(frameData, 0, frameData.Length);

            data.WriteByte(XBeeChecksum.Calculate(frameData));

            Data = data.ToArray();
        }

    }
}
