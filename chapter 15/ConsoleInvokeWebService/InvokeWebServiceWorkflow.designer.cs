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

namespace ConsoleInvokeWebService
{
	partial class InvokeWebServiceWorkflow
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
            this.invokeWebServiceActivity1 = new System.Workflow.Activities.InvokeWebServiceActivity();
            // 
            // invokeWebServiceActivity1
            // 
            this.invokeWebServiceActivity1.MethodName = "DivideNumbers";
            this.invokeWebServiceActivity1.Name = "invokeWebServiceActivity1";
            activitybind1.Name = "InvokeWebServiceWorkflow";
            activitybind1.Path = "quotient";
            workflowparameterbinding1.ParameterName = "(ReturnValue)";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            activitybind2.Name = "InvokeWebServiceWorkflow";
            activitybind2.Path = "dividend";
            workflowparameterbinding2.ParameterName = "dividend";
            workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            activitybind3.Name = "InvokeWebServiceWorkflow";
            activitybind3.Path = "divisor";
            workflowparameterbinding3.ParameterName = "divisor";
            workflowparameterbinding3.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            this.invokeWebServiceActivity1.ParameterBindings.Add(workflowparameterbinding1);
            this.invokeWebServiceActivity1.ParameterBindings.Add(workflowparameterbinding2);
            this.invokeWebServiceActivity1.ParameterBindings.Add(workflowparameterbinding3);
            this.invokeWebServiceActivity1.ProxyClass = typeof(ConsoleInvokeWebService.localhost.MathServiceWorkflow_WebService);
            this.invokeWebServiceActivity1.Invoking += new System.EventHandler<System.Workflow.Activities.InvokeWebServiceEventArgs>(this.invokeWebServiceActivity1_Invoking);
            this.invokeWebServiceActivity1.Invoked += new System.EventHandler<System.Workflow.Activities.InvokeWebServiceEventArgs>(this.invokeWebServiceActivity1_Invoked);
            // 
            // InvokeWebServiceWorkflow
            // 
            this.Activities.Add(this.invokeWebServiceActivity1);
            this.Name = "InvokeWebServiceWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private InvokeWebServiceActivity invokeWebServiceActivity1;







    }
}
