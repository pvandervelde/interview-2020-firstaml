using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using NuGet.Frameworks;
using NUnit.Framework;

namespace FirstAML.Couriers.Tests
{
    [TestFixture]
    public sealed class SizeBasedPriceCalculatorTest
    {
        [TestCase(5, 6, 7, 3, "Small")]
        [TestCase(10, 6, 7, 8, "Medium")]
        [TestCase(5, 10, 7, 8, "Medium")]
        [TestCase(5, 6, 10, 8, "Medium")]
        [TestCase(50, 6, 7, 15, "Large")]
        [TestCase(100, 6, 7, 25, "Extra Large")]
        public void When_ThePriceIsCalculated_Then_ParcelShippingInformationShouldBeReturned(int length, int width, int height, decimal cost, string description)
        {
            var parcel = new Parcel(length, width, height);

            var calculator = new SizeBasedPriceCalculator();
            var info = calculator.Calculate(parcel);


            Assert.That(info.ParcelToBeShipped, Is.SameAs(parcel));
            Assert.That(info.Cost, Is.EqualTo(cost));
            Assert.That(info.ParcelType, Is.EqualTo(description));
        }

        [Test]
        public void When_ThePriceIsCalculated_WithNullParcel_Then_ExceptionIsThrown()
        {
            var calculator = new SizeBasedPriceCalculator();
            Assert.Throws<ArgumentNullException>(() => calculator.Calculate(null));
        }
    }
}
