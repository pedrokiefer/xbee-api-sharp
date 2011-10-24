using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XBee;
using XBee.Frames;

namespace XBee.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var bee = new XBee();

            bee.SetConnection(new SerialConnection("COM4", 9600));
            var request = new ATCommand(AT.ApiEnable) {FrameId = 1};

            var frame = bee.SendSynchronous(request, 1000);

        }
    }
}
