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
    /// Implements events that are handled by workflow instances
    /// </summary>
    public class PersistenceDemoService : IPersistenceDemo
    {
        #region IPersistenceDemo Members

        public event EventHandler<ExternalDataEventArgs> ContinueReceived;

        public event EventHandler<ExternalDataEventArgs> StopReceived;

        #endregion

        #region Members used by the host application

        /// <summary>
        /// Raise the ContinueReceived event
        /// </summary>
        /// <param name="args"></param>
        public void OnContinueReceived(ExternalDataEventArgs args)
        {
            if (ContinueReceived != null)
            {
                ContinueReceived(null, args);
            }
        }

        /// <summary>
        /// Raise the StopReceived event
        /// </summary>
        /// <param name="args"></param>
        public void OnStopReceived(ExternalDataEventArgs args)
        {
            if (StopReceived != null)
            {
                StopReceived(null, args);
            }
        }

        #endregion
    }
}
