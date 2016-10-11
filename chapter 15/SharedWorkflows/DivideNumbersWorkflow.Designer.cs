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
	partial class DivideNumbersWorkflow
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
            this.codeDoDivision = new System.Workflow.Activities.CodeActivity();
            // 
            // codeDoDivision
            // 
            this.codeDoDivision.Name = "codeDoDivision";
            this.codeDoDivision.ExecuteCode += new System.EventHandler(this.codeDoDivision_ExecuteCode);
            // 
            // DivideNumbersWorkflow
            // 
            this.Activities.Add(this.codeDoDivision);
            this.Name = "DivideNumbersWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private CodeActivity codeDoDivision;
	}
}
