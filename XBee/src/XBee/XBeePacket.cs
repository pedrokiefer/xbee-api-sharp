namespace XBee
{
    using System;
    using System.Collections.Generic;

    public enum XBeeSpecialBytes : byte {
                START_BYTE =0x7e, 
                ESCAPE_BYTE = 0x7d, 
                XON_BYTE = 0x11,
                XOFF_BYTE = 0x13
    };

    public class XBeePacket
    {
        private byte[] frameData;
        private byte[] packetData;

        public XBeePacket(byte[] frameData)
        {
            this.frameData = frameData;
        }

        public void Assemble()
        {
            LinkedList<byte> data = new LinkedList<byte>();

            data.AddLast((byte) XBeeSpecialBytes.START_BYTE);

            byte[] packetLength = BitConverter.GetBytes(frameData.Length);
            Array.Reverse(packetLength);

            data.AddLast(packetLength[0]);
            data.AddLast(packetLength[1]);
            foreach (byte b in frameData) {
                data.AddLast(b);
            }
            data.AddLast(XBeeChecksum.Calculate(frameData));

            packetData = new byte[data.Count];
            int i = 0;
            foreach (byte b in data) {
                packetData[i] = b;
                i++;
            }
        }

    }
}
