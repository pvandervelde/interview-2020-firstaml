using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace FirstAML.Couriers.Tests
{
    [TestFixture]
    public sealed class WeightBasedPriceCalculatorTest
    {
        [Test]
        public void When_TheCalculatorIsCreated_WithNullSubCalculator_Then_ExceptionIsThrown()
        {
            Assert.Throws<ArgumentNullException>(() => new WeightBasedPriceCalculator(null));
        }

        [TestCase(5, 6, 7, 1.0, 3, "Small")]
        [TestCase(5, 6, 7, 2.0, 5, "Small")]
        [TestCase(10, 6, 7, 3.0, 8, "Medium")]
        [TestCase(10, 6, 7, 5.0, 12, "Medium")]
        [TestCase(5, 10, 7, 3.0, 8, "Medium")]
        [TestCase(5, 6, 10, 3.0, 8, "Medium")]
        [TestCase(50, 6, 7, 6.0, 15, "Large")]
        [TestCase(50, 6, 7, 9.0, 21, "Large")]
        [TestCase(100, 6, 7, 10.0, 25, "Extra Large")]
        [TestCase(100, 6, 7, 12.5, 30, "Extra Large")]
        public void When_ThePriceIsCalculated_Then_ParcelShippingInformationShouldBeReturned(int length, int width, int height, double weight, decimal cost, string description)
        {
            var parcel = new Parcel(length, width, height, weight);

            var calculator = new WeightBasedPriceCalculator(new SizeBasedPriceCalculator());
            var info = calculator.Calculate(parcel);


            Assert.That(info.ItemToShip, Is.SameAs(parcel));
            Assert.That(info.Cost, Is.EqualTo(cost));
            Assert.That(info.ItemDescription, Is.EqualTo(description));
        }

        [Test]
        public void When_ThePriceIsCalculated_WithNullParcel_Then_ExceptionIsThrown()
        {
            var calculator = new WeightBasedPriceCalculator(new SizeBasedPriceCalculator());
            Assert.Throws<ArgumentNullException>(() => calculator.Calculate(null));
        }
    }
}
