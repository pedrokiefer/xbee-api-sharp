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
        private AT atCommand;
        private XBeeNode destination;

        public byte RemoteOptions { get; set; }

        public RemoteATCommand(AT atCommand, XBeeNode destination)
        {
            this.commandId = XBeeAPICommandId.REMOTE_AT_COMMAND_REQUEST;
            this.atCommand = atCommand;
            this.destination = destination;
        }

        public override byte[] ToByteArray()
        {
            MemoryStream stream = new MemoryStream();

            stream.WriteByte((byte)commandId);
            stream.WriteByte(FrameId);

            stream.Write(destination.Address64.GetAddress(), 0, 8);
            stream.Write(destination.Address16.GetAddress(), 0, 2);

            stream.WriteByte(RemoteOptions);

            var cmd = ((ATAttr)atCommand.GetAttr()).ATCommand.ToCharArray();
            stream.WriteByte((byte)cmd[0]);
            stream.WriteByte((byte)cmd[1]);

            return stream.ToArray();
        }

        public override void Parse(MemoryStream data)
        {
            throw new NotImplementedException();
        }
    }
}
