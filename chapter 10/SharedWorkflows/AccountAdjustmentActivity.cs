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
using System.Data;
using System.Data.SqlClient;
using System.Configuration;  //needs assembly reference
using System.ComponentModel;
using System.Workflow.ComponentModel;

namespace SharedWorkflows
{
    /// <summary>
    /// Custom activity that adjusts the balance of an account
    /// </summary>
    public partial class AccountAdjustmentActivity : Activity
    {
        /// <summary>
        /// Amount Dependency Property
        /// </summary>
        public static DependencyProperty AmountProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
                "Amount", typeof(Decimal), typeof(AccountAdjustmentActivity));
        [Description("The amount of the balance adjustment")]
        [Category("ProWorkflow")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Decimal Amount
        {
            get
            {
                return ((Decimal)(base.GetValue(
                    AccountAdjustmentActivity.AmountProperty)));
            }
            set
            {
                base.SetValue(AccountAdjustmentActivity.AmountProperty, value);
            }
        }

        /// <summary>
        /// AccountId Dependency Property
        /// </summary>
        public static DependencyProperty AccountIdProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
                "AccountId", typeof(Int32), typeof(AccountAdjustmentActivity));
        [Description("Identifies the account")]
        [Category("ProWorkflow")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 AccountId
        {
            get
            {
                return ((Int32)(base.GetValue(
                    AccountAdjustmentActivity.AccountIdProperty)));
            }
            set
            {
                base.SetValue(AccountAdjustmentActivity.AccountIdProperty, value);
            }
        }

        /// <summary>
        /// IsCredit Dependency Property
        /// </summary>
        public static DependencyProperty IsCreditProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
                "IsCredit", typeof(Boolean), typeof(AccountAdjustmentActivity));
        [Description("True if this is a credit, false for a debit")]
        [Category("ProWorkflow")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Boolean IsCredit
        {
            get
            {
                return ((Boolean)(base.GetValue(
                    AccountAdjustmentActivity.IsCreditProperty)));
            }
            set
            {
                base.SetValue(AccountAdjustmentActivity.IsCreditProperty, value);
            }
        }

        public AccountAdjustmentActivity()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Perform the adjustment against the account
        /// </summary>
        /// <param name="executionContext"></param>
        /// <returns></returns>
        protected override ActivityExecutionStatus Execute(
            ActivityExecutionContext executionContext)
        {
            using (SqlConnection connection = new SqlConnection(
                ConfigurationManager.ConnectionStrings
                    ["ProWorkflow"].ConnectionString))
            {
                connection.Open();

                if (!IsCredit)
                {
                    //if this is a debit, see if the account
                    //has a sufficient balance
                    Decimal currentBal = GetCurrentBalance(
                        connection, AccountId);
                    if (currentBal < Amount)
                    {
                        throw new ArgumentException(
                            "Insufficient balance to process debit");
                    }
                }

                //update the account balance
                UpdateBalance(connection, AccountId, Amount, IsCredit);

                connection.Close();
            }

            return base.Execute(executionContext);
        }

        /// <summary>
        /// Retrieve the current balance for an account
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        private Decimal GetCurrentBalance(
            SqlConnection connection, Int32 accountId)
        {
            Decimal balance = 0;
            String sql =
                @"select balance from account where accountId = @AccountId";

            //setup Sql command object
            SqlCommand command = new SqlCommand(sql);
            //setup parameters
            SqlParameter p = new SqlParameter("@AccountId", accountId);
            command.Parameters.Add(p);
            command.Connection = connection;

            Object result = command.ExecuteScalar();
            if (result != null)
            {
                balance = (Decimal)result;
            }

            return balance;
        }

        /// <summary>
        /// Update the account balance
        /// </summary>
        /// <param name="adjAmount"></param>
        /// <returns></returns>
        private void UpdateBalance(SqlConnection connection,
            Int32 accountId, Decimal adjAmount, Boolean isCredit)
        {
            String sql;
            if (isCredit)
            {
                sql =
                    @"update account set balance = balance + @AdjAmount 
                  where accountId = @AccountId";
            }
            else
            {
                sql =
                    @"update account set balance = balance - @AdjAmount 
                  where accountId = @AccountId";
            }
            //setup Sql command object
            SqlCommand command = new SqlCommand(sql);
            //setup parameters
            SqlParameter p = new SqlParameter("@AccountId", accountId);
            command.Parameters.Add(p);
            p = new SqlParameter("@AdjAmount", adjAmount);
            command.Parameters.Add(p);
            command.Connection = connection;

            command.ExecuteNonQuery();
        }
    }
}
