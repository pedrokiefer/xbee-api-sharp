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
        private byte[] rfData;

        public byte BroadcastRadius { get; set; }
        public OptionValues Options { get; set; }

        public TransmitDataRequest(XBeeNode destination)
        {
            this.CommandId = XBeeAPICommandId.TRANSMIT_DATA_REQUEST;
            this.destination = destination;
            this.BroadcastRadius = 0;
            this.Options = 0;
            this.rfData = null;
        }

        public void SetRFData(byte[] rfData)
        {
            this.rfData = rfData;
        }

        public override byte[] ToByteArray()
        {
            MemoryStream stream = new MemoryStream();

            stream.WriteByte((byte)CommandId);
            stream.WriteByte(FrameId);

            stream.Write(destination.Address64.GetAddress(), 0, 8);
            stream.Write(destination.Address16.GetAddress(), 0, 2);

            stream.WriteByte((byte)BroadcastRadius);
            stream.WriteByte((byte)Options);

            if (this.rfData != null) {
                stream.Write(this.rfData, 0, this.rfData.Length);
            }

            return stream.ToArray();
        }

        public override void Parse()
        {
            throw new NotImplementedException();
        }
    }
}
