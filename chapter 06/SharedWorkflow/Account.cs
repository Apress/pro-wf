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

namespace SharedWorkflows
{
    /// <summary>
    /// Defines an account
    /// </summary>
    [Serializable]
    public class Account
    {
        private Int32 _id;
        private String _name = String.Empty;
        private Double _balance;

        public Int32 Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Double Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }
    }
}
