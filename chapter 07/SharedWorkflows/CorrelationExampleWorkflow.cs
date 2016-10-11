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
    /// Workflow that demonstrates correlation
    /// </summary>
    public sealed partial class CorrelationExampleWorkflow :
        SequentialWorkflowActivity
    {
        public CorrelationExampleWorkflow()
        {
            InitializeComponent();
        }

        private void handleExternalEventActivity1_Invoked(
            object sender, ExternalDataEventArgs e)
        {
            if (e is CorrelationExampleEventArgs)
            {
                Console.WriteLine("Received data for branch 1: {0}",
                    ((CorrelationExampleEventArgs)e).EventData);
            }
        }

        private void handleExternalEventActivity2_Invoked(
            object sender, ExternalDataEventArgs e)
        {
            if (e is CorrelationExampleEventArgs)
            {
                Console.WriteLine("Received data for branch 2: {0}",
                    ((CorrelationExampleEventArgs)e).EventData);
            }
        }
    }
}
