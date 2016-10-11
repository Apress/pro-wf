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
using System.Collections;
using System.Workflow.Runtime;
using System.Transactions;

namespace SharedWorkflows
{
    /// <summary>
    /// A local service that demonstrates IPendingWork
    /// </summary>
    public class BatchedService : IBatchedServices, IPendingWork
    {
        #region IBatchedServices Members

        /// <summary>
        /// Method invoked by the workflow to perform work
        /// </summary>
        /// <param name="message"></param>
        public void DoSomeWork(string message)
        {
            //add the requested work to current batch of work
            //for the current workfow
            WorkflowEnvironment.WorkBatch.Add(this, message);
        }

        #endregion

        #region IPendingWork Members

        /// <summary>
        /// Commit the collection of work items
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="items"></param>
        public void Commit(Transaction transaction, ICollection items)
        {
            foreach (Object item in items)
            {
                Console.WriteLine("Commiting: {0}", item.ToString());
            }
        }

        /// <summary>
        /// Called at the end of the Transaction to notify us
        /// of success or failure of the transaction.
        /// </summary>
        /// <param name="succeeded"></param>
        /// <param name="items"></param>
        public void Complete(bool succeeded, ICollection items)
        {
            if (succeeded)
            {
                Console.WriteLine("Complete: Transaction succeeded");
            }
            else
            {
                Console.WriteLine(
                    "Complete: Transaction aborted. Need to rollback");
                foreach (Object item in items)
                {
                    Console.WriteLine("Rolling Back: {0}", item.ToString());
                }
            }
        }

        /// <summary>
        /// Tells the workflow runtime that the collection of work
        /// items should be committed now at the current commit point.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public bool MustCommit(ICollection items)
        {
            Console.WriteLine("Returning true for MustCommit");
            return true;
        }

        #endregion
    }
}
