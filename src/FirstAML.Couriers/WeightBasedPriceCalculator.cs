using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstAML.Couriers
{
    /// <summary>
    /// Implements a <see cref="IPriceCalculator"/> that calculates the price of shipping a package
    /// based on the weight of the package.
    /// </summary>
    public sealed class WeightBasedPriceCalculator : IPriceCalculator
    {
        private readonly SortedList<int, double> _maximumWeightByMaximumDimension =
            new SortedList<int, double>
            {
                { 10, 1.0 },
                { 50, 3.0 },
                { 100, 6.0 },
                { int.MaxValue, 10.0 },
            };

        private readonly SizeBasedPriceCalculator _calculator;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeightBasedPriceCalculator"/> class.
        /// </summary>
        /// <param name="priceCalculator">The size based price calculator upon which the current calculator bases its price.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="priceCalculator"/> is <see langword="null" />.</exception>
        public WeightBasedPriceCalculator(SizeBasedPriceCalculator priceCalculator)
        {
            _calculator = priceCalculator ?? throw new ArgumentNullException(nameof(priceCalculator));
        }

        /// <summary>
        /// Calculates the shipping cost for the given parcel
        /// </summary>
        /// <param name="parcel">The parcel for which the shipping cost should be calculated.</param>
        /// <returns>The shipping cost, in the current currency.</returns>
        public ParcelOrderLine Calculate(Parcel parcel)
        {
            var orderLine = _calculator.Calculate(parcel);

            var dimensions = new List<int>
                {
                    parcel.LengthInCm,
                    parcel.WidthInCm,
                    parcel.HeightInCm,
                };
            var largestDimension = dimensions.OrderByDescending(d => d).First();
            var maximumWeight = _maximumWeightByMaximumDimension.Where(p => largestDimension < p.Key).First().Value;

            var additionalCost = 0m;
            if (parcel.WeightInKg > maximumWeight)
            {
                additionalCost = Convert.ToDecimal(parcel.WeightInKg - maximumWeight) * 2m;
            }

            return new ParcelOrderLine(parcel, orderLine.Cost + additionalCost, orderLine.ItemDescription);
        }
    }
}
