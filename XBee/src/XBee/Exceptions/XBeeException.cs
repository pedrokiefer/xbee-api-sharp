namespace XBee.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class XBeeException : System.Exception
    {
        public XBeeException(String message)
            : base(message)
        { }

        public XBeeException(String message, Exception inner)
            : base(message, inner)
        { }

        protected XBeeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

    }
}
