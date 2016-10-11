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
using System.ComponentModel.Design;
using System.Runtime.Serialization;
using System.Workflow.Activities;
using System.Workflow.ComponentModel.Design;

namespace CustomActivityComponents
{
    /// <summary>
    /// Defines custom activity when a MyCompositeActivity
    /// is dragged from the Toolbox to a workflow
    /// </summary>
    [Serializable]
    public class MyCompositeActivityToolboxItem : ActivityToolboxItem
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public MyCompositeActivityToolboxItem()
            : base()
        {
        }

        /// <summary>
        /// Serialization constructor
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public MyCompositeActivityToolboxItem(
            SerializationInfo info, StreamingContext context)
                : base(info, context)
        {
        }

        protected override IComponent[] CreateComponentsCore(IDesignerHost host)
        {
            //create the primary activity
            MyCompositeActivity activity = new MyCompositeActivity();
            //add an IfElseActivity
            IfElseActivity ifElse = new IfElseActivity("ifElse1");
            //add 3 branches to the IfElseActivity
            ifElse.Activities.Add(new IfElseBranchActivity("ifFirstCondition"));
            ifElse.Activities.Add(new IfElseBranchActivity("ifSecondCondition"));
            ifElse.Activities.Add(new IfElseBranchActivity("elseBranch"));
            activity.Activities.Add(ifElse);

            return new IComponent[] { activity };
        }
    }
}

