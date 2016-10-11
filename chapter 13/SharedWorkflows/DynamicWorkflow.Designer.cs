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
	partial class DynamicWorkflow
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
            this.codeLastPart = new System.Workflow.Activities.CodeActivity();
            this.sequencePlaceholder = new System.Workflow.Activities.SequenceActivity();
            this.codeFirstPart = new System.Workflow.Activities.CodeActivity();
            this.suspendActivity1 = new System.Workflow.ComponentModel.SuspendActivity();
            // 
            // codeLastPart
            // 
            this.codeLastPart.Name = "codeLastPart";
            this.codeLastPart.ExecuteCode += new System.EventHandler(this.codeLastPart_ExecuteCode);
            // 
            // sequencePlaceholder
            // 
            this.sequencePlaceholder.Name = "sequencePlaceholder";
            // 
            // codeFirstPart
            // 
            this.codeFirstPart.Name = "codeFirstPart";
            this.codeFirstPart.ExecuteCode += new System.EventHandler(this.codeFirstPart_ExecuteCode);
            // 
            // suspendActivity1
            // 
            this.suspendActivity1.Name = "suspendActivity1";
            // 
            // DynamicWorkflow
            // 
            this.Activities.Add(this.suspendActivity1);
            this.Activities.Add(this.codeFirstPart);
            this.Activities.Add(this.sequencePlaceholder);
            this.Activities.Add(this.codeLastPart);
            this.Name = "DynamicWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private CodeActivity codeLastPart;
        private SequenceActivity sequencePlaceholder;
        private SuspendActivity suspendActivity1;
        private CodeActivity codeFirstPart;



    }
}
