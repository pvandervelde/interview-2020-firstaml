using System;

namespace FirstAML.Couriers
{
    /// <summary>
    /// Defines an order item for speedy shipping.
    /// </summary>
    public sealed class SpeedyShippingItem : IOrderLine
    {
        private readonly Func<decimal> _fastDeliverySurchargeCalculator;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpeedyShippingItem"/> class.
        /// </summary>
        /// <param name="fastDeliverySurchargeCalculator">The function used to calculate the surcharge for speedy shipping.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="fastDeliverySurchargeCalculator"/> is <see langword="null" />.
        /// </exception>
        public SpeedyShippingItem(Func<decimal> fastDeliverySurchargeCalculator)
        {
            _fastDeliverySurchargeCalculator = fastDeliverySurchargeCalculator ?? 
                throw new ArgumentNullException(nameof(fastDeliverySurchargeCalculator));
        }

        /// <summary>
        /// Gets the cost of shipping the item.
        /// </summary>
        public decimal Cost
        {
            get
            {
                return _fastDeliverySurchargeCalculator();
            }
        }

        /// <summary>
        /// Gets the item that should be shipped.
        /// </summary>
        public IOrderItem ItemToShip
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the item description for shipping purposes.
        /// </summary>
        public string ItemDescription
        {
            get
            {
                return "Fast delivery";
            }
        }
    }
}