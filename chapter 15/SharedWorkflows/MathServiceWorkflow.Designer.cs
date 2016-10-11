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
	partial class MathServiceWorkflow
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
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding1 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding2 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding3 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            this.divideNumbersOutput = new System.Workflow.Activities.WebServiceOutputActivity();
            this.codeDoDivision = new System.Workflow.Activities.CodeActivity();
            this.divideNumbersInput = new System.Workflow.Activities.WebServiceInputActivity();
            // 
            // divideNumbersOutput
            // 
            this.divideNumbersOutput.InputActivityName = "divideNumbersInput";
            this.divideNumbersOutput.Name = "divideNumbersOutput";
            activitybind1.Name = "MathServiceWorkflow";
            activitybind1.Path = "quotient";
            workflowparameterbinding1.ParameterName = "(ReturnValue)";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.divideNumbersOutput.ParameterBindings.Add(workflowparameterbinding1);
            // 
            // codeDoDivision
            // 
            this.codeDoDivision.Name = "codeDoDivision";
            this.codeDoDivision.ExecuteCode += new System.EventHandler(this.codeDoDivision_ExecuteCode);
            // 
            // divideNumbersInput
            // 
            this.divideNumbersInput.InterfaceType = typeof(SharedWorkflows.IMathService);
            this.divideNumbersInput.IsActivating = true;
            this.divideNumbersInput.MethodName = "DivideNumbers";
            this.divideNumbersInput.Name = "divideNumbersInput";
            activitybind2.Name = "MathServiceWorkflow";
            activitybind2.Path = "dividend";
            workflowparameterbinding2.ParameterName = "dividend";
            workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            activitybind3.Name = "MathServiceWorkflow";
            activitybind3.Path = "divisor";
            workflowparameterbinding3.ParameterName = "divisor";
            workflowparameterbinding3.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            this.divideNumbersInput.ParameterBindings.Add(workflowparameterbinding2);
            this.divideNumbersInput.ParameterBindings.Add(workflowparameterbinding3);
            // 
            // MathServiceWorkflow
            // 
            this.Activities.Add(this.divideNumbersInput);
            this.Activities.Add(this.codeDoDivision);
            this.Activities.Add(this.divideNumbersOutput);
            this.Name = "MathServiceWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private CodeActivity codeDoDivision;
        private WebServiceOutputActivity divideNumbersOutput;
        private WebServiceInputActivity divideNumbersInput;











    }
}
