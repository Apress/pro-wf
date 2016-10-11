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
using System.Workflow.ComponentModel;
using System.Workflow.Activities;

namespace SharedWorkflows
{
    /// <summary>
    /// Throw an exception and observe how it is handled
    /// </summary>
    public sealed partial class ExceptionRethrowWorkflow
        : SequentialWorkflowActivity
    {
        private Int32 _testNumber;

        public Int32 TestNumber
        {
            get { return _testNumber; }
            set { _testNumber = value; }
        }

        public ExceptionRethrowWorkflow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Cause an exception to be thrown
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

        private void codeOtherActivity_ExecuteCode(
            object sender, EventArgs e)
        {
            Console.WriteLine("Executing the other CodeActivity");
        }

        /// <summary>
        /// Handle an ArithmeticException
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void codeHandleArithmetic_ExecuteCode(
            object sender, EventArgs e)
        {
            //get the parent fault handler activity in order
            //to retrieve the Exception message
            FaultHandlerActivity faultActivity
                = ((Activity)sender).Parent as FaultHandlerActivity;
            String message = String.Empty;
            if (faultActivity != null)
            {
                message = faultActivity.Fault.Message;
            }
            Console.WriteLine("Handle ArithmeticException: {0}",
                message);
        }

        /// <summary>
        /// Handle a DivideByZeroException
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void codeHandleDivide_ExecuteCode(object sender, EventArgs e)
        {
            FaultHandlerActivity faultActivity
                = ((Activity)sender).Parent as FaultHandlerActivity;
            String message = String.Empty;
            if (faultActivity != null)
            {
                message = faultActivity.Fault.Message;
            }
            Console.WriteLine("Handle DivideByZeroException: {0}",
                message);
        }
    }
}
