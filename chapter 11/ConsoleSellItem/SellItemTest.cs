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

namespace ConsoleSellItem
{
    /// <summary>
    /// Test the SellItemWorkflow 
    /// </summary>
    public class SellItemTest
    {
        public static void Run()
        {
            using (WorkflowRuntimeManager manager
                = new WorkflowRuntimeManager(new WorkflowRuntime()))
            {
                manager.WorkflowRuntime.StartRuntime();

                //execute the workflow with parameters that will 
                //result in a normal priced item and shipping
                Console.WriteLine("Executing SellItemWorkflow");
                SalesItem item = new SalesItem();
                item.ItemPrice = 10.00;
                item.Quantity = 4;
                item.IsNewCustomer = false;
                ExecuteWorkflow(manager, item);
                Console.WriteLine("Completed SellItemWorkflow\n\r");

                //execute the workflow again with parameters that
                //will cause a discounted price and shipping
                Console.WriteLine("Executing SellItemWorkflow (Discounts)");
                item = new SalesItem();
                item.ItemPrice = 10.00;
                item.Quantity = 11;
                item.IsNewCustomer = false;
                ExecuteWorkflow(manager, item);
                Console.WriteLine("Completed SellItemWorkflow (Discounts)\n\r");

                //execute the workflow once more, this time with the 
                //IsNewCustomer property set to true
                Console.WriteLine("Executing SellItemWorkflow (New Customer)");
                item = new SalesItem();
                item.ItemPrice = 10.00;
                item.Quantity = 11;
                item.IsNewCustomer = true;
                ExecuteWorkflow(manager, item);
                Console.WriteLine("Completed SellItemWorkflow (New Customer)\n\r");
            }
        }

        /// <summary>
        /// Execute the SellItemWorkflow
        /// </summary>
        /// <param name="item"></param>
        private static void ExecuteWorkflow(
            WorkflowRuntimeManager manager, SalesItem item)
        {
            DisplaySalesItem(item, "Before");

            //create a dictionary with input arguments
            Dictionary<String, Object> wfArguments
                = new Dictionary<string, object>();
            wfArguments.Add("SalesItem", item);

            //execute the workflow
#if PRIORITY_TEST
            WorkflowInstanceWrapper instance = manager.StartWorkflow(
                typeof(SharedWorkflows.SellItemPriorityWorkflow), wfArguments);
#elif METHODS_TEST
            WorkflowInstanceWrapper instance = manager.StartWorkflow(
                typeof(SharedWorkflows.SellItemMethodsWorkflow), wfArguments);
#elif INVOKE_METHOD_TEST
            WorkflowInstanceWrapper instance = manager.StartWorkflow(
                typeof(SharedWorkflows.SellItemMethods2Workflow), wfArguments);
#elif UPDATE_TEST
            WorkflowInstanceWrapper instance = manager.StartWorkflow(
                typeof(SharedWorkflows.SellItemUpdateWorkflow), wfArguments);
#elif RULESET_IN_CODE_TEST
            WorkflowInstanceWrapper instance = manager.StartWorkflow(
                typeof(SharedWorkflows.SellItemInCodeWorkflow), wfArguments);
#elif SERIALIZED_RULESET_TEST
            WorkflowInstanceWrapper instance = manager.StartWorkflow(
                typeof(SharedWorkflows.SellItemSerializedWorkflow), wfArguments);
#else
            WorkflowInstanceWrapper instance = manager.StartWorkflow(
                typeof(SharedWorkflows.SellItemWorkflow), wfArguments);
#endif
            manager.WaitAll(5000);

            if (instance.Exception != null)
            {
                Console.WriteLine("EXCEPTION: {0}",
                    instance.Exception.Message);
            }
            else
            {
                DisplaySalesItem(item, "After");
            }
        }

        /// <summary>
        /// Display the contents of the SalesItem
        /// </summary>
        /// <param name="item"></param>
        /// <param name="message"></param>
        private static void DisplaySalesItem(SalesItem item, String message)
        {
            Console.WriteLine("{0}:", message);
            Console.WriteLine("  ItemPrice     = {0:C}", item.ItemPrice);
            Console.WriteLine("  Quantity      = {0}", item.Quantity);
            Console.WriteLine("  OrderTotal    = {0:C}", item.OrderTotal);
            Console.WriteLine("  Shipping      = {0:C}", item.Shipping);
            Console.WriteLine("  IsNewCustomer = {0}", item.IsNewCustomer);
        }
    }
}

