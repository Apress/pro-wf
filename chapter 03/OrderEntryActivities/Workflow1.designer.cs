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

namespace OrderEntryActivities
{
	partial class Workflow1
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
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference1 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.ComponentModel.ActivityBind activitybind4 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference2 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.ComponentModel.ActivityBind activitybind5 = new System.Workflow.ComponentModel.ActivityBind();
            this.codeInsufficientCredit = new System.Workflow.Activities.CodeActivity();
            this.enterOrderActivity1 = new OrderEntryActivities.EnterOrderActivity();
            this.ifItemProblems = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifCreditAvailable = new System.Workflow.Activities.IfElseBranchActivity();
            this.codeBadAccountId = new System.Workflow.Activities.CodeActivity();
            this.ifElseActivity2 = new System.Workflow.Activities.IfElseActivity();
            this.validateProductActivity1 = new OrderEntryActivities.ValidateProductActivity();
            this.ifAccountInvalid = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifAccountVerified = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseActivity1 = new System.Workflow.Activities.IfElseActivity();
            this.validateAccountActivity1 = new OrderEntryActivities.ValidateAccountActivity();
            // 
            // codeInsufficientCredit
            // 
            this.codeInsufficientCredit.Name = "codeInsufficientCredit";
            this.codeInsufficientCredit.ExecuteCode += new System.EventHandler(this.codeInsufficientCredit_ExecuteCode);
            // 
            // enterOrderActivity1
            // 
            activitybind1.Name = "Workflow1";
            activitybind1.Path = "AccountId";
            this.enterOrderActivity1.Name = "enterOrderActivity1";
            activitybind2.Name = "validateProductActivity1";
            activitybind2.Path = "SalesItemAmount";
            activitybind3.Name = "Workflow1";
            activitybind3.Path = "SalesItemId";
            this.enterOrderActivity1.SetBinding(OrderEntryActivities.EnterOrderActivity.AccountIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.enterOrderActivity1.SetBinding(OrderEntryActivities.EnterOrderActivity.SalesItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            this.enterOrderActivity1.SetBinding(OrderEntryActivities.EnterOrderActivity.SalesItemAmountProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            // 
            // ifItemProblems
            // 
            this.ifItemProblems.Activities.Add(this.codeInsufficientCredit);
            this.ifItemProblems.Name = "ifItemProblems";
            // 
            // ifCreditAvailable
            // 
            this.ifCreditAvailable.Activities.Add(this.enterOrderActivity1);
            ruleconditionreference1.ConditionName = "checkAvailableCredit";
            this.ifCreditAvailable.Condition = ruleconditionreference1;
            this.ifCreditAvailable.Name = "ifCreditAvailable";
            // 
            // codeBadAccountId
            // 
            this.codeBadAccountId.Name = "codeBadAccountId";
            this.codeBadAccountId.ExecuteCode += new System.EventHandler(this.codeBadAccountId_ExecuteCode);
            // 
            // ifElseActivity2
            // 
            this.ifElseActivity2.Activities.Add(this.ifCreditAvailable);
            this.ifElseActivity2.Activities.Add(this.ifItemProblems);
            this.ifElseActivity2.Name = "ifElseActivity2";
            // 
            // validateProductActivity1
            // 
            this.validateProductActivity1.IsSalesItemVerified = false;
            this.validateProductActivity1.Name = "validateProductActivity1";
            this.validateProductActivity1.SalesItemAmount = new decimal(new int[] {
            0,
            0,
            0,
            0});
            activitybind4.Name = "Workflow1";
            activitybind4.Path = "SalesItemId";
            this.validateProductActivity1.SetBinding(OrderEntryActivities.ValidateProductActivity.SalesItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            // 
            // ifAccountInvalid
            // 
            this.ifAccountInvalid.Activities.Add(this.codeBadAccountId);
            this.ifAccountInvalid.Name = "ifAccountInvalid";
            // 
            // ifAccountVerified
            // 
            this.ifAccountVerified.Activities.Add(this.validateProductActivity1);
            this.ifAccountVerified.Activities.Add(this.ifElseActivity2);
            ruleconditionreference2.ConditionName = "checkIsAccountVerified";
            this.ifAccountVerified.Condition = ruleconditionreference2;
            this.ifAccountVerified.Name = "ifAccountVerified";
            // 
            // ifElseActivity1
            // 
            this.ifElseActivity1.Activities.Add(this.ifAccountVerified);
            this.ifElseActivity1.Activities.Add(this.ifAccountInvalid);
            this.ifElseActivity1.Name = "ifElseActivity1";
            // 
            // validateAccountActivity1
            // 
            activitybind5.Name = "Workflow1";
            activitybind5.Path = "AccountId";
            this.validateAccountActivity1.AvailableCredit = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.validateAccountActivity1.IsAccountVerified = false;
            this.validateAccountActivity1.Name = "validateAccountActivity1";
            this.validateAccountActivity1.SetBinding(OrderEntryActivities.ValidateAccountActivity.AccountIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind5)));
            // 
            // Workflow1
            // 
            this.Activities.Add(this.validateAccountActivity1);
            this.Activities.Add(this.ifElseActivity1);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

		}

		#endregion

        private ValidateAccountActivity validateAccountActivity1;
        private IfElseBranchActivity ifAccountInvalid;
        private IfElseBranchActivity ifAccountVerified;
        private IfElseActivity ifElseActivity1;
        private ValidateProductActivity validateProductActivity1;
        private IfElseBranchActivity ifItemProblems;
        private IfElseBranchActivity ifCreditAvailable;
        private IfElseActivity ifElseActivity2;
        private EnterOrderActivity enterOrderActivity1;
        private CodeActivity codeBadAccountId;
        private CodeActivity codeInsufficientCredit;























    }
}
