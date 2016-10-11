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

using Bukovics.Workflow.Hosting;

#endregion

namespace ConsoleReplicator
{
    /// <summary>
    /// Execute workflow with ReplicatorActivity
    /// </summary>
    public class ReplicatorTest
    {
        public static void Run()
        {
            using (WorkflowRuntimeManager manager
                = new WorkflowRuntimeManager(new WorkflowRuntime()))
            {
                //create a dictionary with input arguments
                Dictionary<String, Object> wfArguments
                    = new Dictionary<string, object>();

                //create and populate a list of strings to process
                List<String> inputList = new List<string>();
                inputList.Add("one");
                inputList.Add("two");
                inputList.Add("three");
                wfArguments.Add("InputList", inputList);

                Console.WriteLine("Executing ReplicatorWorkflow");
                manager.StartWorkflow(
                    typeof(SharedWorkflows.ReplicatorWorkflow), wfArguments);
                manager.WaitAll(2000);
                Console.WriteLine("Completed ReplicatorWorkflow\n\r");
            }
        }
    }
}
