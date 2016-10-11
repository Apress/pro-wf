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

namespace CustomActivityComponents
{
	partial class Workflow1
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
            this.myCustomActivity1 = new CustomActivityComponents.MyCustomActivity();
            // 
            // myCustomActivity1
            // 
            this.myCustomActivity1.MyInt = 1001;
            this.myCustomActivity1.MyString = "set me";
            this.myCustomActivity1.Name = "myCustomActivity1";
            // 
            // Workflow1
            // 
            this.Activities.Add(this.myCustomActivity1);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

		}

		#endregion

        private MyCustomActivity myCustomActivity1;











    }
}
