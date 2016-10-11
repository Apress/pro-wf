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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Activities;

namespace CustomActivityComponents
{
    /// <summary>
    /// Custom designer for MyCompositeActivity
    /// </summary>
    [ActivityDesignerTheme(typeof(MyCompositeActivityTheme))]
    public class MyCompositeActivityDesigner : SequentialActivityDesigner
    {
        /// <summary>
        /// Static list of acceptable child activities
        /// </summary>
        private static List<Type> _allowedActivityTypes = new List<Type>();
        static MyCompositeActivityDesigner()
        {
            //initialize list of allowed child types
            _allowedActivityTypes.Add(typeof(IfElseActivity));
            _allowedActivityTypes.Add(typeof(IfElseBranchActivity));
            _allowedActivityTypes.Add(typeof(CodeActivity));
        }

        /// <summary>
        /// Determine if an activity can be added
        /// </summary>
        /// <param name="insertLocation"></param>
        /// <param name="activitiesToInsert"></param>
        /// <returns></returns>
        public override bool CanInsertActivities(HitTestInfo insertLocation,
            ReadOnlyCollection<Activity> activitiesToInsert)
        {
            //allow only selected activity types
            Boolean result = true;
            if (activitiesToInsert != null)
            {
                foreach (Activity activity in activitiesToInsert)
                {
                    result = (_allowedActivityTypes.Contains(activity.GetType()));
                    if (result == false)
                    {
                        break;
                    }
                }
            }
            return result;
        }
    }
}
