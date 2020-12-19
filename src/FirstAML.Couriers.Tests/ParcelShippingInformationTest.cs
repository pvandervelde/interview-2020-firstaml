using System;
using NUnit.Framework;

namespace FirstAML.Couriers.Tests
{
    [TestFixture]
    public sealed class ParcelShippingInformationTest
    {
        [Test]
        public void When_CreatingAParcelShippingInformation_Then_InformationShouldBeSet()
        {
            var cost = 10m;
            var parcel = new Parcel(1, 2, 3);
            var parcelType = "a";

            var shippingInfo = new ParcelShippingInformation(parcel, cost, parcelType);

            Assert.That(shippingInfo.Cost, Is.EqualTo(cost));
            Assert.That(shippingInfo.ParcelToBeShipped, Is.SameAs(parcel));
            Assert.That(shippingInfo.ParcelType, Is.EqualTo(parcelType));
        }

        [Test]
        public void When_CreatingAParcelShippingInformation_WithEmptyParcelType_Then_ExceptionIsThrown()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new ParcelShippingInformation(new Parcel(1, 2, 3), -1, "a"));
        }

        [Test]
        public void When_CreatingAParcelShippingInformation_WithNegativeCost_Then_ExceptionIsThrown()
        {
            Assert.Throws<ArgumentException>(() => new ParcelShippingInformation(new Parcel(1, 2, 3), 4, string.Empty));
        }

        [Test]
        public void When_CreatingAParcelShippingInformation_WithNullParcel_Then_ExceptionIsThrown()
        {
            Assert.Throws<ArgumentNullException>(() => new ParcelShippingInformation(null, 1, "a"));
        }

        [Test]
        public void When_CreatingAParcelShippingInformation_WithNullParcelType_Then_ExceptionIsThrown()
        {
            Assert.Throws<ArgumentNullException>(() => new ParcelShippingInformation(new Parcel(1, 2, 3), 4, null));
        }
    }
}
