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
using System.Workflow.Activities;

using Bukovics.Workflow.Hosting;
using SharedWorkflows;

namespace ConsoleLocalServices
{
    public class LocalServiceTest
    {
        public static void Run()
        {
            using (WorkflowRuntimeManager manager
                = new WorkflowRuntimeManager(new WorkflowRuntime()))
            {
                //add services to the workflow runtime 
                AddServices(manager.WorkflowRuntime);
                manager.WorkflowRuntime.StartRuntime();

                //create a dictionary with input arguments
                Dictionary<String, Object> wfArguments
                    = new Dictionary<string, object>();

                //run the first workflow
                Console.WriteLine("Executing BalanceAdjustmentWorkflow");
                wfArguments.Add("Id", 101);
                wfArguments.Add("Adjustment", -25.00);
                WorkflowInstanceWrapper instance = manager.StartWorkflow(
                    typeof(SharedWorkflows.BalanceAdjustmentWorkflow),
                    wfArguments);
                manager.WaitAll(2000);

                Account account
                    = instance.OutputParameters["Account"] as Account;
                if (account != null)
                {
                    Console.WriteLine(
                        "Revised Account: {0}, Name={1}, Bal={2:C}",
                        account.Id, account.Name, account.Balance);
                }
                else
                {
                    Console.WriteLine("Invalid Account Id\n\r");
                }

                Console.WriteLine("Completed BalanceAdjustmentWorkflow\n\r");
            }
        }

        /// <summary>
        /// Add any services needed by the runtime engine
        /// </summary>
        /// <param name="instance"></param>
        private static void AddServices(WorkflowRuntime instance)
        {
            //add the external data exchange service to the runtime
            ExternalDataExchangeService exchangeService
                = new ExternalDataExchangeService();
            instance.AddService(exchangeService);

            //add our custom local service 
            //to the external data exchange service
            exchangeService.AddService(new AccountService());
        }
    }
}

