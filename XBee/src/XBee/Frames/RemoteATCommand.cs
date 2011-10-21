using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using XBee.Utils;

namespace XBee.Frames
{
    public class RemoteATCommand : XBeeFrame
    {
        private readonly PacketParser parser;

        public AT Command { get; set; }
        public XBeeNode Destination { get; set; }
        public byte RemoteOptions { get; set; }

        public RemoteATCommand(PacketParser parser)
        {
            this.parser = parser;
            this.CommandId = XBeeAPICommandId.REMOTE_AT_COMMAND_REQUEST;
        }

        public RemoteATCommand(AT command, XBeeNode destination)
        {
            this.CommandId = XBeeAPICommandId.REMOTE_AT_COMMAND_REQUEST;
            this.Command = command;
            this.Destination = destination;
        }

        public override byte[] ToByteArray()
        {
            MemoryStream stream = new MemoryStream();

            stream.WriteByte((byte)CommandId);
            stream.WriteByte(FrameId);

            stream.Write(Destination.Address64.GetAddress(), 0, 8);
            stream.Write(Destination.Address16.GetAddress(), 0, 2);

            stream.WriteByte(RemoteOptions);

            var cmd = ((ATAttr)Command.GetAttr()).ATCommand.ToCharArray();
            stream.WriteByte((byte)cmd[0]);
            stream.WriteByte((byte)cmd[1]);

            return stream.ToArray();
        }

        public override void Parse()
        {
            this.FrameId = (byte) parser.ReadByte();

            Destination = new XBeeNode { Address64 = parser.ReadAddress64(), Address16 = parser.ReadAddress16() };

            RemoteOptions = (byte) parser.ReadByte();
            Command = parser.ReadATCommand();

            if (parser.HasMoreData()) {
                Console.WriteLine("TODO: has data!");
            }
        }
    }
}
