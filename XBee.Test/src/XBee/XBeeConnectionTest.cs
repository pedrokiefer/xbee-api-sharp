using Moq;
using NUnit.Framework;

namespace XBee.Test
{
    [TestFixture]
    public class XBeeConnectionTest
    {
        [Test]
        public void TestXBeeConnection()
        {
            var conn = new Mock<IXBeeConnection>();
            var xbee = new XBee {ApiType = ApiTypeValue.Enabled};

            xbee.SetConnection(conn.Object);

            conn.Verify(connection => connection.SetPacketReader(It.IsAny<IPacketReader>()) );
        }
    }
}
