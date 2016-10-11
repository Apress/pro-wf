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
    partial class MathServiceStatefulWorkflow
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
            System.Workflow.ComponentModel.ActivityBind activitybind4 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding4 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
            this.stopWorkflowInput = new System.Workflow.Activities.WebServiceInputActivity();
            this.getLastQuotientOutput = new System.Workflow.Activities.WebServiceOutputActivity();
            this.getLastQuotientInput = new System.Workflow.Activities.WebServiceInputActivity();
            this.divideNumbersOutput = new System.Workflow.Activities.WebServiceOutputActivity();
            this.codeDoDivision = new System.Workflow.Activities.CodeActivity();
            this.divideNumbersInput = new System.Workflow.Activities.WebServiceInputActivity();
            this.eventDrivenActivity3 = new System.Workflow.Activities.EventDrivenActivity();
            this.eventDrivenActivity2 = new System.Workflow.Activities.EventDrivenActivity();
            this.eventDrivenActivity1 = new System.Workflow.Activities.EventDrivenActivity();
            this.listenActivity1 = new System.Workflow.Activities.ListenActivity();
            this.whileActivity1 = new System.Workflow.Activities.WhileActivity();
            this.startWorkflowInput = new System.Workflow.Activities.WebServiceInputActivity();
            // 
            // stopWorkflowInput
            // 
            this.stopWorkflowInput.InterfaceType = typeof(SharedWorkflows.IMathServiceStateful);
            this.stopWorkflowInput.MethodName = "StopWorkflow";
            this.stopWorkflowInput.Name = "stopWorkflowInput";
            this.stopWorkflowInput.InputReceived += new System.EventHandler(this.stopWorkflowInput_InputReceived);
            // 
            // getLastQuotientOutput
            // 
            this.getLastQuotientOutput.InputActivityName = "getLastQuotientInput";
            this.getLastQuotientOutput.Name = "getLastQuotientOutput";
            activitybind1.Name = "MathServiceStatefulWorkflow";
            activitybind1.Path = "quotient";
            workflowparameterbinding1.ParameterName = "(ReturnValue)";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.getLastQuotientOutput.ParameterBindings.Add(workflowparameterbinding1);
            // 
            // getLastQuotientInput
            // 
            this.getLastQuotientInput.InterfaceType = typeof(SharedWorkflows.IMathServiceStateful);
            this.getLastQuotientInput.MethodName = "GetLastQuotient";
            this.getLastQuotientInput.Name = "getLastQuotientInput";
            // 
            // divideNumbersOutput
            // 
            this.divideNumbersOutput.InputActivityName = "divideNumbersInput";
            this.divideNumbersOutput.Name = "divideNumbersOutput";
            activitybind2.Name = "MathServiceStatefulWorkflow";
            activitybind2.Path = "quotient";
            workflowparameterbinding2.ParameterName = "(ReturnValue)";
            workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.divideNumbersOutput.ParameterBindings.Add(workflowparameterbinding2);
            // 
            // codeDoDivision
            // 
            this.codeDoDivision.Name = "codeDoDivision";
            this.codeDoDivision.ExecuteCode += new System.EventHandler(this.codeDoDivision_ExecuteCode);
            // 
            // divideNumbersInput
            // 
            this.divideNumbersInput.InterfaceType = typeof(SharedWorkflows.IMathServiceStateful);
            this.divideNumbersInput.MethodName = "DivideNumbers";
            this.divideNumbersInput.Name = "divideNumbersInput";
            activitybind3.Name = "MathServiceStatefulWorkflow";
            activitybind3.Path = "dividend";
            workflowparameterbinding3.ParameterName = "dividend";
            workflowparameterbinding3.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            activitybind4.Name = "MathServiceStatefulWorkflow";
            activitybind4.Path = "divisor";
            workflowparameterbinding4.ParameterName = "divisor";
            workflowparameterbinding4.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            this.divideNumbersInput.ParameterBindings.Add(workflowparameterbinding3);
            this.divideNumbersInput.ParameterBindings.Add(workflowparameterbinding4);
            // 
            // eventDrivenActivity3
            // 
            this.eventDrivenActivity3.Activities.Add(this.stopWorkflowInput);
            this.eventDrivenActivity3.Name = "eventDrivenActivity3";
            // 
            // eventDrivenActivity2
            // 
            this.eventDrivenActivity2.Activities.Add(this.getLastQuotientInput);
            this.eventDrivenActivity2.Activities.Add(this.getLastQuotientOutput);
            this.eventDrivenActivity2.Name = "eventDrivenActivity2";
            // 
            // eventDrivenActivity1
            // 
            this.eventDrivenActivity1.Activities.Add(this.divideNumbersInput);
            this.eventDrivenActivity1.Activities.Add(this.codeDoDivision);
            this.eventDrivenActivity1.Activities.Add(this.divideNumbersOutput);
            this.eventDrivenActivity1.Name = "eventDrivenActivity1";
            // 
            // listenActivity1
            // 
            this.listenActivity1.Activities.Add(this.eventDrivenActivity1);
            this.listenActivity1.Activities.Add(this.eventDrivenActivity2);
            this.listenActivity1.Activities.Add(this.eventDrivenActivity3);
            this.listenActivity1.Name = "listenActivity1";
            // 
            // whileActivity1
            // 
            this.whileActivity1.Activities.Add(this.listenActivity1);
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.CheckIsTimeToStop);
            this.whileActivity1.Condition = codecondition1;
            this.whileActivity1.Name = "whileActivity1";
            // 
            // startWorkflowInput
            // 
            this.startWorkflowInput.InterfaceType = typeof(SharedWorkflows.IMathServiceStateful);
            this.startWorkflowInput.IsActivating = true;
            this.startWorkflowInput.MethodName = "StartWorkflow";
            this.startWorkflowInput.Name = "startWorkflowInput";
            // 
            // MathServiceStatefulWorkflow
            // 
            this.Activities.Add(this.startWorkflowInput);
            this.Activities.Add(this.whileActivity1);
            this.Name = "MathServiceStatefulWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private EventDrivenActivity eventDrivenActivity2;
        private EventDrivenActivity eventDrivenActivity1;
        private ListenActivity listenActivity1;
        private WebServiceInputActivity startWorkflowInput;
        private WebServiceOutputActivity getLastQuotientOutput;
        private WebServiceInputActivity getLastQuotientInput;
        private WebServiceInputActivity stopWorkflowInput;
        private EventDrivenActivity eventDrivenActivity3;
        private WhileActivity whileActivity1;
        private CodeActivity codeDoDivision;
        private WebServiceOutputActivity divideNumbersOutput;
        private WebServiceInputActivity divideNumbersInput;































































    }
}
