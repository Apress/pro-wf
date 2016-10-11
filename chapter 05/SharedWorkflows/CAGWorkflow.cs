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
using System.Collections.Generic;
using System.Workflow.Activities;

namespace SharedWorkflows
{
    public sealed partial class CAGWorkflow : SequentialWorkflowActivity
    {
        private List<String> _lineItems;

        public List<String> LineItems
        {
            get { return _lineItems; }
            set { _lineItems = value; }
        }

        public CAGWorkflow()
        {
            InitializeComponent();
        }

        private void codeSandwich_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("Process sandwich");
            ProcessLineItem("sandwich");
        }

        private void codeFries_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("Process fries");
            ProcessLineItem("fries");
        }

        private void codeDrink_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("Process drink");
            ProcessLineItem("drink");
        }

        private void codeCombo_ExecuteCode(object sender, EventArgs e)
        {
            //a combo is composed of a sandwich, fries and drink.
            //add these individual items to the LineItems collection 
            //and remove the combo item.
            Console.WriteLine("Process combo - adding new items");
            ProcessLineItem("combo");
            LineItems.Add("sandwich");
            LineItems.Add("fries");
            LineItems.Add("drink");
        }

        /// <summary>
        /// Indicate an item has been processed by removing it
        /// from the collection
        /// </summary>
        /// <param name="item"></param>
        private void ProcessLineItem(String item)
        {
            Int32 itemIndex = LineItems.IndexOf(item);
            if (itemIndex >= 0)
            {
                LineItems.RemoveAt(itemIndex);
            }
        }
    }
}
