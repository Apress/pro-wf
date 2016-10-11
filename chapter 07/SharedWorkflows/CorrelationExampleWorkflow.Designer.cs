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
	partial class CorrelationExampleWorkflow
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
            System.Workflow.Runtime.CorrelationToken correlationtoken1 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding1 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.Runtime.CorrelationToken correlationtoken2 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding2 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding3 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding4 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            this.delayActivity2 = new System.Workflow.Activities.DelayActivity();
            this.handleExternalEventActivity2 = new System.Workflow.Activities.HandleExternalEventActivity();
            this.delayActivity1 = new System.Workflow.Activities.DelayActivity();
            this.handleExternalEventActivity1 = new System.Workflow.Activities.HandleExternalEventActivity();
            this.eventDrivenActivity4 = new System.Workflow.Activities.EventDrivenActivity();
            this.eventDrivenActivity3 = new System.Workflow.Activities.EventDrivenActivity();
            this.eventDrivenActivity2 = new System.Workflow.Activities.EventDrivenActivity();
            this.eventDrivenActivity1 = new System.Workflow.Activities.EventDrivenActivity();
            this.listenActivity2 = new System.Workflow.Activities.ListenActivity();
            this.callExternalMethodActivity2 = new System.Workflow.Activities.CallExternalMethodActivity();
            this.listenActivity1 = new System.Workflow.Activities.ListenActivity();
            this.callExternalMethodActivity1 = new System.Workflow.Activities.CallExternalMethodActivity();
            this.sequenceActivity2 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity1 = new System.Workflow.Activities.SequenceActivity();
            this.parallelActivity1 = new System.Workflow.Activities.ParallelActivity();
            // 
            // delayActivity2
            // 
            this.delayActivity2.Name = "delayActivity2";
            this.delayActivity2.TimeoutDuration = System.TimeSpan.Parse("00:00:10");
            // 
            // handleExternalEventActivity2
            // 
            correlationtoken1.Name = "branch2";
            correlationtoken1.OwnerActivityName = "CorrelationExampleWorkflow";
            this.handleExternalEventActivity2.CorrelationToken = correlationtoken1;
            this.handleExternalEventActivity2.EventName = "EventReceived";
            this.handleExternalEventActivity2.InterfaceType = typeof(SharedWorkflows.ICorrelationExample);
            this.handleExternalEventActivity2.Name = "handleExternalEventActivity2";
            workflowparameterbinding1.ParameterName = "e";
            this.handleExternalEventActivity2.ParameterBindings.Add(workflowparameterbinding1);
            this.handleExternalEventActivity2.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.handleExternalEventActivity2_Invoked);
            // 
            // delayActivity1
            // 
            this.delayActivity1.Name = "delayActivity1";
            this.delayActivity1.TimeoutDuration = System.TimeSpan.Parse("00:00:10");
            // 
            // handleExternalEventActivity1
            // 
            correlationtoken2.Name = "branch1";
            correlationtoken2.OwnerActivityName = "CorrelationExampleWorkflow";
            this.handleExternalEventActivity1.CorrelationToken = correlationtoken2;
            this.handleExternalEventActivity1.EventName = "EventReceived";
            this.handleExternalEventActivity1.InterfaceType = typeof(SharedWorkflows.ICorrelationExample);
            this.handleExternalEventActivity1.Name = "handleExternalEventActivity1";
            workflowparameterbinding2.ParameterName = "e";
            this.handleExternalEventActivity1.ParameterBindings.Add(workflowparameterbinding2);
            this.handleExternalEventActivity1.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.handleExternalEventActivity1_Invoked);
            // 
            // eventDrivenActivity4
            // 
            this.eventDrivenActivity4.Activities.Add(this.delayActivity2);
            this.eventDrivenActivity4.Name = "eventDrivenActivity4";
            // 
            // eventDrivenActivity3
            // 
            this.eventDrivenActivity3.Activities.Add(this.handleExternalEventActivity2);
            this.eventDrivenActivity3.Name = "eventDrivenActivity3";
            // 
            // eventDrivenActivity2
            // 
            this.eventDrivenActivity2.Activities.Add(this.delayActivity1);
            this.eventDrivenActivity2.Name = "eventDrivenActivity2";
            // 
            // eventDrivenActivity1
            // 
            this.eventDrivenActivity1.Activities.Add(this.handleExternalEventActivity1);
            this.eventDrivenActivity1.Name = "eventDrivenActivity1";
            // 
            // listenActivity2
            // 
            this.listenActivity2.Activities.Add(this.eventDrivenActivity3);
            this.listenActivity2.Activities.Add(this.eventDrivenActivity4);
            this.listenActivity2.Name = "listenActivity2";
            // 
            // callExternalMethodActivity2
            // 
            this.callExternalMethodActivity2.CorrelationToken = correlationtoken1;
            this.callExternalMethodActivity2.InterfaceType = typeof(SharedWorkflows.ICorrelationExample);
            this.callExternalMethodActivity2.MethodName = "StartDemonstration";
            this.callExternalMethodActivity2.Name = "callExternalMethodActivity2";
            workflowparameterbinding3.ParameterName = "branchId";
            workflowparameterbinding3.Value = 2;
            this.callExternalMethodActivity2.ParameterBindings.Add(workflowparameterbinding3);
            // 
            // listenActivity1
            // 
            this.listenActivity1.Activities.Add(this.eventDrivenActivity1);
            this.listenActivity1.Activities.Add(this.eventDrivenActivity2);
            this.listenActivity1.Name = "listenActivity1";
            // 
            // callExternalMethodActivity1
            // 
            this.callExternalMethodActivity1.CorrelationToken = correlationtoken2;
            this.callExternalMethodActivity1.InterfaceType = typeof(SharedWorkflows.ICorrelationExample);
            this.callExternalMethodActivity1.MethodName = "StartDemonstration";
            this.callExternalMethodActivity1.Name = "callExternalMethodActivity1";
            workflowparameterbinding4.ParameterName = "branchId";
            workflowparameterbinding4.Value = 1;
            this.callExternalMethodActivity1.ParameterBindings.Add(workflowparameterbinding4);
            // 
            // sequenceActivity2
            // 
            this.sequenceActivity2.Activities.Add(this.callExternalMethodActivity2);
            this.sequenceActivity2.Activities.Add(this.listenActivity2);
            this.sequenceActivity2.Name = "sequenceActivity2";
            // 
            // sequenceActivity1
            // 
            this.sequenceActivity1.Activities.Add(this.callExternalMethodActivity1);
            this.sequenceActivity1.Activities.Add(this.listenActivity1);
            this.sequenceActivity1.Name = "sequenceActivity1";
            // 
            // parallelActivity1
            // 
            this.parallelActivity1.Activities.Add(this.sequenceActivity1);
            this.parallelActivity1.Activities.Add(this.sequenceActivity2);
            this.parallelActivity1.Name = "parallelActivity1";
            // 
            // CorrelationExampleWorkflow
            // 
            this.Activities.Add(this.parallelActivity1);
            this.Name = "CorrelationExampleWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private DelayActivity delayActivity1;
        private DelayActivity delayActivity2;
        private HandleExternalEventActivity handleExternalEventActivity2;
        private EventDrivenActivity eventDrivenActivity4;
        private EventDrivenActivity eventDrivenActivity3;
        private ListenActivity listenActivity2;
        private SequenceActivity sequenceActivity2;
        private SequenceActivity sequenceActivity1;
        private CallExternalMethodActivity callExternalMethodActivity1;
        private CallExternalMethodActivity callExternalMethodActivity2;
        private HandleExternalEventActivity handleExternalEventActivity1;
        private EventDrivenActivity eventDrivenActivity2;
        private EventDrivenActivity eventDrivenActivity1;
        private ListenActivity listenActivity1;
        private ParallelActivity parallelActivity1;



























    }
}
