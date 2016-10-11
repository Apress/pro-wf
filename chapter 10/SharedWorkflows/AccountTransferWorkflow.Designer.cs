using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace SharedWorkflows
{
	partial class AccountTransferWorkflow
	{
		#region Designer generated code
		
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
		private void InitializeComponent()
		{
            this.CanModifyActivities = true;
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind4 = new System.Workflow.ComponentModel.ActivityBind();
            this.debitActivity = new SharedWorkflows.AccountAdjustmentActivity();
            this.creditActivity = new SharedWorkflows.AccountAdjustmentActivity();
            this.transactionScopeActivity1 = new System.Workflow.ComponentModel.TransactionScopeActivity();
            // 
            // debitActivity
            // 
            activitybind1.Name = "AccountTransferWorkflow";
            activitybind1.Path = "FromAccountId";
            activitybind2.Name = "AccountTransferWorkflow";
            activitybind2.Path = "Amount";
            this.debitActivity.IsCredit = false;
            this.debitActivity.Name = "debitActivity";
            this.debitActivity.SetBinding(SharedWorkflows.AccountAdjustmentActivity.AccountIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.debitActivity.SetBinding(SharedWorkflows.AccountAdjustmentActivity.AmountProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            // 
            // creditActivity
            // 
            activitybind3.Name = "AccountTransferWorkflow";
            activitybind3.Path = "ToAccountId";
            activitybind4.Name = "AccountTransferWorkflow";
            activitybind4.Path = "Amount";
            this.creditActivity.IsCredit = true;
            this.creditActivity.Name = "creditActivity";
            this.creditActivity.SetBinding(SharedWorkflows.AccountAdjustmentActivity.AccountIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            this.creditActivity.SetBinding(SharedWorkflows.AccountAdjustmentActivity.AmountProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            // 
            // transactionScopeActivity1
            // 
            this.transactionScopeActivity1.Activities.Add(this.creditActivity);
            this.transactionScopeActivity1.Activities.Add(this.debitActivity);
            this.transactionScopeActivity1.Name = "transactionScopeActivity1";
            this.transactionScopeActivity1.TransactionOptions.IsolationLevel = System.Transactions.IsolationLevel.Serializable;
            // 
            // AccountTransferWorkflow
            // 
            this.Activities.Add(this.transactionScopeActivity1);
            this.Name = "AccountTransferWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private AccountAdjustmentActivity creditActivity;
        private TransactionScopeActivity transactionScopeActivity1;
        private AccountAdjustmentActivity debitActivity;












    }
}
