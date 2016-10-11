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

namespace ConsoleCAG
{
    /// <summary>
    /// Execute workflow with ConditionedActivityGroup
    /// </summary>
    public class CAGTest
    {
        public static void Run()
        {
            using (WorkflowRuntimeManager manager
                = new WorkflowRuntimeManager(new WorkflowRuntime()))
            {
                Dictionary<String, Object> wfArguments
                    = new Dictionary<string, object>();
                List<String> items = new List<string>();
                items.Add("sandwich");
                items.Add("drink");
                items.Add("fries");
                items.Add("drink");
                items.Add("combo");
                wfArguments.Add("LineItems", items);

                Console.WriteLine("Executing CAGWorkflow");
                manager.StartWorkflow(
                        typeof(SharedWorkflows.CAGWorkflow), wfArguments);
                manager.WaitAll(3000);
                Console.WriteLine("Completed CAGWorkflow\n\r");
            }
        }
    }
}
