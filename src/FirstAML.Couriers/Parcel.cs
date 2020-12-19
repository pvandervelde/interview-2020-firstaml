using System;

namespace FirstAML.Couriers
{
    /// <summary>
    /// This documentation comment is here to make the build pass for now.
    /// </summary>
    public sealed class Parcel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Parcel"/> class.
        /// </summary>
        /// <param name="lengthInCm">The length of the parcel in centimeters.</param>
        /// <param name="widthInCm">The width of the parcel in centimeters.</param>
        /// <param name="heightInCm">The height of the parcel in centimeters.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when one of the <paramref name="lengthInCm"/>, <paramref name="widthInCm"/> or
        ///     <paramref name="heightInCm"/> is less than 0.
        /// </exception>
        public Parcel(int lengthInCm, int widthInCm, int heightInCm)
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

            LengthInCm = lengthInCm;
            HeightInCm = heightInCm;
            WidthInCm = widthInCm;
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
        /// Gets the width of the package in centimeters.
        /// </summary>
        public int WidthInCm
        {
            get;
            private set;
        }
    }
}
