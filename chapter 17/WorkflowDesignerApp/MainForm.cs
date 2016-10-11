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
using System.Drawing.Design;
using System.Windows.Forms;
using System.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;

namespace WorkflowDesignerApp
{
    /// <summary>
    /// The main form of the Markup-only workflow designer
    /// </summary>
    public partial class MainForm : Form
    {
        private String _loadedMarkupFileName = String.Empty;
        private TypeProvider _typeProvider;

        public MainForm()
        {
            InitializeComponent();
            _typeProvider = new TypeProvider(new ServiceContainer());
            designer.TypeProvider = _typeProvider;
        }

        #region Load and Save the Workflow

        /// <summary>
        /// Open an existing markup file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuOpenMarkup_Click(object sender, EventArgs e)
        {
            SetApplicationTitle(null);
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = Environment.CurrentDirectory;
            openFile.Filter
                = "xoml files (*.xoml)|*.xoml|All files (*.*)|*.*";
            openFile.FilterIndex = 1;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                String fileName = openFile.FileName;
                try
                {
                    //tell the designer to load the workflow markup
                    if (designer.LoadWorkflow(fileName))
                    {
                        _loadedMarkupFileName = fileName;
                        SetApplicationTitle(fileName);
                    }
                    else
                    {
                        MessageBox.Show("Unable to load markup file",
                          "Error loading markup",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(String.Format(
                      "Exception loading workflow: {0}",
                      exception.Message), "Exception in LoadWorkflow",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Save the workflow design to a markup file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(_loadedMarkupFileName))
            {
                SaveWorkflowDefinition(_loadedMarkupFileName);
            }
        }

        /// <summary>
        /// Save the workflow design to a new markup file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.InitialDirectory = Environment.CurrentDirectory;
            saveFile.Filter
                = "xoml files (*.xoml)|*.xoml|All files (*.*)|*.*";
            saveFile.FilterIndex = 1;
            saveFile.FileName = _loadedMarkupFileName;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                if (SaveWorkflowDefinition(saveFile.FileName))
                {
                    SetApplicationTitle(saveFile.FileName);
                }
                else
                {
                    SetApplicationTitle(null);
                }
            }
        }

        /// <summary>
        /// Save to markup
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private Boolean SaveWorkflowDefinition(String fileName)
        {
            Boolean result = false;
            try
            {
                //let the designer handle the save operation
                if (designer.SaveWorkflow(fileName))
                {
                    _loadedMarkupFileName = fileName;
                    result = true;
                }
                else
                {
                    MessageBox.Show("Unable to save markup file",
                      "Error saving markup",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(String.Format(
                  "Exception saving workflow: {0}",
                  exception.Message),
                  "Exception in SaveWorkflowDefinition",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        #endregion

        #region Update UI Elements

        private void SetApplicationTitle(String fileName)
        {
            if (String.IsNullOrEmpty(fileName))
            {
                this.Text = "Custom Workflow Designer";
            }
            else
            {
                this.Text = String.Format(
                    "Custom Workflow Designer: {0}",
                    Path.GetFileName(fileName));
            }
        }

        #endregion

        #region Assembly References

        /// <summary>
        /// Show the Add References dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuReferences_Click(object sender, EventArgs e)
        {
            AssemblyReferenceForm form
                = new AssemblyReferenceForm(_typeProvider);
            form.ShowDialog();

            //rebuild the toolbox with referenced assemblies
            if (designer.ToolboxControl != null)
            {
                ((IToolboxService)designer.ToolboxControl).Refresh();
            }
        }

        #endregion

        #region New Workflow

        /// <summary>
        /// Create a new workflow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuNewWorkflow_Click(object sender, EventArgs e)
        {
            NewWorkflowForm form
                = new NewWorkflowForm(_typeProvider);
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //let the designer create a new workflow
                    //base on the selected workflow Type
                    if (designer.CreateNewWorkflow(
                        form.SelectedWorkflowType, form.NewWorkflowName))
                    {
                        _loadedMarkupFileName
                            = form.NewWorkflowName + ".xoml";
                        SetApplicationTitle(_loadedMarkupFileName);

                        //immediately prompt to save the workflow
                        menuSaveAs_Click(this, new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show("Unable to create new workflow",
                          "Error creating workflow",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(String.Format(
                      "Exception creating workflow: {0}",
                        exception.Message),
                      "Exception in CreateNewWorkflow",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion
    }
}