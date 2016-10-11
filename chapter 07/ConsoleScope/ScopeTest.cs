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
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Activities;

using Bukovics.Workflow.Hosting;
using SharedWorkflows;

namespace ConsoleScope
{
    /// <summary>
    /// Test the ScopeExampleWorkflow
    /// </summary>
    public class ScopeTest
    {
        private static ScopeExampleService _scopeService;

        public static void Run()
        {
            using (WorkflowRuntimeManager manager
                = new WorkflowRuntimeManager(new WorkflowRuntime()))
            {
                //add services to the workflow runtime 
                AddServices(manager.WorkflowRuntime);
                manager.WorkflowRuntime.StartRuntime();

                //start the workflow
                Console.WriteLine("Executing ScopeExampleWorkflow");
                manager.StartWorkflow(
                    typeof(SharedWorkflows.ScopeExampleWorkflow), null);

                //allow the main line of the workflow to execute
                Thread.Sleep(3000);
                //fire some events
                _scopeService.OnEventOne();
                Thread.Sleep(100);
                _scopeService.OnEventOne();
                Thread.Sleep(100);
                _scopeService.OnEventOne();
                Thread.Sleep(100);
                _scopeService.OnEventTwo();
                Thread.Sleep(100);
                _scopeService.OnEventOne();
                //let the main line execute by itself again
                Thread.Sleep(3000);
                //signal that the workflow should stop
                _scopeService.OnEventStop();

                manager.WaitAll(10000);

                Console.WriteLine("Completed ScopeExampleWorkflow\n\r");
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
            _scopeService = new ScopeExampleService();
            exchangeService.AddService(_scopeService);
        }
    }
}

