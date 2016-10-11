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
using System.Workflow.ComponentModel.Compiler;

namespace CustomActivityComponents
{
    /// <summary>
    /// Validator for MyCustomActivity
    /// </summary>
    public class MyCustomActivityValidator : ActivityValidator
    {
        public override ValidationErrorCollection Validate(
            ValidationManager manager, object obj)
        {
            ValidationErrorCollection errors = base.Validate(manager, obj);
            //only validate a single custom activity type
            if (obj is MyCustomActivity)
            {
                MyCustomActivity activity = obj as MyCustomActivity;
                //only do validation when the activity is in a workflow
                if (activity.Parent != null)
                {
                    if (activity.MyInt == 0)
                    {
                        errors.Add(
                            ValidationError.GetNotSetValidationError(
                                "MyInt"));
                    }

                    if (activity.MyString == null ||
                        activity.MyString.Length == 0)
                    {
                        errors.Add(new ValidationError(
                            "MyString Property is incorrect", 501));
                    }
                }
            }
            return errors;
        }
    }
}
