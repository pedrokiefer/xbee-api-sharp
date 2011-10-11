using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XBee
{
    public class XBeeAddress16 : XBeeAddress
    {
        public static XBeeAddress16 BROADCAST = new XBeeAddress16((ushort)0xFFFF);
        public static XBeeAddress16 ZNET_BROADCAST = new XBeeAddress16((ushort)0xFFFE);

        private byte[] address;

        public XBeeAddress16(ushort address)
        {
            byte[] addressLittleEndian = BitConverter.GetBytes(address);
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
            if ((obj == null) || (typeof(XBeeAddress16) != obj.GetType()))
                return false;

            XBeeAddress16 addr = (XBeeAddress16) obj;

            if (Array.Equals(this.address, addr.GetAddress()))
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return address.GetHashCode();
        }

    }
}
