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
using System.IO;
using System.Xml;
using System.Reflection;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;

namespace SharedWorkflows
{
    /// <summary>
    /// Processes a sales item using a RuleSet definition
    /// that is deserialized from an embedded .rules resource
    /// </summary>
    public sealed partial class SellItemSerializedWorkflow
        : SequentialWorkflowActivity
    {
        private SalesItem _salesItem;

        public SalesItem SalesItem
        {
            get { return _salesItem; }
            set { _salesItem = value; }
        }

        public SellItemSerializedWorkflow()
        {
            InitializeComponent();
        }

        [RuleRead("SalesItem/OrderTotal")]
        public Double GetOrderTotal()
        {
            return SalesItem.OrderTotal;
        }

        [RuleInvoke("PrivateOrderTotalMethod")]
        public void SetOrderTotal(Double newTotal)
        {
            PrivateOrderTotalMethod(newTotal);
        }

        [RuleWrite("SalesItem/OrderTotal")]
        private void PrivateOrderTotalMethod(Double newTotal)
        {
            SalesItem.OrderTotal = newTotal;
        }

        /// <summary>
        /// Execute a RuleSet definition read from
        /// a file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void codeExecuteRuleSet_ExecuteCode(
            object sender, EventArgs e)
        {
            //get a stream from the embedded .rules resource
            Assembly assembly = Assembly.GetAssembly(typeof(SellItemWorkflow));
            Stream stream = assembly.GetManifestResourceStream(
                "SharedWorkflows.SellItemMethods2Workflow.rules");

            //get a stream from an externally saved .rules file
            //Stream stream
            //    = new FileStream(@"SerializedSellItem.rules", 
            //        FileMode.Open, FileAccess.Read, FileShare.Read);

            using (XmlReader xmlReader = XmlReader.Create(
                new StreamReader(stream)))
            {
                WorkflowMarkupSerializer markupSerializer
                    = new WorkflowMarkupSerializer();
                //deserialize the rule definitions
                RuleDefinitions ruleDefinitions
                    = markupSerializer.Deserialize(xmlReader) as RuleDefinitions;
                if (ruleDefinitions != null)
                {
                    if (ruleDefinitions.RuleSets.Contains("CalculateItemTotals"))
                    {
                        RuleSet rs 
                            = ruleDefinitions.RuleSets["CalculateItemTotals"];
                        //validate and execute the RuleSet against this
                        //workflow instance
                        RuleValidation validation = new RuleValidation(
                            typeof(SellItemSerializedWorkflow), null);
                        if (rs.Validate(validation))
                        {
                            RuleExecution execution
                                = new RuleExecution(validation, this);
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
        }
    }
}
