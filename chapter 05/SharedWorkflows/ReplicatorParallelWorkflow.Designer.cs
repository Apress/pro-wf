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
	partial class ReplicatorParallelWorkflow
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
            this.consoleMessageActivity1 = new SharedWorkflows.ConsoleMessageActivity();
            this.sequenceActivity1 = new System.Workflow.Activities.SequenceActivity();
            this.replicatorActivity1 = new System.Workflow.Activities.ReplicatorActivity();
            // 
            // consoleMessageActivity1
            // 
            this.consoleMessageActivity1.Message = null;
            this.consoleMessageActivity1.Name = "consoleMessageActivity1";
            // 
            // sequenceActivity1
            // 
            this.sequenceActivity1.Activities.Add(this.consoleMessageActivity1);
            this.sequenceActivity1.Name = "sequenceActivity1";
            activitybind1.Name = "ReplicatorParallelWorkflow";
            activitybind1.Path = "InputList";
            // 
            // replicatorActivity1
            // 
            this.replicatorActivity1.Activities.Add(this.sequenceActivity1);
            this.replicatorActivity1.ExecutionType = System.Workflow.Activities.ExecutionType.Parallel;
            this.replicatorActivity1.Name = "replicatorActivity1";
            this.replicatorActivity1.ChildInitialized += new System.EventHandler<System.Workflow.Activities.ReplicatorChildEventArgs>(this.replicatorActivity1_ChildInitialized);
            this.replicatorActivity1.SetBinding(System.Workflow.Activities.ReplicatorActivity.InitialChildDataProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // 
            // ReplicatorParallelWorkflow
            // 
            this.Activities.Add(this.replicatorActivity1);
            this.Name = "ReplicatorParallelWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private ReplicatorActivity replicatorActivity1;
        private SequenceActivity sequenceActivity1;
        private ConsoleMessageActivity consoleMessageActivity1;











    }
}
