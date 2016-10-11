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
using System.Reflection;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.Activities;

namespace SharedWorkflows
{
    /// <summary>
    /// Workflow that will be dynamically updated
    /// internally
    /// </summary>
    public sealed partial class SelfUpdatingWorkflow
        : SequentialWorkflowActivity
    {
        private Int32 _testNumber;
        private Type _newActivityType;
        private DependencyProperty _numberProperty;

        public Int32 TestNumber
        {
            get { return _testNumber; }
            set { _testNumber = value; }
        }

        public Type NewActivityType
        {
            get { return _newActivityType; }
            set { _newActivityType = value; }
        }

        public DependencyProperty NumberProperty
        {
            get { return _numberProperty; }
            set { _numberProperty = value; }
        }

        public SelfUpdatingWorkflow()
        {
            InitializeComponent();
        }

        private void codeFirstPart_ExecuteCode(
            object sender, EventArgs e)
        {
            Console.WriteLine(
                "Executing the First Part for TestNumber {0}", TestNumber);
        }

        private void codeLastPart_ExecuteCode(
            object sender, EventArgs e)
        {
            Console.WriteLine(
                "Executing the Last Part for TestNumber {0}", TestNumber);
        }

        /// <summary>
        /// Initialize a new workflow instance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorkflowInitialized(object sender, EventArgs e)
        {
            //should we update the structure of the workflow?
            if (NewActivityType != null)
            {
                AddNewActivity();
            }
        }

        /// <summary>
        /// Add a new custom activity to this workflow instance
        /// </summary>
        /// <param name="instance"></param>
        private void AddNewActivity()
        {
            //create an instance of the specified new activity
            if (NewActivityType != null && NumberProperty != null)
            {
                //create a workflow changes object
                WorkflowChanges wfChanges = new WorkflowChanges(this);

                //find the SequenceActivity that is a placeholder
                //for new activities
                CompositeActivity placeholder
                    = wfChanges.TransientWorkflow.GetActivityByName(
                        "sequencePlaceholder") as CompositeActivity;
                if (placeholder == null)
                {
                    return;
                }

                //construct an instance of the activity 
                //using reflection 
                ConstructorInfo ctor
                    = NewActivityType.GetConstructor(Type.EmptyTypes);
                Activity newActivity = ctor.Invoke(null) as Activity;

                //bind the TestNumber property of the activity
                //to the TestNumber property of the workflow
                newActivity.SetBinding(NumberProperty,
                    new ActivityBind(this.Name, "TestNumber"));

                //add the new custom activity to the workflow
                placeholder.Activities.Add(newActivity);

                //validate the structural changes before applying them
                ValidationErrorCollection errors = wfChanges.Validate();
                if (errors.Count == 0)
                {
                    //apply the changes to the workflow instance
                    this.ApplyWorkflowChanges(wfChanges);
                }
                else
                {
                    //the proposed changes are not valid
                    foreach (ValidationError error in errors)
                    {
                        Console.WriteLine(error.ToString());
                    }
                }
            }
        }
    }
}
