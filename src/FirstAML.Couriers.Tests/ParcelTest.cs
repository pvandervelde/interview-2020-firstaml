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

            Assert.That(parcel.LengthInCm, Is.EqualTo(length));
            Assert.That(parcel.WidthInCm, Is.EqualTo(width));
            Assert.That(parcel.HeightInCm, Is.EqualTo(height));
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