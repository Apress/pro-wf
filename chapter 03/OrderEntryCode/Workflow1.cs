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

namespace OrderEntryCode
{
    /// <summary>
    /// Order entry workflow using CodeActivity
    /// </summary>
    public sealed partial class Workflow1 : SequentialWorkflowActivity
    {
        private Boolean isAccountVerified;
        private Boolean isSalesItemVerified;
        private Decimal availableCredit;
        private Decimal salesItemAmount;

        public Workflow1()
        {
            InitializeComponent();
        }

        #region Public workflow properties

        public static DependencyProperty AccountIdProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
            "AccountId", typeof(Int32), typeof(Workflow1));

        /// <summary>
        /// Identifies the account
        /// </summary>
        [Description("Identifies the account")]
        [Category("CodeActivity Example")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 AccountId
        {
            get
            {
                return ((Int32)(base.GetValue(Workflow1.AccountIdProperty)));
            }
            set
            {
                base.SetValue(Workflow1.AccountIdProperty, value);
            }
        }

        public static DependencyProperty SalesItemIdProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
            "SalesItemId", typeof(Int32), typeof(Workflow1));

        /// <summary>
        /// Identifies the item to sell
        /// </summary>
        [Description("Identifies the item to sell")]
        [Category("CodeActivity Example")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 SalesItemId
        {
            get
            {
                return ((Int32)(base.GetValue(Workflow1.SalesItemIdProperty)));
            }
            set
            {
                base.SetValue(Workflow1.SalesItemIdProperty, value);
            }
        }

        #endregion

        /// <summary>
        /// CodeActivity handler for looking up an account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void codeLookupAccount_ExecuteCode(object sender, EventArgs e)
        {
            //simulate an account lookup
            switch (AccountId)
            {
                case 1001:
                    isAccountVerified = true;
                    availableCredit = 100.00M;
                    break;
                case 2002:
                    isAccountVerified = true;
                    availableCredit = 500.00M;
                    break;
                default:
                    isAccountVerified = false;
                    availableCredit = 0;
                    break;
            }
        }

        /// <summary>
        /// Identify the item to order based on the SalesItemId
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void codeLookupItem_ExecuteCode(object sender, EventArgs e)
        {
            //simulate an item lookup to retrieve the sales amount
            switch (SalesItemId)
            {
                case 501:
                    isSalesItemVerified = true;
                    salesItemAmount = 59.95M;
                    break;
                case 502:
                    isSalesItemVerified = true;
                    salesItemAmount = 199.99M;
                    break;
                default:
                    isSalesItemVerified = false;
                    salesItemAmount = 0;
                    break;
            }
        }

        /// <summary>
        /// Process a validated order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void codeEnterOrder_ExecuteCode(object sender, EventArgs e)
        {
            //simulate the order
            Console.WriteLine(
                "Order entered for account {0}, Item id {1} for {2}",
                AccountId, SalesItemId, salesItemAmount);
        }

        /// <summary>
        /// The AccountId is invalid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void codeBadAccountId_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("AccountId {0} is invalid", AccountId);
        }

        /// <summary>
        /// The Item is invalid or the account has insufficient credit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void codeInsufficientCredit_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine(
                "Item {0} invalid or AccountId {1} credit of {2} insufficient",
                SalesItemId, AccountId, availableCredit);
        }
    }
}
