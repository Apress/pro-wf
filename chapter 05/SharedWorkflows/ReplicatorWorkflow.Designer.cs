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
	partial class ReplicatorWorkflow
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
            this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
            this.replicatorActivity1 = new System.Workflow.Activities.ReplicatorActivity();
            // 
            // codeActivity1
            // 
            this.codeActivity1.Name = "codeActivity1";
            this.codeActivity1.ExecuteCode += new System.EventHandler(this.codeActivity1_ExecuteCode);
            activitybind1.Name = "ReplicatorWorkflow";
            activitybind1.Path = "InputList";
            // 
            // replicatorActivity1
            // 
            this.replicatorActivity1.Activities.Add(this.codeActivity1);
            this.replicatorActivity1.ExecutionType = System.Workflow.Activities.ExecutionType.Sequence;
            this.replicatorActivity1.Name = "replicatorActivity1";
            this.replicatorActivity1.SetBinding(System.Workflow.Activities.ReplicatorActivity.InitialChildDataProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // 
            // ReplicatorWorkflow
            // 
            this.Activities.Add(this.replicatorActivity1);
            this.Name = "ReplicatorWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private CodeActivity codeActivity1;
        private ReplicatorActivity replicatorActivity1;
















    }
}
