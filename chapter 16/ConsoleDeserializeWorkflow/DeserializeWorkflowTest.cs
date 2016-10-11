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
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;

using SharedWorkflows;

namespace ConsoleDeserializeWorkflow
{
    /// <summary>
    /// Workflow serialization and deserialization
    /// </summary>
    public class DeserializeWorkflowTest
    {
        public static void Run()
        {
            //deserialize the workflow from a markup file
            Activity workflow =
                DeserializeFromMarkup("SerializedCodedWorkflow.xoml");

            if (workflow != null)
            {
                //modify the workflow definition in code
                ModifyWorkflow(workflow);

                //serialize the new workflow to a markup file
                SerializeToMarkup(workflow,
                    "SerializedCodedWorkflowRevised.xoml");
            }
            else
            {
                Console.WriteLine("Unable to deserialize workflow");
            }
        }

        /// <summary>
        /// Deserialize a workflow from markup (xaml)
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static Activity DeserializeFromMarkup(String fileName)
        {
            Activity workflow = null;

            try
            {
                //add a TypeProvider to resolve SharedWorkflow references
                ServiceContainer container = new ServiceContainer();
                TypeProvider provider = new TypeProvider(container);
                //provider.AddAssemblyReference("SharedWorkflows.dll");
                provider.AddAssembly(
                    typeof(SharedWorkflows.MarkupOnlyBaseWorkflow).Assembly);
                container.AddService(typeof(ITypeProvider), provider);

                //add the ServiceContainer with the TypeProvider to 
                //a serialization manager
                DesignerSerializationManager dsm
                    = new DesignerSerializationManager(container);

                using (dsm.CreateSession())
                {
                    using (XmlReader xmlReader = XmlReader.Create(fileName))
                    {
                        //deserialize the workflow from the XmlReader
                        WorkflowMarkupSerializer markupSerializer
                            = new WorkflowMarkupSerializer();
                        workflow = markupSerializer.Deserialize(dsm, xmlReader)
                            as Activity;

                        if (dsm.Errors.Count > 0)
                        {
                            foreach (WorkflowMarkupSerializationException error
                                in dsm.Errors)
                            {
                                Console.WriteLine(
                                    "Deserialization error: {0}", error);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception during deserialization: {0}",
                    e.Message);
            }

            return workflow;
        }

        /// <summary>
        /// Modify the workflow definition in code
        /// </summary>
        /// <param name="workflow"></param>
        private static void ModifyWorkflow(Activity workflow)
        {
            //locate the activity to change
            WriteMessageActivity wmActivity
                = workflow.GetActivityByName("writeMessagePositive")
                    as WriteMessageActivity;
            if (wmActivity != null)
            {
                //change the message
                wmActivity.Message = "This is a revised message";
            }
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
    }
}
