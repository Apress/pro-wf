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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Workflow.ComponentModel.Design;

namespace CustomActivityComponents
{
    /// <summary>
    /// Custom theme for MyCompositeActivityDesigner
    /// </summary>
    public class MyCompositeActivityTheme : CompositeDesignerTheme
    {
        public MyCompositeActivityTheme(WorkflowTheme theme)
            : base(theme)
        {
            this.BackColorStart = Color.LightSteelBlue;
            this.BackColorEnd = Color.Gainsboro;
            this.BorderStyle = DashStyle.DashDot;
            this.BorderColor = Color.DarkBlue;
            this.BackgroundStyle = LinearGradientMode.Vertical;
            this.ConnectorStartCap = LineAnchor.RectangleAnchor;
            this.ConnectorEndCap = LineAnchor.DiamondAnchor;
            this.ShowDropShadow = true;
        }
    }
}
