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
using System.Text;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;

using Bukovics.Workflow.Hosting;

#endregion

namespace ConsoleWhile
{
    /// <summary>
    /// Execute workflow with WhileActivity
    /// </summary>
    public class WhileTest
    {
        public static void Run()
        {
            using (WorkflowRuntimeManager manager
                = new WorkflowRuntimeManager(new WorkflowRuntime()))
            {
                //create a dictionary with input arguments
                Dictionary<String, Object> wfArguments
                    = new Dictionary<string, object>();

                //run the first workflow
                Console.WriteLine("Executing WhileWorkflow Test 1");
                wfArguments.Add("TestNumber", 5);
                manager.StartWorkflow(
                    typeof(SharedWorkflows.WhileWorkflow), wfArguments);
                manager.WaitAll(2000);
                Console.WriteLine("Completed WhileWorkflow Test 1\n\r");

                //run the second workflow
                Console.WriteLine("Executing WhileWorkflow Test 2");
                wfArguments.Clear();
                wfArguments.Add("TestNumber", 0);
                manager.StartWorkflow(
                    typeof(SharedWorkflows.WhileWorkflow), wfArguments);
                manager.WaitAll(2000);
                Console.WriteLine("Completed WhileWorkflow Test 2\n\r");
            }
        }
    }
}
