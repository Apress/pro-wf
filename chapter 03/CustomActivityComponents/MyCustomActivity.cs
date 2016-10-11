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
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.Activities;

namespace CustomActivityComponents
{
    /// <summary>
    /// A custom activity that demonstrates activity components
    /// </summary>
    [ActivityValidator(typeof(MyCustomActivityValidator))]
    public partial class MyCustomActivity : Activity
    {
        public MyCustomActivity()
        {
            InitializeComponent();
        }

        public static DependencyProperty MyStringProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
            "MyString", typeof(string), typeof(MyCustomActivity));

        [Description("A String property")]
        [Category("Custom Activity Components")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string MyString
        {
            get
            {
                return ((string)(base.GetValue(
                    MyCustomActivity.MyStringProperty)));
            }
            set
            {
                base.SetValue(MyCustomActivity.MyStringProperty, value);
            }
        }

        public static DependencyProperty MyIntProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
            "MyInt", typeof(Int32), typeof(MyCustomActivity));

        [Description("An Int32 property")]
        [Category("Custom Activity Components")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 MyInt
        {
            get
            {
                return ((Int32)(base.GetValue(MyCustomActivity.MyIntProperty)));
            }
            set
            {
                base.SetValue(MyCustomActivity.MyIntProperty, value);
            }
        }
    }
}
