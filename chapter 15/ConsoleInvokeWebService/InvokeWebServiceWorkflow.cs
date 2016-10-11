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

namespace ConsoleInvokeWebService
{
    /// <summary>
    /// Invoke a web service from a workflow
    /// </summary>
    public sealed partial class InvokeWebServiceWorkflow
        : SequentialWorkflowActivity
    {
        public Double dividend = 100;
        public Double divisor = 4;
        public Double quotient;

        public InvokeWebServiceWorkflow()
        {
            InitializeComponent();
        }

        private void invokeWebServiceActivity1_Invoking(
            object sender, InvokeWebServiceEventArgs e)
        {
            Console.WriteLine(
                "Invoking web service dividend={0}, divisor={1}",
                    dividend, divisor);
        }

        private void invokeWebServiceActivity1_Invoked(
            object sender, InvokeWebServiceEventArgs e)
        {
            Console.WriteLine("Invoked web service result={0}",
                quotient);
        }
    }
}
