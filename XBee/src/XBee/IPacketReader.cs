using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XBee
{
    public delegate void FrameReceivedHandler(object sender, FrameReceivedArgs args);

    public interface IPacketReader
    {
        event FrameReceivedHandler FrameReceived;
        void ReceiveData(byte[] data);
    }
}
