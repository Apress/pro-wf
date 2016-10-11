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
	partial class BalanceAdjustmentWorkflow3
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
            this.callExternalMethodActivity1 = new System.Workflow.Activities.CallExternalMethodActivity();
            // 
            // callExternalMethodActivity1
            // 
            this.callExternalMethodActivity1.InterfaceType = typeof(SharedWorkflows.IAccountServices);
            this.callExternalMethodActivity1.MethodName = "AdjustBalance";
            this.callExternalMethodActivity1.Name = "callExternalMethodActivity1";
            activitybind1.Name = "BalanceAdjustmentWorkflow3";
            activitybind1.Path = "Account";
            workflowparameterbinding1.ParameterName = "(ReturnValue)";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            activitybind2.Name = "BalanceAdjustmentWorkflow3";
            activitybind2.Path = "Adjustment";
            workflowparameterbinding2.ParameterName = "adjustment";
            workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            activitybind3.Name = "BalanceAdjustmentWorkflow3";
            activitybind3.Path = "Id";
            workflowparameterbinding3.ParameterName = "id";
            workflowparameterbinding3.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            this.callExternalMethodActivity1.ParameterBindings.Add(workflowparameterbinding1);
            this.callExternalMethodActivity1.ParameterBindings.Add(workflowparameterbinding2);
            this.callExternalMethodActivity1.ParameterBindings.Add(workflowparameterbinding3);
            // 
            // BalanceAdjustmentWorkflow3
            // 
            this.Activities.Add(this.callExternalMethodActivity1);
            this.Name = "BalanceAdjustmentWorkflow3";
            this.CanModifyActivities = false;

		}

		#endregion

        private CallExternalMethodActivity callExternalMethodActivity1;















    }
}
