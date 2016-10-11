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
	partial class GuessingGameWcaWorkflow
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
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference1 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            this.terminateActivity1 = new System.Workflow.ComponentModel.TerminateActivity();
            this.delayActivity1 = new System.Workflow.Activities.DelayActivity();
            this.sendMessage2 = new SharedWorkflows.SendMessage();
            this.guessReceived1 = new SharedWorkflows.GuessReceived();
            this.eventDrivenActivity2 = new System.Workflow.Activities.EventDrivenActivity();
            this.eventDrivenActivity1 = new System.Workflow.Activities.EventDrivenActivity();
            this.listenActivity1 = new System.Workflow.Activities.ListenActivity();
            this.whileActivity1 = new System.Workflow.Activities.WhileActivity();
            this.sendMessage1 = new SharedWorkflows.SendMessage();
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
            // sendMessage2
            // 
            activitybind1.Name = "GuessingGameWcaWorkflow";
            activitybind1.Path = "Message";
            this.sendMessage2.Name = "sendMessage2";
            this.sendMessage2.SetBinding(SharedWorkflows.SendMessage.messageProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // 
            // guessReceived1
            // 
            this.guessReceived1.Name = "guessReceived1";
            this.guessReceived1.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.guessReceived1_Invoked);
            // 
            // eventDrivenActivity2
            // 
            this.eventDrivenActivity2.Activities.Add(this.delayActivity1);
            this.eventDrivenActivity2.Activities.Add(this.terminateActivity1);
            this.eventDrivenActivity2.Name = "eventDrivenActivity2";
            // 
            // eventDrivenActivity1
            // 
            this.eventDrivenActivity1.Activities.Add(this.guessReceived1);
            this.eventDrivenActivity1.Activities.Add(this.sendMessage2);
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
            // sendMessage1
            // 
            activitybind3.Name = "GuessingGameWcaWorkflow";
            activitybind3.Path = "Message";
            this.sendMessage1.Name = "sendMessage1";
            this.sendMessage1.SetBinding(SharedWorkflows.SendMessage.messageProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            // 
            // GuessingGameWcaWorkflow
            // 
            this.Activities.Add(this.sendMessage1);
            this.Activities.Add(this.whileActivity1);
            this.Name = "GuessingGameWcaWorkflow";
            this.Initialized += new System.EventHandler(this.OnInitialized);
            this.CanModifyActivities = false;

		}

		#endregion

        private SendMessage sendMessage1;
        private SendMessage sendMessage2;
        private GuessReceived guessReceived1;
        private TerminateActivity terminateActivity1;
        private DelayActivity delayActivity1;
        private EventDrivenActivity eventDrivenActivity2;
        private EventDrivenActivity eventDrivenActivity1;
        private ListenActivity listenActivity1;
        private WhileActivity whileActivity1;





































    }
}
