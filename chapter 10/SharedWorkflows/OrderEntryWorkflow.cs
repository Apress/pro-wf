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
using System.Workflow.Activities;

namespace SharedWorkflows
{
    public sealed partial class OrderEntryWorkflow
        : SequentialWorkflowActivity
    {
        /// <summary>
        /// OrderId Dependency Property
        /// </summary>
        public static DependencyProperty OrderIdProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
                "OrderId", typeof(Int32), typeof(OrderEntryWorkflow));
        [Description("Identifies the order")]
        [Category("ProWorkflow")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 OrderId
        {
            get
            {
                return ((Int32)(base.GetValue(
                    OrderEntryWorkflow.OrderIdProperty)));
            }
            set
            {
                base.SetValue(OrderEntryWorkflow.OrderIdProperty, value);
            }
        }
        /// <summary>
        /// ItemId Dependency Property
        /// </summary>
        public static DependencyProperty ItemIdProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
                "ItemId", typeof(Int32), typeof(OrderEntryWorkflow));
        [Description("Identifies the item being ordered")]
        [Category("ProWorkflow")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 ItemId
        {
            get
            {
                return ((Int32)(base.GetValue(
                    OrderEntryWorkflow.ItemIdProperty)));
            }
            set
            {
                base.SetValue(OrderEntryWorkflow.ItemIdProperty, value);
            }
        }

        /// <summary>
        /// Quantity Dependency Property
        /// </summary>
        public static DependencyProperty QuantityProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
                "Quantity", typeof(Int32), typeof(OrderEntryWorkflow));
        [Description("The quantity of the item to order")]
        [Category("ProWorkflow")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 Quantity
        {
            get
            {
                return ((Int32)(base.GetValue(
                    OrderEntryWorkflow.QuantityProperty)));
            }
            set
            {
                base.SetValue(OrderEntryWorkflow.QuantityProperty, value);
            }
        }

        /// <summary>
        /// Amount Dependency Property
        /// </summary>
        public static DependencyProperty AmountProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
                "Amount", typeof(Decimal), typeof(OrderEntryWorkflow));
        [Description("The amount of the balance adjustment")]
        [Category("ProWorkflow")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Decimal Amount
        {
            get
            {
                return ((Decimal)(base.GetValue(
                    OrderEntryWorkflow.AmountProperty)));
            }
            set
            {
                base.SetValue(OrderEntryWorkflow.AmountProperty, value);
            }
        }

        /// <summary>
        /// OrderAccountId Dependency Property
        /// </summary>
        public static DependencyProperty OrderAccountIdProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
                "OrderAccountId", typeof(Int32), typeof(OrderEntryWorkflow));
        [Description("Identifies the account placing the order")]
        [Category("ProWorkflow")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 OrderAccountId
        {
            get
            {
                return ((Int32)(base.GetValue(
                    OrderEntryWorkflow.OrderAccountIdProperty)));
            }
            set
            {
                base.SetValue(OrderEntryWorkflow.OrderAccountIdProperty, value);
            }
        }

        /// <summary>
        /// ToAccountId Dependency Property
        /// </summary>
        public static DependencyProperty ToAccountIdProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
                "ToAccountId", typeof(Int32), typeof(OrderEntryWorkflow));
        [Description("Identifies the account to receive funds from the order")]
        [Category("ProWorkflow")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 ToAccountId
        {
            get
            {
                return ((Int32)(base.GetValue(
                    OrderEntryWorkflow.ToAccountIdProperty)));
            }
            set
            {
                base.SetValue(OrderEntryWorkflow.ToAccountIdProperty, value);
            }
        }

        public OrderEntryWorkflow()
        {
            InitializeComponent();
        }

        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("CodeActivity: Executing code");
        }

        private void compensateCodeActivity_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("CodeActivity: Executing compensation code");
        }

    }
}
