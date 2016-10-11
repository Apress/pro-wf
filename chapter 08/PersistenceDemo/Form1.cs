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
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;

using System.Workflow.Activities;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;

using Bukovics.Workflow.Hosting;
using SharedWorkflows;

namespace PersistenceDemo
{
    /// <summary>
    /// The persistence demo application
    /// </summary>
    public partial class Form1 : Form
    {
        private WorkflowRuntimeManager _workflowManager;
        private WorkflowPersistenceService _persistence;
        private PersistenceDemoService _persistenceDemoService;
        private Dictionary<Guid, Workflow> _workflows
            = new Dictionary<Guid, Workflow>();
        private Workflow _selectedWorkflow;

        public Form1()
        {
            InitializeComponent();
        }

        #region Initialization and shutdown

        /// <summary>
        /// Initialize the workflow runtime during startup
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //create workflow runtime and manager
            _workflowManager = new WorkflowRuntimeManager(
                new WorkflowRuntime());

            //add services to the workflow runtime
            AddServices(_workflowManager.WorkflowRuntime);

            _workflowManager.WorkflowRuntime.WorkflowCreated
                += new EventHandler<WorkflowEventArgs>(
                    WorkflowRuntime_WorkflowCreated);
            _workflowManager.WorkflowRuntime.WorkflowCompleted
                += new EventHandler<WorkflowCompletedEventArgs>(
                    WorkflowRuntime_WorkflowCompleted);
            _workflowManager.WorkflowRuntime.WorkflowPersisted
                += new EventHandler<WorkflowEventArgs>(
                    WorkflowRuntime_WorkflowPersisted);
            _workflowManager.WorkflowRuntime.WorkflowUnloaded
                += new EventHandler<WorkflowEventArgs>(
                    WorkflowRuntime_WorkflowUnloaded);
            _workflowManager.WorkflowRuntime.WorkflowLoaded
                += new EventHandler<WorkflowEventArgs>(
                    WorkflowRuntime_WorkflowLoaded);
            _workflowManager.WorkflowRuntime.WorkflowIdled
                += new EventHandler<WorkflowEventArgs>(
                    WorkflowRuntime_WorkflowIdled);

            //initially disable these buttons until a workflow
            //is selected in the data grid view
            btnContinue.Enabled = false;
            btnStop.Enabled = false;

            //start the runtime prior to checking for any
            //existing workflows that have been persisted
            _workflowManager.WorkflowRuntime.StartRuntime();

            //load information about any workflows that
            //have been persisted
            RetrieveExistingWorkflows();
        }

        /// <summary>
        /// Add any services needed by the runtime engine
        /// </summary>
        /// <param name="instance"></param>
        private void AddServices(WorkflowRuntime instance)
        {
#if CUSTOM_PERSISTENCE
            //use the custom file based persistence service
            _persistence = new FileWorkflowPersistenceService();
            instance.AddService(_persistence);
#else
            //use the standard SQL Server persistence service
            String connStringPersistence = String.Format(
                "Initial Catalog={0};Data Source={1};Integrated Security={2};",
                "WorkflowPersistence", @"localhost\SQLEXPRESS", "SSPI");
            _persistence =
                new SqlWorkflowPersistenceService(connStringPersistence, true,
                    new TimeSpan(0, 2, 0), new TimeSpan(0, 0, 5));
            instance.AddService(_persistence);
#endif
            //add the external data exchange service to the runtime
            ExternalDataExchangeService exchangeService
                = new ExternalDataExchangeService();
            instance.AddService(exchangeService);

            //add our local service 
            _persistenceDemoService = new PersistenceDemoService();
            exchangeService.AddService(_persistenceDemoService);
        }

        /// <summary>
        /// Perform cleanup during application shutdown 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            //cleanup the workflow runtime
            if (_workflowManager != null)
            {
                _workflowManager.Dispose();
            }
        }

        #endregion

        #region Workflow event handling

        void WorkflowRuntime_WorkflowCreated(object sender,
            WorkflowEventArgs e)
        {
            UpdateDisplay(e.WorkflowInstance.InstanceId, "Created");
        }

        void WorkflowRuntime_WorkflowIdled(object sender,
            WorkflowEventArgs e)
        {
            UpdateDisplay(e.WorkflowInstance.InstanceId, "Idled");
        }

        void WorkflowRuntime_WorkflowLoaded(object sender,
            WorkflowEventArgs e)
        {
            UpdateDisplay(e.WorkflowInstance.InstanceId, "Loaded");
        }

        void WorkflowRuntime_WorkflowUnloaded(object sender,
            WorkflowEventArgs e)
        {
            UpdateDisplay(e.WorkflowInstance.InstanceId, "Unloaded");
        }

        void WorkflowRuntime_WorkflowPersisted(object sender,
            WorkflowEventArgs e)
        {
            UpdateDisplay(e.WorkflowInstance.InstanceId, "Persisted");
        }

        void WorkflowRuntime_WorkflowCompleted(object sender,
            WorkflowCompletedEventArgs e)
        {
            UpdateCompletedWorkflow(e.WorkflowInstance.InstanceId);
            UpdateDisplay(e.WorkflowInstance.InstanceId, "Completed");
        }

        private delegate void UpdateDelegate();

        /// <summary>
        /// Update the status message for a workflow
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="statusMessage"></param>
        private void UpdateDisplay(Guid instanceId, String statusMessage)
        {
            UpdateDelegate theDelegate = delegate()
            {
                Workflow workflow = GetWorkflow(instanceId);
                workflow.StatusMessage = statusMessage;
                RefreshData();
                //slow things down so you can see the status changes
                System.Threading.Thread.Sleep(1000);
            };

            //execute the anonymous delegate on the UI thread
            this.Invoke(theDelegate);
        }

        /// <summary>
        /// Updating the bindings for the DataGridView
        /// </summary>
        private void RefreshData()
        {
            //setup binding for DataGridView
            BindingSource source = new BindingSource();
            dataGridView1.DataSource = source;
            source.DataSource = _workflows.Values;

            dataGridView1.Columns[0].MinimumWidth = 250;
            dataGridView1.Columns[1].MinimumWidth = 140;
            dataGridView1.Columns[2].MinimumWidth = 40;

            dataGridView1.Refresh();
        }

        /// <summary>
        /// Mark a workflow as completed
        /// </summary>
        /// <param name="instanceId"></param>
        private void UpdateCompletedWorkflow(Guid instanceId)
        {
            UpdateDelegate theDelegate = delegate()
            {
                Workflow workflow = GetWorkflow(instanceId);
                workflow.IsCompleted = true;
            };

            //execute the anonymous delegate on the UI thread
            this.Invoke(theDelegate);
        }

        #endregion

        #region UI event handlers and management

        /// <summary>
        /// Start a new workflow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewWorkflow_Click(object sender, EventArgs e)
        {
            //start a new workflow instance
            _workflowManager.StartWorkflow(
                typeof(PersistenceDemoWorkflow), null);
        }

        /// <summary>
        /// Raise the Continue event through the local service
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (_selectedWorkflow != null)
            {
                _persistenceDemoService.OnContinueReceived(
                    new ExternalDataEventArgs(_selectedWorkflow.InstanceId));
            }
        }

        /// <summary>
        /// Raise the Stop event through the local service
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_selectedWorkflow != null)
            {
                _persistenceDemoService.OnStopReceived(
                    new ExternalDataEventArgs(_selectedWorkflow.InstanceId));
            }
        }

        /// <summary>
        /// The selected workflow has changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_SelectionChanged(
            object sender, EventArgs e)
        {
            //save the selected workflow instance
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                _selectedWorkflow = selectedRow.DataBoundItem as Workflow;
                SetButtonState();
            }
        }

        /// <summary>
        /// Enable / Disable buttons
        /// </summary>
        private void SetButtonState()
        {
            if (_selectedWorkflow != null)
            {
                btnContinue.Enabled = !(_selectedWorkflow.IsCompleted);
                btnStop.Enabled = !(_selectedWorkflow.IsCompleted);
            }
            else
            {
                btnContinue.Enabled = false;
                btnStop.Enabled = false;
            }
        }

        #endregion

        #region Collection Management

        /// <summary>
        /// Retrieve a workflow from our local collection
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        private Workflow GetWorkflow(Guid instanceId)
        {
            Workflow result = null;
            if (_workflows.ContainsKey(instanceId))
            {
                result = _workflows[instanceId];
            }
            else
            {
                //create a new instance
                result = new Workflow();
                result.InstanceId = instanceId;
                _workflows.Add(result.InstanceId, result);
            }
            return result;
        }

        /// <summary>
        /// Identify all persisted workflows
        /// </summary>
        private void RetrieveExistingWorkflows()
        {
            _workflows.Clear();
            //retrieve a list of workflows that have been persisted

#if CUSTOM_PERSISTENCE
            foreach (Guid instanceId
                in ((FileWorkflowPersistenceService)_persistence).GetAllWorkflows())
            {
                Workflow workflow = new Workflow();
                workflow.InstanceId = instanceId;
                workflow.StatusMessage = "Unloaded";
                _workflows.Add(workflow.InstanceId, workflow);
            }
#else
            foreach (SqlPersistenceWorkflowInstanceDescription workflowDesc
                in ((SqlWorkflowPersistenceService)_persistence).GetAllWorkflows())
            {
                Workflow workflow = new Workflow();
                workflow.InstanceId = workflowDesc.WorkflowInstanceId;
                workflow.StatusMessage = "Unloaded";
                _workflows.Add(workflow.InstanceId, workflow);
            }
#endif

            if (_workflows.Count > 0)
            {
                RefreshData();
            }
        }

        #endregion

    }
}