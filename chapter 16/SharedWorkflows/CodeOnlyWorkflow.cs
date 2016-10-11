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
    /// A code only workflow
    /// </summary>
    public sealed partial class CodeOnlyWorkflow
        : SequentialWorkflowActivity
    {
        private Int32 _theNumber;

        public Int32 TheNumber
        {
            get { return _theNumber; }
            set { _theNumber = value; }
        }

        public CodeOnlyWorkflow()
        {
            InitializeComponent();
        }

        private void IsNumberPositive(
            object sender, ConditionalEventArgs e)
        {
            e.Result = (TheNumber > 0);
        }

        private void codeNumberIsPositive_ExecuteCode(
            object sender, EventArgs e)
        {
            Console.WriteLine("The number is positive");

        }

        private void codeNumberNotPositive_ExecuteCode(
            object sender, EventArgs e)
        {
            Console.WriteLine("The number is NOT positive");
        }
    }
}
