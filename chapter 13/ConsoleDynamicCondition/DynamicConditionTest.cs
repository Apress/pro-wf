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
using System.Workflow.Activities.Rules;

#if DYNAMIC_RULE
using System.IO;
using System.Xml;
using System.Workflow.ComponentModel.Serialization;
#else
using System.CodeDom;
#endif

using Bukovics.Workflow.Hosting;
using SharedWorkflows;

namespace ConsoleDynamicCondition
{
    /// <summary>
    /// Test the DynamicConditionWorkflow 
    /// </summary>
    public class DynamicConditionTest
    {
        private static Boolean _firstWorkflow = true;

        public static void Run()
        {
            using (WorkflowRuntimeManager manager
                = new WorkflowRuntimeManager(new WorkflowRuntime()))
            {
                manager.WorkflowRuntime.StartRuntime();

                //handle the WorkflowCreated event
                manager.WorkflowRuntime.WorkflowCreated
                    += new EventHandler<WorkflowEventArgs>(
                        WorkflowRuntime_WorkflowCreated);

                //
                //modify the rule for this workflow
                //
                Console.WriteLine("Executing DynamicConditionWorkflow - 1st");
                Dictionary<String, Object> wfArguments
                    = new Dictionary<string, object>();
                wfArguments.Add("TestNumber", 200);
                manager.StartWorkflow(
                    typeof(SharedWorkflows.DynamicConditionWorkflow), wfArguments);
                manager.WaitAll(5000);
                Console.WriteLine("Completed DynamicConditionWorkflow - 1st\n\r");

                //
                //let this activity execute normally without changes
                //
                Console.WriteLine("Executing DynamicConditionWorkflow - 2nd");
                wfArguments.Clear();
                wfArguments.Add("TestNumber", 200);
                manager.StartWorkflow(
                    typeof(SharedWorkflows.DynamicConditionWorkflow), wfArguments);
                manager.WaitAll(5000);
                Console.WriteLine("Completed DynamicConditionWorkflow - 2nd\n\r");
            }
        }

        /// <summary>
        /// A workflow was created but not yet started
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void WorkflowRuntime_WorkflowCreated(
            object sender, WorkflowEventArgs e)
        {
            //should we update the workflow?
            if (_firstWorkflow)
            {
#if DYNAMIC_RULE
                ReplaceRuleDefinition(e.WorkflowInstance);
#else
                ModifyRuleCondition(e.WorkflowInstance);
#endif
                _firstWorkflow = false;
            }
        }

#if DYNAMIC_RULE
        /// <summary>
        /// Replace the entire rule definition for a workflow
        /// </summary>
        /// <param name="instance"></param>
        private static void ReplaceRuleDefinition(WorkflowInstance instance)
        {
            //create a workflow changes object
            WorkflowChanges wfChanges = new WorkflowChanges(
                instance.GetWorkflowDefinition());

            //get a stream from an externally saved .rules file
            Stream stream
                = new FileStream(@"ModifiedRule.rules",
                    FileMode.Open, FileAccess.Read, FileShare.Read);
            //read the .rules file using an XmlReader
            using (XmlReader xmlReader = XmlReader.Create(
                new StreamReader(stream)))
            {
                WorkflowMarkupSerializer markupSerializer
                    = new WorkflowMarkupSerializer();
                //deserialize the rule definitions
                RuleDefinitions ruleDefinitions
                    = markupSerializer.Deserialize(xmlReader) 
                        as RuleDefinitions;
                if (ruleDefinitions != null)
                {
                    //replace the embedded rules definition 
                    //with the new one that was deserialzed from a file
                    wfChanges.TransientWorkflow.SetValue(
                        RuleDefinitions.RuleDefinitionsProperty,
                        ruleDefinitions);

                    ValidateAndApplyChanges(instance, wfChanges);
                }
            }
        }
#else
        /// <summary>
        /// Modify a single rule condition
        /// </summary>
        /// <param name="instance"></param>
        private static void ModifyRuleCondition(WorkflowInstance instance)
        {
            //create a workflow changes object
            WorkflowChanges wfChanges = new WorkflowChanges(
                instance.GetWorkflowDefinition());

            //retrieve the RuleDefinitions for the workflow
            RuleDefinitions ruleDefinitions
                = (RuleDefinitions)wfChanges.TransientWorkflow.GetValue(
                    RuleDefinitions.RuleDefinitionsProperty);

            if (ruleDefinitions != null)
            {
                if (ruleDefinitions.Conditions.Contains("conditionOne"))
                {
                    //retrieve the rule that we want to change
                    RuleExpressionCondition condition
                        = ruleDefinitions.Conditions["conditionOne"]
                            as RuleExpressionCondition;

                    //change the rule by setting the right side of the
                    //operation to 300 instead of the original value of 100.
                    //was:  this.TestNumber > 100
                    //now:  this.TestNumber > 300
                    CodeBinaryOperatorExpression codeExpression =
                        condition.Expression as CodeBinaryOperatorExpression;
                    codeExpression.Right = new CodePrimitiveExpression(300);

                    ValidateAndApplyChanges(instance, wfChanges);
                }
            }
        }
#endif

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


