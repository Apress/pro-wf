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
	partial class ParallelDelayWorkflow
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
            this.codeSequence2Number3 = new System.Workflow.Activities.CodeActivity();
            this.codeSequence2Number2 = new System.Workflow.Activities.CodeActivity();
            this.codeSequence2Number1 = new System.Workflow.Activities.CodeActivity();
            this.codeSequence1Number2 = new System.Workflow.Activities.CodeActivity();
            this.delayActivity1 = new System.Workflow.Activities.DelayActivity();
            this.codeSequence1Number1 = new System.Workflow.Activities.CodeActivity();
            this.sequenceActivity2 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity1 = new System.Workflow.Activities.SequenceActivity();
            this.parallelActivity1 = new System.Workflow.Activities.ParallelActivity();
            this.whileActivity1 = new System.Workflow.Activities.WhileActivity();
            // 
            // codeSequence2Number3
            // 
            this.codeSequence2Number3.Name = "codeSequence2Number3";
            this.codeSequence2Number3.ExecuteCode += new System.EventHandler(this.commonCode_ExecuteCode);
            // 
            // codeSequence2Number2
            // 
            this.codeSequence2Number2.Name = "codeSequence2Number2";
            this.codeSequence2Number2.ExecuteCode += new System.EventHandler(this.commonCode_ExecuteCode);
            // 
            // codeSequence2Number1
            // 
            this.codeSequence2Number1.Name = "codeSequence2Number1";
            this.codeSequence2Number1.ExecuteCode += new System.EventHandler(this.commonCode_ExecuteCode);
            // 
            // codeSequence1Number2
            // 
            this.codeSequence1Number2.Name = "codeSequence1Number2";
            this.codeSequence1Number2.ExecuteCode += new System.EventHandler(this.codeSequence1Number2_ExecuteCode);
            // 
            // delayActivity1
            // 
            this.delayActivity1.Name = "delayActivity1";
            this.delayActivity1.TimeoutDuration = System.TimeSpan.Parse("00:00:00.2000000");
            // 
            // codeSequence1Number1
            // 
            this.codeSequence1Number1.Name = "codeSequence1Number1";
            this.codeSequence1Number1.ExecuteCode += new System.EventHandler(this.commonCode_ExecuteCode);
            // 
            // sequenceActivity2
            // 
            this.sequenceActivity2.Activities.Add(this.codeSequence2Number1);
            this.sequenceActivity2.Activities.Add(this.codeSequence2Number2);
            this.sequenceActivity2.Activities.Add(this.codeSequence2Number3);
            this.sequenceActivity2.Name = "sequenceActivity2";
            // 
            // sequenceActivity1
            // 
            this.sequenceActivity1.Activities.Add(this.codeSequence1Number1);
            this.sequenceActivity1.Activities.Add(this.delayActivity1);
            this.sequenceActivity1.Activities.Add(this.codeSequence1Number2);
            this.sequenceActivity1.Name = "sequenceActivity1";
            // 
            // parallelActivity1
            // 
            this.parallelActivity1.Activities.Add(this.sequenceActivity1);
            this.parallelActivity1.Activities.Add(this.sequenceActivity2);
            this.parallelActivity1.Name = "parallelActivity1";
            // 
            // whileActivity1
            // 
            this.whileActivity1.Activities.Add(this.parallelActivity1);
            ruleconditionreference1.ConditionName = "checkIterationCount";
            this.whileActivity1.Condition = ruleconditionreference1;
            this.whileActivity1.Name = "whileActivity1";
            // 
            // ParallelDelayWorkflow
            // 
            this.Activities.Add(this.whileActivity1);
            this.Name = "ParallelDelayWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private WhileActivity whileActivity1;
        private SequenceActivity sequenceActivity2;
        private SequenceActivity sequenceActivity1;
        private ParallelActivity parallelActivity1;
        private CodeActivity codeSequence1Number1;
        private CodeActivity codeSequence1Number2;
        private CodeActivity codeSequence2Number2;
        private CodeActivity codeSequence2Number3;
        private DelayActivity delayActivity1;
        private CodeActivity codeSequence2Number1;
























    }
}
