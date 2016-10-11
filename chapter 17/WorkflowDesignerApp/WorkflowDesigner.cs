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
using System.Collections;
using System.Windows.Forms;
using System.Drawing.Design;
using System.ComponentModel.Design;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;

namespace WorkflowDesignerApp
{
    /// <summary>
    /// Implement a workflow designer control
    /// </summary>
    public partial class WorkflowDesigner : UserControl
    {
        private WorkflowLoader _wfLoader = new WorkflowLoader();
        private WorkflowView _workflowView;
        private Control _toolboxControl;

        private DesignSurface _designSurface;
        private TypeProvider _typeProvider;

        public WorkflowDesigner()
        {
            InitializeComponent();
        }

        public Control ToolboxControl
        {
            get { return _toolboxControl; }
        }

        public TypeProvider TypeProvider
        {
            get { return _typeProvider; }
            set
            {
                _typeProvider = value;
                //pass the TypeProvider to the loader
                _wfLoader.TypeProvider = _typeProvider;
            }
        }

        /// <summary>
        /// Load a markup file into the designer
        /// </summary>
        /// <param name="markupFileName"></param>
        /// <returns></returns>
        public Boolean LoadWorkflow(String markupFileName)
        {
            //remove the current workflow from the designer
            //if there is one
            ClearWorkflow();

            //create the design surface
            _designSurface = new DesignSurface();

            //pass the markup file name to the loader
            _wfLoader.MarkupFileName = markupFileName;
            _wfLoader.NewWorkflowType = null;

            //complete the loading
            return CommonWorkflowLoading();
        }

        /// <summary>
        /// Create a new workflow using the specified Type
        /// </summary>
        /// <param name="workflowType"></param>
        /// <returns></returns>
        public Boolean CreateNewWorkflow(Type workflowType,
            String newWorkflowName)
        {
            //remove the current workflow from the designer
            //if there is one
            ClearWorkflow();

            //create the design surface
            _designSurface = new DesignSurface();

            //pass the new workflow type to the loader
            _wfLoader.MarkupFileName = String.Empty;
            _wfLoader.NewWorkflowType = workflowType;
            _wfLoader.NewWorkflowName = newWorkflowName;

            //complete the creation of a new workflow
            return CommonWorkflowLoading();
        }

        /// <summary>
        /// Finish the process of loading an existing
        /// or new workflow
        /// </summary>
        /// <returns></returns>
        private Boolean CommonWorkflowLoading()
        {
            Boolean result = false;

            //tell the designer to begin loading
            _designSurface.BeginLoad(_wfLoader);

            //retrieve the designer host 
            IDesignerHost designer
                = _designSurface.GetService(typeof(IDesignerHost))
                    as IDesignerHost;
            if (designer == null || designer.RootComponent == null)
            {
                return false;
            }

            IRootDesigner rootDesigner
                = designer.GetDesigner(designer.RootComponent)
                    as IRootDesigner;
            if (rootDesigner != null)
            {
                SuspendLayout();
                //get the default workflow view from the designer
                _workflowView = rootDesigner.GetView(
                    ViewTechnology.Default)
                        as WorkflowView;
                //add the workflow view to a panel for display
                splitContainer1.Panel2.Controls.Add(_workflowView);
                _workflowView.Dock = DockStyle.Fill;
                _workflowView.Focus();

                //link the propertyGrid with the designer
                propertyGrid1.Site = designer.RootComponent.Site;

                //setup the toolbar for the workflow using the one
                //constructed by the workflow loader
                IToolboxService toolboxService = designer.GetService(
                    typeof(IToolboxService)) as IToolboxService;
                if (toolboxService != null)
                {
                    if (toolboxService is Control)
                    {
                        //add the toolbox control to a panel
                        _toolboxControl = (Control)toolboxService;
                        splitContainer2.Panel1.Controls.Add(
                            _toolboxControl);
                    }
                }

                //get the ISelectionService from the workflow view 
                //and add a handler for the SelectionChanged event
                ISelectionService selectionService
                    = ((IServiceProvider)_workflowView).GetService(
                        typeof(ISelectionService)) as ISelectionService;
                if (selectionService != null)
                {
                    selectionService.SelectionChanged += new EventHandler(
                        selectionService_SelectionChanged);
                }

                ResumeLayout();
                result = true;
            }
            return result;
        }

        /// <summary>
        /// The selected object in the workflow view has changed, 
        /// so update the properties grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectionService_SelectionChanged(
            object sender, EventArgs e)
        {
            ISelectionService selectionService
                = ((IServiceProvider)_workflowView).GetService(
                    typeof(ISelectionService)) as ISelectionService;
            if (selectionService != null)
            {
                propertyGrid1.SelectedObjects = new ArrayList(
                    selectionService.GetSelectedComponents()).ToArray();
            }
        }

        /// <summary>
        /// Save the current workflow
        /// </summary>
        /// <param name="markupFileName"></param>
        /// <returns></returns>
        public Boolean SaveWorkflow(String markupFileName)
        {
            _wfLoader.MarkupFileName = markupFileName;
            _designSurface.Flush();
            return true;
        }

        /// <summary>
        /// Remove the current workflow from the designer
        /// </summary>
        private void ClearWorkflow()
        {
            if (_designSurface != null)
            {
                IDesignerHost designer = _designSurface.GetService(
                    typeof(IDesignerHost)) as IDesignerHost;
                if (designer != null)
                {
                    if (designer.Container.Components.Count > 0)
                    {
                        _wfLoader.RemoveFromDesigner(designer,
                            designer.RootComponent as Activity);
                    }
                }
            }

            if (_designSurface != null)
            {
                _designSurface.Dispose();
                _designSurface = null;
            }

            if (_workflowView != null)
            {
                ISelectionService selectionService
                    = ((IServiceProvider)_workflowView).GetService(
                        typeof(ISelectionService)) as ISelectionService;
                if (selectionService != null)
                {
                    selectionService.SelectionChanged -= new EventHandler(
                        selectionService_SelectionChanged);
                }

                Controls.Remove(_workflowView);
                _workflowView.Dispose();
                _workflowView = null;
            }

            if (_toolboxControl != null)
            {
                Controls.Remove(_toolboxControl);
            }
        }
    }
}