using System;
using NUnit.Framework;

namespace FirstAML.Couriers.Tests
{
    [TestFixture]
    public sealed class ParcelOrderLineTest
    {
        [Test]
        public void When_CreatingAParcelOrderLine_Then_InformationShouldBeSet()
        {
            var cost = 10m;
            var parcel = new Parcel(1, 2, 3, 1.0);
            var parcelType = "a";

            var shippingInfo = new ParcelOrderLine(parcel, cost, parcelType);

            Assert.That(shippingInfo.Cost, Is.EqualTo(cost));
            Assert.That(shippingInfo.ItemToShip, Is.SameAs(parcel));
            Assert.That(shippingInfo.ItemDescription, Is.EqualTo(parcelType));
        }

        [Test]
        public void When_CreatingAParcelOrderLine_WithEmptyParcelType_Then_ExceptionIsThrown()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new ParcelOrderLine(new Parcel(1, 2, 3, 1.0), -1, "a"));
        }

        [Test]
        public void When_CreatingAParcelOrderLine_WithNegativeCost_Then_ExceptionIsThrown()
        {
            Assert.Throws<ArgumentException>(() => new ParcelOrderLine(new Parcel(1, 2, 3, 1.0), 4, string.Empty));
        }

        [Test]
        public void When_CreatingAParcelOrderLine_WithNullParcel_Then_ExceptionIsThrown()
        {
            Assert.Throws<ArgumentNullException>(() => new ParcelOrderLine(null, 1, "a"));
        }

        [Test]
        public void When_CreatingAParcelOrderLine_WithNullParcelType_Then_ExceptionIsThrown()
        {
            Assert.Throws<ArgumentNullException>(() => new ParcelOrderLine(new Parcel(1, 2, 3, 1.0), 4, null));
        }
    }
}
