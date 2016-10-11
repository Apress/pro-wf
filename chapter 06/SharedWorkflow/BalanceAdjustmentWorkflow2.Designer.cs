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
	partial class BalanceAdjustmentWorkflow2
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
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            this.adjustAccountActivity1 = new SharedWorkflows.AdjustAccountActivity();
            // 
            // adjustAccountActivity1
            // 
            activitybind1.Name = "BalanceAdjustmentWorkflow2";
            activitybind1.Path = "Account";
            activitybind2.Name = "BalanceAdjustmentWorkflow2";
            activitybind2.Path = "Adjustment";
            activitybind3.Name = "BalanceAdjustmentWorkflow2";
            activitybind3.Path = "Id";
            this.adjustAccountActivity1.Name = "adjustAccountActivity1";
            this.adjustAccountActivity1.SetBinding(SharedWorkflows.AdjustAccountActivity.AdjustmentProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.adjustAccountActivity1.SetBinding(SharedWorkflows.AdjustAccountActivity.IdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            this.adjustAccountActivity1.SetBinding(SharedWorkflows.AdjustAccountActivity.AccountProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // 
            // BalanceAdjustmentWorkflow2
            // 
            this.Activities.Add(this.adjustAccountActivity1);
            this.Name = "BalanceAdjustmentWorkflow2";
            this.CanModifyActivities = false;

		}

		#endregion

        private AdjustAccountActivity adjustAccountActivity1;










    }
}
