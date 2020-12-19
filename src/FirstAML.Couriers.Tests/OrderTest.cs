using System;
using System.Linq;
using Moq;
using NUnit.Framework;

namespace FirstAML.Couriers.Tests
{
    [TestFixture]
    public sealed class OrderTest
    {
        [Test]
        public void When_AnOrderIsCreated_Then_TheTotalPrice_ShouldBeCorrect()
        {
            const decimal costPerParcel = 10m;

            var calculator = new Mock<IPriceCalculator>();
            {
                calculator.Setup(c => c.Calculate(It.IsAny<Parcel>()))
                    .Returns<Parcel>(p => new ParcelOrderLine(p, costPerParcel, "not-an-actual-type"));
            }
            
            var order = new Order(calculator.Object);

            int count = 10;
            for (int i = 0; i < count; i++)
            {
                var parcel = new Parcel(i + 1, i + 1, i + 1, 1.0);
                order.Add(parcel);
            }

            Assert.That(order.TotalCost, Is.EqualTo(count * costPerParcel));

            Assert.That(order.Items.Count(), Is.EqualTo(count));
            foreach (var parcel in order.Items)
            {
                Assert.That(parcel.Cost, Is.EqualTo(costPerParcel));
            }
        }

        [Test]
        public void When_AnOrderIsCreated_WithSpeedyShipping_Then_TheTotalPrice_ShouldBeCorrect()
        {
            const decimal costPerParcel = 10m;

            var calculator = new Mock<IPriceCalculator>();
            {
                calculator.Setup(c => c.Calculate(It.IsAny<Parcel>()))
                    .Returns<Parcel>(p => new ParcelOrderLine(p, costPerParcel, "not-an-actual-type"));
            }

            var order = new Order(calculator.Object, true);

            int count = 10;
            for (int i = 0; i < count; i++)
            {
                var parcel = new Parcel(i + 1, i + 1, i + 1, 1.0);
                order.Add(parcel);
            }

            Assert.That(order.TotalCost, Is.EqualTo(2 * count * costPerParcel));

            Assert.That(order.Items.Count(), Is.EqualTo(count + 1));
            foreach (var parcel in order.Items)
            {
                if (parcel is ParcelOrderLine)
                {
                    Assert.That(parcel.Cost, Is.EqualTo(costPerParcel));
                }
                else
                {
                    Assert.That(parcel.Cost, Is.EqualTo(count * costPerParcel));
                }
            }
        }

        [Test]
        public void When_AnOrderIsCreated_WithNullCalculator_Then_ExceptionIsThrown()
        {
            Assert.Throws<ArgumentNullException>(() => new Order(null));
        }
    }
}
