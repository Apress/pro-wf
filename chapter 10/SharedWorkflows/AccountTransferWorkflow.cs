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

namespace SharedWorkflows
{
    /// <summary>
    /// Workflow that processes a transfer of funds
    /// between two accounts
    /// </summary>
    public sealed partial class AccountTransferWorkflow
        : SequentialWorkflowActivity
    {
        /// <summary>
        /// Amount Dependency Property
        /// </summary>
        public static DependencyProperty AmountProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
                "Amount", typeof(Decimal), typeof(AccountTransferWorkflow));
        [Description("The amount of the balance adjustment")]
        [Category("ProWorkflow")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Decimal Amount
        {
            get
            {
                return ((Decimal)(base.GetValue(
                    AccountTransferWorkflow.AmountProperty)));
            }
            set
            {
                base.SetValue(AccountTransferWorkflow.AmountProperty, value);
            }
        }

        /// <summary>
        /// FromAccountId Dependency Property
        /// </summary>
        public static DependencyProperty FromAccountIdProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
                "FromAccountId", typeof(Int32), typeof(AccountTransferWorkflow));
        [Description("Identifies the account")]
        [Category("ProWorkflow")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 FromAccountId
        {
            get
            {
                return ((Int32)(base.GetValue(
                    AccountTransferWorkflow.FromAccountIdProperty)));
            }
            set
            {
                base.SetValue(AccountTransferWorkflow.FromAccountIdProperty, value);
            }
        }

        /// <summary>
        /// ToAccountId Dependency Property
        /// </summary>
        public static DependencyProperty ToAccountIdProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
                "ToAccountId", typeof(Int32), typeof(AccountTransferWorkflow));
        [Description("Identifies the account")]
        [Category("ProWorkflow")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 ToAccountId
        {
            get
            {
                return ((Int32)(base.GetValue(
                    AccountTransferWorkflow.ToAccountIdProperty)));
            }
            set
            {
                base.SetValue(AccountTransferWorkflow.ToAccountIdProperty, value);
            }
        }

        public AccountTransferWorkflow()
        {
            InitializeComponent();
        }
    }
}
