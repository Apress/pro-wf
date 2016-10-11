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
	partial class WhileWorkflow
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
            this.codeProcessIteration = new System.Workflow.Activities.CodeActivity();
            this.codeWriteNumber = new System.Workflow.Activities.CodeActivity();
            this.sequenceActivity1 = new System.Workflow.Activities.SequenceActivity();
            this.whileActivity1 = new System.Workflow.Activities.WhileActivity();
            // 
            // codeProcessIteration
            // 
            this.codeProcessIteration.Name = "codeProcessIteration";
            this.codeProcessIteration.ExecuteCode += new System.EventHandler(this.codeProcessIteration_ExecuteCode);
            // 
            // codeWriteNumber
            // 
            this.codeWriteNumber.Name = "codeWriteNumber";
            this.codeWriteNumber.ExecuteCode += new System.EventHandler(this.codeWriteNumber_ExecuteCode);
            // 
            // sequenceActivity1
            // 
            this.sequenceActivity1.Activities.Add(this.codeWriteNumber);
            this.sequenceActivity1.Activities.Add(this.codeProcessIteration);
            this.sequenceActivity1.Name = "sequenceActivity1";
            // 
            // whileActivity1
            // 
            this.whileActivity1.Activities.Add(this.sequenceActivity1);
            ruleconditionreference1.ConditionName = "checkIterationNumber";
            this.whileActivity1.Condition = ruleconditionreference1;
            this.whileActivity1.Name = "whileActivity1";
            // 
            // WhileWorkflow
            // 
            this.Activities.Add(this.whileActivity1);
            this.Name = "WhileWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private WhileActivity whileActivity1;
        private SequenceActivity sequenceActivity1;
        private CodeActivity codeWriteNumber;
        private CodeActivity codeProcessIteration;








    }
}
