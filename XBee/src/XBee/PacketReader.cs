using System;

namespace XBee
{
    public class PacketReader : IPacketReader
    {
        public event FrameReceivedHandler FrameReceived;
        public void ReceiveData(byte[] data)
        {
            throw new NotImplementedException();
        }
    }
}