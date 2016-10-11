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
    partial class MathServiceFaultsWorkflow
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
            System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding2 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind4 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding3 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            this.divideNumbersOutput = new System.Workflow.Activities.WebServiceOutputActivity();
            this.codeDoDivision = new System.Workflow.Activities.CodeActivity();
            this.divideNumbersFault = new System.Workflow.Activities.WebServiceFaultActivity();
            this.ifDivisorNotZero = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifDivisorZero = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseActivity1 = new System.Workflow.Activities.IfElseActivity();
            this.divideNumbersInput = new System.Workflow.Activities.WebServiceInputActivity();
            // 
            // divideNumbersOutput
            // 
            this.divideNumbersOutput.InputActivityName = "divideNumbersInput";
            this.divideNumbersOutput.Name = "divideNumbersOutput";
            activitybind1.Name = "MathServiceFaultsWorkflow";
            activitybind1.Path = "quotient";
            workflowparameterbinding1.ParameterName = "(ReturnValue)";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.divideNumbersOutput.ParameterBindings.Add(workflowparameterbinding1);
            // 
            // codeDoDivision
            // 
            this.codeDoDivision.Name = "codeDoDivision";
            this.codeDoDivision.ExecuteCode += new System.EventHandler(this.codeDoDivision_ExecuteCode);
            activitybind2.Name = "MathServiceFaultsWorkflow";
            activitybind2.Path = "fault";
            // 
            // divideNumbersFault
            // 
            this.divideNumbersFault.InputActivityName = "divideNumbersInput";
            this.divideNumbersFault.Name = "divideNumbersFault";
            this.divideNumbersFault.SetBinding(System.Workflow.Activities.WebServiceFaultActivity.FaultProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            // 
            // ifDivisorNotZero
            // 
            this.ifDivisorNotZero.Activities.Add(this.codeDoDivision);
            this.ifDivisorNotZero.Activities.Add(this.divideNumbersOutput);
            this.ifDivisorNotZero.Name = "ifDivisorNotZero";
            // 
            // ifDivisorZero
            // 
            this.ifDivisorZero.Activities.Add(this.divideNumbersFault);
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.IsDivisorZero);
            this.ifDivisorZero.Condition = codecondition1;
            this.ifDivisorZero.Name = "ifDivisorZero";
            // 
            // ifElseActivity1
            // 
            this.ifElseActivity1.Activities.Add(this.ifDivisorZero);
            this.ifElseActivity1.Activities.Add(this.ifDivisorNotZero);
            this.ifElseActivity1.Name = "ifElseActivity1";
            // 
            // divideNumbersInput
            // 
            this.divideNumbersInput.InterfaceType = typeof(SharedWorkflows.IMathService);
            this.divideNumbersInput.IsActivating = true;
            this.divideNumbersInput.MethodName = "DivideNumbers";
            this.divideNumbersInput.Name = "divideNumbersInput";
            activitybind3.Name = "MathServiceFaultsWorkflow";
            activitybind3.Path = "dividend";
            workflowparameterbinding2.ParameterName = "dividend";
            workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            activitybind4.Name = "MathServiceFaultsWorkflow";
            activitybind4.Path = "divisor";
            workflowparameterbinding3.ParameterName = "divisor";
            workflowparameterbinding3.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            this.divideNumbersInput.ParameterBindings.Add(workflowparameterbinding2);
            this.divideNumbersInput.ParameterBindings.Add(workflowparameterbinding3);
            // 
            // MathServiceFaultsWorkflow
            // 
            this.Activities.Add(this.divideNumbersInput);
            this.Activities.Add(this.ifElseActivity1);
            this.Name = "MathServiceFaultsWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private WebServiceFaultActivity divideNumbersFault;
        private IfElseBranchActivity ifDivisorNotZero;
        private IfElseBranchActivity ifDivisorZero;
        private IfElseActivity ifElseActivity1;
        private CodeActivity codeDoDivision;
        private WebServiceOutputActivity divideNumbersOutput;
        private WebServiceInputActivity divideNumbersInput;
































    }
}
