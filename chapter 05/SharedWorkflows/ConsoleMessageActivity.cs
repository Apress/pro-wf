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
using System.Workflow.ComponentModel;

namespace SharedWorkflows
{
    public partial class ConsoleMessageActivity : Activity
    {
        public static DependencyProperty MessageProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
            "Message", typeof(string), typeof(ConsoleMessageActivity));

        [Description("A String message to write to the Console")]
        [Category("Flow Control")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Message
        {
            get
            {
                return ((string)(base.GetValue(
                    ConsoleMessageActivity.MessageProperty)));
            }
            set
            {
                base.SetValue(ConsoleMessageActivity.MessageProperty, value);
            }
        }

        public ConsoleMessageActivity()
        {
            InitializeComponent();
        }

        protected override ActivityExecutionStatus Execute(
            ActivityExecutionContext executionContext)
        {
            //write the message
            if (Message != null)
            {
                Console.WriteLine(Message);
            }
            return base.Execute(executionContext);
        }

    }
}
