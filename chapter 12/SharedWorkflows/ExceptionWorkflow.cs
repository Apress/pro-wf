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
    /// Throw an exception and observe how it is handled
    /// </summary>
    public sealed partial class ExceptionWorkflow
        : SequentialWorkflowActivity
    {
        private Int32 _testNumber;

        public Int32 TestNumber
        {
            get { return _testNumber; }
            set { _testNumber = value; }
        }

        public ExceptionWorkflow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Throw an exception
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void codeCauseException_ExecuteCode(
            object sender, EventArgs e)
        {
            switch (TestNumber)
            {
                case 1:
                    throw new DivideByZeroException("Error 1");
                case 2:
                    throw new ArithmeticException("Error 2");
                default:
                    break;
            }
        }

        /// <summary>
        /// Write a message to the Console
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void codeOtherActivity_ExecuteCode(
            object sender, EventArgs e)
        {
            Console.WriteLine("Executing the other CodeActivity");
        }
    }
}
