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
using System.Workflow.Runtime;

namespace SharedWorkflows
{
    public class GuessingGameService : IGuessingGame
    {
        #region IGuessingGame Members

        /// <summary>
        /// Called by a workflow to send a message to the host
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(string message)
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

        /// <summary>
        /// Handled by a HandleExternalEventActivity in a workflow
        /// </summary>
        public event EventHandler<GuessReceivedEventArgs> GuessReceived;

        #endregion

        #region Public Members (not part of the service contract)

        /// <summary>
        /// Handled by the host application to receive messages
        /// </summary>
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        /// <summary>
        /// Called by the host application to raise the
        /// GuessReceived event
        /// </summary>
        /// <param name="args"></param>
        public void OnGuessReceived(GuessReceivedEventArgs args)
        {
            if (GuessReceived != null)
            {
                //must pass null as the sender otherwise
                //the correct workflow won't receive the event.
                GuessReceived(null, args);
            }
        }

        #endregion
    }
}
