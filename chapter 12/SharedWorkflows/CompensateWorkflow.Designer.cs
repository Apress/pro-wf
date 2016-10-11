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
	partial class CompensateWorkflow
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
            this.compensateActivity1 = new System.Workflow.ComponentModel.CompensateActivity();
            this.codeHandleAppException = new System.Workflow.Activities.CodeActivity();
            this.codeMainLineCompensation = new System.Workflow.Activities.CodeActivity();
            this.faultHandlerAppException = new System.Workflow.ComponentModel.FaultHandlerActivity();
            this.compensationHandlerActivity1 = new System.Workflow.ComponentModel.CompensationHandlerActivity();
            this.codeMainLine = new System.Workflow.Activities.CodeActivity();
            this.faultHandlersActivity2 = new System.Workflow.ComponentModel.FaultHandlersActivity();
            this.throwActivity1 = new System.Workflow.ComponentModel.ThrowActivity();
            this.compensatableSequenceActivity1 = new System.Workflow.Activities.CompensatableSequenceActivity();
            this.sequenceMain = new System.Workflow.Activities.SequenceActivity();
            // 
            // compensateActivity1
            // 
            this.compensateActivity1.Name = "compensateActivity1";
            this.compensateActivity1.TargetActivityName = "sequenceMain";
            // 
            // codeHandleAppException
            // 
            this.codeHandleAppException.Name = "codeHandleAppException";
            this.codeHandleAppException.ExecuteCode += new System.EventHandler(this.codeHandleAppException_ExecuteCode);
            // 
            // codeMainLineCompensation
            // 
            this.codeMainLineCompensation.Name = "codeMainLineCompensation";
            this.codeMainLineCompensation.ExecuteCode += new System.EventHandler(this.codeMainLineCompensation_ExecuteCode);
            // 
            // faultHandlerAppException
            // 
            this.faultHandlerAppException.Activities.Add(this.codeHandleAppException);
            this.faultHandlerAppException.Activities.Add(this.compensateActivity1);
            this.faultHandlerAppException.FaultType = typeof(System.ApplicationException);
            this.faultHandlerAppException.Name = "faultHandlerAppException";
            // 
            // compensationHandlerActivity1
            // 
            this.compensationHandlerActivity1.Activities.Add(this.codeMainLineCompensation);
            this.compensationHandlerActivity1.Name = "compensationHandlerActivity1";
            // 
            // codeMainLine
            // 
            this.codeMainLine.Name = "codeMainLine";
            this.codeMainLine.ExecuteCode += new System.EventHandler(this.codeMainLine_ExecuteCode);
            // 
            // faultHandlersActivity2
            // 
            this.faultHandlersActivity2.Activities.Add(this.faultHandlerAppException);
            this.faultHandlersActivity2.Name = "faultHandlersActivity2";
            // 
            // throwActivity1
            // 
            this.throwActivity1.FaultType = typeof(System.ApplicationException);
            this.throwActivity1.Name = "throwActivity1";
            // 
            // compensatableSequenceActivity1
            // 
            this.compensatableSequenceActivity1.Activities.Add(this.codeMainLine);
            this.compensatableSequenceActivity1.Activities.Add(this.compensationHandlerActivity1);
            this.compensatableSequenceActivity1.Name = "compensatableSequenceActivity1";
            // 
            // sequenceMain
            // 
            this.sequenceMain.Activities.Add(this.compensatableSequenceActivity1);
            this.sequenceMain.Activities.Add(this.throwActivity1);
            this.sequenceMain.Activities.Add(this.faultHandlersActivity2);
            this.sequenceMain.Name = "sequenceMain";
            // 
            // CompensateWorkflow
            // 
            this.Activities.Add(this.sequenceMain);
            this.Name = "CompensateWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private CodeActivity codeMainLine;
        private CodeActivity codeMainLineCompensation;
        private CompensationHandlerActivity compensationHandlerActivity1;
        private ThrowActivity throwActivity1;
        private SequenceActivity sequenceMain;
        private FaultHandlerActivity faultHandlerAppException;
        private FaultHandlersActivity faultHandlersActivity2;
        private CompensateActivity compensateActivity1;
        private CodeActivity codeHandleAppException;
        private CompensatableSequenceActivity compensatableSequenceActivity1;






















    }
}
