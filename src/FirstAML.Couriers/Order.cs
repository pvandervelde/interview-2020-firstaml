using System;
using System.Collections.Generic;

namespace FirstAML.Couriers
{
    /// <summary>
    /// Stores information about an order of parcels and the costs associated with shipping the parcels.
    /// </summary>
    public sealed class Order : IOrder
    {
        private readonly List<IOrderLine> _parcels = new List<IOrderLine>();

        private readonly IPriceCalculator _priceCalculator;

        private readonly bool _speedyShipping;

        private SpeedyShippingItem _speedyShippingItem;

        private decimal _totalCost;

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        /// <param name="calculator">
        ///     The <see cref="IPriceCalculator"/> instance that is used to calculate the shipping cost of
        ///     an individual parcel.
        /// </param>
        /// <param name="speedyShipping">
        ///     A flag that indicates whether the order should be shipped with 'speedy shipping'.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="calculator"/> is <see langword="null" />.
        /// </exception>
        public Order(IPriceCalculator calculator, bool speedyShipping = false)
        {
            _priceCalculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
            _speedyShipping = speedyShipping;

            _speedyShippingItem = new SpeedyShippingItem(() => this._speedyShipping ? this._totalCost : 0m);
            if (_speedyShipping)
            {
                _parcels.Add(_speedyShippingItem);
            }
        }

        /// <summary>
        /// Adds a new <see cref="Parcel"/> to the order.
        /// </summary>
        /// <param name="parcel">The parcel to add.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="parcel"/> is <see langword="null" />. </exception>
        public void Add(Parcel parcel)
        {
            if (parcel is null)
            {
                throw new ArgumentNullException(nameof(parcel));
            }

            var shippingInformation = _priceCalculator.Calculate(parcel);
            _parcels.Add(shippingInformation);

            _totalCost += shippingInformation.Cost;
        }

        /// <summary>
        /// Gets the collection of items and their shipping information.
        /// </summary>
        public IEnumerable<IOrderLine> Items
        {
            get
            {
                return _parcels.AsReadOnly();
            }
        }

        /// <summary>
        /// Gets the total cost for the current order.
        /// </summary>
        public decimal TotalCost 
        {
            get
            {
                return _totalCost + _speedyShippingItem.Cost;
            }
        }
    }
}
