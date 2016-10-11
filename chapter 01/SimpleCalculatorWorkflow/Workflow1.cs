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

namespace SimpleCalculatorWorkflow
{
    public sealed partial class Workflow1 : SequentialWorkflowActivity
    {
        private String _operation = String.Empty;
        private Int32 _number1;
        private Int32 _number2;
        private Double _result;

        public String Operation
        {
            get { return _operation; }
            set { _operation = value; }
        }

        public Int32 Number1
        {
            get { return _number1; }
            set { _number1 = value; }
        }

        public Int32 Number2
        {
            get { return _number2; }
            set { _number2 = value; }
        }

        public Double Result
        {
            get { return _result; }
            set { _result = value; }
        }

        public Workflow1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Add the numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddOperation(object sender, EventArgs e)
        {
            _result = _number1 + _number2;
        }

        /// <summary>
        /// Subtract the numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubtractOperation(object sender, EventArgs e)
        {
            _result = _number1 - _number2;
        }

        /// <summary>
        /// Multiply the numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MultiplyOperation(object sender, EventArgs e)
        {
            _result = _number1 * _number2;
        }

        /// <summary>
        /// Divide the numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DivideOperation(object sender, EventArgs e)
        {
            if (_number2 != 0)
            {
                _result = (Double)_number1 / (Double)_number2;
            }
            else
            {
                _result = 0;
            }
        }

        /// <summary>
        /// Handle invalid operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UnknownOperation(object sender, EventArgs e)
        {
            throw new ArgumentException(String.Format(
                "Invalid operation of {0} requested", Operation));
        }
    }

}
