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
	partial class OrderEntryWorkflow
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
            System.Workflow.ComponentModel.ActivityBind activitybind5 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind6 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind7 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind8 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind9 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind10 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind11 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind12 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind13 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind14 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind15 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind16 = new System.Workflow.ComponentModel.ActivityBind();
            this.compensateCodeActivity = new System.Workflow.Activities.CodeActivity();
            this.compensateOrderActivity = new SharedWorkflows.OrderDetailActivity();
            this.compensateInventoryActivity = new SharedWorkflows.InventoryUpdateActivity();
            this.debitActivity = new SharedWorkflows.AccountAdjustmentActivity();
            this.creditActivity = new SharedWorkflows.AccountAdjustmentActivity();
            this.compensationHandlerActivity2 = new System.Workflow.ComponentModel.CompensationHandlerActivity();
            this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
            this.compensationHandlerActivity1 = new System.Workflow.ComponentModel.CompensationHandlerActivity();
            this.orderDetailActivity1 = new SharedWorkflows.OrderDetailActivity();
            this.inventoryUpdateActivity1 = new SharedWorkflows.InventoryUpdateActivity();
            this.faultHandlersActivity1 = new System.Workflow.ComponentModel.FaultHandlersActivity();
            this.transactionScopeActivity1 = new System.Workflow.ComponentModel.TransactionScopeActivity();
            this.compensatableSequenceActivity1 = new System.Workflow.Activities.CompensatableSequenceActivity();
            this.orderEntryScope = new System.Workflow.ComponentModel.CompensatableTransactionScopeActivity();
            // 
            // compensateCodeActivity
            // 
            this.compensateCodeActivity.Name = "compensateCodeActivity";
            this.compensateCodeActivity.ExecuteCode += new System.EventHandler(this.compensateCodeActivity_ExecuteCode);
            // 
            // compensateOrderActivity
            // 
            activitybind1.Name = "OrderEntryWorkflow";
            activitybind1.Path = "OrderAccountId";
            this.compensateOrderActivity.IsAddOrder = false;
            activitybind2.Name = "OrderEntryWorkflow";
            activitybind2.Path = "ItemId";
            this.compensateOrderActivity.Name = "compensateOrderActivity";
            activitybind3.Name = "OrderEntryWorkflow";
            activitybind3.Path = "OrderId";
            activitybind4.Name = "OrderEntryWorkflow";
            activitybind4.Path = "Quantity";
            this.compensateOrderActivity.SetBinding(SharedWorkflows.OrderDetailActivity.AccountIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.compensateOrderActivity.SetBinding(SharedWorkflows.OrderDetailActivity.ItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.compensateOrderActivity.SetBinding(SharedWorkflows.OrderDetailActivity.OrderIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            this.compensateOrderActivity.SetBinding(SharedWorkflows.OrderDetailActivity.QuantityProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            // 
            // compensateInventoryActivity
            // 
            this.compensateInventoryActivity.IsReduction = false;
            activitybind5.Name = "OrderEntryWorkflow";
            activitybind5.Path = "ItemId";
            this.compensateInventoryActivity.Name = "compensateInventoryActivity";
            activitybind6.Name = "OrderEntryWorkflow";
            activitybind6.Path = "Quantity";
            this.compensateInventoryActivity.SetBinding(SharedWorkflows.InventoryUpdateActivity.ItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind5)));
            this.compensateInventoryActivity.SetBinding(SharedWorkflows.InventoryUpdateActivity.QuantityProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind6)));
            // 
            // debitActivity
            // 
            activitybind7.Name = "OrderEntryWorkflow";
            activitybind7.Path = "OrderAccountId";
            activitybind8.Name = "OrderEntryWorkflow";
            activitybind8.Path = "Amount";
            this.debitActivity.IsCredit = false;
            this.debitActivity.Name = "debitActivity";
            this.debitActivity.SetBinding(SharedWorkflows.AccountAdjustmentActivity.AccountIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind7)));
            this.debitActivity.SetBinding(SharedWorkflows.AccountAdjustmentActivity.AmountProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind8)));
            // 
            // creditActivity
            // 
            activitybind9.Name = "OrderEntryWorkflow";
            activitybind9.Path = "ToAccountId";
            activitybind10.Name = "OrderEntryWorkflow";
            activitybind10.Path = "Amount";
            this.creditActivity.IsCredit = true;
            this.creditActivity.Name = "creditActivity";
            this.creditActivity.SetBinding(SharedWorkflows.AccountAdjustmentActivity.AccountIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind9)));
            this.creditActivity.SetBinding(SharedWorkflows.AccountAdjustmentActivity.AmountProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind10)));
            // 
            // compensationHandlerActivity2
            // 
            this.compensationHandlerActivity2.Activities.Add(this.compensateCodeActivity);
            this.compensationHandlerActivity2.Name = "compensationHandlerActivity2";
            // 
            // codeActivity1
            // 
            this.codeActivity1.Name = "codeActivity1";
            this.codeActivity1.ExecuteCode += new System.EventHandler(this.codeActivity1_ExecuteCode);
            // 
            // compensationHandlerActivity1
            // 
            this.compensationHandlerActivity1.Activities.Add(this.compensateInventoryActivity);
            this.compensationHandlerActivity1.Activities.Add(this.compensateOrderActivity);
            this.compensationHandlerActivity1.Name = "compensationHandlerActivity1";
            // 
            // orderDetailActivity1
            // 
            activitybind11.Name = "OrderEntryWorkflow";
            activitybind11.Path = "OrderAccountId";
            this.orderDetailActivity1.IsAddOrder = true;
            activitybind12.Name = "OrderEntryWorkflow";
            activitybind12.Path = "ItemId";
            this.orderDetailActivity1.Name = "orderDetailActivity1";
            activitybind13.Name = "OrderEntryWorkflow";
            activitybind13.Path = "OrderId";
            activitybind14.Name = "OrderEntryWorkflow";
            activitybind14.Path = "Quantity";
            this.orderDetailActivity1.SetBinding(SharedWorkflows.OrderDetailActivity.AccountIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind11)));
            this.orderDetailActivity1.SetBinding(SharedWorkflows.OrderDetailActivity.ItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind12)));
            this.orderDetailActivity1.SetBinding(SharedWorkflows.OrderDetailActivity.OrderIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind13)));
            this.orderDetailActivity1.SetBinding(SharedWorkflows.OrderDetailActivity.QuantityProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind14)));
            // 
            // inventoryUpdateActivity1
            // 
            this.inventoryUpdateActivity1.IsReduction = true;
            activitybind15.Name = "OrderEntryWorkflow";
            activitybind15.Path = "ItemId";
            this.inventoryUpdateActivity1.Name = "inventoryUpdateActivity1";
            activitybind16.Name = "OrderEntryWorkflow";
            activitybind16.Path = "Quantity";
            this.inventoryUpdateActivity1.SetBinding(SharedWorkflows.InventoryUpdateActivity.ItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind15)));
            this.inventoryUpdateActivity1.SetBinding(SharedWorkflows.InventoryUpdateActivity.QuantityProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind16)));
            // 
            // faultHandlersActivity1
            // 
            this.faultHandlersActivity1.Name = "faultHandlersActivity1";
            // 
            // transactionScopeActivity1
            // 
            this.transactionScopeActivity1.Activities.Add(this.creditActivity);
            this.transactionScopeActivity1.Activities.Add(this.debitActivity);
            this.transactionScopeActivity1.Name = "transactionScopeActivity1";
            this.transactionScopeActivity1.TransactionOptions.IsolationLevel = System.Transactions.IsolationLevel.Serializable;
            // 
            // compensatableSequenceActivity1
            // 
            this.compensatableSequenceActivity1.Activities.Add(this.codeActivity1);
            this.compensatableSequenceActivity1.Activities.Add(this.compensationHandlerActivity2);
            this.compensatableSequenceActivity1.Name = "compensatableSequenceActivity1";
            // 
            // orderEntryScope
            // 
            this.orderEntryScope.Activities.Add(this.inventoryUpdateActivity1);
            this.orderEntryScope.Activities.Add(this.orderDetailActivity1);
            this.orderEntryScope.Activities.Add(this.compensationHandlerActivity1);
            this.orderEntryScope.Name = "orderEntryScope";
            this.orderEntryScope.TransactionOptions.IsolationLevel = System.Transactions.IsolationLevel.Serializable;
            // 
            // OrderEntryWorkflow
            // 
            this.Activities.Add(this.orderEntryScope);
            this.Activities.Add(this.compensatableSequenceActivity1);
            this.Activities.Add(this.transactionScopeActivity1);
            this.Activities.Add(this.faultHandlersActivity1);
            this.Name = "OrderEntryWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private CodeActivity compensateCodeActivity;
        private CompensationHandlerActivity compensationHandlerActivity2;
        private CodeActivity codeActivity1;
        private CompensatableSequenceActivity compensatableSequenceActivity1;
        private InventoryUpdateActivity compensateInventoryActivity;
        private CompensationHandlerActivity compensationHandlerActivity1;
        private OrderDetailActivity compensateOrderActivity;
        private FaultHandlersActivity faultHandlersActivity1;
        private OrderDetailActivity orderDetailActivity1;
        private InventoryUpdateActivity inventoryUpdateActivity1;
        private CompensatableTransactionScopeActivity orderEntryScope;
        private AccountAdjustmentActivity debitActivity;
        private AccountAdjustmentActivity creditActivity;
        private TransactionScopeActivity transactionScopeActivity1;













































    }
}
