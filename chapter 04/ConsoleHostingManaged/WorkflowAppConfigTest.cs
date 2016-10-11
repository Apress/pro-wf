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
using System.Collections.Generic;
using System.Text;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;

using Bukovics.Workflow.Hosting;

//System.Configuration must be added as an assembly reference
//in order to load workflow service configuration from 
//the App.Config file

namespace ConsoleHostingManaged
{
    /// <summary>
    /// Workflow hosting using custom wrapper classes and
    /// configuring the workflow runtime from the App.Config
    /// </summary>
    public class WorkflowAppConfigTest
    {
        public static void Run()
        {
            Console.WriteLine("Running test configured with App.Config");

            using (WorkflowRuntimeManager manager
                = new WorkflowRuntimeManager(
                    new WorkflowRuntime("WorkflowRuntime")))
            {
                //add event handler to log messages from the manager
                manager.MessageEvent += delegate(
                    Object sender, WorkflowLogEventArgs e)
                {
                    Console.WriteLine(e.Message);
                };

                //start the workflow runtime. It will also autostart if 
                //we don't do it here.
                manager.WorkflowRuntime.StartRuntime();

                //create a dictionary with input arguments
                Dictionary<String, Object> wfArguments
                    = new Dictionary<string, object>();
                wfArguments.Add("InputString", "one");
                //run the workflow
                manager.StartWorkflow(
                    typeof(SharedWorkflows.Workflow1), wfArguments);

                //run another instance with different parameters
                wfArguments.Clear();
                wfArguments.Add("InputString", "two");
                manager.StartWorkflow(
                    typeof(SharedWorkflows.Workflow1), wfArguments);

                //run another instance with different parameters
                wfArguments.Clear();
                wfArguments.Add("InputString", "three");
                manager.StartWorkflow(
                    typeof(SharedWorkflows.Workflow1), wfArguments);

                //wait for all workflow instances to complete
                manager.WaitAll(15000);

                //display the results from all workflow instances
                foreach (WorkflowInstanceWrapper wrapper
                    in manager.Workflows.Values)
                {
                    if (wrapper.OutputParameters.ContainsKey("Result"))
                    {
                        Console.WriteLine(wrapper.OutputParameters["Result"]);
                    }
                    else
                    {
                        //must be a problem - see if there is an exception
                        if (wrapper.Exception != null)
                        {
                            Console.WriteLine("{0} - Exception: {1}",
                                wrapper.Id, wrapper.Exception.Message);
                        }
                    }
                }
                manager.ClearAllWorkflows();
            }
        }
    }
}
