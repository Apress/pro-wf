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
    /// Workflow that does division
    /// </summary>
    public sealed partial class DivideNumbersWorkflow
        : SequentialWorkflowActivity
    {
        private Double dividend;
        private Double divisor;
        private Double quotient;

        public Double Dividend
        {
            get { return dividend; }
            set { dividend = value; }
        }

        public Double Divisor
        {
            get { return divisor; }
            set { divisor = value; }
        }

        public Double Quotient
        {
            get { return quotient; }
            set { quotient = value; }
        }

        public DivideNumbersWorkflow()
        {
            InitializeComponent();
        }

        private void codeDoDivision_ExecuteCode(
            object sender, EventArgs e)
        {
            //do the division
            quotient = dividend / divisor;
        }
    }
}
