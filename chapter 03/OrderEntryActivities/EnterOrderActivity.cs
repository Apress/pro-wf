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
using System.ComponentModel;
using System.Workflow.ComponentModel;
using System.Workflow.Activities;

namespace OrderEntryActivities
{
    /// <summary>
    /// Enter a validated order
    /// </summary>
    public partial class EnterOrderActivity : Activity
    {
        public EnterOrderActivity()
        {
            InitializeComponent();
        }

        #region Public workflow properties

        public static DependencyProperty AccountIdProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
            "AccountId", typeof(Int32), typeof(EnterOrderActivity));

        /// <summary>
        /// Identifies the account
        /// </summary>
        [Description("Identifies the account")]
        [Category("Custom Activity Example")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 AccountId
        {
            get
            {
                return ((Int32)(base.GetValue(
                    EnterOrderActivity.AccountIdProperty)));
            }
            set
            {
                base.SetValue(EnterOrderActivity.AccountIdProperty, value);
            }
        }

        public static DependencyProperty SalesItemIdProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
            "SalesItemId", typeof(Int32), typeof(EnterOrderActivity));

        /// <summary>
        /// Identifies the product
        /// </summary>
        [Description("Identifies the product")]
        [Category("Custom Activity Example")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 SalesItemId
        {
            get
            {
                return ((Int32)(base.GetValue(
                    EnterOrderActivity.SalesItemIdProperty)));
            }
            set
            {
                base.SetValue(EnterOrderActivity.SalesItemIdProperty, value);
            }
        }

        public static DependencyProperty SalesItemAmountProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
            "SalesItemAmount", typeof(Decimal), typeof(EnterOrderActivity));

        /// <summary>
        /// The cost of the product
        /// </summary>
        [Description("The cost of the product")]
        [Category("Custom Activity Example")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Decimal SalesItemAmount
        {
            get
            {
                return ((Decimal)(base.GetValue(
                    EnterOrderActivity.SalesItemAmountProperty)));
            }
            set
            {
                base.SetValue(EnterOrderActivity.SalesItemAmountProperty, value);
            }
        }

        #endregion

        /// <summary>
        /// Enter a validated order
        /// </summary>
        /// <param name="executionContext"></param>
        /// <returns></returns>
        protected override ActivityExecutionStatus Execute(
            ActivityExecutionContext executionContext)
        {
            //simulate the order
            Console.WriteLine(
                "Order entered for account {0}, Item id {1} for {2}",
                AccountId, SalesItemId, SalesItemAmount);

            return base.Execute(executionContext);
        }
    }
}
