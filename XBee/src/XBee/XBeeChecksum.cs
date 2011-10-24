using System.Linq;
using NLog;

namespace XBee
{
    public class XBeeChecksum
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public static byte Calculate(byte[] data)
        {
            var checksum = data.Aggregate(0, (current, b) => current + b);

            // discard values > 1 byte
            checksum = 0xff & checksum;
            // perform 2s complement
            checksum = 0xff - checksum;

            logger.Debug("Computed checksum is {0:2x}", checksum);
            return (byte)checksum;
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
