using System;
using NUnit.Framework;

namespace FirstAML.Couriers.Tests
{
    public sealed class Tests
    {
        [Test]
        public void When_CreatingAPackage_Then_DimensionsShouldBeSet()
        {
            var length = 1;
            var width = 2;
            var height = 3;

            var parcel = new Parcel(length, width, height);

            Assert.AreEqual(length, parcel.LengthInCm);
            Assert.AreEqual(width, parcel.WidthInCm);
            Assert.AreEqual(height, parcel.HeightInCm);
        }

        [Test]
        public void When_CreatingAPackage_WithNegativeHeight_Then_ExceptionIsThrown()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new Parcel(1, 1, -1));
            Assert.That(exception.Message, Does.Contain("height"));
        }

        [Test]
        public void When_CreatingAPackage_WithNegativeLength_Then_ExceptionIsThrown()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new Parcel(-1, 1, 1));
            Assert.That(exception.Message, Does.Contain("length"));
        }

        [Test]
        public void When_CreatingAPackage_WithNegativeWidth_Then_ExceptionIsThrown()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new Parcel(1, -1, 1));
            Assert.That(exception.Message, Does.Contain("width"));
        }
    }
}