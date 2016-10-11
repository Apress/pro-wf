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
    /// Defines methods and events to demonstrate the 
    /// use of correlation attributes.
    /// </summary>
    [ExternalDataExchange]
    [CorrelationParameter("branchId")]
    public interface ICorrelationExample
    {
        /// <summary>
        /// Called by the workflow to start the 
        /// correlation example
        /// </summary>
        /// <param name="branchId"></param>
        [CorrelationInitializer]
        void StartDemonstration(Int32 branchId);

        /// <summary>
        /// An event that is handled by the workflow
        /// </summary>
        [CorrelationAlias("branchId", "e.BranchId")]
        event EventHandler<CorrelationExampleEventArgs> EventReceived;
    }
}
