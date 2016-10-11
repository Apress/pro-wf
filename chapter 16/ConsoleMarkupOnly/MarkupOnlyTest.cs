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
using System.Reflection;
using System.Collections.Generic;
using System.Workflow.Runtime;
using System.Workflow.ComponentModel.Compiler;

using Bukovics.Workflow.Hosting;

namespace ConsoleMarkupOnly
{
    /// <summary>
    /// Execute the MarkupOnlyWorkflow
    /// </summary>
    public class MarkupOnlyTest
    {
        public static void Run()
        {
            using (WorkflowRuntimeManager manager
                = new WorkflowRuntimeManager(new WorkflowRuntime()))
            {
                //start the runtime 
                manager.WorkflowRuntime.StartRuntime();

                Console.WriteLine("Executing Workflow");
                //pass a number to test
                Dictionary<String, Object> wfArguments
                    = new Dictionary<string, object>();
                wfArguments.Add("TheNumber", 1);

                try
                {
                    //start the workflow
#if MARKUP_ONLY_RULES
                    WorkflowInstanceWrapper instance =
                        manager.StartWorkflow(
                            "MarkupOnlyRulesWorkflow.xoml", 
                            "MarkupOnlyRulesWorkflow.rules",
                            wfArguments);
#else
                    WorkflowInstanceWrapper instance =
                        manager.StartWorkflow(
                            "MarkupOnlyWorkflow.xoml", null, wfArguments);
#endif
                }
                catch (WorkflowValidationFailedException e)
                {
                    foreach (ValidationError error in e.Errors)
                    {
                        Console.WriteLine(error.ErrorText);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                //wait for the workflow to complete
                manager.WaitAll(2000);
                Console.WriteLine("Completed Workflow\n\r");
            }
        }
    }
}
