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
    /// A local service that provides events used to control
    /// a vehicle
    /// </summary>
    public class CarService : ICarServices
    {
        #region ICarServices Members

        public event EventHandler<ExternalDataEventArgs> StartEngine;

        public event EventHandler<ExternalDataEventArgs> StopEngine;

        public event EventHandler<ExternalDataEventArgs> StopMovement;

        public event EventHandler<ExternalDataEventArgs> GoForward;

        public event EventHandler<ExternalDataEventArgs> GoReverse;

        public event EventHandler<ExternalDataEventArgs> BeepHorn;

        public event EventHandler<ExternalDataEventArgs> LeaveCar;

        /// <summary>
        /// Send a message from a workflow to the host application
        /// </summary>
        /// <param name="message"></param>
        public void OnSendMessage(String message)
        {
            if (MessageReceived != null)
            {
                MessageReceivedEventArgs args
                    = new MessageReceivedEventArgs(
                        WorkflowEnvironment.WorkflowInstanceId,
                        message);
                MessageReceived(this, args);
            }
        }

        #endregion

        #region Members used by the host application

        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        public void OnStartEngine(ExternalDataEventArgs args)
        {
            if (StartEngine != null)
            {
                StartEngine(null, args);
            }
        }

        public void OnStopEngine(ExternalDataEventArgs args)
        {
            if (StopEngine != null)
            {
                StopEngine(null, args);
            }
        }

        public void OnStopMovement(ExternalDataEventArgs args)
        {
            if (StopMovement != null)
            {
                StopMovement(null, args);
            }
        }

        public void OnGoForward(ExternalDataEventArgs args)
        {
            if (GoForward != null)
            {
                GoForward(null, args);
            }
        }

        public void OnGoReverse(ExternalDataEventArgs args)
        {
            if (GoReverse != null)
            {
                GoReverse(null, args);
            }
        }

        public void OnBeepHorn(ExternalDataEventArgs args)
        {
            if (BeepHorn != null)
            {
                BeepHorn(null, args);
            }
        }

        public void OnLeaveCar(ExternalDataEventArgs args)
        {
            if (LeaveCar != null)
            {
                LeaveCar(null, args);
            }
        }

        #endregion
    }
}
