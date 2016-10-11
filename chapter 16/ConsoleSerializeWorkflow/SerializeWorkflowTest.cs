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
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Workflow.Activities;
using System.Workflow.Runtime;
#if COMPILE_RULES_WORKFLOW
using System.Workflow.Activities.Rules;
#endif
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;

using Bukovics.Workflow.Hosting;
using SharedWorkflows;

namespace ConsoleSerializeWorkflow
{
    /// <summary>
    /// Create a workflow in code and serialize it to markup
    /// </summary>
    public class SerializeWorkflowTest
    {
        public static void Run()
        {
            //create a workflow in code
            Activity workflow = CreateWorkflowInCode();

            //serialize the new workflow to a markup file
            SerializeToMarkup(workflow, "SerializedCodedWorkflow.xoml");

#if COMPILE_WORKFLOW
            //create a new assembly containing the workflow
            CompileWorkflow("SerializedCodedWorkflow.xoml",
                "MyNewAssembly.dll");
#endif

            using (WorkflowRuntimeManager manager
                = new WorkflowRuntimeManager(new WorkflowRuntime()))
            {
                //start the runtime 
                manager.WorkflowRuntime.StartRuntime();

                Console.WriteLine("Executing Workflow");
                Dictionary<String, Object> wfArguments
                    = new Dictionary<string, object>();
                wfArguments.Add("TheNumber", 1);

                try
                {
#if COMPILE_WORKFLOW
                    //get a Type object for the newly compiled workflow
                    Type workflowType = Type.GetType(
                        "ProWF.MyNewWorkflowClass,MyNewAssembly");
                    //start the workflow using the Type
                    WorkflowInstanceWrapper instance =
                        manager.StartWorkflow(workflowType, wfArguments);
#else
                    //start the workflow
                    WorkflowInstanceWrapper instance =
                        manager.StartWorkflow(
                            "SerializedCodedWorkflow.xoml",
                            null, wfArguments);
#endif
                }
#if !COMPILE_WORKFLOW
                catch (WorkflowValidationFailedException e)
                {
                    foreach (ValidationError error in e.Errors)
                    {
                        Console.WriteLine(error.ErrorText);
                    }
                }
#endif
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                //wait for the workflow to complete
                manager.WaitAll(2000);
                Console.WriteLine("Completed Workflow\n\r");
            }
        }

        /// <summary>
        /// Create a workflow by hand
        /// </summary>
        /// <returns></returns>
        private static Activity CreateWorkflowInCode()
        {
            MarkupOnlyBaseWorkflow workflow = null;

            //create the root workflow object
            workflow = new MarkupOnlyBaseWorkflow();
            workflow.Name = "CodedWorkflow";

            //create an IfElseActivity
            IfElseActivity ifElse
                = new IfElseActivity("ifElseActivity1");

            //
            //Add the left side branch to the IfElseActivity
            //
            IfElseBranchActivity branch
                = new IfElseBranchActivity("ifElseBranchActivity1");
#if COMPILE_RULES_WORKFLOW
            //add a rule condition to the branch
            RuleConditionReference ruleCondition
                = new RuleConditionReference();
            ruleCondition.ConditionName = "IsNumberPositive";
            branch.Condition = ruleCondition;
#else
            //add a condition to the branch
            CodeCondition condition = new CodeCondition();
            //bind the ConditionEvent to the IsNumberPositive member
            ActivityBind bind = new ActivityBind(
                "CodedWorkflow", "IsNumberPositive");
            condition.SetBinding(CodeCondition.ConditionEvent, bind);
            branch.Condition = condition;
#endif
            //add a custom WriteMessageActivity to the branch
            WriteMessageActivity writeMessage = new WriteMessageActivity();
            writeMessage.Name = "writeMessagePositive";
            writeMessage.Message = "The number is positive";
            branch.Activities.Add(writeMessage);
            //add the branch to the IfElseActivity
            ifElse.Activities.Add(branch);

            //
            //add the right side branch to the IfElseActivity
            //
            branch = new IfElseBranchActivity("ifElseBranchActivity2");
            //add a custom WriteMessageActivity to the branch
            writeMessage = new WriteMessageActivity();
            writeMessage.Name = "writeMessageNotPositive";
            writeMessage.Message = "The number is NOT positive";
            branch.Activities.Add(writeMessage);
            //add the branch to the IfElseActivity
            ifElse.Activities.Add(branch);

            //add the IfElseActivity to the workflow
            workflow.Activities.Add(ifElse);

#if COMPILE_WORKFLOW
            //provide a class name for the new workflow
            workflow.SetValue(WorkflowMarkupSerializer.XClassProperty,
                "ProWF.MyNewWorkflowClass");
#endif
            return workflow;
        }

        /// <summary>
        /// Serialize a workflow to markup (xaml)
        /// </summary>
        /// <param name="workflow"></param>
        /// <param name="fileName"></param>
        private static void SerializeToMarkup(
            Activity workflow, String fileName)
        {
            try
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(fileName))
                {
                    WorkflowMarkupSerializer markupSerializer
                        = new WorkflowMarkupSerializer();
                    markupSerializer.Serialize(xmlWriter, workflow);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception during serialization: {0}",
                    e.Message);
            }
        }

#if COMPILE_WORKFLOW
        private static void CompileWorkflow(
            String fileName, String assemblyName)
        {
            WorkflowCompiler compiler = new WorkflowCompiler();
            WorkflowCompilerParameters parameters
                = new WorkflowCompilerParameters();
            parameters.OutputAssembly = assemblyName;
            parameters.ReferencedAssemblies.Add("SharedWorkflows.dll");
#if COMPILE_RULES_WORKFLOW
            //add the .rules file for this workflow as a resource
            parameters.EmbeddedResources.Add("ProWF.MyNewWorkflowClass.rules");
#endif
            WorkflowCompilerResults results
                = compiler.Compile(parameters, fileName);
            if (results.Errors.Count > 0)
            {
                foreach (System.CodeDom.Compiler.CompilerError error
                    in results.Errors)
                {
                    Console.WriteLine("Compiler error: Line{0}: {1}",
                        error.Line, error.ErrorText);
                }
            }
        }
#endif

    }
}
