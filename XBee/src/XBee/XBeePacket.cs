namespace XBee
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public enum XBeeSpecialBytes : byte
    {
        START_BYTE = 0x7E,
        ESCAPE_BYTE = 0x7D,
        XON_BYTE = 0x11,
        XOFF_BYTE = 0x13
    };

    public class XBeePacket
    {
        private readonly byte[] frameData;
        private byte[] packetData;

        public XBeePacket(byte[] frameData)
        {
            this.frameData = frameData;
        }

        public void Assemble()
        {
            var data = new MemoryStream();

            data.WriteByte((byte) XBeeSpecialBytes.START_BYTE);

            var packetLength = BitConverter.GetBytes(frameData.Length);
            Array.Reverse(packetLength);

            data.WriteByte(packetLength[0]);
            data.WriteByte(packetLength[1]);

            data.Write(frameData, 0, frameData.Length);

            data.WriteByte(XBeeChecksum.Calculate(frameData));

            packetData = data.ToArray();
        }

    }
}
