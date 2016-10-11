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
using System.Workflow.ComponentModel;
using System.Workflow.Activities;

namespace SharedWorkflows
{
    public sealed partial class ParallelDelayWorkflow : SequentialWorkflowActivity
    {
        public static DependencyProperty TestNumberProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
                "TestNumber", typeof(Int32), typeof(ParallelDelayWorkflow));

        [Description("A number to test")]
        [Category("Flow Control")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 TestNumber
        {
            get
            {
                return ((Int32)(base.GetValue(
                    ParallelDelayWorkflow.TestNumberProperty)));
            }
            set
            {
                base.SetValue(ParallelDelayWorkflow.TestNumberProperty, value);
            }
        }

        public ParallelDelayWorkflow()
        {
            InitializeComponent();
        }

        private void commonCode_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine(((Activity)sender).Name);
        }

        private void codeSequence1Number2_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine(((Activity)sender).Name);
            TestNumber--;
        }
    }
}
