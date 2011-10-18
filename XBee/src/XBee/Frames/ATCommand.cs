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

        public ATCommand(AT atCommand)
        {
            this.atCommand = atCommand;
            this.value = 0;
            this.hasValue = false;
            this.commandId = XBeeAPICommandId.AT_REQUEST;
        }

        public void SetValue(long value)
        {
            this.hasValue = true;
            this.value = value;
        }

        public override byte[] ToByteArray()
        {
            MemoryStream stream = new MemoryStream();

            stream.WriteByte((byte)commandId);
            stream.WriteByte(FrameId);

            var cmd = ((ATAttr)atCommand.GetAttr()).ATCommand.ToCharArray();
            stream.WriteByte((byte)cmd[0]);
            stream.WriteByte((byte)cmd[1]);

            if (hasValue) {
                // TODO: write value;
                stream.Write(new byte[] { 0x11, 0x22 }, 0, 2);
            }

            return stream.ToArray();
        }

        public override void Parse(MemoryStream data)
        {
            var cmd = new char[2];
            cmd[0] = (char) data.ReadByte();
            cmd[1] = (char) data.ReadByte();

            Console.WriteLine(String.Format("{0}", new String(cmd)));
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
