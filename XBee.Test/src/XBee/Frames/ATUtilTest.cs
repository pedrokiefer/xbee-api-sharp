using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using XBee.Frames;

namespace XBee.Test.src.XBee.Frames
{
    [TestFixture]
    class ATUtilTest
    {
        [Test]
        public void ATUtilValid()
        {
            Assert.That(ATUtil.Parse("DH"), Is.EqualTo(AT.DH));
        }

        [Test]
        public void ATUtilInvalidReturnsUnknown()
        {
            Assert.That(ATUtil.Parse("11"), Is.EqualTo(AT.UNKNOWN));
        }

        [Test]
        public void ATUtilNullReturnsUnknown()
        {
            Assert.That(ATUtil.Parse(null), Is.EqualTo(AT.UNKNOWN));
        }
    }
}
