namespace XBee.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class XBeeFrameException : System.Exception
    {
        public XBeeFrameException(String message)
            : base(message)
        { }

        public XBeeFrameException(String message, Exception inner)
            : base(message, inner)
        { }

        protected XBeeFrameException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

    }
}
