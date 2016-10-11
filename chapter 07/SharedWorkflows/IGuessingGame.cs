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
    /// Defines the methods and events that
    /// are exposed to workflows for the 
    /// number guessing game.
    /// </summary>
    [ExternalDataExchange]
    public interface IGuessingGame
    {
        /// <summary>
        /// Send a message from the workflow to the local service
        /// </summary>
        /// <param name="message"></param>
        void SendMessage(String message);

        /// <summary>
        /// Notify the workflow that a new guess has been received
        /// </summary>
        event EventHandler<GuessReceivedEventArgs> GuessReceived;
    }
}
