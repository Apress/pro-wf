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
    public partial class AdjustAccountActivity : Activity
    {
        public static DependencyProperty IdProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
            "Id", typeof(Int32), typeof(AdjustAccountActivity));

        [Description("Identifies the account")]
        [Category("Local Services")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 Id
        {
            get
            {
                return ((Int32)(base.GetValue(AdjustAccountActivity.IdProperty)));
            }
            set
            {
                base.SetValue(AdjustAccountActivity.IdProperty, value);
            }
        }

        public static DependencyProperty AdjustmentProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
            "Adjustment", typeof(Double), typeof(AdjustAccountActivity));

        [Description("The adjustment amount")]
        [Category("Local Services")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Double Adjustment
        {
            get
            {
                return ((Double)(base.GetValue(
                    AdjustAccountActivity.AdjustmentProperty)));
            }
            set
            {
                base.SetValue(AdjustAccountActivity.AdjustmentProperty, value);
            }
        }

        public static DependencyProperty AccountProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
            "Account", typeof(Account), typeof(AdjustAccountActivity));

        [Description("The revised Account object")]
        [Category("Local Services")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Account Account
        {
            get
            {
                return ((Account)(base.GetValue(
                    AdjustAccountActivity.AccountProperty)));
            }
            set
            {
                base.SetValue(AdjustAccountActivity.AccountProperty, value);
            }
        }

        public AdjustAccountActivity()
        {
            InitializeComponent();
        }

        protected override ActivityExecutionStatus Execute(
            ActivityExecutionContext executionContext)
        {
            IAccountServices accountServices =
                executionContext.GetService<IAccountServices>();
            if (accountServices == null)
            {
                //we have a big problem
                throw new InvalidOperationException(
                    "Unable to retrieve IAccountServices from runtime");
            }

            //apply the adjustment to the account
            Account = accountServices.AdjustBalance(Id, Adjustment);

            return base.Execute(executionContext);
        }
    }
}
