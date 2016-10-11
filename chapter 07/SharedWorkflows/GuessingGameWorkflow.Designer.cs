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
	partial class GuessingGameWorkflow
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
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding2 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference1 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding3 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            this.terminateActivity1 = new System.Workflow.ComponentModel.TerminateActivity();
            this.delayActivity1 = new System.Workflow.Activities.DelayActivity();
            this.callExternalMethodActivity2 = new System.Workflow.Activities.CallExternalMethodActivity();
            this.handleExternalEventActivity1 = new System.Workflow.Activities.HandleExternalEventActivity();
            this.eventDrivenActivity2 = new System.Workflow.Activities.EventDrivenActivity();
            this.eventDrivenActivity1 = new System.Workflow.Activities.EventDrivenActivity();
            this.listenActivity1 = new System.Workflow.Activities.ListenActivity();
            this.whileActivity1 = new System.Workflow.Activities.WhileActivity();
            this.callExternalMethodActivity1 = new System.Workflow.Activities.CallExternalMethodActivity();
            // 
            // terminateActivity1
            // 
            this.terminateActivity1.Error = "You never made a guess";
            this.terminateActivity1.Name = "terminateActivity1";
            // 
            // delayActivity1
            // 
            this.delayActivity1.Name = "delayActivity1";
            this.delayActivity1.TimeoutDuration = System.TimeSpan.Parse("00:01:00");
            // 
            // callExternalMethodActivity2
            // 
            this.callExternalMethodActivity2.InterfaceType = typeof(SharedWorkflows.IGuessingGame);
            this.callExternalMethodActivity2.MethodName = "SendMessage";
            this.callExternalMethodActivity2.Name = "callExternalMethodActivity2";
            activitybind1.Name = "GuessingGameWorkflow";
            activitybind1.Path = "Message";
            workflowparameterbinding1.ParameterName = "message";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.callExternalMethodActivity2.ParameterBindings.Add(workflowparameterbinding1);
            // 
            // handleExternalEventActivity1
            // 
            this.handleExternalEventActivity1.EventName = "GuessReceived";
            this.handleExternalEventActivity1.InterfaceType = typeof(SharedWorkflows.IGuessingGame);
            this.handleExternalEventActivity1.Name = "handleExternalEventActivity1";
            workflowparameterbinding2.ParameterName = "e";
            this.handleExternalEventActivity1.ParameterBindings.Add(workflowparameterbinding2);
            this.handleExternalEventActivity1.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.handleExternalEventActivity1_Invoked);
            // 
            // eventDrivenActivity2
            // 
            this.eventDrivenActivity2.Activities.Add(this.delayActivity1);
            this.eventDrivenActivity2.Activities.Add(this.terminateActivity1);
            this.eventDrivenActivity2.Name = "eventDrivenActivity2";
            // 
            // eventDrivenActivity1
            // 
            this.eventDrivenActivity1.Activities.Add(this.handleExternalEventActivity1);
            this.eventDrivenActivity1.Activities.Add(this.callExternalMethodActivity2);
            this.eventDrivenActivity1.Name = "eventDrivenActivity1";
            // 
            // listenActivity1
            // 
            this.listenActivity1.Activities.Add(this.eventDrivenActivity1);
            this.listenActivity1.Activities.Add(this.eventDrivenActivity2);
            this.listenActivity1.Name = "listenActivity1";
            // 
            // whileActivity1
            // 
            this.whileActivity1.Activities.Add(this.listenActivity1);
            ruleconditionreference1.ConditionName = "checkIsComplete";
            this.whileActivity1.Condition = ruleconditionreference1;
            this.whileActivity1.Name = "whileActivity1";
            // 
            // callExternalMethodActivity1
            // 
            this.callExternalMethodActivity1.InterfaceType = typeof(SharedWorkflows.IGuessingGame);
            this.callExternalMethodActivity1.MethodName = "SendMessage";
            this.callExternalMethodActivity1.Name = "callExternalMethodActivity1";
            activitybind2.Name = "GuessingGameWorkflow";
            activitybind2.Path = "Message";
            workflowparameterbinding3.ParameterName = "message";
            workflowparameterbinding3.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.callExternalMethodActivity1.ParameterBindings.Add(workflowparameterbinding3);
            // 
            // GuessingGameWorkflow
            // 
            this.Activities.Add(this.callExternalMethodActivity1);
            this.Activities.Add(this.whileActivity1);
            this.Name = "GuessingGameWorkflow";
            this.Initialized += new System.EventHandler(this.OnInitialized);
            this.CanModifyActivities = false;

		}

		#endregion

        private CallExternalMethodActivity callExternalMethodActivity2;
        private TerminateActivity terminateActivity1;
        private DelayActivity delayActivity1;
        private EventDrivenActivity eventDrivenActivity2;
        private EventDrivenActivity eventDrivenActivity1;
        private ListenActivity listenActivity1;
        private HandleExternalEventActivity handleExternalEventActivity1;
        private CallExternalMethodActivity callExternalMethodActivity1;
        private WhileActivity whileActivity1;

































    }
}
