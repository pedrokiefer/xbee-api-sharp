using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XBee
{
    public enum XBeeAPICommandId
    {
        TX_REQUEST_64 = 0x00,
        TX_REQUEST_16 = 0x01,
        AT_COMMAND = 0x08,
        AT_COMMAND_QUEUE = 0x09,
        REMOTE_AT_REQUEST = 0x17,   
        ZNET_TX_REQUEST = 0x10,
        ZNET_EXPLICIT_TX_REQUEST = 0x11,    
        RX_64_RESPONSE = 0x80,     
        RX_16_RESPONSE = 0x81,    
        RX_64_IO_RESPONSE = 0x82,    
        RX_16_IO_RESPONSE = 0x83,    
        AT_RESPONSE = 0x88,    
        TX_STATUS_RESPONSE = 0x89,    
        MODEM_STATUS_RESPONSE = 0x8A,    
        ZNET_RX_RESPONSE = 0x90,    
        ZNET_EXPLICIT_RX_RESPONSE = 0x91,    
        ZNET_TX_STATUS_RESPONSE = 0x8B,    
        REMOTE_AT_RESPONSE = 0x97,     
        ZNET_IO_SAMPLE_RESPONSE = 0x92,     
        ZNET_IO_NODE_IDENTIFIER_RESPONSE = 0x95,
        UNKNOWN = 0xFF,
    }
}
