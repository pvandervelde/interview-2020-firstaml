namespace FirstAML.Couriers
{
    /// <summary>
    /// Stores information about the shipping item.
    /// </summary>
    public interface IOrderLine
    {
        /// <summary>
        /// Gets the cost of shipping the item.
        /// </summary>
        decimal Cost
        {
            get;
        }

        /// <summary>
        /// Gets the item that should be shipped.
        /// </summary>
        IOrderItem ItemToShip
        {
            get;
        }

        /// <summary>
        /// Gets the item description for shipping purposes.
        /// </summary>
        string ItemDescription
        {
            get;
        }
    }
}