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
using System.Collections.Generic;

#if IDENTIFYEVENTS
using System.Collections.ObjectModel;
#endif

using System.Windows.Forms;
using System.Workflow.Activities;
using System.Workflow.Runtime;

using Bukovics.Workflow.Hosting;
using SharedWorkflows;


namespace CarStateMachine
{
    /// <summary>
    /// Application to test the CarWorkflow
    /// </summary>
    public partial class Form1 : Form
    {
        private WorkflowRuntimeManager _workflowManager;
        private CarService _carService;
        private Guid _instanceId = Guid.Empty;
        private WorkflowInstanceWrapper _instanceWrapper;

        public Form1()
        {
            InitializeComponent();

#if IDENTIFYEVENTS
            //associate each button with the event that it raises
            btnStartEngine.Tag = "StartEngine";
            btnStopEngine.Tag = "StopEngine";
            btnForward.Tag = "GoForward";
            btnReverse.Tag = "GoReverse";
            btnStop.Tag = "StopMovement";
            btnBeepHorn.Tag = "BeepHorn";
            btnLeaveCar.Tag = "LeaveCar";
#endif

            EnableEventButtons(false);
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

#if IDENTIFYEVENTS
            _workflowManager.WorkflowRuntime.WorkflowIdled
                += new EventHandler<WorkflowEventArgs>(
                    WorkflowRuntime_WorkflowIdled);
#endif

            //add services to the workflow runtime
            AddServices(_workflowManager.WorkflowRuntime);
        }

        /// <summary>
        /// Add any services needed by the runtime engine
        /// </summary>
        /// <param name="instance"></param>
        private void AddServices(WorkflowRuntime instance)
        {
            //add the external data exchange service to the runtime
            ExternalDataExchangeService exchangeService
                = new ExternalDataExchangeService();
            instance.AddService(exchangeService);

            //add our local service
            _carService = new CarService();
            _carService.MessageReceived
                += new EventHandler<MessageReceivedEventArgs>(
                    carService_MessageReceived);
            exchangeService.AddService(_carService);
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

        #region Workflow originated events

        private delegate void UpdateDelegate();

        void carService_MessageReceived(
            object sender, MessageReceivedEventArgs e)
        {
            //save the workflow instance Id
            _instanceId = e.InstanceId;

            UpdateDelegate theDelegate = delegate()
            {
                //update the message shown in the UI
                lblMessage.Text = e.Message;
            };

            //execute the anonymous delegate on the UI thread
            this.Invoke(theDelegate);
        }

#if IDENTIFYEVENTS
        /// <summary>
        /// Handle the WorkflowIdled event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorkflowRuntime_WorkflowIdled(
            object sender, WorkflowEventArgs e)
        {
            UpdateDelegate theDelegate = delegate()
            {
                //first disable all buttons
                EnableEventButtons(false);

                //determine which events are allowed.  
                //Note:  ReadOnlyCollection is in the 
                //System.Collections.ObjectModel namespace.
                ReadOnlyCollection<WorkflowQueueInfo> queueInfoData
                    = _instanceWrapper.WorkflowInstance.GetWorkflowQueueData();
                if (queueInfoData != null)
                {
                    foreach (WorkflowQueueInfo info in queueInfoData)
                    {
                        EventQueueName eventQueue = info.QueueName
                            as EventQueueName;
                        if (eventQueue == null)
                        {
                            break;
                        }

                        //enable the button that is associated
                        //with this event
                        EnableButtonForEvent(eventQueue.MethodName);
                    }
                }

#if STATEMACHINEINSTANCE
                StateMachineWorkflowInstance stateMachine
                    = new StateMachineWorkflowInstance(
                        _workflowManager.WorkflowRuntime,
                        _instanceWrapper.WorkflowInstance.InstanceId);

                //set the form title to the current state name
                this.Text = String.Format(
                    "State: {0}", stateMachine.CurrentStateName);
#endif
            };

            //execute the anonymous delegate on the UI thread
            this.Invoke(theDelegate);
        }
#endif

        #endregion

        #region UI event handlers

        private void btnNewCar_Click(object sender, EventArgs e)
        {
#if CARWORKFLOWRECURSIVE
            _instanceWrapper
                = _workflowManager.StartWorkflow(
                    typeof(CarWorkflowRecursive), null);
#else
            _instanceWrapper
                = _workflowManager.StartWorkflow(
                    typeof(CarWorkflow), null);
#endif

            _instanceId = _instanceWrapper.WorkflowInstance.InstanceId;

            //enable the buttons
            EnableEventButtons(true);
            btnNewCar.Enabled = false;
        }

        private void btnStartEngine_Click(object sender, EventArgs e)
        {
            try
            {
                _carService.OnStartEngine(GetEventArgs());
            }
            catch (Exception exception)
            {
                HandleException(exception);
            }
        }

        private void btnStopEngine_Click(object sender, EventArgs e)
        {
            try
            {
                _carService.OnStopEngine(GetEventArgs());
            }
            catch (Exception exception)
            {
                HandleException(exception);
            }
        }

        private void btnLeaveCar_Click(object sender, EventArgs e)
        {
            try
            {
                _carService.OnLeaveCar(GetEventArgs());
                //disable the buttons
                EnableEventButtons(false);
                btnNewCar.Enabled = true;
            }
            catch (Exception exception)
            {
                HandleException(exception);
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            try
            {
                _carService.OnGoForward(GetEventArgs());
            }
            catch (Exception exception)
            {
                HandleException(exception);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                _carService.OnStopMovement(GetEventArgs());
            }
            catch (Exception exception)
            {
                HandleException(exception);
            }
        }

        private void btnReverse_Click(object sender, EventArgs e)
        {
            try
            {
                _carService.OnGoReverse(GetEventArgs());
            }
            catch (Exception exception)
            {
                HandleException(exception);
            }
        }

        private void btnBeepHorn_Click(object sender, EventArgs e)
        {
            try
            {
                _carService.OnBeepHorn(GetEventArgs());
            }
            catch (Exception exception)
            {
                HandleException(exception);
            }
        }

        private ExternalDataEventArgs GetEventArgs()
        {
            ExternalDataEventArgs args
                = new ExternalDataEventArgs(_instanceId);
            args.WaitForIdle = true;
            return args;
        }

        private void HandleException(Exception e)
        {
            if (e is EventDeliveryFailedException)
            {
                MessageBox.Show("Action not allowed", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show(e.Message, "Unhandled Exception",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Internal Helper methods

        private void EnableEventButtons(Boolean enabled)
        {
            btnStartEngine.Enabled = enabled;
            btnStopEngine.Enabled = enabled;
            btnForward.Enabled = enabled;
            btnReverse.Enabled = enabled;
            btnStop.Enabled = enabled;
            btnBeepHorn.Enabled = enabled;
            btnLeaveCar.Enabled = enabled;
        }

#if IDENTIFYEVENTS
        private void EnableButtonForEvent(String eventName)
        {
            //if a control has a Tag property equal 
            //to the event name, then enable it
            foreach (Control control in this.Controls)
            {
                if (control is Button && 
                    control.Tag != null)
                {
                    if (control.Tag.ToString() == eventName)
                    {
                        control.Enabled = true;
                    }
                }
            }
        }
#endif

        #endregion

    }
}