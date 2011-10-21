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
        private long value;
        private readonly PacketParser parser;

        public AT Command
        {
            get { return atCommand; }
            set { this.atCommand = value; }
        }

        public ATCommand(PacketParser parser)
        {
            this.parser = parser;
            this.value = 0;
            this.hasValue = false;
            this.CommandId = XBeeAPICommandId.AT_COMMAND_REQUEST;
        }

        public ATCommand(AT atCommand)
        {
            this.atCommand = atCommand;
            this.value = 0;
            this.hasValue = false;
            this.CommandId = XBeeAPICommandId.AT_COMMAND_REQUEST;
        }

        public void SetValue(long value)
        {
            this.hasValue = true;
            this.value = value;
        }

        public override byte[] ToByteArray()
        {
            MemoryStream stream = new MemoryStream();

            stream.WriteByte((byte) CommandId);
            stream.WriteByte(FrameId);

            var cmd = ((ATAttr) atCommand.GetAttr()).ATCommand.ToCharArray();
            stream.WriteByte((byte) cmd[0]);
            stream.WriteByte((byte) cmd[1]);

            if (hasValue) {
                // TODO: write value;
                stream.Write(new byte[] { 0x11, 0x22 }, 0, 2);
            }

            return stream.ToArray();
        }

        public override void Parse()
        {
            this.FrameId = (byte) parser.ReadByte();
            this.atCommand = parser.ReadATCommand();

            if (parser.HasMoreData()) {
                Console.WriteLine("TODO: has data!");
            }
        }
    }

    public class ATValue
    {
        private byte[] byteData;

        public static ATValue NewFromLong(ulong value)
        {
            ATValue v = new ATValue();

            return v;
        }
    }
}
