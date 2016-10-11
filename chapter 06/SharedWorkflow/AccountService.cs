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

namespace SharedWorkflows
{
    /// <summary>
    /// Provides account services to workflows
    /// </summary>
    public class AccountService : IAccountServices
    {
        private Dictionary<Int32, Account> _accounts
            = new Dictionary<int, Account>();

        public AccountService()
        {
            PopulateTestData();
        }

        #region IAccountServices Members

        /// <summary>
        /// Adjust the balance for an account
        /// </summary>
        /// <param name="id"></param>
        /// <param name="adjustment"></param>
        /// <returns></returns>
        public Account AdjustBalance(Int32 id, Double adjustment)
        {
            Account account = null;
            if (_accounts.ContainsKey(id))
            {
                account = _accounts[id];
                account.Balance += adjustment;
            }
            return account;
        }

        #endregion

        #region Generate Test Data

        private void PopulateTestData()
        {
            Account account = new Account();
            account.Id = 101;
            account.Name = "Neil Armstrong";
            account.Balance = 100.00;
            _accounts.Add(account.Id, account);

            account = new Account();
            account.Id = 102;
            account.Name = "Michael Collins";
            account.Balance = 99.95;
            _accounts.Add(account.Id, account);

            account = new Account();
            account.Id = 103;
            account.Name = "Buzz Aldrin";
            account.Balance = 0;
            _accounts.Add(account.Id, account);
        }

        #endregion
    }
}
