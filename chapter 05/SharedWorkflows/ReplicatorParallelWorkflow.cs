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
    public sealed partial class ReplicatorParallelWorkflow :
        SequentialWorkflowActivity
    {
        public static DependencyProperty InputListProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
                "InputList", typeof(List<String>),
                typeof(ReplicatorParallelWorkflow));

        [Description("A list of strings to process")]
        [Category("Flow Control")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public List<String> InputList
        {
            get
            {
                return ((List<String>)(base.GetValue(
                    ReplicatorParallelWorkflow.InputListProperty)));
            }
            set
            {
                base.SetValue(
                    ReplicatorParallelWorkflow.InputListProperty, value);
            }
        }

        public ReplicatorParallelWorkflow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Executed as each child activity instance is initialized
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void replicatorActivity1_ChildInitialized(
            object sender, ReplicatorChildEventArgs e)
        {
            //ConsoleMessageActivity cma
            //    = ((SequenceActivity)e.Activity).Activities[0]
            //        as ConsoleMessageActivity;

            //find the activity that needs the input string
            ConsoleMessageActivity cma = e.Activity.GetActivityByName(
                "consoleMessageActivity1", true) as ConsoleMessageActivity;
            //pass the input parameter to the child activity
            if (cma != null)
            {
                cma.Message = e.InstanceData as String;
            }
        }
    }
}
