using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XBee
{
    public class XBeeAddress64 : XBeeAddress
    {
        public static XBeeAddress64 BROADCAST = new XBeeAddress64(0x000000000000FFFF);
        public static XBeeAddress64 ZNET_COORDINATOR = new XBeeAddress64(0);
        private readonly byte[] address;

        public XBeeAddress64(ulong address)
        {
            var addressLittleEndian = BitConverter.GetBytes(address);
            Array.Reverse(addressLittleEndian);
            this.address = addressLittleEndian;
        }

        public override byte[] GetAddress()
        {
            return this.address;
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if ((obj == null) || (typeof(XBeeAddress64) != obj.GetType()))
                return false;

            var addr = (XBeeAddress64) obj;

            return this.GetAddress().SequenceEqual(addr.GetAddress());
        }

        public override int GetHashCode()
        {
            return address.GetHashCode();
        }
    }
}
