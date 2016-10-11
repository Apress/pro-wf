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
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.Threading;

#endregion

namespace ConsoleManualScheduler
{
    /// <summary>
    /// Use the ManualWorkflowSchedulerService to 
    /// synchronously execute a workflow
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            using (WorkflowRuntime workflowRuntime = new WorkflowRuntime())
            {
                String wfResult = String.Empty;
                AutoResetEvent waitHandle = new AutoResetEvent(false);

                workflowRuntime.WorkflowCompleted
                    += delegate(object sender, WorkflowCompletedEventArgs e)
                    {
                        //retrieve the output parameter value
                        if (e.OutputParameters.ContainsKey("Result"))
                        {
                            wfResult = (String)e.OutputParameters["Result"];
                            waitHandle.Set();
                        }
                    };

                //add the manual scheduler service prior to 
                //starting the workflow runtime. Use the constructor
                //that allows us to set useActiveTimers to true.
                ManualWorkflowSchedulerService scheduler =
                    new ManualWorkflowSchedulerService(true);
                workflowRuntime.AddService(scheduler);
                //start the workflow runtime
                workflowRuntime.StartRuntime();

                //create a dictionary with input arguments
                Dictionary<String, Object> wfArguments
                    = new Dictionary<string, object>();
                wfArguments.Add("InputString", "one");

                //create the workflow instance
                WorkflowInstance instance = workflowRuntime.CreateWorkflow(
                    typeof(SharedWorkflows.Workflow1), wfArguments);
                //indicate that it should execute when we provide a thread
                instance.Start();

                //run the workflow instance synchronously on our thread
                scheduler.RunWorkflow(instance.InstanceId);

                //since the workflow contains a DelayActivity, the RunWorkflow
                //method will return immediately at the start of the delay.
                //use the waitHandle to signal the actual completion of 
                //the workflow when the DelayActivity completes.
                waitHandle.WaitOne(7000, false);

                //display the workflow result
                Console.WriteLine(wfResult);

                Console.WriteLine("Press any key to exit");
                Console.ReadLine();
            }
        }
    }
}
