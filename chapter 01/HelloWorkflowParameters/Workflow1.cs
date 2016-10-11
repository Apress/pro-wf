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
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace HelloWorkflow
{
    public sealed partial class Workflow1 : SequentialWorkflowActivity
    {
        private String _person = String.Empty;
        private String _message = String.Empty;

        /// <summary>
        /// The target of the greeting
        /// </summary>
        public String Person
        {
            get { return _person; }
            set { _person = value; }
        }

        /// <summary>
        /// The greeting message
        /// </summary>
        public String Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public Workflow1()
        {
            InitializeComponent();
        }

        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
            //display the variable greeting
            Console.WriteLine("Hello {0}, {1}", _person, _message);
        }
    }
}
