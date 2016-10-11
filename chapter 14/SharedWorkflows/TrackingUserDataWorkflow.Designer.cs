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
    partial class TrackingUserDataWorkflow
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
            this.codeLastActivity = new System.Workflow.Activities.CodeActivity();
            this.delayActivity1 = new System.Workflow.Activities.DelayActivity();
            this.codeFirstActivity = new System.Workflow.Activities.CodeActivity();
            // 
            // codeLastActivity
            // 
            this.codeLastActivity.Name = "codeLastActivity";
            this.codeLastActivity.ExecuteCode += new System.EventHandler(this.codeLastActivity_ExecuteCode);
            // 
            // delayActivity1
            // 
            this.delayActivity1.Name = "delayActivity1";
            this.delayActivity1.TimeoutDuration = System.TimeSpan.Parse("00:00:01");
            // 
            // codeFirstActivity
            // 
            this.codeFirstActivity.Name = "codeFirstActivity";
            this.codeFirstActivity.ExecuteCode += new System.EventHandler(this.codeFirstActivity_ExecuteCode);
            // 
            // TrackingExampleWorkflow
            // 
            this.Activities.Add(this.codeFirstActivity);
            this.Activities.Add(this.delayActivity1);
            this.Activities.Add(this.codeLastActivity);
            this.Name = "TrackingExampleWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private CodeActivity codeLastActivity;
        private DelayActivity delayActivity1;
        private CodeActivity codeFirstActivity;









    }
}
