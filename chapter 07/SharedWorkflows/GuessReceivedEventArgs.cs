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
    /// Passes a guess from the local service to a workflow
    /// </summary>
    [Serializable]
    public class GuessReceivedEventArgs : ExternalDataEventArgs
    {
        private Int32 _nextGuess;

        public GuessReceivedEventArgs(Guid instanceId, Int32 nextGuess)
            : base(instanceId)
        {
            _nextGuess = nextGuess;
        }

        public Int32 NextGuess
        {
            get { return _nextGuess; }
            set { _nextGuess = value; }
        }
    }
}
