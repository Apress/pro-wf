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
using System.Workflow.Runtime;

using Bukovics.Workflow.Hosting;
using SharedWorkflows;

namespace ConsoleSelfUpdating
{
    /// <summary>
    /// Test the SelfUpdatingWorkflow
    /// </summary>
    public class SelfUpdatingTest
    {
        public static void Run()
        {
            using (WorkflowRuntimeManager manager
                = new WorkflowRuntimeManager(new WorkflowRuntime()))
            {
                manager.WorkflowRuntime.StartRuntime();

                //
                //add a new activity to this workflow
                //
                Console.WriteLine("Executing SelfUpdatingWorkflow for 1001");
                Dictionary<String, Object> wfArguments
                    = new Dictionary<string, object>();
                wfArguments.Add("TestNumber", 1001);
                //pass the Type of new activity to add along with the
                //dependency property to bind
                wfArguments.Add("NewActivityType",
                    typeof(NewFunctionActivity));
                wfArguments.Add("NumberProperty",
                    NewFunctionActivity.TestNumberProperty);
                manager.StartWorkflow(
                    typeof(SharedWorkflows.SelfUpdatingWorkflow), wfArguments);
                manager.WaitAll(5000);
                Console.WriteLine("Completed SelfUpdatingWorkflow for 1001\n\r");

                //
                //let this activity execute normally without changes
                //
                Console.WriteLine("Executing SelfUpdatingWorkflow for 2002");
                wfArguments.Clear();
                wfArguments.Add("TestNumber", 2002);
                manager.StartWorkflow(
                    typeof(SharedWorkflows.SelfUpdatingWorkflow), wfArguments);
                manager.WaitAll(5000);
                Console.WriteLine("Completed SelfUpdatingWorkflow for 2002\n\r");
            }
        }
    }
}


