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
    /// Validate the account and determine the available credit
    /// </summary>
    public partial class ValidateAccountActivity : Activity
    {
        public ValidateAccountActivity()
        {
            InitializeComponent();
        }

        #region Public workflow properties

        public static DependencyProperty AccountIdProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
            "AccountId", typeof(Int32), typeof(ValidateAccountActivity));

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
                    ValidateAccountActivity.AccountIdProperty)));
            }
            set
            {
                base.SetValue(ValidateAccountActivity.AccountIdProperty, value);
            }
        }

        public static DependencyProperty AvailableCreditProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
            "AvailableCredit", typeof(Decimal), typeof(ValidateAccountActivity));

        /// <summary>
        /// The credit amount available for the account
        /// </summary>
        [Description("The credit amount available for the account")]
        [Category("Custom Activity Example")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Decimal AvailableCredit
        {
            get
            {
                return ((Decimal)(base.GetValue(
                    ValidateAccountActivity.AvailableCreditProperty)));
            }
            set
            {
                base.SetValue(
                    ValidateAccountActivity.AvailableCreditProperty, value);
            }
        }

        public static DependencyProperty IsAccountVerifiedProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
            "IsAccountVerified", typeof(Boolean), typeof(ValidateAccountActivity));

        /// <summary>
        /// Determines if the account is valid
        /// </summary>
        [Description("Determines if the account is valid")]
        [Category("Custom Activity Example")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Boolean IsAccountVerified
        {
            get
            {
                return ((Boolean)(base.GetValue(
                    ValidateAccountActivity.IsAccountVerifiedProperty)));
            }
            set
            {
                base.SetValue(
                    ValidateAccountActivity.IsAccountVerifiedProperty, value);
            }
        }

        #endregion

        /// <summary>
        /// Validate the account
        /// </summary>
        /// <param name="executionContext"></param>
        /// <returns></returns>
        protected override ActivityExecutionStatus Execute(
            ActivityExecutionContext executionContext)
        {
            //simulate an account lookup
            switch (AccountId)
            {
                case 1001:
                    IsAccountVerified = true;
                    AvailableCredit = 100.00M;
                    break;
                case 2002:
                    IsAccountVerified = true;
                    AvailableCredit = 500.00M;
                    break;
                default:
                    IsAccountVerified = false;
                    AvailableCredit = 0;
                    break;
            }

            return base.Execute(executionContext);
        }
    }
}
