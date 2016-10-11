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
	partial class CAGWorkflow
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
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference3 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference4 = new System.Workflow.Activities.Rules.RuleConditionReference();
            this.codeCombo = new System.Workflow.Activities.CodeActivity();
            this.codeDrink = new System.Workflow.Activities.CodeActivity();
            this.codeFries = new System.Workflow.Activities.CodeActivity();
            this.codeSandwich = new System.Workflow.Activities.CodeActivity();
            this.conditionedActivityGroup1 = new System.Workflow.Activities.ConditionedActivityGroup();
            ruleconditionreference1.ConditionName = "checkForCombo";
            // 
            // codeCombo
            // 
            this.codeCombo.Name = "codeCombo";
            this.codeCombo.ExecuteCode += new System.EventHandler(this.codeCombo_ExecuteCode);
            this.codeCombo.SetValue(System.Workflow.Activities.ConditionedActivityGroup.WhenConditionProperty, ruleconditionreference1);
            ruleconditionreference2.ConditionName = "checkForDrink";
            // 
            // codeDrink
            // 
            this.codeDrink.Name = "codeDrink";
            this.codeDrink.ExecuteCode += new System.EventHandler(this.codeDrink_ExecuteCode);
            this.codeDrink.SetValue(System.Workflow.Activities.ConditionedActivityGroup.WhenConditionProperty, ruleconditionreference2);
            ruleconditionreference3.ConditionName = "checkForFries";
            // 
            // codeFries
            // 
            this.codeFries.Name = "codeFries";
            this.codeFries.ExecuteCode += new System.EventHandler(this.codeFries_ExecuteCode);
            this.codeFries.SetValue(System.Workflow.Activities.ConditionedActivityGroup.WhenConditionProperty, ruleconditionreference3);
            ruleconditionreference4.ConditionName = "checkForSandwich";
            // 
            // codeSandwich
            // 
            this.codeSandwich.Name = "codeSandwich";
            this.codeSandwich.ExecuteCode += new System.EventHandler(this.codeSandwich_ExecuteCode);
            this.codeSandwich.SetValue(System.Workflow.Activities.ConditionedActivityGroup.WhenConditionProperty, ruleconditionreference4);
            // 
            // conditionedActivityGroup1
            // 
            this.conditionedActivityGroup1.Activities.Add(this.codeSandwich);
            this.conditionedActivityGroup1.Activities.Add(this.codeFries);
            this.conditionedActivityGroup1.Activities.Add(this.codeDrink);
            this.conditionedActivityGroup1.Activities.Add(this.codeCombo);
            this.conditionedActivityGroup1.Name = "conditionedActivityGroup1";
            // 
            // CAGWorkflow
            // 
            this.Activities.Add(this.conditionedActivityGroup1);
            this.Name = "CAGWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private CodeActivity codeSandwich;
        private CodeActivity codeFries;
        private CodeActivity codeDrink;
        private CodeActivity codeCombo;
        private ConditionedActivityGroup conditionedActivityGroup1;















    }
}
