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
	partial class PersistenceDemoWorkflow
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
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference1 = new System.Workflow.Activities.Rules.RuleConditionReference();
            this.handleStopReceived = new System.Workflow.Activities.HandleExternalEventActivity();
            this.handleContinueReceived = new System.Workflow.Activities.HandleExternalEventActivity();
            this.eventDrivenActivity2 = new System.Workflow.Activities.EventDrivenActivity();
            this.eventDrivenActivity1 = new System.Workflow.Activities.EventDrivenActivity();
            this.listenActivity1 = new System.Workflow.Activities.ListenActivity();
            this.compensatableSequenceActivity1 = new System.Workflow.Activities.CompensatableSequenceActivity();
            this.whileActivity1 = new System.Workflow.Activities.WhileActivity();
            // 
            // handleStopReceived
            // 
            this.handleStopReceived.EventName = "StopReceived";
            this.handleStopReceived.InterfaceType = typeof(SharedWorkflows.IPersistenceDemo);
            this.handleStopReceived.Name = "handleStopReceived";
            this.handleStopReceived.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.handleStopReceived_Invoked);
            // 
            // handleContinueReceived
            // 
            this.handleContinueReceived.EventName = "ContinueReceived";
            this.handleContinueReceived.InterfaceType = typeof(SharedWorkflows.IPersistenceDemo);
            this.handleContinueReceived.Name = "handleContinueReceived";
            // 
            // eventDrivenActivity2
            // 
            this.eventDrivenActivity2.Activities.Add(this.handleStopReceived);
            this.eventDrivenActivity2.Name = "eventDrivenActivity2";
            // 
            // eventDrivenActivity1
            // 
            this.eventDrivenActivity1.Activities.Add(this.handleContinueReceived);
            this.eventDrivenActivity1.Name = "eventDrivenActivity1";
            // 
            // listenActivity1
            // 
            this.listenActivity1.Activities.Add(this.eventDrivenActivity1);
            this.listenActivity1.Activities.Add(this.eventDrivenActivity2);
            this.listenActivity1.Name = "listenActivity1";
            // 
            // compensatableSequenceActivity1
            // 
            this.compensatableSequenceActivity1.Activities.Add(this.listenActivity1);
            this.compensatableSequenceActivity1.Name = "compensatableSequenceActivity1";
            // 
            // whileActivity1
            // 
            this.whileActivity1.Activities.Add(this.compensatableSequenceActivity1);
            ruleconditionreference1.ConditionName = "checkIsComplete";
            this.whileActivity1.Condition = ruleconditionreference1;
            this.whileActivity1.Name = "whileActivity1";
            // 
            // PersistenceDemoWorkflow
            // 
            this.Activities.Add(this.whileActivity1);
            this.Name = "PersistenceDemoWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private WhileActivity whileActivity1;
        private EventDrivenActivity eventDrivenActivity2;
        private EventDrivenActivity eventDrivenActivity1;
        private ListenActivity listenActivity1;
        private HandleExternalEventActivity handleStopReceived;
        private CompensatableSequenceActivity compensatableSequenceActivity1;
        private HandleExternalEventActivity handleContinueReceived;








    }
}
