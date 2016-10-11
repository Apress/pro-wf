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
	partial class ExceptionHandledWorkflow
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
            this.codeHandleArithmetic = new System.Workflow.Activities.CodeActivity();
            this.faultHandlerArithmetic = new System.Workflow.ComponentModel.FaultHandlerActivity();
            this.faultHandlersActivity1 = new System.Workflow.ComponentModel.FaultHandlersActivity();
            this.codeOtherActivity = new System.Workflow.Activities.CodeActivity();
            this.codeCauseException = new System.Workflow.Activities.CodeActivity();
            // 
            // codeHandleArithmetic
            // 
            this.codeHandleArithmetic.Name = "codeHandleArithmetic";
            this.codeHandleArithmetic.ExecuteCode += new System.EventHandler(this.codeHandleArithmetic_ExecuteCode);
            // 
            // faultHandlerArithmetic
            // 
            this.faultHandlerArithmetic.Activities.Add(this.codeHandleArithmetic);
            this.faultHandlerArithmetic.FaultType = typeof(System.ArithmeticException);
            this.faultHandlerArithmetic.Name = "faultHandlerArithmetic";
            // 
            // faultHandlersActivity1
            // 
            this.faultHandlersActivity1.Activities.Add(this.faultHandlerArithmetic);
            this.faultHandlersActivity1.Name = "faultHandlersActivity1";
            // 
            // codeOtherActivity
            // 
            this.codeOtherActivity.Name = "codeOtherActivity";
            this.codeOtherActivity.ExecuteCode += new System.EventHandler(this.codeOtherActivity_ExecuteCode);
            // 
            // codeCauseException
            // 
            this.codeCauseException.Name = "codeCauseException";
            this.codeCauseException.ExecuteCode += new System.EventHandler(this.codeCauseException_ExecuteCode);
            // 
            // ExceptionHandledWorkflow
            // 
            this.Activities.Add(this.codeCauseException);
            this.Activities.Add(this.codeOtherActivity);
            this.Activities.Add(this.faultHandlersActivity1);
            this.Name = "ExceptionHandledWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private CodeActivity codeOtherActivity;
        private FaultHandlersActivity faultHandlersActivity1;
        private CodeActivity codeHandleArithmetic;
        private FaultHandlerActivity faultHandlerArithmetic;
        private CodeActivity codeCauseException;






















    }
}
