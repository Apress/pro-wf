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
using System.Windows.Forms;
using System.Workflow.ComponentModel.Compiler;

namespace WorkflowDesignerApp
{
    /// <summary>
    /// A form used to add assembly references
    /// </summary>
    public partial class AssemblyReferenceForm : Form
    {
        private TypeProvider _typeProvider;

        public AssemblyReferenceForm(TypeProvider provider)
        {
            InitializeComponent();

            //build the list of referenced assemblies
            _typeProvider = provider;
            if (_typeProvider != null)
            {
                PopulateListWithReferences();
            }
        }

        /// <summary>
        /// Build the list of referenced assemblies
        /// </summary>
        private void PopulateListWithReferences()
        {
            listReferences.Items.Clear();
            foreach (Assembly assembly in
                _typeProvider.ReferencedAssemblies)
            {
                listReferences.Items.Add(assembly);
            }
        }

        /// <summary>
        /// Add a new assembly to the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = Environment.CurrentDirectory;
            openFile.Filter
                = "Dll files (*.Dll)|*.Dll|All files (*.*)|*.*";
            openFile.FilterIndex = 1;
            openFile.Multiselect = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                foreach (String filename in openFile.FileNames)
                {
                    //add the referenced assemblies to the TypeProvider
                    _typeProvider.AddAssemblyReference(filename);
                }
                PopulateListWithReferences();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}