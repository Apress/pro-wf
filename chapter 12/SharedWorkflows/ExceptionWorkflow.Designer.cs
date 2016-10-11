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
	partial class ExceptionWorkflow
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
            this.codeOtherActivity = new System.Workflow.Activities.CodeActivity();
            this.codeCauseException = new System.Workflow.Activities.CodeActivity();
            // 
            // codeOtherActivity
            // 
            this.codeOtherActivity.Name = "codeOtherActivity";
            this.codeOtherActivity.ExecuteCode += new System.EventHandler(this.codeOtherActivity_ExecuteCode);
            // 
            // codeCauseException
            // 
            this.codeCauseException.Name = "codeCauseException";
            this.codeCauseException.ExecuteCode += new System.EventHandler(this.codeCauseException_ExecuteCode);
            // 
            // ExceptionWorkflow
            // 
            this.Activities.Add(this.codeCauseException);
            this.Activities.Add(this.codeOtherActivity);
            this.Name = "ExceptionWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private CodeActivity codeOtherActivity;
        private CodeActivity codeCauseException;





    }
}
