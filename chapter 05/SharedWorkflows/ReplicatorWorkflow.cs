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
using System.Collections.Generic;

namespace SharedWorkflows
{
    public sealed partial class ReplicatorWorkflow : SequentialWorkflowActivity
    {
        public static DependencyProperty InputListProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
                "InputList", typeof(List<String>), typeof(ReplicatorWorkflow));

        [Description("A list of strings to process")]
        [Category("Flow Control")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public List<String> InputList
        {
            get
            {
                return ((List<String>)(base.GetValue(
                    ReplicatorWorkflow.InputListProperty)));
            }
            set
            {
                base.SetValue(ReplicatorWorkflow.InputListProperty, value);
            }
        }

        public ReplicatorWorkflow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handler for the CodeActivity that is replicated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
            Object data = String.Empty;
            if (sender is Activity)
            {
                //retrieve the instance data from the parent activity
                if (((Activity)sender).Parent is ReplicatorActivity)
                {
                    ReplicatorActivity rep
                        = ((Activity)sender).Parent as ReplicatorActivity;
                    data = rep.InitialChildData[rep.CurrentIndex];
                }
            }
            Console.WriteLine("CodeActivity instance data:  {0}", data);
        }
    }
}
