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
using System.Reflection;
using System.Collections.Generic;
using System.Drawing.Design;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Activities.Rules;

namespace WorkflowDesignerApp
{
    /// <summary>
    /// A workflow designer loader for markup and .rules files
    /// </summary>
    public class WorkflowLoader : WorkflowDesignerLoader
    {
        private String _markupFileName = String.Empty;
        private Type _newWorkflowType;
        private IToolboxService _toolboxService;
        private TypeProvider _typeProvider;
        private String _newWorkflowName = String.Empty;

        public String MarkupFileName
        {
            get { return _markupFileName; }
            set { _markupFileName = value; }
        }

        public Type NewWorkflowType
        {
            get { return _newWorkflowType; }
            set { _newWorkflowType = value; }
        }

        public String NewWorkflowName
        {
            get { return _newWorkflowName; }
            set { _newWorkflowName = value; }
        }

        public TypeProvider TypeProvider
        {
            get { return _typeProvider; }
            set { _typeProvider = value; }
        }

        #region Required implementations for abstract members

        public override string FileName
        {
            get { return _markupFileName; }
        }

        public override System.IO.TextReader GetFileReader(
            string filePath)
        {
            return null;
        }

        public override System.IO.TextWriter GetFileWriter(
            string filePath)
        {
            return null;
        }

        #endregion

        #region Initialization

        /// <summary>
        /// Initialize the workflow designer loader
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            //add any necessary services
            IDesignerLoaderHost host = LoaderHost;
            if (host != null)
            {
                //add the custom MenuCommandService 
                host.AddService(
                    typeof(IMenuCommandService),
                    new WorkflowMenuService(host));

                //add the TypeProvider 
                host.AddService(
                    typeof(ITypeProvider), _typeProvider, true);

                //add the toolbox service
                _toolboxService = new WorkflowToolboxService(host);
                host.AddService(
                    typeof(IToolboxService), _toolboxService);

                //add the property value UI service
                host.AddService(
                    typeof(IPropertyValueUIService),
                    new WorkflowPropertyValueService());

                //add the event binding service
                host.AddService(
                    typeof(IEventBindingService),
                    new WorkflowEventBindingService(host));
            }
        }

        #endregion

        #region Load the markup and add activities to the designer

        /// <summary>
        /// Load the markup file and add the workflow to the designer
        /// </summary>
        /// <param name="serializationManager"></param>
        protected override void PerformLoad(
            IDesignerSerializationManager serializationManager)
        {
            base.PerformLoad(serializationManager);
            Activity workflow = null;

            if (!String.IsNullOrEmpty(MarkupFileName))
            {
                //load a workflow from markup
                workflow = DeserializeFromMarkup(MarkupFileName);
            }
            else if (NewWorkflowType != null)
            {
                //create a new workflow
                workflow = CreateNewWorkflow(
                    NewWorkflowType, NewWorkflowName);
            }

            if (workflow != null)
            {
                IDesignerHost designer
                    = (IDesignerHost)GetService(typeof(IDesignerHost));
                //add the workfow definition to the designer
                AddWorkflowToDesigner(designer, workflow);
                //activate the designer
                designer.Activate();
            }
        }

        /// <summary>
        /// Deserialize the markup file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private Activity DeserializeFromMarkup(String fileName)
        {
            Activity workflow = null;

            //construct a serialization manager.
            DesignerSerializationManager dsm
                = new DesignerSerializationManager();
            using (dsm.CreateSession())
            {
                using (XmlReader xmlReader
                    = XmlReader.Create(fileName))
                {
                    //deserialize the workflow from the XmlReader
                    WorkflowMarkupSerializer markupSerializer
                        = new WorkflowMarkupSerializer();
                    workflow = markupSerializer.Deserialize(
                        dsm, xmlReader) as Activity;

                    if (dsm.Errors.Count > 0)
                    {
                        WorkflowMarkupSerializationException error
                            = dsm.Errors[0]
                              as WorkflowMarkupSerializationException;
                        throw error;
                    }
                }

                //deserialize a .rules file is one exists
                String rulesFileName = GetRulesFileName(fileName);
                if (File.Exists(rulesFileName))
                {
                    //read the .rules file
                    using (XmlReader xmlReader
                        = XmlReader.Create(rulesFileName))
                    {
                        WorkflowMarkupSerializer markupSerializer
                            = new WorkflowMarkupSerializer();
                        //deserialize the rule definitions
                        RuleDefinitions ruleDefinitions
                            = markupSerializer.Deserialize(dsm, xmlReader)
                                as RuleDefinitions;
                        if (ruleDefinitions != null)
                        {
                            //add the rules definitions to the workflow
                            workflow.SetValue(
                                RuleDefinitions.RuleDefinitionsProperty,
                                ruleDefinitions);
                        }
                    }
                }
            }

            return workflow;
        }

        /// <summary>
        /// Determine the name of the .rules file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static String GetRulesFileName(String fileName)
        {
            String rulesFileName = Path.Combine(
                Path.GetDirectoryName(fileName),
                Path.GetFileNameWithoutExtension(fileName) + ".rules");
            return rulesFileName;
        }

        /// <summary>
        /// Create a new workflow using the specified Type
        /// </summary>
        /// <param name="workflowType"></param>
        /// <returns></returns>
        private Activity CreateNewWorkflow(Type workflowType,
            String newWorkflowName)
        {
            Activity workflow = null;

            ConstructorInfo cstr
                = workflowType.GetConstructor(Type.EmptyTypes);
            if (cstr != null)
            {
                workflow = cstr.Invoke(new Object[] { }) as Activity;
                workflow.Name = newWorkflowName;
                //set a default file name
                _markupFileName = newWorkflowName + ".xoml";
            }
            return workflow;
        }

        /// <summary>
        /// Add the workflow definition to the designer
        /// </summary>
        /// <param name="designer"></param>
        /// <param name="workflow"></param>
        private static void AddWorkflowToDesigner(
            IDesignerHost designer, Activity workflow)
        {
            //add the root activity to the designer
            designer.Container.Add(workflow, workflow.QualifiedName);

            //add any child activities
            if (workflow is CompositeActivity)
            {
                List<Activity> children = new List<Activity>();
                //get a collection of all child activities
                GetChildActivities(
                    workflow as CompositeActivity, children);
                foreach (Activity child in children)
                {
                    designer.Container.Add(child, child.QualifiedName);
                }
            }
        }

        /// <summary>
        /// Recursively get a collection of all child activities
        /// </summary>
        /// <param name="composite"></param>
        /// <param name="children"></param>
        private static void GetChildActivities(
            CompositeActivity composite, List<Activity> children)
        {
            foreach (Activity activity in composite.Activities)
            {
                children.Add(activity);
                if (activity is CompositeActivity)
                {
                    //make recursive call
                    GetChildActivities(
                        activity as CompositeActivity, children);
                }
            }
        }

        #endregion

        #region Cleanup methods

        /// <summary>
        /// Remove the workflow from the designer
        /// </summary>
        /// <param name="designer"></param>
        /// <param name="workflow"></param>
        public void RemoveFromDesigner(IDesignerHost designer,
            Activity workflow)
        {
            if (workflow != null)
            {
                designer.DestroyComponent(workflow);
                if (workflow is CompositeActivity)
                {
                    List<Activity> children = new List<Activity>();
                    //remove all child activities
                    GetChildActivities(
                        workflow as CompositeActivity, children);
                    foreach (Activity child in children)
                    {
                        designer.DestroyComponent(child);
                    }
                }
            }
        }

        #endregion

        #region Save the workflow design to a markup file

        /// <summary>
        /// Flush the current workflow model to a xoml file
        /// </summary>
        public override void Flush()
        {
            PerformFlush(null);
        }

        /// <summary>
        /// Write the current workflow model to a xoml file
        /// </summary>
        /// <param name="serializationManager"></param>
        protected override void PerformFlush(
            IDesignerSerializationManager serializationManager)
        {
            base.PerformFlush(serializationManager);

            //get the designer
            IDesignerHost designer
                = (IDesignerHost)GetService(typeof(IDesignerHost));

            //get the root activity of the workflow
            Activity workflow = designer.RootComponent as Activity;

            //serialize to a markup file
            if (workflow != null)
            {
                SerializeToMarkup(workflow, _markupFileName);
            }
        }

        /// <summary>
        /// Serialize the workflow to a xoml file
        /// </summary>
        /// <param name="workflow"></param>
        /// <param name="fileName"></param>
        private void SerializeToMarkup(
            Activity workflow, String fileName)
        {
            //clear the class name property since we are 
            //never creating a new class type.
            workflow.SetValue(
                WorkflowMarkupSerializer.XClassProperty, null);

            using (XmlWriter xmlWriter = XmlWriter.Create(fileName))
            {
                WorkflowMarkupSerializer markupSerializer
                    = new WorkflowMarkupSerializer();
                markupSerializer.Serialize(xmlWriter, workflow);
            }

            //Serialize rules if they exist
            RuleDefinitions ruleDefinitions = workflow.GetValue(
                RuleDefinitions.RuleDefinitionsProperty)
                    as RuleDefinitions;
            if (ruleDefinitions != null)
            {
                if (ruleDefinitions.Conditions.Count > 0 ||
                    ruleDefinitions.RuleSets.Count > 0)
                {
                    String rulesFileName = GetRulesFileName(fileName);
                    using (XmlWriter xmlWriter
                        = XmlWriter.Create(rulesFileName))
                    {
                        WorkflowMarkupSerializer markupSerializer
                            = new WorkflowMarkupSerializer();
                        markupSerializer.Serialize(
                            xmlWriter, ruleDefinitions);
                    }
                }
            }
        }

        #endregion
    }
}
