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

namespace OrderEntryCode
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
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference1 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference2 = new System.Workflow.Activities.Rules.RuleConditionReference();
            this.codeInsufficientCredit = new System.Workflow.Activities.CodeActivity();
            this.codeEnterOrder = new System.Workflow.Activities.CodeActivity();
            this.ifItemProblems = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifCreditAvailable = new System.Workflow.Activities.IfElseBranchActivity();
            this.codeBadAccountId = new System.Workflow.Activities.CodeActivity();
            this.ifElseActivity2 = new System.Workflow.Activities.IfElseActivity();
            this.codeLookupItem = new System.Workflow.Activities.CodeActivity();
            this.ifAccountInvalid = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifAccountVerified = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseActivity1 = new System.Workflow.Activities.IfElseActivity();
            this.codeLookupAccount = new System.Workflow.Activities.CodeActivity();
            // 
            // codeInsufficientCredit
            // 
            this.codeInsufficientCredit.Name = "codeInsufficientCredit";
            this.codeInsufficientCredit.ExecuteCode += new System.EventHandler(this.codeInsufficientCredit_ExecuteCode);
            // 
            // codeEnterOrder
            // 
            this.codeEnterOrder.Name = "codeEnterOrder";
            this.codeEnterOrder.ExecuteCode += new System.EventHandler(this.codeEnterOrder_ExecuteCode);
            // 
            // ifItemProblems
            // 
            this.ifItemProblems.Activities.Add(this.codeInsufficientCredit);
            this.ifItemProblems.Name = "ifItemProblems";
            // 
            // ifCreditAvailable
            // 
            this.ifCreditAvailable.Activities.Add(this.codeEnterOrder);
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
            // codeLookupItem
            // 
            this.codeLookupItem.Name = "codeLookupItem";
            this.codeLookupItem.ExecuteCode += new System.EventHandler(this.codeLookupItem_ExecuteCode);
            // 
            // ifAccountInvalid
            // 
            this.ifAccountInvalid.Activities.Add(this.codeBadAccountId);
            this.ifAccountInvalid.Name = "ifAccountInvalid";
            // 
            // ifAccountVerified
            // 
            this.ifAccountVerified.Activities.Add(this.codeLookupItem);
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
            // codeLookupAccount
            // 
            this.codeLookupAccount.Name = "codeLookupAccount";
            this.codeLookupAccount.ExecuteCode += new System.EventHandler(this.codeLookupAccount_ExecuteCode);
            // 
            // Workflow1
            // 
            this.Activities.Add(this.codeLookupAccount);
            this.Activities.Add(this.ifElseActivity1);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

		}

		#endregion

        private CodeActivity codeInsufficientCredit;
        private CodeActivity codeBadAccountId;
        private IfElseBranchActivity ifItemProblems;
        private IfElseBranchActivity ifCreditAvailable;
        private IfElseActivity ifElseActivity2;
        private CodeActivity codeEnterOrder;
        private IfElseBranchActivity ifAccountInvalid;
        private IfElseBranchActivity ifAccountVerified;
        private IfElseActivity ifElseActivity1;
        private CodeActivity codeLookupItem;
        private CodeActivity codeLookupAccount;













    }
}
