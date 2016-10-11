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

namespace ConsoleTerminate
{
	partial class Workflow1
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
            this.terminateActivity1 = new System.Workflow.ComponentModel.TerminateActivity();
            this.delayActivity1 = new System.Workflow.Activities.DelayActivity();
            // 
            // terminateActivity1
            // 
            this.terminateActivity1.Error = "Forced Termination";
            this.terminateActivity1.Name = "terminateActivity1";
            // 
            // delayActivity1
            // 
            this.delayActivity1.Name = "delayActivity1";
            this.delayActivity1.TimeoutDuration = System.TimeSpan.Parse("00:00:00");
            // 
            // Workflow1
            // 
            this.Activities.Add(this.delayActivity1);
            this.Activities.Add(this.terminateActivity1);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

		}

		#endregion

        private TerminateActivity terminateActivity1;
        private DelayActivity delayActivity1;


    }
}
