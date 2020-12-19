namespace FirstAML.Couriers
{
    /// <summary>
    /// Defines the interface for types that calculate the price of shipping a parcel
    /// </summary>
    public interface IPriceCalculator
    {
        /// <summary>
        /// Calculates the shipping cost for the given parcel
        /// </summary>
        /// <param name="parcel">The parcel for which the shipping cost should be calculated.</param>
        /// <returns>The shipping cost, in the current currency.</returns>
        OrderLine Calculate(Parcel parcel);
    }
}