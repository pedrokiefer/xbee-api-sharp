using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using XBee.Exceptions;

namespace XBee.Frames
{
    public class ExplicitAddressingTransmit : XBeeFrame
    {
        public enum OptionValues : byte
        {
            DISABLE_ACK = 0x01,
            ENABLE_APS_ENCRYPTION = 0x20,
            EXTENDED_TIMEOUT = 0x40
        }

        private XBeeNode destination;
        private byte[] RFData;

        public byte? SourceEndpoint { get; set; }
        public byte? DestinationEndpoint { get; set; }
        public UInt16? ClusterId { get; set; }
        public UInt16? ProfileId { get; set; }

        public byte BroadcastRadius { get; set; }
        public OptionValues Options { get; set; }

        public ExplicitAddressingTransmit(XBeeNode destination)
        {
            this.commandId = XBeeAPICommandId.EXPLICIT_ADDR_REQUEST;
            this.destination = destination;
            this.BroadcastRadius = 0;
            this.Options = 0;

            this.SourceEndpoint = null;
            this.DestinationEndpoint = null;
            this.ClusterId = null;
            this.ProfileId = null;
            
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

            if (!SourceEndpoint.HasValue)
                throw new XBeeFrameException("Missing Source Endpoint");
            stream.WriteByte(SourceEndpoint.Value);

            if (!DestinationEndpoint.HasValue)
                throw new XBeeFrameException("Missing Destination Endpoint");
            stream.WriteByte(DestinationEndpoint.Value);

            if (!ClusterId.HasValue)
                throw new XBeeFrameException("Missing Cluster ID");
            byte[] clusterIdMSB = BitConverter.GetBytes(ClusterId.Value);
            Array.Reverse(clusterIdMSB);
            stream.Write(clusterIdMSB, 0, 2);

            if (!ProfileId.HasValue)
                throw new XBeeFrameException("Missing Profile ID");
            byte[] profileIdMSB = BitConverter.GetBytes(ProfileId.Value);
            Array.Reverse(profileIdMSB);
            stream.Write(profileIdMSB, 0, 2);

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
