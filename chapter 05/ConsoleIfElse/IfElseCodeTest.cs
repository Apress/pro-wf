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

namespace ConsoleIfElse
{
    /// <summary>
    /// Execute IfElse workflow with Code conditions
    /// </summary>
    public class IfElseCodeTest
    {
        public static void Run()
        {
            using (WorkflowRuntimeManager manager
                = new WorkflowRuntimeManager(new WorkflowRuntime()))
            {
                Console.WriteLine("Executing IfElseCodeWorkflow");

                //create a dictionary with input arguments
                Dictionary<String, Object> wfArguments
                    = new Dictionary<string, object>();

                //run the first workflow
                wfArguments.Add("TestNumber", -100);
                manager.StartWorkflow(
                    typeof(SharedWorkflows.IfElseCodeWorkflow), wfArguments);

                //run the second workflow
                wfArguments.Clear();
                wfArguments.Add("TestNumber", +200);
                manager.StartWorkflow(
                    typeof(SharedWorkflows.IfElseCodeWorkflow), wfArguments);

                //run the third workflow
                wfArguments.Clear();
                wfArguments.Add("TestNumber", 0);
                manager.StartWorkflow(
                    typeof(SharedWorkflows.IfElseCodeWorkflow), wfArguments);

                manager.WaitAll(2000);

                Console.WriteLine("Completed IfElseCodeWorkflow\n\r");
            }
        }
    }
}
