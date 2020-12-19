using System;
using NUnit.Framework;

namespace FirstAML.Couriers.Tests
{
    [TestFixture]
    public sealed class SpeedyShippingItemTest
    {
        [Test]
        public void When_CreatingASpeedyShippingItem_Then_InformationShouldBeSet()
        {
            Func<decimal> func = () => 10m;
            var speedyShipping = new SpeedyShippingItem(func);

            Assert.That(speedyShipping.Cost, Is.EqualTo(10m));
        }

        [Test]
        public void When_CreatingASpeedyShippingItem_WithNullCalculator_Then_ExceptionIsThrown()
        {
            Assert.Throws<ArgumentNullException>(() => new SpeedyShippingItem(null));
        }
    }
}
