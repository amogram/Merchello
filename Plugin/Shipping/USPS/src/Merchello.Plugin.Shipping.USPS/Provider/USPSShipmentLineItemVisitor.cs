﻿using Merchello.Core.Models;

namespace Merchello.Plugin.Shipping.USPS.Provider
{
    public class UspsShipmentLineItemVisitor : ILineItemVisitor
    {
        public void Visit(ILineItem lineItem)
        {
            if (!lineItem.ExtendedData.DefinesProductVariant()) return;

            // adjust the total weight
            TotalWeight += lineItem.ExtendedData.GetWeightValue() * lineItem.Quantity;


            TotalLength += lineItem.ExtendedData.GetLengthValue() * lineItem.Quantity;
            TotalWidth += lineItem.ExtendedData.GetWidthValue() * lineItem.Quantity;
            TotalHeight += lineItem.ExtendedData.GetHeightValue()*lineItem.Quantity;

            // adjust the total price
            if (UseOnSalePriceIfOnSale)
            {
                TotalPrice += lineItem.ExtendedData.GetOnSaleValue()
                    ? lineItem.ExtendedData.GetSalePriceValue()
                    : lineItem.ExtendedData.GetPriceValue();
            }
            else
            {
                TotalPrice += lineItem.ExtendedData.GetPriceValue() * lineItem.Quantity;
            }

            Quantity = lineItem.Quantity;
        }

        /// <summary>
        /// Returns the TotalWeight from ExtendedData
        /// </summary>
        public decimal TotalWeight { get; private set; }

        /// <summary>
        /// Returns the TotalLength from ExtendedData
        /// </summary>
        public decimal TotalLength { get; private set; }

        /// <summary>
        /// Returns the TotalWidth from ExtendedData
        /// </summary>
        public decimal TotalWidth { get; private set; }

        /// <summary>
        /// Returns the TotalHeight from ExtendedData
        /// </summary>
        public decimal TotalHeight { get; private set; }

        /// <summary>
        /// Returns the TotalPrice form ExtendedData
        /// </summary>
        public decimal TotalPrice { get; private set; }

        /// <summary>
        /// Returns the TotalWeight from ExtendedData
        /// </summary>
        public int Quantity { get; private set; }

        /// <summary>
        /// True/false indicating whether or not to use the OnSale price in the total price calculation
        /// </summary>
        public bool UseOnSalePriceIfOnSale
        {
            get;
            set;
        }
    }
}