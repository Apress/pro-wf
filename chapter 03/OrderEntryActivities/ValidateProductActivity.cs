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
    /// Validate a product ID and retrieve its cost
    /// </summary>
    public partial class ValidateProductActivity : Activity
    {
        public ValidateProductActivity()
        {
            InitializeComponent();
        }

        #region Public workflow properties

        public static DependencyProperty SalesItemIdProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
            "SalesItemId", typeof(Int32), typeof(ValidateProductActivity));

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
                    ValidateProductActivity.SalesItemIdProperty)));
            }
            set
            {
                base.SetValue(ValidateProductActivity.SalesItemIdProperty, value);
            }
        }

        public static DependencyProperty SalesItemAmountProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
            "SalesItemAmount", typeof(Decimal), typeof(ValidateProductActivity));

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
                    ValidateProductActivity.SalesItemAmountProperty)));
            }
            set
            {
                base.SetValue(
                    ValidateProductActivity.SalesItemAmountProperty, value);
            }
        }

        public static DependencyProperty IsSalesItemVerifiedProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
            "IsSalesItemVerified", typeof(Boolean), 
            typeof(ValidateProductActivity));

        /// <summary>
        /// Determines if the SalesItemId valid
        /// </summary>
        [Description("Determines if the SalesItemId valid")]
        [Category("Custom Activity Example")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Boolean IsSalesItemVerified
        {
            get
            {
                return ((Boolean)(base.GetValue(
                    ValidateProductActivity.IsSalesItemVerifiedProperty)));
            }
            set
            {
                base.SetValue(
                    ValidateProductActivity.IsSalesItemVerifiedProperty, value);
            }
        }

        #endregion

        /// <summary>
        /// Validate the product ID and determine the product cost
        /// </summary>
        /// <param name="executionContext"></param>
        /// <returns></returns>
        protected override ActivityExecutionStatus Execute(
            ActivityExecutionContext executionContext)
        {
            //simulate an item lookup to retrieve the sales amount
            switch (SalesItemId)
            {
                case 501:
                    IsSalesItemVerified = true;
                    SalesItemAmount = 59.95M;
                    break;
                case 502:
                    IsSalesItemVerified = true;
                    SalesItemAmount = 199.99M;
                    break;
                default:
                    IsSalesItemVerified = false;
                    SalesItemAmount = 0;
                    break;
            }

            return base.Execute(executionContext);
        }
    }
}
