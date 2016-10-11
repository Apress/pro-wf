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
using System.Threading;
using System.Collections.Generic;
using System.Workflow.Runtime;

namespace Bukovics.Workflow.Hosting
{
    /// <summary>
    /// A container for a workflow instance
    /// </summary>
    [Serializable]
    public class WorkflowInstanceWrapper
    {
        private WorkflowInstance _workflowInstance;
        private ManualResetEvent _waitHandle = new ManualResetEvent(false);

        private Dictionary<String, Object> _outputParameters
            = new Dictionary<string, object>();
        private Exception _exception;
        private String _reasonSuspended = String.Empty;

        public WorkflowInstanceWrapper(WorkflowInstance instance)
        {
            _workflowInstance = instance;
        }

        #region Public Properties and Methods

        /// <summary>
        /// Get the workflow instance Id
        /// </summary>
        public Guid Id
        {
            get
            {
                if (_workflowInstance != null)
                {
                    return _workflowInstance.InstanceId;
                }
                else
                {
                    return Guid.Empty;
                }
            }
        }

        /// <summary>
        /// A collection of output parameters
        /// </summary>
        public Dictionary<String, Object> OutputParameters
        {
            get { return _outputParameters; }
            set { _outputParameters = value; }
        }

        /// <summary>
        /// A wait handle that the host application can use
        /// if it wants to halt processing until the 
        /// workflow has completed.
        /// </summary>
        public ManualResetEvent WaitHandle
        {
            get { return _waitHandle; }
            set { _waitHandle = value; }
        }

        /// <summary>
        /// An Exception object if one was thrown from the workflow
        /// </summary>
        public Exception Exception
        {
            get { return _exception; }
            set { _exception = value; }
        }

        /// <summary>
        /// A string that identifies the ReasonSuspended a workflow was
        /// suspended
        /// </summary>
        public String ReasonSuspended
        {
            get { return _reasonSuspended; }
            set { _reasonSuspended = value; }
        }

        /// <summary>
        /// The real workflow instance
        /// </summary>
        public WorkflowInstance WorkflowInstance
        {
            get { return _workflowInstance; }
        }

        /// <summary>
        /// Signal that the workflow has finished and the host
        /// application can stop waiting
        /// </summary>
        public void StopWaiting()
        {
            _waitHandle.Set();
        }

        #endregion
    }
}
