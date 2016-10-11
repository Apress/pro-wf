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

//#region Using directives

//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading;
//using System.Workflow.Runtime;
//using System.Workflow.Runtime.Hosting;

//#endregion

//namespace CustomActivityComponents
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            using(WorkflowRuntime workflowRuntime = new WorkflowRuntime())
//            {
//                AutoResetEvent waitHandle = new AutoResetEvent(false);
//                workflowRuntime.WorkflowCompleted += delegate(object sender, WorkflowCompletedEventArgs e) {waitHandle.Set();};
//                workflowRuntime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs e)
//                {
//                    Console.WriteLine(e.Exception.Message);
//                    waitHandle.Set();
//                };

//                WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(CustomActivityComponents.Workflow1));
//                instance.Start();

//                waitHandle.WaitOne();
//            }
//        }
//    }
//}
