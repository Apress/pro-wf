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
using System.Workflow.Runtime;

namespace SharedWorkflows
{
    /// <summary>
    /// Local service used with the
    /// EventHandlingScopeActivity example.
    /// </summary>
    public class ScopeExampleService : IScopeExample
    {
        private Guid _instanceId;

        #region IScopeExample Members

        public void Started()
        {
            //save the workflow instance Id
            _instanceId = WorkflowEnvironment.WorkflowInstanceId;
        }

        public event EventHandler<ExternalDataEventArgs> EventOne;

        public event EventHandler<ExternalDataEventArgs> EventTwo;

        public event EventHandler<ExternalDataEventArgs> EventStop;

        #endregion

        #region Methods to raise events from the host

        public void OnEventOne()
        {
            if (EventOne != null)
            {
                EventOne(null, new ExternalDataEventArgs(_instanceId));
            }
        }

        public void OnEventTwo()
        {
            if (EventTwo != null)
            {
                EventTwo(null, new ExternalDataEventArgs(_instanceId));
            }
        }

        public void OnEventStop()
        {
            if (EventStop != null)
            {
                EventStop(null, new ExternalDataEventArgs(_instanceId));
            }
        }

        #endregion
    }
}
