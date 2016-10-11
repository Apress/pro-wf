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

namespace ConsoleInvokeWorkflow
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
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding1 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding2 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            this.invokeWorkflowActivity2 = new System.Workflow.Activities.InvokeWorkflowActivity();
            this.invokeWorkflowActivity1 = new System.Workflow.Activities.InvokeWorkflowActivity();
            // 
            // invokeWorkflowActivity2
            // 
            this.invokeWorkflowActivity2.Name = "invokeWorkflowActivity2";
            workflowparameterbinding1.ParameterName = "TestNumber";
            workflowparameterbinding1.Value = 3;
            this.invokeWorkflowActivity2.ParameterBindings.Add(workflowparameterbinding1);
            this.invokeWorkflowActivity2.TargetWorkflow = typeof(SharedWorkflows.WhileWorkflow);
            // 
            // invokeWorkflowActivity1
            // 
            this.invokeWorkflowActivity1.Name = "invokeWorkflowActivity1";
            workflowparameterbinding2.ParameterName = "TestNumber";
            workflowparameterbinding2.Value = 2;
            this.invokeWorkflowActivity1.ParameterBindings.Add(workflowparameterbinding2);
            this.invokeWorkflowActivity1.TargetWorkflow = typeof(SharedWorkflows.ParallelWorkflow);
            // 
            // Workflow1
            // 
            this.Activities.Add(this.invokeWorkflowActivity1);
            this.Activities.Add(this.invokeWorkflowActivity2);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

		}

		#endregion

        private InvokeWorkflowActivity invokeWorkflowActivity1;
        private InvokeWorkflowActivity invokeWorkflowActivity2;











    }
}
