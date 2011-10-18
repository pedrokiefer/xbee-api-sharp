using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using XBee;

namespace XBee.Frames
{
    public class TransmitDataRequest : XBeeFrame
    {
        public enum OptionValues : byte
        {
            DISABLE_ACK = 0x01,
            ENABLE_APS_ENCRYPTION = 0x20,
            EXTENDED_TIMEOUT = 0x40
        }

        private XBeeNode destination;
        private byte[] RFData;

        public byte BroadcastRadius { get; set; }
        public OptionValues Options { get; set; }

        public TransmitDataRequest(XBeeNode destination)
        {
            this.commandId = XBeeAPICommandId.TRANSMIT_DATA_REQUEST;
            this.destination = destination;
            this.BroadcastRadius = 0;
            this.Options = 0;
            this.RFData = null;
        }

        public void SetRFData(byte[] RFData)
        {
            this.RFData = RFData;
        }

        public override byte[] ToByteArray()
        {
            MemoryStream stream = new MemoryStream();

            stream.WriteByte((byte)commandId);
            stream.WriteByte(FrameId);

            stream.Write(destination.Address64.GetAddress(), 0, 8);
            stream.Write(destination.Address16.GetAddress(), 0, 2);

            stream.WriteByte((byte)BroadcastRadius);
            stream.WriteByte((byte)Options);

            if (this.RFData != null) {
                stream.Write(this.RFData, 0, this.RFData.Length);
            }

            return stream.ToArray();
        }

        public override void Parse(MemoryStream data)
        {
            throw new NotImplementedException();
        }
    }
}
