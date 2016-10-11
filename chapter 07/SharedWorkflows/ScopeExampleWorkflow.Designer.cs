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
	partial class ScopeExampleWorkflow
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
            this.delayActivity1 = new System.Workflow.Activities.DelayActivity();
            this.codeMainlineMessage = new System.Workflow.Activities.CodeActivity();
            this.handleEventStop = new System.Workflow.Activities.HandleExternalEventActivity();
            this.handleEventTwo = new System.Workflow.Activities.HandleExternalEventActivity();
            this.handleEventOne = new System.Workflow.Activities.HandleExternalEventActivity();
            this.sequenceActivity2 = new System.Workflow.Activities.SequenceActivity();
            this.eventDrivenActivity3 = new System.Workflow.Activities.EventDrivenActivity();
            this.eventDrivenActivity2 = new System.Workflow.Activities.EventDrivenActivity();
            this.eventDrivenActivity1 = new System.Workflow.Activities.EventDrivenActivity();
            this.whileActivity1 = new System.Workflow.Activities.WhileActivity();
            this.callStartMethod = new System.Workflow.Activities.CallExternalMethodActivity();
            this.eventHandlersActivity1 = new System.Workflow.Activities.EventHandlersActivity();
            this.sequenceActivity1 = new System.Workflow.Activities.SequenceActivity();
            this.eventHandlingScopeActivity1 = new System.Workflow.Activities.EventHandlingScopeActivity();
            // 
            // delayActivity1
            // 
            this.delayActivity1.Name = "delayActivity1";
            this.delayActivity1.TimeoutDuration = System.TimeSpan.Parse("00:00:01");
            // 
            // codeMainlineMessage
            // 
            this.codeMainlineMessage.Name = "codeMainlineMessage";
            this.codeMainlineMessage.ExecuteCode += new System.EventHandler(this.codeMainlineMessage_ExecuteCode);
            // 
            // handleEventStop
            // 
            this.handleEventStop.EventName = "EventStop";
            this.handleEventStop.InterfaceType = typeof(SharedWorkflows.IScopeExample);
            this.handleEventStop.Name = "handleEventStop";
            this.handleEventStop.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.handleEventStop_Invoked);
            // 
            // handleEventTwo
            // 
            this.handleEventTwo.EventName = "EventTwo";
            this.handleEventTwo.InterfaceType = typeof(SharedWorkflows.IScopeExample);
            this.handleEventTwo.Name = "handleEventTwo";
            this.handleEventTwo.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.handleEventTwo_Invoked);
            // 
            // handleEventOne
            // 
            this.handleEventOne.EventName = "EventOne";
            this.handleEventOne.InterfaceType = typeof(SharedWorkflows.IScopeExample);
            this.handleEventOne.Name = "handleEventOne";
            this.handleEventOne.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.handleEventOne_Invoked);
            // 
            // sequenceActivity2
            // 
            this.sequenceActivity2.Activities.Add(this.codeMainlineMessage);
            this.sequenceActivity2.Activities.Add(this.delayActivity1);
            this.sequenceActivity2.Name = "sequenceActivity2";
            // 
            // eventDrivenActivity3
            // 
            this.eventDrivenActivity3.Activities.Add(this.handleEventStop);
            this.eventDrivenActivity3.Name = "eventDrivenActivity3";
            // 
            // eventDrivenActivity2
            // 
            this.eventDrivenActivity2.Activities.Add(this.handleEventTwo);
            this.eventDrivenActivity2.Name = "eventDrivenActivity2";
            // 
            // eventDrivenActivity1
            // 
            this.eventDrivenActivity1.Activities.Add(this.handleEventOne);
            this.eventDrivenActivity1.Name = "eventDrivenActivity1";
            // 
            // whileActivity1
            // 
            this.whileActivity1.Activities.Add(this.sequenceActivity2);
            ruleconditionreference1.ConditionName = "checkIsComplete";
            this.whileActivity1.Condition = ruleconditionreference1;
            this.whileActivity1.Name = "whileActivity1";
            // 
            // callStartMethod
            // 
            this.callStartMethod.InterfaceType = typeof(SharedWorkflows.IScopeExample);
            this.callStartMethod.MethodName = "Started";
            this.callStartMethod.Name = "callStartMethod";
            // 
            // eventHandlersActivity1
            // 
            this.eventHandlersActivity1.Activities.Add(this.eventDrivenActivity1);
            this.eventHandlersActivity1.Activities.Add(this.eventDrivenActivity2);
            this.eventHandlersActivity1.Activities.Add(this.eventDrivenActivity3);
            this.eventHandlersActivity1.Name = "eventHandlersActivity1";
            // 
            // sequenceActivity1
            // 
            this.sequenceActivity1.Activities.Add(this.callStartMethod);
            this.sequenceActivity1.Activities.Add(this.whileActivity1);
            this.sequenceActivity1.Name = "sequenceActivity1";
            // 
            // eventHandlingScopeActivity1
            // 
            this.eventHandlingScopeActivity1.Activities.Add(this.sequenceActivity1);
            this.eventHandlingScopeActivity1.Activities.Add(this.eventHandlersActivity1);
            this.eventHandlingScopeActivity1.Name = "eventHandlingScopeActivity1";
            // 
            // ScopeExampleWorkflow
            // 
            this.Activities.Add(this.eventHandlingScopeActivity1);
            this.Name = "ScopeExampleWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private EventHandlersActivity eventHandlersActivity1;
        private WhileActivity whileActivity1;
        private CodeActivity codeMainlineMessage;
        private DelayActivity delayActivity1;
        private SequenceActivity sequenceActivity2;
        private EventDrivenActivity eventDrivenActivity1;
        private HandleExternalEventActivity handleEventOne;
        private HandleExternalEventActivity handleEventTwo;
        private EventDrivenActivity eventDrivenActivity2;
        private HandleExternalEventActivity handleEventStop;
        private EventDrivenActivity eventDrivenActivity3;
        private CallExternalMethodActivity callStartMethod;
        private SequenceActivity sequenceActivity1;
        private EventHandlingScopeActivity eventHandlingScopeActivity1;










    }
}
