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
using System.ComponentModel;
using System.Drawing;
using System.Workflow.Activities;

namespace CustomActivityComponents
{
    /// <summary>
    /// A composite activity that demonstrates ToolboxItem and
    /// ToolboxBitmap
    /// </summary>
    [ToolboxBitmap(typeof(MyCompositeActivity), "Resources.graphhs.png")]
    [ToolboxItem(typeof(MyCompositeActivityToolboxItem))]
    [Designer(typeof(MyCompositeActivityDesigner))]
    public partial class MyCompositeActivity : SequenceActivity
    {
        public MyCompositeActivity()
        {
            InitializeComponent();
        }
    }
}
