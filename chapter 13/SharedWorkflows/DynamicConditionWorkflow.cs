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
using System.Workflow.Activities;

namespace SharedWorkflows
{
    /// <summary>
    /// Workflow with Rule Conditions that 
    /// are updated externally
    /// </summary>
    public sealed partial class DynamicConditionWorkflow
        : SequentialWorkflowActivity
    {
        private Int32 _testNumber;

        public Int32 TestNumber
        {
            get { return _testNumber; }
            set { _testNumber = value; }
        }

        public DynamicConditionWorkflow()
        {
            InitializeComponent();
        }

        private void codeActivity1_ExecuteCode(
            object sender, EventArgs e)
        {
            Console.WriteLine("Condition One is true");
        }

        private void codeActivity2_ExecuteCode(
            object sender, EventArgs e)
        {
            Console.WriteLine("Condition Two is true");
        }

        private void codeActivity3_ExecuteCode(
            object sender, EventArgs e)
        {
            Console.WriteLine("Neither condition is true");
        }
    }
}
