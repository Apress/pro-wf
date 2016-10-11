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

#region Using directives

using System;
using System.Collections.Generic;
using System.Threading;
using System.Workflow.Runtime;

#endregion

namespace OrderEntryCode
{
    /// <summary>
    /// Execute OrderEntry workflow with CodeActivity
    /// </summary>
    public class Program : IDisposable
    {
        private WorkflowRuntime _workflowRuntime;
        private AutoResetEvent _waitHandle = new AutoResetEvent(false);

        public Program()
        {
            InitializeWorkflowRuntime();
        }

        #region IDisposable Members

        /// <summary>
        /// Dispose of the workflow runtime
        /// </summary>
        public void Dispose()
        {
            _workflowRuntime.StopRuntime();
            _workflowRuntime.Dispose();
        }

        #endregion

        /// <summary>
        /// Start the workflow runtime
        /// </summary>
        private void InitializeWorkflowRuntime()
        {
            _workflowRuntime = new WorkflowRuntime();
            _workflowRuntime.WorkflowCompleted
                += delegate(object sender, WorkflowCompletedEventArgs e)
                {
                    _waitHandle.Set();
                };
            _workflowRuntime.WorkflowTerminated
                += delegate(object sender, WorkflowTerminatedEventArgs e)
                {
                    Console.WriteLine(e.Exception.Message);
                    _waitHandle.Set();
                };
        }

        /// <summary>
        /// Run the workflow
        /// </summary>
        /// <param name="wfArguments"></param>
        public void RunWorkflow(Dictionary<String, Object> wfArguments)
        {
            //create the workflow instance and start it
            WorkflowInstance instance = _workflowRuntime.CreateWorkflow(
                    typeof(OrderEntryCode.Workflow1), wfArguments);
            instance.Start();

            //wait for the workflow to complete
            _waitHandle.WaitOne();
        }

        static void Main(string[] args)
        {
            using (Program instance = new Program())
            {
                //create a dictionary with input arguments
                Dictionary<String, Object> wfArguments
                    = new Dictionary<string, object>();
                wfArguments.Add("AccountId", 1001);
                wfArguments.Add("SalesItemId", 501);
                //run the workflow
                instance.RunWorkflow(wfArguments);

                //change the parameters and run the workflow
                //one more time with another account and item
                wfArguments.Clear();
                wfArguments.Add("AccountId", 2002);
                wfArguments.Add("SalesItemId", 502);
                instance.RunWorkflow(wfArguments);

                //try the workflow gain, this time the account
                //should have insufficient funds for the order.
                wfArguments.Clear();
                wfArguments.Add("AccountId", 1001);
                wfArguments.Add("SalesItemId", 502);
                instance.RunWorkflow(wfArguments);

                //run the workflow again with an invalid account
                wfArguments.Clear();
                wfArguments.Add("AccountId", 9999);
                wfArguments.Add("SalesItemId", 501);
                instance.RunWorkflow(wfArguments);

                Console.WriteLine("Press any key to exit");
                Console.ReadLine();
            }
        }
    }
}
