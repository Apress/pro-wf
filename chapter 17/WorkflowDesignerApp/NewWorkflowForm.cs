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
using System.Windows.Forms;
using System.Reflection;
using System.Workflow.ComponentModel;
using System.Workflow.Activities;
using System.Workflow.ComponentModel.Compiler;

namespace WorkflowDesignerApp
{
    /// <summary>
    /// A form used to select the new workflow Type
    /// </summary>
    public partial class NewWorkflowForm : Form
    {
        private TypeProvider _typeProvider;
        private Type _selectedWorkflowType;
        private String _newWorkflowName = String.Empty;

        public NewWorkflowForm(TypeProvider provider)
        {
            InitializeComponent();
            _typeProvider = provider;
            if (_typeProvider != null)
            {
                PopulateWorkflowList();
            }

            btnCreate.Enabled = false;
        }

        public Type SelectedWorkflowType
        {
            get { return _selectedWorkflowType; }
        }

        public String NewWorkflowName
        {
            get { return _newWorkflowName; }
        }

        private void PopulateWorkflowList()
        {
            listWorkflowTypes.Items.Clear();

            //add standard workflow types
            listWorkflowTypes.Items.Add(
                typeof(SequentialWorkflowActivity));
            listWorkflowTypes.Items.Add(
                typeof(StateMachineWorkflowActivity));

            //add any workflow types found in referenced assemblies
            foreach (Assembly assembly in
                _typeProvider.ReferencedAssemblies)
            {
                Type[] types = assembly.GetTypes();
                foreach (Type type in types)
                {
                    if (typeof(SequentialWorkflowActivity).
                            IsAssignableFrom(type) ||
                        typeof(StateMachineWorkflowActivity).
                            IsAssignableFrom(type))
                    {
                        listWorkflowTypes.Items.Add(type);
                    }
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtNewWorkflowName.Text.Trim().Length > 0)
            {
                _newWorkflowName = txtNewWorkflowName.Text.Trim();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Please enter a new workflow name",
                    "Name Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _selectedWorkflowType = null;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void listWorkflowTypes_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            //save the selected workflow type
            if (listWorkflowTypes.SelectedIndex >= 0)
            {
                _selectedWorkflowType
                    = listWorkflowTypes.SelectedItem as Type;
                btnCreate.Enabled = true;
            }
        }
    }
}