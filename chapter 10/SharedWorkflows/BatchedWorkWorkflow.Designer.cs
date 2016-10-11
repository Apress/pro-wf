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
	partial class BatchedWorkWorkflow
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
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding1 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding2 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding3 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            this.callExternalMethodActivity3 = new System.Workflow.Activities.CallExternalMethodActivity();
            this.callExternalMethodActivity2 = new System.Workflow.Activities.CallExternalMethodActivity();
            this.callExternalMethodActivity1 = new System.Workflow.Activities.CallExternalMethodActivity();
            this.transactionScopeActivity1 = new System.Workflow.ComponentModel.TransactionScopeActivity();
            // 
            // callExternalMethodActivity3
            // 
            this.callExternalMethodActivity3.InterfaceType = typeof(SharedWorkflows.IBatchedServices);
            this.callExternalMethodActivity3.MethodName = "DoSomeWork";
            this.callExternalMethodActivity3.Name = "callExternalMethodActivity3";
            workflowparameterbinding1.ParameterName = "message";
            workflowparameterbinding1.Value = "work item three";
            this.callExternalMethodActivity3.ParameterBindings.Add(workflowparameterbinding1);
            // 
            // callExternalMethodActivity2
            // 
            this.callExternalMethodActivity2.InterfaceType = typeof(SharedWorkflows.IBatchedServices);
            this.callExternalMethodActivity2.MethodName = "DoSomeWork";
            this.callExternalMethodActivity2.Name = "callExternalMethodActivity2";
            workflowparameterbinding2.ParameterName = "message";
            workflowparameterbinding2.Value = "work item two";
            this.callExternalMethodActivity2.ParameterBindings.Add(workflowparameterbinding2);
            // 
            // callExternalMethodActivity1
            // 
            this.callExternalMethodActivity1.InterfaceType = typeof(SharedWorkflows.IBatchedServices);
            this.callExternalMethodActivity1.MethodName = "DoSomeWork";
            this.callExternalMethodActivity1.Name = "callExternalMethodActivity1";
            workflowparameterbinding3.ParameterName = "message";
            workflowparameterbinding3.Value = "work item one";
            this.callExternalMethodActivity1.ParameterBindings.Add(workflowparameterbinding3);
            // 
            // transactionScopeActivity1
            // 
            this.transactionScopeActivity1.Activities.Add(this.callExternalMethodActivity1);
            this.transactionScopeActivity1.Activities.Add(this.callExternalMethodActivity2);
            this.transactionScopeActivity1.Activities.Add(this.callExternalMethodActivity3);
            this.transactionScopeActivity1.Name = "transactionScopeActivity1";
            this.transactionScopeActivity1.TransactionOptions.IsolationLevel = System.Transactions.IsolationLevel.Serializable;
            // 
            // BatchedWorkWorkflow
            // 
            this.Activities.Add(this.transactionScopeActivity1);
            this.Name = "BatchedWorkWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private CallExternalMethodActivity callExternalMethodActivity2;
        private CallExternalMethodActivity callExternalMethodActivity1;
        private CallExternalMethodActivity callExternalMethodActivity3;
        private TransactionScopeActivity transactionScopeActivity1;






    }
}
