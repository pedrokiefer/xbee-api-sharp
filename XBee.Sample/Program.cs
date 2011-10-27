using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using XBee;
using XBee.Frames;

namespace XBee.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var bee = new XBee();
            bee.ApiType = ApiTypeValue.EnabledWithEscape;
            bee.SetConnection(new SerialConnection("COM4", 9600));

            var request = new ATCommand(AT.ApiEnable) {FrameId = 1};
            var frame = bee.SendSynchronous(request, 1000);
            var value = ((ATCommandResponse) frame).Value;
            Console.WriteLine(String.Format("API type: {0}", ((ATLongValue)value).Value));

            request = new ATCommand(AT.BaudRate) { FrameId = 1 };
            frame = bee.SendSynchronous(request, 1000);
            value = ((ATCommandResponse) frame).Value;
            Console.WriteLine(String.Format("Baud rate: {0}", ((ATLongValue) value).Value));

            request = new ATCommand(AT.FirmwareVersion) { FrameId = 1 };
            frame = bee.SendSynchronous(request, 1000);
            value = ((ATCommandResponse) frame).Value;
            Console.WriteLine(String.Format("Firmware Version: {0:X4}", ((ATLongValue) value).Value));
        }
    }
}
