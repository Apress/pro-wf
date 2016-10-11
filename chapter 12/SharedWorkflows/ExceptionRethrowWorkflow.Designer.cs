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
	partial class ExceptionRethrowWorkflow
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
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            this.throwActivity1 = new System.Workflow.ComponentModel.ThrowActivity();
            this.codeHandleArithmetic = new System.Workflow.Activities.CodeActivity();
            this.codeHandleDivide = new System.Workflow.Activities.CodeActivity();
            this.faultHandlerArithmetic = new System.Workflow.ComponentModel.FaultHandlerActivity();
            this.faultHandlerDivide = new System.Workflow.ComponentModel.FaultHandlerActivity();
            this.faultHandlersActivity2 = new System.Workflow.ComponentModel.FaultHandlersActivity();
            this.codeCauseException = new System.Workflow.Activities.CodeActivity();
            this.faultHandlersActivity1 = new System.Workflow.ComponentModel.FaultHandlersActivity();
            this.codeOtherActivity = new System.Workflow.Activities.CodeActivity();
            this.sequenceActivity1 = new System.Workflow.Activities.SequenceActivity();
            activitybind1.Name = "faultHandlerArithmetic";
            activitybind1.Path = "Fault";
            activitybind2.Name = "faultHandlerArithmetic";
            activitybind2.Path = "FaultType";
            // 
            // throwActivity1
            // 
            this.throwActivity1.Name = "throwActivity1";
            this.throwActivity1.SetBinding(System.Workflow.ComponentModel.ThrowActivity.FaultProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.throwActivity1.SetBinding(System.Workflow.ComponentModel.ThrowActivity.FaultTypeProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            // 
            // codeHandleArithmetic
            // 
            this.codeHandleArithmetic.Name = "codeHandleArithmetic";
            this.codeHandleArithmetic.ExecuteCode += new System.EventHandler(this.codeHandleArithmetic_ExecuteCode);
            // 
            // codeHandleDivide
            // 
            this.codeHandleDivide.Name = "codeHandleDivide";
            this.codeHandleDivide.ExecuteCode += new System.EventHandler(this.codeHandleDivide_ExecuteCode);
            // 
            // faultHandlerArithmetic
            // 
            this.faultHandlerArithmetic.Activities.Add(this.codeHandleArithmetic);
            this.faultHandlerArithmetic.Activities.Add(this.throwActivity1);
            this.faultHandlerArithmetic.FaultType = typeof(System.ArithmeticException);
            this.faultHandlerArithmetic.Name = "faultHandlerArithmetic";
            // 
            // faultHandlerDivide
            // 
            this.faultHandlerDivide.Activities.Add(this.codeHandleDivide);
            this.faultHandlerDivide.FaultType = typeof(System.DivideByZeroException);
            this.faultHandlerDivide.Name = "faultHandlerDivide";
            // 
            // faultHandlersActivity2
            // 
            this.faultHandlersActivity2.Activities.Add(this.faultHandlerDivide);
            this.faultHandlersActivity2.Activities.Add(this.faultHandlerArithmetic);
            this.faultHandlersActivity2.Name = "faultHandlersActivity2";
            // 
            // codeCauseException
            // 
            this.codeCauseException.Name = "codeCauseException";
            this.codeCauseException.ExecuteCode += new System.EventHandler(this.codeCauseException_ExecuteCode);
            // 
            // faultHandlersActivity1
            // 
            this.faultHandlersActivity1.Name = "faultHandlersActivity1";
            // 
            // codeOtherActivity
            // 
            this.codeOtherActivity.Name = "codeOtherActivity";
            this.codeOtherActivity.ExecuteCode += new System.EventHandler(this.codeOtherActivity_ExecuteCode);
            // 
            // sequenceActivity1
            // 
            this.sequenceActivity1.Activities.Add(this.codeCauseException);
            this.sequenceActivity1.Activities.Add(this.faultHandlersActivity2);
            this.sequenceActivity1.Name = "sequenceActivity1";
            // 
            // ExceptionCompositeWorkflow
            // 
            this.Activities.Add(this.sequenceActivity1);
            this.Activities.Add(this.codeOtherActivity);
            this.Activities.Add(this.faultHandlersActivity1);
            this.Name = "ExceptionCompositeWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private CodeActivity codeOtherActivity;
        private FaultHandlersActivity faultHandlersActivity1;
        private CodeActivity codeHandleArithmetic;
        private CodeActivity codeHandleDivide;
        private FaultHandlerActivity faultHandlerArithmetic;
        private FaultHandlerActivity faultHandlerDivide;
        private FaultHandlersActivity faultHandlersActivity2;
        private SequenceActivity sequenceActivity1;
        private ThrowActivity throwActivity1;
        private CodeActivity codeCauseException;







































    }
}
