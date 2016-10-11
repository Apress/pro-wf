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

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SharedWorkflows {
    using System;
    using System.ComponentModel;
    using System.Workflow.Activities;
    using System.Workflow.ComponentModel;
    using System.Workflow.ComponentModel.Design;
    using System.Workflow.ComponentModel.Compiler;
    
    
    [ToolboxItemAttribute(typeof(ActivityToolboxItem))]
    public partial class SendMessage : CallExternalMethodActivity {
        
        public static DependencyProperty messageProperty = DependencyProperty.Register("message", typeof(string), typeof(SendMessage));
        
        public SendMessage() {
            base.InterfaceType = typeof(SharedWorkflows.IGuessingGame);
            base.MethodName = "SendMessage";
        }
        
        [BrowsableAttribute(false)]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
        public override System.Type InterfaceType {
            get {
                return base.InterfaceType;
            }
            set {
                throw new InvalidOperationException("Cannot set InterfaceType on a derived CallExternalMethodActivity.");
            }
        }
        
        [BrowsableAttribute(false)]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
        public override string MethodName {
            get {
                return base.MethodName;
            }
            set {
                throw new InvalidOperationException("Cannot set MethodName on a derived CallExternalMethodActivity.");
            }
        }
        
        [ValidationOptionAttribute(ValidationOption.Required)]
        public string message {
            get {
                return ((string)(this.GetValue(SendMessage.messageProperty)));
            }
            set {
                this.SetValue(SendMessage.messageProperty, value);
            }
        }
        
        protected override void OnMethodInvoking(System.EventArgs e) {
            this.ParameterBindings["message"].Value = this.message;
        }
    }
}
