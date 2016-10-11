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
    /// Workflow that will be dynamically updated
    /// by the host application
    /// </summary>
    public sealed partial class DynamicRestrictedWorkflow
        : SequentialWorkflowActivity
    {
        private Int32 _testNumber;

        public Int32 TestNumber
        {
            get { return _testNumber; }
            set { _testNumber = value; }
        }

        public DynamicRestrictedWorkflow()
        {
            InitializeComponent();
        }

        private void codeFirstPart_ExecuteCode(
            object sender, EventArgs e)
        {
            Console.WriteLine(
                "Executing the First Part for TestNumber {0}", TestNumber);
        }

        private void codeLastPart_ExecuteCode(
            object sender, EventArgs e)
        {
            Console.WriteLine(
                "Executing the Last Part for TestNumber {0}", TestNumber);
        }

        /// <summary>
        /// Determine if dynamic updates are allowed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IsUpdateAllowed(object sender, ConditionalEventArgs e)
        {
            e.Result = (TestNumber != 3003);
        }
    }
}
