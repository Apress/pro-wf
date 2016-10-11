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
using System.Workflow.Runtime;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Compiler;

using Bukovics.Workflow.Hosting;
using SharedWorkflows;

namespace ConsoleDynamicUpdate
{
    /// <summary>
    /// Test the DynamicWorkflow 
    /// </summary>
    public class DynamicUpdateTest
    {
        private static Int32 _testNumber = 0;

        public static void Run()
        {
            using (WorkflowRuntimeManager manager
                = new WorkflowRuntimeManager(new WorkflowRuntime()))
            {
                manager.WorkflowRuntime.StartRuntime();

                //handle the WorkflowSuspended event
                manager.WorkflowRuntime.WorkflowSuspended
                    += new EventHandler<WorkflowSuspendedEventArgs>(
                        WorkflowRuntime_WorkflowSuspended);

                //
                //add a new activity to this workflow
                //
                Console.WriteLine("Executing DynamicWorkflow for 1001");
                Dictionary<String, Object> wfArguments
                    = new Dictionary<string, object>();
                _testNumber = 1001;
                wfArguments.Add("TestNumber", _testNumber);
#if UPDATES_RESTRICTED
                manager.StartWorkflow(
                    typeof(SharedWorkflows.DynamicRestrictedWorkflow), wfArguments);
#else
                manager.StartWorkflow(
                    typeof(SharedWorkflows.DynamicWorkflow), wfArguments);
#endif
                manager.WaitAll(5000);
                Console.WriteLine("Completed DynamicWorkflow for 1001\n\r");

                //
                //let this activity execute normally without changes
                //
                Console.WriteLine("Executing DynamicWorkflow for 2002");
                wfArguments.Clear();
                _testNumber = 2002;
                wfArguments.Add("TestNumber", _testNumber);
#if UPDATES_RESTRICTED
                manager.StartWorkflow(
                    typeof(SharedWorkflows.DynamicRestrictedWorkflow), wfArguments);
#else
                manager.StartWorkflow(
                    typeof(SharedWorkflows.DynamicWorkflow), wfArguments);
#endif
                manager.WaitAll(5000);
                Console.WriteLine("Completed DynamicWorkflow for 2002\n\r");

                //
                //remove the first activity from this worfklow
                //
                Console.WriteLine("Executing DynamicWorkflow for 3003");
                wfArguments.Clear();
                _testNumber = 3003;
                wfArguments.Add("TestNumber", _testNumber);
#if UPDATES_RESTRICTED
                manager.StartWorkflow(
                    typeof(SharedWorkflows.DynamicRestrictedWorkflow), wfArguments);
#else
                manager.StartWorkflow(
                    typeof(SharedWorkflows.DynamicWorkflow), wfArguments);
#endif
                manager.WaitAll(5000);
                Console.WriteLine("Completed DynamicWorkflow for 3003\n\r");
            }
        }

        /// <summary>
        /// A workflow instance has been suspended
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void WorkflowRuntime_WorkflowSuspended(
            object sender, WorkflowSuspendedEventArgs e)
        {
            //should we update the structure of the workflow?
            switch (_testNumber)
            {
                case 1001:
                    AddNewActivity(e.WorkflowInstance);
                    break;
                case 3003:
                    DeleteActivity(e.WorkflowInstance);
                    break;
                default:
                    break;
            }

            //resume execution of the workflow instance
            e.WorkflowInstance.Resume();
        }

        /// <summary>
        /// Add a new custom activity to the workflow instance
        /// </summary>
        /// <param name="instance"></param>
        private static void AddNewActivity(WorkflowInstance instance)
        {
            //create a workflow changes object
            WorkflowChanges wfChanges = new WorkflowChanges(
                instance.GetWorkflowDefinition());

            //find the SequenceActivity that is a placeholder
            //for new activities
            CompositeActivity placeholder
                = wfChanges.TransientWorkflow.GetActivityByName(
                    "sequencePlaceholder") as CompositeActivity;
            if (placeholder != null)
            {
                //create an instance of the new activity
                NewFunctionActivity newActivity
                    = new NewFunctionActivity();

                //bind the TestNumber property of the activity
                //to the TestNumber property of the workflow
#if UPDATES_RESTRICTED
                newActivity.SetBinding(
                    NewFunctionActivity.TestNumberProperty,
                    new ActivityBind("DynamicRestrictedWorkflow", "TestNumber"));
#else
                newActivity.SetBinding(
                    NewFunctionActivity.TestNumberProperty,
                    new ActivityBind("DynamicWorkflow", "TestNumber"));
#endif
                //add the new custom activity to the workflow
                placeholder.Activities.Add(newActivity);
                //apply the changes
                ValidateAndApplyChanges(instance, wfChanges);
            }
        }

        /// <summary>
        /// Delete an activity from the workflow instance
        /// </summary>
        /// <param name="instance"></param>
        private static void DeleteActivity(WorkflowInstance instance)
        {
            //create a workflow changes object
            WorkflowChanges wfChanges = new WorkflowChanges(
                instance.GetWorkflowDefinition());

            //find the activity we want to remove
            Activity activity =
                wfChanges.TransientWorkflow.GetActivityByName(
                    "codeFirstPart");
            if (activity != null)
            {
                //remove the activity from its parent
                activity.Parent.Activities.Remove(activity);
                //apply the changes
                ValidateAndApplyChanges(instance, wfChanges);
            }
        }

        /// <summary>
        /// Apply the changes
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="wfChanges"></param>
        private static void ValidateAndApplyChanges(
            WorkflowInstance instance, WorkflowChanges wfChanges)
        {
            //validate the structural changes before applying them
            ValidationErrorCollection errors = wfChanges.Validate();
            if (errors.Count == 0)
            {
                try
                {
                    //apply the changes to the workflow instance
                    instance.ApplyWorkflowChanges(wfChanges);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception applying changes: {0}",
                        e.Message);
                }
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


