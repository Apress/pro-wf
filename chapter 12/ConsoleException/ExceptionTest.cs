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

namespace ConsoleException
{
    /// <summary>
    /// Test the ExceptionWorkflow 
    /// </summary>
    public class ExceptionTest
    {
        public static void Run()
        {
            using (WorkflowRuntimeManager manager
                = new WorkflowRuntimeManager(new WorkflowRuntime()))
            {
                manager.WorkflowRuntime.StartRuntime();

                Console.WriteLine("Executing ExceptionWorkflow Value 1");
                ExecuteWorkflow(manager, 1);
                Console.WriteLine("Completed ExceptionWorkflow Value 1\n\r");

                Console.WriteLine("Executing ExceptionWorkflow Value 2");
                ExecuteWorkflow(manager, 2);
                Console.WriteLine("Completed ExceptionWorkflow Value 2\n\r");
            }
        }

        /// <summary>
        /// Execute the workflow
        /// </summary>
        /// <param name="item"></param>
        private static void ExecuteWorkflow(
            WorkflowRuntimeManager manager, Int32 testNumber)
        {
            //create a dictionary with input arguments
            Dictionary<String, Object> wfArguments
                = new Dictionary<string, object>();
            wfArguments.Add("TestNumber", testNumber);

            //execute the workflow
#if EXCEPTION_HANDLED
            WorkflowInstanceWrapper instance = manager.StartWorkflow(
                typeof(SharedWorkflows.ExceptionHandledWorkflow), wfArguments);
#elif EXCEPTION_HANDLED2
            WorkflowInstanceWrapper instance = manager.StartWorkflow(
                typeof(SharedWorkflows.ExceptionHandled2Workflow), wfArguments);
#elif EXCEPTION_COMPOSITE
            WorkflowInstanceWrapper instance = manager.StartWorkflow(
                typeof(SharedWorkflows.ExceptionCompositeWorkflow), wfArguments);
#elif EXCEPTION_RETHROW
            WorkflowInstanceWrapper instance = manager.StartWorkflow(
                typeof(SharedWorkflows.ExceptionRethrowWorkflow), wfArguments);
#else
            WorkflowInstanceWrapper instance = manager.StartWorkflow(
                typeof(SharedWorkflows.ExceptionWorkflow), wfArguments);
#endif
            manager.WaitAll(5000);

            if (instance.Exception != null)
            {
                Console.WriteLine("EXCEPTION: {0}: {1}",
                    instance.Exception.GetType().Name,
                    instance.Exception.Message);
            }
        }
    }
}

