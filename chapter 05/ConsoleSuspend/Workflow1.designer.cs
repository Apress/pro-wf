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

namespace ConsoleSuspend
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
            this.codeActivity2 = new System.Workflow.Activities.CodeActivity();
            this.suspendActivity1 = new System.Workflow.ComponentModel.SuspendActivity();
            this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
            // 
            // codeActivity2
            // 
            this.codeActivity2.Name = "codeActivity2";
            this.codeActivity2.ExecuteCode += new System.EventHandler(this.codeActivity2_ExecuteCode);
            // 
            // suspendActivity1
            // 
            this.suspendActivity1.Error = "Suspended Workflow";
            this.suspendActivity1.Name = "suspendActivity1";
            // 
            // codeActivity1
            // 
            this.codeActivity1.Name = "codeActivity1";
            this.codeActivity1.ExecuteCode += new System.EventHandler(this.codeActivity1_ExecuteCode);
            // 
            // Workflow1
            // 
            this.Activities.Add(this.codeActivity1);
            this.Activities.Add(this.suspendActivity1);
            this.Activities.Add(this.codeActivity2);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

		}

		#endregion

        private CodeActivity codeActivity2;
        private SuspendActivity suspendActivity1;
        private CodeActivity codeActivity1;


    }
}
