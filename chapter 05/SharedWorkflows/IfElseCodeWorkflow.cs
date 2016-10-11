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
    public sealed partial class IfElseCodeWorkflow : SequentialWorkflowActivity
    {
        public static DependencyProperty TestNumberProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
                "TestNumber", typeof(Int32), typeof(IfElseCodeWorkflow));

        [Description("A number to test")]
        [Category("Flow Control")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 TestNumber
        {
            get
            {
                return ((Int32)(base.GetValue(
                    IfElseCodeWorkflow.TestNumberProperty)));
            }
            set
            {
                base.SetValue(IfElseCodeWorkflow.TestNumberProperty, value);
            }
        }

        public IfElseCodeWorkflow()
        {
            InitializeComponent();
        }

        private void CheckForNegative(object sender, ConditionalEventArgs e)
        {
            e.Result = (TestNumber < 0);
        }

        private void CheckForPositive(object sender, ConditionalEventArgs e)
        {
            e.Result = (TestNumber > 0);
        }

        private void codeActivityIsNegative_ExecuteCode(
            object sender, EventArgs e)
        {
            Console.WriteLine("TestNumber {0} is negative", TestNumber);
        }

        private void codeActivityIsPositive_ExecuteCode(
            object sender, EventArgs e)
        {
            Console.WriteLine("TestNumber {0} is positive", TestNumber);
        }

        private void codeActivityIsZero_ExecuteCode(
            object sender, EventArgs e)
        {
            Console.WriteLine("TestNumber {0} is zero", TestNumber);
        }
    }
}
