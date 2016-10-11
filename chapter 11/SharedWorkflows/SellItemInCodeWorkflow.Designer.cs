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
	partial class SellItemInCodeWorkflow
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
            this.codeExecuteRuleSet = new System.Workflow.Activities.CodeActivity();
            // 
            // codeExecuteRuleSet
            // 
            this.codeExecuteRuleSet.Name = "codeExecuteRuleSet";
            this.codeExecuteRuleSet.ExecuteCode += new System.EventHandler(this.codeExecuteRuleSet_ExecuteCode);
            // 
            // SellItemInCodeWorkflow
            // 
            this.Activities.Add(this.codeExecuteRuleSet);
            this.Name = "SellItemInCodeWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private CodeActivity codeExecuteRuleSet;
	}
}
