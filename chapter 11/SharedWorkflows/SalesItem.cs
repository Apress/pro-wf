//--------------------------------------------------------------------------------
// This file is part of the downloadable code for the Apress book:
// Pro WF: Windows Workflow in .NET 3.0
// Copyright (c) Bruce Bukovics.  All rights reserved.
//
// This code is provided as is without warranty of any kind, either expressed
// or implied, including but not limited to fitness for any particular purpose. 
// You may use the code for any commercial or noncommercial purpose, and combine 
// it with your own code, but cannot reproduce it in whole or in part for 
// publication purposes without prior approval. 
//--------------------------------------------------------------------------------

using System;

namespace SharedWorkflows
{
    /// <summary>
    /// A class that defines an item to sell
    /// </summary>
    [Serializable]
    public class SalesItem
    {
        private Int32 _quantity;
        private Double _itemPrice;
        private Double _orderTotal;
        private Double _shipping;
        private Boolean _isNewCustomer;

        public Int32 Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public Double ItemPrice
        {
            get { return _itemPrice; }
            set { _itemPrice = value; }
        }

        public Double OrderTotal
        {
            get { return _orderTotal; }
            set { _orderTotal = value; }
        }

        public Double Shipping
        {
            get { return _shipping; }
            set { _shipping = value; }
        }

        public Boolean IsNewCustomer
        {
            get { return _isNewCustomer; }
            set { _isNewCustomer = value; }
        }
    }
}
