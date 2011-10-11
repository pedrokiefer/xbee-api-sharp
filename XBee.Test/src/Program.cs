using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace XBee.Test
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string[] myArgs = { Assembly.GetExecutingAssembly().Location };

            int returnCode = NUnit.Gui.AppEntry.Main(myArgs);
                //.Runner.Main(myArgs);

            if (returnCode != 0)
                Console.Beep();
        }
    }
}
