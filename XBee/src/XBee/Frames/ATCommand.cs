using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using XBee.Utils;

namespace XBee.Frames
{
    public class ATCommand : XBeeFrame
    {

        private AT atCommand;
        private bool hasValue;
        private ATValue value;
        private readonly PacketParser parser;

        public AT Command
        {
            get { return atCommand; }
            set { this.atCommand = value; }
        }

        public ATCommand(PacketParser parser)
        {
            this.parser = parser;
            this.CommandId = XBeeAPICommandId.AT_COMMAND_REQUEST;
        }

        public ATCommand(AT atCommand)
        {
            this.atCommand = atCommand;
            this.CommandId = XBeeAPICommandId.AT_COMMAND_REQUEST;
        }

        public void SetValue(ATValue value)
        {
            this.hasValue = true;
            this.value = value;
        }

        public override byte[] ToByteArray()
        {
            var stream = new MemoryStream();

            stream.WriteByte((byte) CommandId);
            stream.WriteByte(FrameId);

            var cmd = ((ATAttribute) atCommand.GetAttr()).ATCommand.ToCharArray();
            stream.WriteByte((byte) cmd[0]);
            stream.WriteByte((byte) cmd[1]);

            if (hasValue) {
                var v = value.ToByteArray();
                stream.Write(v, 0, v.Length);
            }

            return stream.ToArray();
        }

        public override void Parse()
        {
            FrameId = (byte) parser.ReadByte();
            atCommand = parser.ReadATCommand();

            if (parser.HasMoreData()) {
                Console.WriteLine("TODO: has data!");
            }
        }
    }
}
