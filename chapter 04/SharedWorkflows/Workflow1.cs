//--------------------------------------------------------------------------------
// This file is part of the downloadable code for the Apress book:
// Pro WF: Windows Workflow in .NET 3.0
// Copyright (c) Bruce Bukovics.  All rights reserved.
//
// This code is provided as is without warranty of any kind, either expressed
// or implied, including but not limited to fitness for any particular purpose. 
// You may use the code for any commercial or noncommercial purpose, and combine 
// it with your own code, but cannot reproduce it in whole or in part for 
// publication purposes without prior approval. 
//--------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace SharedWorkflows
{
    public sealed partial class Workflow1 : SequentialWorkflowActivity
    {
        #region Public Dependency Properties

        public static DependencyProperty InputStringProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
                "InputString", typeof(string), typeof(Workflow1));

        [Description("The workflow input string parameter")]
        [Category("Hosting the workflow runtime")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string InputString
        {
            get
            {
                return ((string)(base.GetValue(Workflow1.InputStringProperty)));
            }
            set
            {
                base.SetValue(Workflow1.InputStringProperty, value);
            }
        }

        public static DependencyProperty ResultProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
                "Result", typeof(string), typeof(Workflow1));

        [Description("The workflow result")]
        [Category("Hosting the workflow runtime")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Result
        {
            get
            {
                return ((string)(base.GetValue(Workflow1.ResultProperty)));
            }
            set
            {
                base.SetValue(Workflow1.ResultProperty, value);
            }
        }

        #endregion

        public Workflow1()
        {
            InitializeComponent();
        }

        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
            //provide some indication that the workflow executed
            Console.WriteLine("{0} executing, parameter={1}",
                this.WorkflowInstanceId, InputString);
            //return the InstanceId in the workflow parameter
            Result = String.Format("{0} result property",
                this.WorkflowInstanceId);
        }
    }
}
