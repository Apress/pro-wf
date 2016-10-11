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
	partial class IfElseCodeWorkflow
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
            System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition2 = new System.Workflow.Activities.CodeCondition();
            this.codeActivityIsZero = new System.Workflow.Activities.CodeActivity();
            this.codeActivityIsPositive = new System.Workflow.Activities.CodeActivity();
            this.codeActivityIsNegative = new System.Workflow.Activities.CodeActivity();
            this.ifElseBranchActivity3 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity2 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity1 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseActivity1 = new System.Workflow.Activities.IfElseActivity();
            // 
            // codeActivityIsZero
            // 
            this.codeActivityIsZero.Name = "codeActivityIsZero";
            this.codeActivityIsZero.ExecuteCode += new System.EventHandler(this.codeActivityIsZero_ExecuteCode);
            // 
            // codeActivityIsPositive
            // 
            this.codeActivityIsPositive.Name = "codeActivityIsPositive";
            this.codeActivityIsPositive.ExecuteCode += new System.EventHandler(this.codeActivityIsPositive_ExecuteCode);
            // 
            // codeActivityIsNegative
            // 
            this.codeActivityIsNegative.Name = "codeActivityIsNegative";
            this.codeActivityIsNegative.ExecuteCode += new System.EventHandler(this.codeActivityIsNegative_ExecuteCode);
            // 
            // ifElseBranchActivity3
            // 
            this.ifElseBranchActivity3.Activities.Add(this.codeActivityIsZero);
            this.ifElseBranchActivity3.Name = "ifElseBranchActivity3";
            // 
            // ifElseBranchActivity2
            // 
            this.ifElseBranchActivity2.Activities.Add(this.codeActivityIsPositive);
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.CheckForPositive);
            this.ifElseBranchActivity2.Condition = codecondition1;
            this.ifElseBranchActivity2.Name = "ifElseBranchActivity2";
            // 
            // ifElseBranchActivity1
            // 
            this.ifElseBranchActivity1.Activities.Add(this.codeActivityIsNegative);
            codecondition2.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.CheckForNegative);
            this.ifElseBranchActivity1.Condition = codecondition2;
            this.ifElseBranchActivity1.Name = "ifElseBranchActivity1";
            // 
            // ifElseActivity1
            // 
            this.ifElseActivity1.Activities.Add(this.ifElseBranchActivity1);
            this.ifElseActivity1.Activities.Add(this.ifElseBranchActivity2);
            this.ifElseActivity1.Activities.Add(this.ifElseBranchActivity3);
            this.ifElseActivity1.Name = "ifElseActivity1";
            // 
            // IfElseCodeWorkflow
            // 
            this.Activities.Add(this.ifElseActivity1);
            this.Name = "IfElseCodeWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private IfElseBranchActivity ifElseBranchActivity2;
        private IfElseBranchActivity ifElseBranchActivity1;
        private IfElseBranchActivity ifElseBranchActivity3;
        private CodeActivity codeActivityIsNegative;
        private CodeActivity codeActivityIsPositive;
        private CodeActivity codeActivityIsZero;
        private IfElseActivity ifElseActivity1;

















    }
}
