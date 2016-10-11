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
	partial class CancelHandlerWorkflow
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
            this.codeCancelHandler = new System.Workflow.Activities.CodeActivity();
            this.codeLeftBranch = new System.Workflow.Activities.CodeActivity();
            this.throwActivity1 = new System.Workflow.ComponentModel.ThrowActivity();
            this.codeRightBranch = new System.Workflow.Activities.CodeActivity();
            this.cancellationHandlerActivity3 = new System.Workflow.ComponentModel.CancellationHandlerActivity();
            this.whileActivity1 = new System.Workflow.Activities.WhileActivity();
            this.sequenceActivity2 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity1 = new System.Workflow.Activities.SequenceActivity();
            this.parallelActivity1 = new System.Workflow.Activities.ParallelActivity();
            // 
            // codeCancelHandler
            // 
            this.codeCancelHandler.Name = "codeCancelHandler";
            this.codeCancelHandler.ExecuteCode += new System.EventHandler(this.codeCancelHandler_ExecuteCode);
            // 
            // codeLeftBranch
            // 
            this.codeLeftBranch.Name = "codeLeftBranch";
            this.codeLeftBranch.ExecuteCode += new System.EventHandler(this.codeLeftBranch_ExecuteCode);
            // 
            // throwActivity1
            // 
            this.throwActivity1.FaultType = typeof(System.ApplicationException);
            this.throwActivity1.Name = "throwActivity1";
            // 
            // codeRightBranch
            // 
            this.codeRightBranch.Name = "codeRightBranch";
            this.codeRightBranch.ExecuteCode += new System.EventHandler(this.codeRightBranch_ExecuteCode);
            // 
            // cancellationHandlerActivity3
            // 
            this.cancellationHandlerActivity3.Activities.Add(this.codeCancelHandler);
            this.cancellationHandlerActivity3.Name = "cancellationHandlerActivity3";
            // 
            // whileActivity1
            // 
            this.whileActivity1.Activities.Add(this.codeLeftBranch);
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.RunForever);
            this.whileActivity1.Condition = codecondition1;
            this.whileActivity1.Name = "whileActivity1";
            // 
            // sequenceActivity2
            // 
            this.sequenceActivity2.Activities.Add(this.codeRightBranch);
            this.sequenceActivity2.Activities.Add(this.throwActivity1);
            this.sequenceActivity2.Name = "sequenceActivity2";
            // 
            // sequenceActivity1
            // 
            this.sequenceActivity1.Activities.Add(this.whileActivity1);
            this.sequenceActivity1.Activities.Add(this.cancellationHandlerActivity3);
            this.sequenceActivity1.Name = "sequenceActivity1";
            // 
            // parallelActivity1
            // 
            this.parallelActivity1.Activities.Add(this.sequenceActivity1);
            this.parallelActivity1.Activities.Add(this.sequenceActivity2);
            this.parallelActivity1.Name = "parallelActivity1";
            // 
            // CancelHandlerWorkflow
            // 
            this.Activities.Add(this.parallelActivity1);
            this.Name = "CancelHandlerWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private CodeActivity codeLeftBranch;
        private CodeActivity codeRightBranch;
        private CodeActivity codeCancelHandler;
        private WhileActivity whileActivity1;
        private SequenceActivity sequenceActivity2;
        private SequenceActivity sequenceActivity1;
        private ParallelActivity parallelActivity1;
        private ThrowActivity throwActivity1;
        private CancellationHandlerActivity cancellationHandlerActivity3;




























    }
}
