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
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.Workflow.ComponentModel.Compiler;
using System.CodeDom;

namespace SharedWorkflows
{
    /// <summary>
    /// Processes a sales item using a RuleSet composed
    /// and executed in code
    /// </summary>
    public sealed partial class SellItemInCodeWorkflow
        : SequentialWorkflowActivity
    {
        private SalesItem _salesItem;

        public SalesItem SalesItem
        {
            get { return _salesItem; }
            set { _salesItem = value; }
        }

        public SellItemInCodeWorkflow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Execute a RuleSet in code
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void codeExecuteRuleSet_ExecuteCode(
            object sender, EventArgs e)
        {
            //create references to properties
            CodeThisReferenceExpression codeThis
                = new CodeThisReferenceExpression();
            CodePropertyReferenceExpression quantityRef
                = new CodePropertyReferenceExpression(codeThis, "Quantity");
            CodePropertyReferenceExpression itemPriceRef
                = new CodePropertyReferenceExpression(codeThis, "ItemPrice");
            CodePropertyReferenceExpression orderTotalRef
                = new CodePropertyReferenceExpression(codeThis, "OrderTotal");

            //create the ruleset
            RuleSet rs = new RuleSet("CalculateItemTotals");

            //
            //define the CalcTotal rule
            //
            Rule rule = new Rule("CalcTotal");

            //IF this.SalesItem.Quantity > 10 
            CodeBinaryOperatorExpression condition
                = new CodeBinaryOperatorExpression(
                    quantityRef, CodeBinaryOperatorType.GreaterThan,
                    new CodePrimitiveExpression(10));
            rule.Condition = new RuleExpressionCondition(condition);

            //THEN this.SalesItem.OrderTotal = this.SalesItem.Quantity * 
            //  (this.SalesItem.ItemPrice * 0.95) 
            CodeAssignStatement assignWithDiscount
                = new CodeAssignStatement(orderTotalRef,
                    new CodeBinaryOperatorExpression(
                        quantityRef, CodeBinaryOperatorType.Multiply,
                            new CodeBinaryOperatorExpression(itemPriceRef,
                                CodeBinaryOperatorType.Multiply,
                                new CodePrimitiveExpression(0.95))));
            rule.ThenActions.Add(new RuleStatementAction(assignWithDiscount));

            //ELSE this.SalesItem.OrderTotal = this.SalesItem.Quantity * 
            //   this.SalesItem.ItemPrice 
            CodeAssignStatement assignWithoutDiscount
                = new CodeAssignStatement(orderTotalRef,
                    new CodeBinaryOperatorExpression(
                        quantityRef, CodeBinaryOperatorType.Multiply,
                        itemPriceRef));
            rule.ElseActions.Add(new RuleStatementAction(assignWithoutDiscount));

            //add rule to ruleset
            rs.Rules.Add(rule);

            //validate and execute the RuleSet against the
            //SalesItem property
            RuleValidation validation
                = new RuleValidation(typeof(SalesItem), null);
            if (rs.Validate(validation))
            {
                RuleExecution execution = new RuleExecution(validation, SalesItem);
                rs.Execute(execution);
            }
            else
            {
                foreach (ValidationError error in validation.Errors)
                {
                    Console.WriteLine(error.ErrorText);
                }
            }
        }
    }
}
