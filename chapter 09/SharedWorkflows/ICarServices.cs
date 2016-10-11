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
    /// Define the contract for operating a vehicle
    /// </summary>
    [ExternalDataExchange]
    public interface ICarServices
    {
        /// <summary>
        /// Start the engine
        /// </summary>
        event EventHandler<ExternalDataEventArgs> StartEngine;

        /// <summary>
        /// Stop the engine
        /// </summary>
        event EventHandler<ExternalDataEventArgs> StopEngine;

        /// <summary>
        /// Stop movement of the vehicle
        /// </summary>
        event EventHandler<ExternalDataEventArgs> StopMovement;

        /// <summary>
        /// Move the vehicle forward
        /// </summary>
        event EventHandler<ExternalDataEventArgs> GoForward;

        /// <summary>
        /// Move the vehicle in reverse
        /// </summary>
        event EventHandler<ExternalDataEventArgs> GoReverse;

        /// <summary>
        /// Done with the car
        /// </summary>
        event EventHandler<ExternalDataEventArgs> LeaveCar;

        /// <summary>
        /// Beep the horn
        /// </summary>
        event EventHandler<ExternalDataEventArgs> BeepHorn;

        /// <summary>
        /// Send a message to the host application
        /// </summary>
        /// <param name="message"></param>
        void OnSendMessage(String message);
    }
}
