using NUnit.Framework;

namespace FirstAML.Couriers.Tests
{
    [TestFixture]
    public sealed class OrderIntegrationTest
    {
        [Test]
        public void When_AnOrderIsCreated_WithTheSizeBasedCalculator_Then_TheTotalPrice_ShouldBeCorrect()
        {
            var smallParcel = new Parcel(5, 6, 7);
            var mediumParcel = new Parcel(10, 6, 7);
            var largeParcel = new Parcel(50, 6, 7);
            var extraLargeParcel = new Parcel(100, 6, 7);

            var calculator = new SizeBasedPriceCalculator();
            var order = new Order(calculator);

            order.Add(smallParcel);
            order.Add(mediumParcel);
            order.Add(largeParcel);
            order.Add(extraLargeParcel);

            Assert.That(order.TotalCost, Is.EqualTo(3m + 8m + 15m + 25m));
        }
    }
}
