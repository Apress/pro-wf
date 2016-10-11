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
    /// Order entry workflow using custom activities
    /// </summary>
    public sealed partial class Workflow1 : SequentialWorkflowActivity
    {
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

        private void codeBadAccountId_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("AccountId {0} is invalid", AccountId);
        }

        private void codeInsufficientCredit_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine(
                "Item {0} invalid or AccountId {1} credit of {2} insufficient",
                SalesItemId, AccountId,
                this.validateAccountActivity1.AvailableCredit);
        }
    }
}
