using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;

namespace XBee
{
    public class XBeeChecksum
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static byte Calculate(byte[] data)
        {
            int checksum = 0;

            foreach (byte b in data) {
                checksum += b;
            }

            // discard values > 1 byte
            checksum = 0xff & checksum;
            // perform 2s complement
            checksum = 0xff - checksum;

            logger.Debug("Computed checksum is {0:2x}", checksum );
            return (byte) checksum;
        }

        public static bool Verify(byte[] data)
        {
            int checksum = Calculate(data);
            checksum = checksum & 0xff;
            
            logger.Debug("Verify checksum is {0:2x}", checksum);

            if (checksum == 0x00)
                return true;
            
            return false;
        }
    }
}
