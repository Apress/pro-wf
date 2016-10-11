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
using System.Workflow.Activities;
using System.Workflow.Activities.Rules; //needed for rule attributes

namespace SharedWorkflows
{
    /// <summary>
    /// Processes a sales item using a RuleSet
    /// </summary>
    public sealed partial class SellItemMethods2Workflow
        : SequentialWorkflowActivity
    {
        private SalesItem _salesItem;

        public SalesItem SalesItem
        {
            get { return _salesItem; }
            set { _salesItem = value; }
        }

        public SellItemMethods2Workflow()
        {
            InitializeComponent();
        }

        [RuleRead("SalesItem/OrderTotal")]
        public Double GetOrderTotal()
        {
            return SalesItem.OrderTotal;
        }

        [RuleInvoke("PrivateOrderTotalMethod")]
        public void SetOrderTotal(Double newTotal)
        {
            PrivateOrderTotalMethod(newTotal);
        }

        [RuleWrite("SalesItem/OrderTotal")]
        private void PrivateOrderTotalMethod(Double newTotal)
        {
            SalesItem.OrderTotal = newTotal;
        }
    }
}
