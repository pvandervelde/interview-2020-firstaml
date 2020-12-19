using System;
using System.Globalization;

namespace FirstAML.Couriers
{
    /// <summary>
    /// Stores information about the shipping details of a parcel.
    /// </summary>
    public sealed class ParcelShippingInformation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParcelShippingInformation"/> class.
        /// </summary>
        /// <param name="parcel">The parcel to which the shipping information applies.</param>
        /// <param name="cost">The cost of shipping the parcel.</param>
        /// <param name="parcelType">The type of the parcel.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="parcel"/> or <paramref name="parcelType"/> are <see langword="null" />.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     Thrown when <paramref name="parcelType"/> is an empty string.
        /// </exception>
        public ParcelShippingInformation(Parcel parcel, decimal cost, string parcelType)
        {
            if (parcel is null)
            {
                throw new ArgumentNullException(nameof(parcel));
            }

            if (parcelType is null)
            {
                throw new ArgumentNullException(nameof(parcelType));
            }

            if (string.IsNullOrWhiteSpace(parcelType))
            {
                throw new ArgumentException(
                    "The type of a parcel should not be an empty string",
                    nameof(parcelType));
            }

            if (cost < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(cost),
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "The cost of shiping a parcel should be greater than 0. The supplied value was: {0}",
                        cost));
            }

            ParcelToBeShipped = parcel;
            ParcelType = parcelType;
            Cost = cost;
        }

        /// <summary>
        /// Gets the cost of shipping the parcel.
        /// </summary>
        public decimal Cost
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the parcel that should be shipped.
        /// </summary>
        public Parcel ParcelToBeShipped
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the type of the parcel for shipping purposes.
        /// </summary>
        public string ParcelType
        {
            get;
            private set;
        }
    }
}