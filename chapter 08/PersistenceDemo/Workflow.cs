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

namespace PersistenceDemo
{
    /// <summary>
    /// Used for display of workflow status in a DataGridView
    /// </summary>
    public class Workflow
    {
        private Guid _instanceId = Guid.Empty;
        private String _statusMessage = String.Empty;
        private Boolean _isCompleted;

        public Guid InstanceId
        {
            get { return _instanceId; }
            set { _instanceId = value; }
        }

        public String StatusMessage
        {
            get { return _statusMessage; }
            set { _statusMessage = value; }
        }

        public Boolean IsCompleted
        {
            get { return _isCompleted; }
            set { _isCompleted = value; }
        }
    }
}
