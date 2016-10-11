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

namespace SimpleCalculatorWorkflow
{
	public sealed partial class Workflow1
	{
		#region Designer generated code
		
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.CanModifyActivities = true;
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference1 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference2 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference3 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference4 = new System.Workflow.Activities.Rules.RuleConditionReference();
            this.codeActivity5 = new System.Workflow.Activities.CodeActivity();
            this.codeActivity4 = new System.Workflow.Activities.CodeActivity();
            this.codeActivity3 = new System.Workflow.Activities.CodeActivity();
            this.codeActivity2 = new System.Workflow.Activities.CodeActivity();
            this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
            this.ifElseBranchActivityUnknown = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivityIsDivide = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivityIsMultiply = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivityIsSubtract = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivityIsAdd = new System.Workflow.Activities.IfElseBranchActivity();
            this.faultHandlersActivity1 = new System.Workflow.ComponentModel.FaultHandlersActivity();
            this.cancellationHandlerActivity1 = new System.Workflow.ComponentModel.CancellationHandlerActivity();
            this.ifElseActivity1 = new System.Workflow.Activities.IfElseActivity();
            // 
            // codeActivity5
            // 
            this.codeActivity5.Name = "codeActivity5";
            this.codeActivity5.ExecuteCode += new System.EventHandler(this.UnknownOperation);
            // 
            // codeActivity4
            // 
            this.codeActivity4.Name = "codeActivity4";
            this.codeActivity4.ExecuteCode += new System.EventHandler(this.DivideOperation);
            // 
            // codeActivity3
            // 
            this.codeActivity3.Name = "codeActivity3";
            this.codeActivity3.ExecuteCode += new System.EventHandler(this.MultiplyOperation);
            // 
            // codeActivity2
            // 
            this.codeActivity2.Name = "codeActivity2";
            this.codeActivity2.ExecuteCode += new System.EventHandler(this.SubtractOperation);
            // 
            // codeActivity1
            // 
            this.codeActivity1.Name = "codeActivity1";
            this.codeActivity1.ExecuteCode += new System.EventHandler(this.AddOperation);
            // 
            // ifElseBranchActivityUnknown
            // 
            this.ifElseBranchActivityUnknown.Activities.Add(this.codeActivity5);
            this.ifElseBranchActivityUnknown.Name = "ifElseBranchActivityUnknown";
            // 
            // ifElseBranchActivityIsDivide
            // 
            this.ifElseBranchActivityIsDivide.Activities.Add(this.codeActivity4);
            ruleconditionreference1.ConditionName = "IsDivide";
            this.ifElseBranchActivityIsDivide.Condition = ruleconditionreference1;
            this.ifElseBranchActivityIsDivide.Name = "ifElseBranchActivityIsDivide";
            // 
            // ifElseBranchActivityIsMultiply
            // 
            this.ifElseBranchActivityIsMultiply.Activities.Add(this.codeActivity3);
            ruleconditionreference2.ConditionName = "IsMultiply";
            this.ifElseBranchActivityIsMultiply.Condition = ruleconditionreference2;
            this.ifElseBranchActivityIsMultiply.Name = "ifElseBranchActivityIsMultiply";
            // 
            // ifElseBranchActivityIsSubtract
            // 
            this.ifElseBranchActivityIsSubtract.Activities.Add(this.codeActivity2);
            ruleconditionreference3.ConditionName = "IsSubtract";
            this.ifElseBranchActivityIsSubtract.Condition = ruleconditionreference3;
            this.ifElseBranchActivityIsSubtract.Name = "ifElseBranchActivityIsSubtract";
            // 
            // ifElseBranchActivityIsAdd
            // 
            this.ifElseBranchActivityIsAdd.Activities.Add(this.codeActivity1);
            ruleconditionreference4.ConditionName = "IsAdd";
            this.ifElseBranchActivityIsAdd.Condition = ruleconditionreference4;
            this.ifElseBranchActivityIsAdd.Name = "ifElseBranchActivityIsAdd";
            // 
            // faultHandlersActivity1
            // 
            this.faultHandlersActivity1.Name = "faultHandlersActivity1";
            // 
            // cancellationHandlerActivity1
            // 
            this.cancellationHandlerActivity1.Name = "cancellationHandlerActivity1";
            // 
            // ifElseActivity1
            // 
            this.ifElseActivity1.Activities.Add(this.ifElseBranchActivityIsAdd);
            this.ifElseActivity1.Activities.Add(this.ifElseBranchActivityIsSubtract);
            this.ifElseActivity1.Activities.Add(this.ifElseBranchActivityIsMultiply);
            this.ifElseActivity1.Activities.Add(this.ifElseBranchActivityIsDivide);
            this.ifElseActivity1.Activities.Add(this.ifElseBranchActivityUnknown);
            this.ifElseActivity1.Name = "ifElseActivity1";
            // 
            // Workflow1
            // 
            this.Activities.Add(this.ifElseActivity1);
            this.Activities.Add(this.cancellationHandlerActivity1);
            this.Activities.Add(this.faultHandlersActivity1);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

		}

		#endregion

        private CancellationHandlerActivity cancellationHandlerActivity1;
        private FaultHandlersActivity faultHandlersActivity1;
        private IfElseBranchActivity ifElseBranchActivityUnknown;
        private CodeActivity codeActivity1;
        private CodeActivity codeActivity2;
        private CodeActivity codeActivity3;
        private CodeActivity codeActivity4;
        private CodeActivity codeActivity5;
        private IfElseBranchActivity ifElseBranchActivityIsMultiply;
        private IfElseBranchActivity ifElseBranchActivityIsDivide;
        private IfElseActivity ifElseActivity1;
        private IfElseBranchActivity ifElseBranchActivityIsAdd;
        private IfElseBranchActivity ifElseBranchActivityIsSubtract;



























    }
}
