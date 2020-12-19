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
                    .Returns<Parcel>(p => new ParcelShippingInformation(p, costPerParcel, "not-an-actual-type"));
            }
            
            var order = new Order(calculator.Object);

            int count = 10;
            for (int i = 0; i < count; i++)
            {
                var parcel = new Parcel(i + 1, i + 1, i + 1);
                order.Add(parcel);
            }

            Assert.That(order.TotalCost, Is.EqualTo(count * costPerParcel));

            Assert.That(order.Parcels.Count(), Is.EqualTo(count));
            foreach (var parcel in order.Parcels)
            {
                Assert.That(parcel.Cost, Is.EqualTo(costPerParcel));
            }
        }

        [Test]
        public void When_AnOrderIsCreated_WithNullCalculator_Then_ExceptionIsThrown()
        {
            Assert.Throws<ArgumentNullException>(() => new Order(null));
        }
    }
}
