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

namespace ConsoleAccountTransfer
{
    /// <summary>
    /// Test the AccountTransferWorkflow
    /// </summary>
    public class AccountTransferTest
    {
        public static void Run()
        {
            using (WorkflowRuntimeManager manager
                = new WorkflowRuntimeManager(new WorkflowRuntime()))
            {
                //configure services for the workflow runtime 
                AddServices(manager.WorkflowRuntime);
                manager.WorkflowRuntime.StartRuntime();

                //run the workflow using a transfer value that should work

                Console.WriteLine("Executing 1st AccountTransferWorkflow");
                DisplayTestData(1001, 2002, "before");

                //create a dictionary with input arguments
                Dictionary<String, Object> wfArguments
                    = new Dictionary<string, object>();
                wfArguments.Add("FromAccountId", 1001);
                wfArguments.Add("ToAccountId", 2002);
                wfArguments.Add("Amount", (Decimal)25.00);
                //start the workflow
                WorkflowInstanceWrapper instance = manager.StartWorkflow(
                    typeof(SharedWorkflows.AccountTransferWorkflow), wfArguments);
                manager.WaitAll(5000);
                if (instance.Exception != null)
                {
                    Console.WriteLine("EXCEPTION: {0}",
                        instance.Exception.Message);
                }
                DisplayTestData(1001, 2002, "after");
                Console.WriteLine("Completed 1st AccountTransferWorkflow\n\r");

                //run the workflow again using an amount that should fail

                Console.WriteLine("Executing 2nd AccountTransferWorkflow");
                DisplayTestData(1001, 2002, "before");

                wfArguments = new Dictionary<string, object>();
                wfArguments.Add("FromAccountId", 1001);
                wfArguments.Add("ToAccountId", 2002);
                //this transfer amount should exceed the available balance
                wfArguments.Add("Amount", (Decimal)200.00);
                instance = manager.StartWorkflow(
                    typeof(SharedWorkflows.AccountTransferWorkflow), wfArguments);
                manager.WaitAll(5000);
                if (instance.Exception != null)
                {
                    Console.WriteLine("EXCEPTION: {0}",
                        instance.Exception.Message);
                }
                DisplayTestData(1001, 2002, "after");
                Console.WriteLine("Completed 2nd AccountTransferWorkflow\n\r");
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

        #region Display Test Data

        /// <summary>
        /// Display the balances for the test accounts
        /// </summary>
        /// <param name="acctId1"></param>
        /// <param name="acctId2"></param>
        /// <param name="desc"></param>
        private static void DisplayTestData(
            Int32 acctId1, Int32 acctId2, String desc)
        {
            using (SqlConnection connection = new SqlConnection(
                ConfigurationManager.ConnectionStrings
                    ["ProWorkflow"].ConnectionString))
            {
                connection.Open();
                Decimal balance = GetCurrentBalance(connection, acctId1);
                Console.WriteLine("Balance {0} test for AccountId {1}: {2}",
                    desc, acctId1, balance);
                balance = GetCurrentBalance(connection, acctId2);
                Console.WriteLine("Balance {0} test for AccountId {1}: {2}",
                    desc, acctId2, balance);
                connection.Close();
            }
        }

        /// <summary>
        /// Get the balance for an account
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        private static Decimal GetCurrentBalance(
            SqlConnection connection, Int32 accountId)
        {
            Decimal balance = 0;
            String sql =
                @"select balance from account where accountId = @AccountId";

            //setup Sql command object
            SqlCommand command = new SqlCommand(sql);
            //setup parameters
            SqlParameter p = new SqlParameter("@AccountId", accountId);
            command.Parameters.Add(p);
            command.Connection = connection;

            Object result = command.ExecuteScalar();
            if (result != null)
            {
                balance = (Decimal)result;
            }

            return balance;
        }

        #endregion
    }
}

