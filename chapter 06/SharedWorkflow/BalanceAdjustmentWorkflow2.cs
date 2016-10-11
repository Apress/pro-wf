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
    public sealed partial class BalanceAdjustmentWorkflow2
        : SequentialWorkflowActivity
    {
        private Int32 _id;
        private Double _adjustment;
        private Account _account;

        public Int32 Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public Double Adjustment
        {
            get { return _adjustment; }
            set { _adjustment = value; }
        }

        public Account Account
        {
            get { return _account; }
            set { _account = value; }
        }

        public BalanceAdjustmentWorkflow2()
        {
            InitializeComponent();
        }
    }
}
