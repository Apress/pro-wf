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
using System.Configuration;  //need assembly reference
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Runtime.Hosting;

using Bukovics.Workflow.Hosting;
using SharedWorkflows;

namespace ConsoleOrderEntry
{
    /// <summary>
    /// Test the OrderEntryWorkflow
    /// </summary>
    public class OrderEntryTest
    {
        public static void Run()
        {
            using (WorkflowRuntimeManager manager
                = new WorkflowRuntimeManager(new WorkflowRuntime()))
            {
                //configure services for the workflow runtime 
                AddServices(manager.WorkflowRuntime);
                manager.WorkflowRuntime.StartRuntime();

                Console.WriteLine("Executing OrderEntryWorkflow");
                //create a dictionary with input arguments
                Dictionary<String, Object> wfArguments
                    = new Dictionary<string, object>();
                wfArguments.Add("OrderId", 1234);
                wfArguments.Add("OrderAccountId", 1001);
                wfArguments.Add("ToAccountId", 9000);
                wfArguments.Add("ItemId", 52);
                wfArguments.Add("Quantity", 2);
                wfArguments.Add("Amount", (Decimal)225.00);
                //start the workflow
                WorkflowInstanceWrapper instance = manager.StartWorkflow(
                    typeof(SharedWorkflows.OrderEntryWorkflow), wfArguments);
                manager.WaitAll(20000);
                if (instance.Exception != null)
                {
                    Console.WriteLine("EXCEPTION: {0}",
                        instance.Exception.Message);
                }
                Console.WriteLine("Completed OrderEntryWorkflow\n\r");
            }
        }

        /// <summary>
        /// Add any services needed by the runtime engine
        /// </summary>
        /// <param name="instance"></param>
        private static void AddServices(WorkflowRuntime instance)
        {
            //use the standard SQL Server persistence service
            SqlWorkflowPersistenceService persistence =
                new SqlWorkflowPersistenceService(
                    ConfigurationManager.ConnectionStrings
                        ["WorkflowPersistence"].ConnectionString,
                    true, new TimeSpan(0, 2, 0), new TimeSpan(0, 0, 5));
            instance.AddService(persistence);
        }
    }
}

