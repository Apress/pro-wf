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
    /// The guessing game workflow
    /// </summary>
    public sealed partial class GuessingGameWorkflow
        : SequentialWorkflowActivity
    {
        #region Variables and Properties

        private Int32 _theNumber;
        private Boolean _isComplete = false;
        private String _message = String.Empty;

        public String Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public Boolean IsComplete
        {
            get { return _isComplete; }
            set { _isComplete = value; }
        }

        #endregion

        public GuessingGameWorkflow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize variables as the workflow is started
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnInitialized(object sender, EventArgs e)
        {
            Random random = new Random();
            _theNumber = random.Next(1, 10);
            Message = "Please guess a number between 1 and 10.";
        }

        /// <summary>
        /// The event was received
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void handleExternalEventActivity1_Invoked(
            object sender, ExternalDataEventArgs e)
        {
            GuessReceivedEventArgs eventArgs
                = e as GuessReceivedEventArgs;
            if (eventArgs != null)
            {
                if (eventArgs.NextGuess < _theNumber)
                {
                    Message = "Try a higher number.";
                }
                else if (eventArgs.NextGuess > _theNumber)
                {
                    Message = "Try a lower number.";
                }
                else
                {
                    Message = String.Format(
                        "Congratulations! You correctly guessed {0}.", _theNumber);
                    IsComplete = true;
                }
            }
        }
    }
}
