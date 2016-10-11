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
    /// <summary>
    /// A custom activity that writes a message to the Console
    /// </summary>
    public partial class WriteMessageActivity : Activity
    {
        public static DependencyProperty MessageProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
                "Message", typeof(String), typeof(WriteMessageActivity));

        [Description("A string message to write")]
        [Category("Pro Workflow")]
        [Browsable(true)]
        [DesignerSerializationVisibility(
            DesignerSerializationVisibility.Visible)]
        public String Message
        {
            get
            {
                return ((String)(base.GetValue(
                    WriteMessageActivity.MessageProperty)));
            }
            set
            {
                base.SetValue(
                    WriteMessageActivity.MessageProperty, value);
            }
        }

        public WriteMessageActivity()
        {
            InitializeComponent();
        }

        protected override ActivityExecutionStatus Execute(
            ActivityExecutionContext executionContext)
        {
            if (Message != null)
            {
                Console.WriteLine(Message);
            }
            return base.Execute(executionContext);
        }
    }
}
