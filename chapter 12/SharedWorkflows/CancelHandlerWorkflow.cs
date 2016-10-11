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
    /// Use a CancellationHandler
    /// </summary>
    public sealed partial class CancelHandlerWorkflow
        : SequentialWorkflowActivity
    {
        public CancelHandlerWorkflow()
        {
            InitializeComponent();
        }

        private void codeLeftBranch_ExecuteCode(
            object sender, EventArgs e)
        {
            Console.WriteLine("Executing left branch CodeActivity");
        }

        private void codeRightBranch_ExecuteCode(
            object sender, EventArgs e)
        {
            Console.WriteLine("Executing right branch CodeActivity");
        }

        private void codeCancelHandler_ExecuteCode(
            object sender, EventArgs e)
        {
            Console.WriteLine(
                "Executing CancellationHandler CodeActivity");
        }

        private void RunForever(object sender, ConditionalEventArgs e)
        {
            e.Result = true;
        }
    }
}
