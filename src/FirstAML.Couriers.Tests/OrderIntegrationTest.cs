using NUnit.Framework;

namespace FirstAML.Couriers.Tests
{
    [TestFixture]
    public sealed class OrderIntegrationTest
    {
        [Test]
        public void When_AnOrderIsCreated_WithSize_Then_TheTotalPrice_ShouldBeCorrect()
        {
            var smallParcel = new Parcel(5, 6, 7, 0.5);
            var mediumParcel = new Parcel(10, 6, 7, 1.5);
            var largeParcel = new Parcel(50, 6, 7, 3.0);
            var extraLargeParcel = new Parcel(100, 6, 7, 5.0);

            var calculator = new WeightBasedPriceCalculator(new SizeBasedPriceCalculator());
            var order = new Order(calculator);

            order.Add(smallParcel);
            order.Add(mediumParcel);
            order.Add(largeParcel);
            order.Add(extraLargeParcel);

            Assert.That(order.TotalCost, Is.EqualTo(3m + 8m + 15m + 25m));
        }

        [Test]
        public void When_AnOrderIsCreated_WithSizeAndWeight_Then_TheTotalPrice_ShouldBeCorrect()
        {
            var smallParcel = new Parcel(5, 6, 7, 3.0);
            var mediumParcel = new Parcel(10, 6, 7, 5.0);
            var largeParcel = new Parcel(50, 6, 7, 8.0);
            var extraLargeParcel = new Parcel(100, 6, 7, 12.0);

            var calculator = new WeightBasedPriceCalculator(new SizeBasedPriceCalculator());
            var order = new Order(calculator);

            order.Add(smallParcel);
            order.Add(mediumParcel);
            order.Add(largeParcel);
            order.Add(extraLargeParcel);

            Assert.That(order.TotalCost, Is.EqualTo(3m + 4m + 8m + 4m + 15m + 4m + 25m + 4m));
        }

        [Test]
        public void When_AnOrderIsCreated_WithSize_And_SpeedyDelivery_Then_TheTotalPrice_ShouldBeCorrect()
        {
            var smallParcel = new Parcel(5, 6, 7, 0.5);
            var mediumParcel = new Parcel(10, 6, 7, 1.5);
            var largeParcel = new Parcel(50, 6, 7, 3.0);
            var extraLargeParcel = new Parcel(100, 6, 7, 5.0);

            var calculator = new WeightBasedPriceCalculator(new SizeBasedPriceCalculator());
            var order = new Order(calculator, speedyShipping:true);

            order.Add(smallParcel);
            order.Add(mediumParcel);
            order.Add(largeParcel);
            order.Add(extraLargeParcel);

            Assert.That(order.TotalCost, Is.EqualTo(2 * (3m + 8m + 15m + 25m)));
        }

        [Test]
        public void When_AnOrderIsCreated_WithSizeAndWeight_And_SpeedyDelivery_Then_TheTotalPrice_ShouldBeCorrect()
        {
            var smallParcel = new Parcel(5, 6, 7, 3.0);
            var mediumParcel = new Parcel(10, 6, 7, 5.0);
            var largeParcel = new Parcel(50, 6, 7, 8.0);
            var extraLargeParcel = new Parcel(100, 6, 7, 12.0);

            var calculator = new WeightBasedPriceCalculator(new SizeBasedPriceCalculator());
            var order = new Order(calculator, speedyShipping: true);

            order.Add(smallParcel);
            order.Add(mediumParcel);
            order.Add(largeParcel);
            order.Add(extraLargeParcel);

            Assert.That(order.TotalCost, Is.EqualTo(2 * (3m + 4m + 8m + 4m + 15m + 4m + 25m + 4m)));
        }
    }
}
