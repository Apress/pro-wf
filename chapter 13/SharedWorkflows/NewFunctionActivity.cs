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
using System.Workflow.Activities;

namespace SharedWorkflows
{
    /// <summary>
    /// A custom activity that is dynamically added
    /// to a workflow instance
    /// </summary>
    public partial class NewFunctionActivity : Activity
    {
        public static DependencyProperty TestNumberProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
                "TestNumber", typeof(Int32), typeof(NewFunctionActivity));

        [Description("A simple number used for testing")]
        [Category("ProWF")]
        [Browsable(true)]
        [DesignerSerializationVisibility(
            DesignerSerializationVisibility.Visible)]
        public Int32 TestNumber
        {
            get
            {
                return ((Int32)(base.GetValue(
                    NewFunctionActivity.TestNumberProperty)));
            }
            set
            {
                base.SetValue(
                    NewFunctionActivity.TestNumberProperty, value);
            }
        }

        public NewFunctionActivity()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Display a message to prove that we executed
        /// </summary>
        /// <param name="executionContext"></param>
        /// <returns></returns>
        protected override ActivityExecutionStatus Execute(
            ActivityExecutionContext executionContext)
        {
            Console.WriteLine(
                "Executing the New Functionality for {0}", TestNumber);

            return base.Execute(executionContext);
        }
    }
}
