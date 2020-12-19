using System;

namespace FirstAML.Couriers
{
    /// <summary>
    /// Stores information about a given parcel.
    /// </summary>
    public sealed class Parcel : IOrderItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Parcel"/> class.
        /// </summary>
        /// <param name="lengthInCm">The length of the parcel in centimeters.</param>
        /// <param name="widthInCm">The width of the parcel in centimeters.</param>
        /// <param name="heightInCm">The height of the parcel in centimeters.</param>
        /// <param name="weightInKg">The weight of the parcel in kilogram.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when one of the <paramref name="lengthInCm"/>, <paramref name="widthInCm"/>,
        ///     <paramref name="heightInCm"/> or <paramref name="weightInKg"/> is less than 0.
        /// </exception>
        public Parcel(int lengthInCm, int widthInCm, int heightInCm, double weightInKg)
        {
            if (lengthInCm < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(lengthInCm),
                    string.Format(
                        "The length of the parcel should be greater than 0 cm. The supplied value was: {0}",
                        lengthInCm));
            }

            if (widthInCm < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(widthInCm),
                    string.Format(
                        "The width of the parcel should be greater than 0 cm. The supplied value was: {0}",
                        widthInCm));
            }

            if (heightInCm < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(heightInCm),
                    string.Format(
                        "The height of the parcel should be greater than 0 cm. The supplied value was: {0}",
                        heightInCm));
            }

            if (weightInKg < 0.0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(weightInKg),
                    string.Format(
                        "The weight of the parcel should be greater than 0 kg. The supplied value was: {0}",
                        weightInKg));
            }

            LengthInCm = lengthInCm;
            HeightInCm = heightInCm;
            WidthInCm = widthInCm;

            WeightInKg = weightInKg;
        }

        /// <summary>
        /// Gets the height of the package in centimeters.
        /// </summary>
        public int HeightInCm
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the length of the package in centimeters.
        /// </summary>
        public int LengthInCm
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the weight of the package in kilograms.
        /// </summary>
        public double WeightInKg
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the width of the package in centimeters.
        /// </summary>
        public int WidthInCm
        {
            get;
            private set;
        }
    }
}
