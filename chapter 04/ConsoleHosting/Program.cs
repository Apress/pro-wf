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
using System.Workflow.Runtime.Hosting;

#endregion

namespace ConsoleHosting
{
    /// <summary>
    /// Simple workflow hosting
    /// </summary>
    public class Program : IDisposable
    {
        private WorkflowRuntime _workflowRuntime;
        private AutoResetEvent _waitHandle = new AutoResetEvent(false);
        private String _result = String.Empty;

        public Program()
        {
            InitializeWorkflowRuntime();
        }

        public String Result
        {
            get { return _result; }
            set { _result = value; }
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
                    //retrieve the output parameter value
                    if (e.OutputParameters.ContainsKey("Result"))
                    {
                        _result = (String)e.OutputParameters["Result"];
                    }
                    _waitHandle.Set();
                };
            _workflowRuntime.WorkflowTerminated
                += delegate(object sender, WorkflowTerminatedEventArgs e)
                {
                    Console.WriteLine(e.Exception.Message);
                    _waitHandle.Set();
                };

            //start execution of the runtime engine
            _workflowRuntime.StartRuntime();
        }

        /// <summary>
        /// Run the workflow
        /// </summary>
        /// <param name="wfArguments"></param>
        public void RunWorkflow(Dictionary<String, Object> wfArguments,
            Type workflowType)
        {
            //create the workflow instance and start it
            WorkflowInstance instance = _workflowRuntime.CreateWorkflow(
                    workflowType, wfArguments);
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
                wfArguments.Add("InputString", "one");
                //run the workflow
                instance.RunWorkflow(wfArguments,
                    typeof(SharedWorkflows.Workflow1));
                Console.WriteLine(instance.Result);

                wfArguments.Clear();
                wfArguments.Add("InputString", "two");
                instance.RunWorkflow(wfArguments,
                    typeof(SharedWorkflows.Workflow1));
                Console.WriteLine(instance.Result);

                wfArguments.Clear();
                wfArguments.Add("InputString", "three");
                instance.RunWorkflow(wfArguments,
                    typeof(SharedWorkflows.Workflow1));
                Console.WriteLine(instance.Result);

                Console.WriteLine("Press any key to exit");
                Console.ReadLine();
            }
        }
    }
}

