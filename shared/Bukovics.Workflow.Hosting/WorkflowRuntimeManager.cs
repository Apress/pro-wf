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
using System.Xml; //added for markup support
using System.Collections.Generic;
using System.Threading;
using System.Workflow.Runtime;

namespace Bukovics.Workflow.Hosting
{
    /// <summary>
    /// A wrapper class to manage workflow creation
    /// and workflow runtime engine events
    /// </summary>
    public class WorkflowRuntimeManager : IDisposable
    {
        private WorkflowRuntime _workflowRuntime;
        private Dictionary<Guid, WorkflowInstanceWrapper> _workflows
            = new Dictionary<Guid, WorkflowInstanceWrapper>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="instance"></param>
        public WorkflowRuntimeManager(WorkflowRuntime instance)
        {
            _workflowRuntime = instance;
            if (instance == null)
            {
                throw new NullReferenceException(
                    "A non-null WorkflowRuntime instance is required");
            }

            //subscribe to all workflow runtime events
            SubscribeToEvents(instance);
        }

        /// <summary>
        /// Create and start a workflow
        /// </summary>
        /// <param name="workflowType"></param>
        /// <param name="parameters"></param>
        /// <returns>A wrapped workflow instance</returns>
        public WorkflowInstanceWrapper StartWorkflow(Type workflowType,
            Dictionary<String, Object> parameters)
        {
            WorkflowInstance instance = _workflowRuntime.CreateWorkflow(
                workflowType, parameters);
            WorkflowInstanceWrapper wrapper
                = AddWorkflowInstance(instance);
            instance.Start();
            return wrapper;
        }

        /// <summary>
        /// Create and start a workflow using markup (xoml)
        /// </summary>
        /// <param name="markupFileName"></param>
        /// <param name="rulesMarkupFileName"></param>
        /// <param name="parameters"></param>
        /// <returns>A wrapped workflow instance</returns>
        public WorkflowInstanceWrapper StartWorkflow(String markupFileName,
            String rulesMarkupFileName,
            Dictionary<String, Object> parameters)
        {
            WorkflowInstance instance = null;
            WorkflowInstanceWrapper wrapper = null;
            XmlReader wfReader = null;
            XmlReader rulesReader = null;
            try
            {
                wfReader = XmlReader.Create(markupFileName);
                if (!String.IsNullOrEmpty(rulesMarkupFileName))
                {
                    rulesReader = XmlReader.Create(rulesMarkupFileName);
                    //create the workflow with workflow and rules
                    instance = _workflowRuntime.CreateWorkflow(
                        wfReader, rulesReader, parameters);
                }
                else
                {
                    //create the workflow with workflow markup only
                    instance = _workflowRuntime.CreateWorkflow(
                        wfReader, null, parameters);
                }

                wrapper = AddWorkflowInstance(instance);
                instance.Start();
            }
            finally
            {
                if (wfReader != null)
                {
                    wfReader.Close();
                }
                if (rulesReader != null)
                {
                    rulesReader.Close();
                }
            }
            return wrapper;
        }

        #region Public properties and Events

        /// <summary>
        /// Get the WorkflowRuntime instance
        /// </summary>
        public WorkflowRuntime WorkflowRuntime
        {
            get { return _workflowRuntime; }
        }

        /// <summary>
        /// Get a Dictionary of workflow instance wrappers
        /// </summary>
        public Dictionary<Guid, WorkflowInstanceWrapper> Workflows
        {
            get { return _workflows; }
        }

        /// <summary>
        /// Event for logging messages from this class
        /// </summary>
        public event EventHandler<WorkflowLogEventArgs> MessageEvent;

        #endregion

        #region Workflow collection management

        /// <summary>
        /// Remove a single instance from the workflow Dictionary
        /// </summary>
        /// <param name="workflowId"></param>
        public void ClearWorkflow(Guid workflowId)
        {
            if (_workflows.ContainsKey(workflowId))
            {
                _workflows.Remove(workflowId);
            }
        }

        /// <summary>
        /// Clear all workflows from the Dictionary
        /// </summary>
        public void ClearAllWorkflows()
        {
            _workflows.Clear();
        }

        /// <summary>
        /// Add a new workflow instance to the Dictionary
        /// </summary>
        /// <param name="instance"></param>
        /// <returns>A wrapped workflow instance</returns>
        private WorkflowInstanceWrapper AddWorkflowInstance(
            WorkflowInstance instance)
        {
            WorkflowInstanceWrapper wrapper = null;
            if (!_workflows.ContainsKey(instance.InstanceId))
            {
                wrapper = new WorkflowInstanceWrapper(instance);
                _workflows.Add(wrapper.Id, wrapper);
            }
            return wrapper;
        }

        /// <summary>
        /// Find a workflow instance by Id
        /// </summary>
        /// <param name="workflowId"></param>
        /// <returns></returns>
        public WorkflowInstanceWrapper FindWorkflowInstance(Guid workflowId)
        {
            WorkflowInstanceWrapper result = null;
            if (_workflows.ContainsKey(workflowId))
            {
                result = _workflows[workflowId];
            }
            return result;
        }

        /// <summary>
        /// Wait for all workflow instances to complete
        /// </summary>
        /// <param name="msecondsTimeout"></param>
        public void WaitAll(Int32 msecondsTimeout)
        {
            if (_workflows.Count > 0)
            {
                WaitHandle[] handles = new WaitHandle[_workflows.Count];
                Int32 index = 0;
                foreach (WorkflowInstanceWrapper wrapper
                    in _workflows.Values)
                {
                    handles[index] = wrapper.WaitHandle;
                    index++;
                }
                WaitHandle.WaitAll(handles, msecondsTimeout, false);
            }
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Cleanup the workflow runtime
        /// </summary>
        public void Dispose()
        {
            if (_workflowRuntime != null)
            {
                _workflowRuntime.StopRuntime();
                _workflowRuntime.Dispose();
            }
            ClearAllWorkflows();
        }

        #endregion

        #region Workflow Event Handling

        /// <summary>
        /// Subscribe to all events that we care about
        /// </summary>
        /// <param name="runtime"></param>
        private void SubscribeToEvents(WorkflowRuntime runtime)
        {
            runtime.Started
                += new EventHandler<WorkflowRuntimeEventArgs>(
                    runtime_Started);
            runtime.Stopped
                += new EventHandler<WorkflowRuntimeEventArgs>(
                    runtime_Stopped);
            runtime.WorkflowAborted
                += new EventHandler<WorkflowEventArgs>(
                    runtime_WorkflowAborted);
            runtime.WorkflowCompleted
                += new EventHandler<WorkflowCompletedEventArgs>(
                    runtime_WorkflowCompleted);
            runtime.WorkflowCreated
                += new EventHandler<WorkflowEventArgs>(
                    runtime_WorkflowCreated);
            runtime.WorkflowIdled
                += new EventHandler<WorkflowEventArgs>(
                    runtime_WorkflowIdled);
            runtime.WorkflowLoaded
                += new EventHandler<WorkflowEventArgs>(
                    runtime_WorkflowLoaded);
            runtime.WorkflowPersisted
                += new EventHandler<WorkflowEventArgs>(
                    runtime_WorkflowPersisted);
            runtime.WorkflowResumed
                += new EventHandler<WorkflowEventArgs>(
                    runtime_WorkflowResumed);
            runtime.WorkflowStarted
                += new EventHandler<WorkflowEventArgs>(
                    runtime_WorkflowStarted);
            runtime.WorkflowSuspended
                += new EventHandler<WorkflowSuspendedEventArgs>(
                    runtime_WorkflowSuspended);
            runtime.WorkflowTerminated
                += new EventHandler<WorkflowTerminatedEventArgs>(
                    runtime_WorkflowTerminated);
            runtime.WorkflowUnloaded
                += new EventHandler<WorkflowEventArgs>(
                    runtime_WorkflowUnloaded);
        }

        void runtime_Started(object sender, WorkflowRuntimeEventArgs e)
        {
            LogStatus(Guid.Empty, "Started");
        }

        void runtime_Stopped(object sender, WorkflowRuntimeEventArgs e)
        {
            LogStatus(Guid.Empty, "Stopped");
        }

        void runtime_WorkflowCreated(object sender, WorkflowEventArgs e)
        {
            LogStatus(e.WorkflowInstance.InstanceId, "WorkflowCreated");
        }

        void runtime_WorkflowStarted(object sender, WorkflowEventArgs e)
        {
            LogStatus(e.WorkflowInstance.InstanceId, "WorkflowStarted");
        }

        void runtime_WorkflowIdled(object sender, WorkflowEventArgs e)
        {
            LogStatus(e.WorkflowInstance.InstanceId, "WorkflowIdled");
        }

        void runtime_WorkflowCompleted(object sender, WorkflowCompletedEventArgs e)
        {
            LogStatus(e.WorkflowInstance.InstanceId, "WorkflowCompleted");
            WorkflowInstanceWrapper wrapper
                = FindWorkflowInstance(e.WorkflowInstance.InstanceId);
            if (wrapper != null)
            {
                wrapper.OutputParameters = e.OutputParameters;
                wrapper.StopWaiting();
            }
        }

        void runtime_WorkflowTerminated(object sender,
            WorkflowTerminatedEventArgs e)
        {
            LogStatus(e.WorkflowInstance.InstanceId, "WorkflowTerminated");
            WorkflowInstanceWrapper wrapper
                = FindWorkflowInstance(e.WorkflowInstance.InstanceId);
            if (wrapper != null)
            {
                wrapper.Exception = e.Exception;
                wrapper.StopWaiting();
            }
        }

        void runtime_WorkflowSuspended(object sender, WorkflowSuspendedEventArgs e)
        {
            LogStatus(e.WorkflowInstance.InstanceId, "WorkflowSuspended");
            WorkflowInstanceWrapper wrapper
                = FindWorkflowInstance(e.WorkflowInstance.InstanceId);
            if (wrapper != null)
            {
                wrapper.ReasonSuspended = e.Error;
            }
        }

        void runtime_WorkflowResumed(object sender, WorkflowEventArgs e)
        {
            LogStatus(e.WorkflowInstance.InstanceId, "WorkflowResumed");
        }

        void runtime_WorkflowPersisted(object sender, WorkflowEventArgs e)
        {
            LogStatus(e.WorkflowInstance.InstanceId, "WorkflowPersisted");
        }

        void runtime_WorkflowLoaded(object sender, WorkflowEventArgs e)
        {
            LogStatus(e.WorkflowInstance.InstanceId, "WorkflowLoaded");
        }

        void runtime_WorkflowAborted(object sender, WorkflowEventArgs e)
        {
            LogStatus(e.WorkflowInstance.InstanceId, "WorkflowAborted");
            WorkflowInstanceWrapper wrapper
                = FindWorkflowInstance(e.WorkflowInstance.InstanceId);
            if (wrapper != null)
            {
                wrapper.StopWaiting();
            }
        }

        void runtime_WorkflowUnloaded(object sender, WorkflowEventArgs e)
        {
            LogStatus(e.WorkflowInstance.InstanceId, "WorkflowUnloaded");
        }

        private void LogStatus(Guid instanceId, String msg)
        {
            if (MessageEvent != null)
            {
                String formattedMsg;
                if (instanceId == Guid.Empty)
                {
                    formattedMsg = String.Format("Runtime - {0}", msg);
                }
                else
                {
                    formattedMsg = String.Format("{0} - {1}", instanceId, msg);
                }

                //raise the event
                MessageEvent(this, new WorkflowLogEventArgs(formattedMsg));
            }
        }

        #endregion
    }

    /// <summary>
    /// An EventArgs for logging a message from 
    /// the WorkflowRuntimeManager
    /// </summary>
    public class WorkflowLogEventArgs : EventArgs
    {
        private String _msg = String.Empty;
        public WorkflowLogEventArgs(String msg)
        {
            _msg = msg;
        }

        public String Message
        {
            get { return _msg; }
        }
    }
}
