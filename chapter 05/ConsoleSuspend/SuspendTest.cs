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

namespace ConsoleSuspend
{
    /// <summary>
    /// Execute workflow with SuspendActivity
    /// </summary>
    public class SuspendTest
    {
        static Boolean isSuspended = false;

        public static void Run()
        {
            using (WorkflowRuntimeManager manager
                = new WorkflowRuntimeManager(new WorkflowRuntime()))
            {
                manager.MessageEvent 
                    += new EventHandler<WorkflowLogEventArgs>(manager_MessageEvent);
                manager.WorkflowRuntime.WorkflowSuspended
                    += new EventHandler<WorkflowSuspendedEventArgs>(WorkflowRuntime_WorkflowSuspended);


                Console.WriteLine("Executing Workflow1");
                WorkflowInstanceWrapper instance 
                    = manager.StartWorkflow(
                        typeof(ConsoleSuspend.Workflow1), null);
                manager.WaitAll(10000);

                if (isSuspended)
                {
                    instance.WorkflowInstance.Resume();
                }

                manager.WaitAll(1000);
                Console.WriteLine("Completed Workflow1\n\r");
            }
        }

        static void WorkflowRuntime_WorkflowSuspended(object sender, WorkflowSuspendedEventArgs e)
        {
            isSuspended = true;
        }

        static void manager_MessageEvent(object sender, WorkflowLogEventArgs e)
        {
            Console.WriteLine("{0}\n\r", e.Message);
        }
    }
}
