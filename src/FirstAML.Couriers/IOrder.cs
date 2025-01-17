﻿using System.Collections.Generic;

namespace FirstAML.Couriers
{
    /// <summary>
    /// Defines the interface for types that define an order, a collection of parcels and
    /// their associated shipping costs.
    /// </summary>
    public interface IOrder
    {
        /// <summary>
        /// Adds a new <see cref="Parcel"/> to the order.
        /// </summary>
        /// <param name="parcel">The parcel to add.</param>
        void Add(Parcel parcel);

        /// <summary>
        /// Gets the collection of items and their shipping information.
        /// </summary>
        IEnumerable<IOrderLine> Items
        {
            get;
        }

        /// <summary>
        /// Gets the total cost for the current order.
        /// </summary>
        decimal TotalCost 
        { 
            get; 
        }
    }
}