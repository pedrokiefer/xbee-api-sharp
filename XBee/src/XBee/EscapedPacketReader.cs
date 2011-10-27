using System;
using System.IO;
using System.Linq;
using XBee.Exceptions;

namespace XBee
{
    public class EscapedPacketReader : IPacketReader
    {
        public event FrameReceivedHandler FrameReceived;

        private MemoryStream stream = new MemoryStream();
        private uint packetLength = 0;

        public void ReceiveData(byte[] data)
        {
            if (data[0] == (byte) XBeeSpecialBytes.StartByte) {
                stream = new MemoryStream();
                packetLength = (uint) (data[1] << 8 | data[2]) + 3;
                EscapeData(data);
            } else if (packetLength != 0) {
                EscapeData(data);
            }

            if (stream.Length != packetLength)
                return;

            try {
                stream.Position = 0;
                var frame = XBeePacketUnmarshaler.Unmarshal(stream.ToArray());
                if (FrameReceived != null)
                    FrameReceived.Invoke(this, new FrameReceivedArgs(frame));
            } catch (XBeeFrameException ex) {
                throw new XBeeException("Unable to unmarshal packet", ex);
            }
        }

        public MemoryStream EscapeData(byte[] data)
        {
            var escapeNext = false;
            foreach (var b in data) {
                if (IsSpecialByte(b)) {
                    if (b == (byte) XBeeSpecialBytes.EscapeByte) {
                        escapeNext = true;
                        continue;
                    }
                    if (b == (byte) XBeeSpecialBytes.StartByte) {
                        continue;
                    }
                }

                if (escapeNext) {
                    stream.WriteByte(EscapeByte(b));
                    escapeNext = false;
                } else {
                    stream.WriteByte(b);
                }
            }
            return stream;
        }

        public bool IsSpecialByte(byte b)
        {
            return Enum.IsDefined(typeof(XBeeSpecialBytes), b);
        }

        public byte EscapeByte(byte b)
        {
            return (byte) (0x20 ^ b);
        }
    }
}