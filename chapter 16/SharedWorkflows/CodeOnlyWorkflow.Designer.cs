using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace SharedWorkflows
{
    partial class CodeOnlyWorkflow
    {
        #region Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            System.Workflow.Activities.CodeCondition codecondition1
                = new System.Workflow.Activities.CodeCondition();
            this.codeNumberNotPositive
                = new System.Workflow.Activities.CodeActivity();
            this.codeNumberIsPositive
                = new System.Workflow.Activities.CodeActivity();
            this.ifElseBranchActivity2
                = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity1
                = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseActivity1
                = new System.Workflow.Activities.IfElseActivity();
            // 
            // codeNumberNotPositive
            // 
            this.codeNumberNotPositive.Name = "codeNumberNotPositive";
            this.codeNumberNotPositive.ExecuteCode
                += new System.EventHandler(this.codeNumberNotPositive_ExecuteCode);
            // 
            // codeNumberIsPositive
            // 
            this.codeNumberIsPositive.Name = "codeNumberIsPositive";
            this.codeNumberIsPositive.ExecuteCode
                += new System.EventHandler(this.codeNumberIsPositive_ExecuteCode);
            // 
            // ifElseBranchActivity2
            // 
            this.ifElseBranchActivity2.Activities.Add(this.codeNumberNotPositive);
            this.ifElseBranchActivity2.Name = "ifElseBranchActivity2";
            // 
            // ifElseBranchActivity1
            // 
            this.ifElseBranchActivity1.Activities.Add(this.codeNumberIsPositive);
            codecondition1.Condition += new System.EventHandler<
                System.Workflow.Activities.ConditionalEventArgs>(
                    this.IsNumberPositive);
            this.ifElseBranchActivity1.Condition = codecondition1;
            this.ifElseBranchActivity1.Name = "ifElseBranchActivity1";
            // 
            // ifElseActivity1
            // 
            this.ifElseActivity1.Activities.Add(this.ifElseBranchActivity1);
            this.ifElseActivity1.Activities.Add(this.ifElseBranchActivity2);
            this.ifElseActivity1.Name = "ifElseActivity1";
            // 
            // CodeOnlyWorkflow
            // 
            this.Activities.Add(this.ifElseActivity1);
            this.Name = "CodeOnlyWorkflow";
            this.CanModifyActivities = false;

        }

        #endregion

        private CodeActivity codeNumberNotPositive;
        private CodeActivity codeNumberIsPositive;
        private IfElseBranchActivity ifElseBranchActivity2;
        private IfElseBranchActivity ifElseBranchActivity1;
        private IfElseActivity ifElseActivity1;
    }
}
