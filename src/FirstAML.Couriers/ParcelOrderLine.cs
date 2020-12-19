using System;
using System.Globalization;

namespace FirstAML.Couriers
{
    /// <summary>
    /// Stores information about the parcel that should be shipped.
    /// </summary>
    public sealed class ParcelOrderLine : IOrderLine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParcelOrderLine"/> class.
        /// </summary>
        /// <param name="item">The parcel to which the shipping information applies.</param>
        /// <param name="cost">The cost of shipping the parcel.</param>
        /// <param name="itemDescription">The description of the parcel.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="item"/> or <paramref name="itemDescription"/> are <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     Thrown when <paramref name="itemDescription"/> is an empty string.
        /// </exception>
        public ParcelOrderLine(Parcel item, decimal cost, string itemDescription)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (itemDescription is null)
            {
                throw new ArgumentNullException(nameof(itemDescription));
            }

            if (string.IsNullOrWhiteSpace(itemDescription))
            {
                throw new ArgumentException(
                    "The item description should not be an empty string",
                    nameof(itemDescription));
            }

            if (cost < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(cost),
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "The cost of shiping an item should be greater than 0. The supplied value was: {0}",
                        cost));
            }

            ItemToShip = item;
            ItemDescription = itemDescription;
            Cost = cost;
        }

        /// <summary>
        /// Gets the cost of shipping the item.
        /// </summary>
        public decimal Cost
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the item that should be shipped.
        /// </summary>
        public IOrderItem ItemToShip
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the item description for shipping purposes.
        /// </summary>
        public string ItemDescription
        {
            get;
            private set;
        }
    }
}