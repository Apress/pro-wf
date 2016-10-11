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
    /// A workflow that demonstrates the behavior of 
    /// persistence services
    /// </summary>
    public sealed partial class PersistenceDemoWorkflow :
        SequentialWorkflowActivity
    {
        private Boolean _isComplete = false;

        public Boolean IsComplete
        {
            get { return _isComplete; }
            set { _isComplete = value; }
        }

        public PersistenceDemoWorkflow()
        {
            InitializeComponent();
        }

        private void handleStopReceived_Invoked(
            object sender, ExternalDataEventArgs e)
        {
            //tell the WhileActivity to stop
            _isComplete = true;
        }
    }
}
