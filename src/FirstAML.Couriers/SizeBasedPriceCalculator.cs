using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstAML.Couriers
{
    /// <summary>
    /// Implements a <see cref="IPriceCalculator"/> that calculates the price of shipping a package
    /// based on the size of the package.
    /// </summary>
    public sealed class SizeBasedPriceCalculator : IPriceCalculator
    {
        private readonly SortedList<int, Tuple<decimal, string>> _shippingCostByMaximumDimension =
            new SortedList<int, Tuple<decimal, string>>
            {
                { 10, Tuple.Create(3m, "Small") },
                { 50, Tuple.Create(8m, "Medium") },
                { 100, Tuple.Create(15m, "Large") },
                { int.MaxValue, Tuple.Create(25m, "Extra Large") },
            };

        /// <summary>
        /// Calculates the shipping cost for the given parcel
        /// </summary>
        /// <param name="parcel">The parcel for which the shipping cost should be calculated.</param>
        /// <returns>The shipping cost, in the current currency.</returns>
        public ParcelShippingInformation Calculate(Parcel parcel)
        {
            if (parcel is null)
            {
                throw new ArgumentNullException(nameof(parcel));
            }

            var dimensions = new List<int>
                {
                    parcel.LengthInCm,
                    parcel.WidthInCm,
                    parcel.HeightInCm,
                };
            var largestDimension = dimensions.OrderByDescending(d => d).First();
            var info = _shippingCostByMaximumDimension.Where(p => largestDimension < p.Key).First().Value;

            return new ParcelShippingInformation(parcel, info.Item1, info.Item2);
        }
    }
}
