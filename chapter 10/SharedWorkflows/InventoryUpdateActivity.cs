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
using System.Data;
using System.Data.SqlClient;
using System.Configuration;  //needs assembly reference
using System.ComponentModel;
using System.Workflow.ComponentModel;

namespace SharedWorkflows
{
    public partial class InventoryUpdateActivity : Activity
    {
        /// <summary>
        /// ItemId Dependency Property
        /// </summary>
        public static DependencyProperty ItemIdProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
                "ItemId", typeof(Int32), typeof(InventoryUpdateActivity));
        [Description("Identifies the item to update")]
        [Category("ProWorkflow")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 ItemId
        {
            get
            {
                return ((Int32)(base.GetValue(
                    InventoryUpdateActivity.ItemIdProperty)));
            }
            set
            {
                base.SetValue(InventoryUpdateActivity.ItemIdProperty, value);
            }
        }

        /// <summary>
        /// Quantity Dependency Property
        /// </summary>
        public static DependencyProperty QuantityProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
                "Quantity", typeof(Int32), typeof(InventoryUpdateActivity));
        [Description("The quantity of the item to remove from inventory")]
        [Category("ProWorkflow")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 Quantity
        {
            get
            {
                return ((Int32)(base.GetValue(
                    InventoryUpdateActivity.QuantityProperty)));
            }
            set
            {
                base.SetValue(InventoryUpdateActivity.QuantityProperty, value);
            }
        }

        /// <summary>
        /// IsReduction Dependency Property
        /// </summary>
        public static DependencyProperty IsReductionProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
                "IsReduction", typeof(Boolean), typeof(InventoryUpdateActivity));
        [Description("True to reduce inventory, false to increase it")]
        [Category("ProWorkflow")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Boolean IsReduction
        {
            get
            {
                return ((Boolean)(base.GetValue(
                    InventoryUpdateActivity.IsReductionProperty)));
            }
            set
            {
                base.SetValue(InventoryUpdateActivity.IsReductionProperty, value);
            }
        }

        public InventoryUpdateActivity()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Control updates to inventory
        /// </summary>
        /// <param name="executionContext"></param>
        /// <returns></returns>
        protected override ActivityExecutionStatus Execute(
            ActivityExecutionContext executionContext)
        {
            using (SqlConnection connection = new SqlConnection(
                ConfigurationManager.ConnectionStrings
                    ["ProWorkflow"].ConnectionString))
            {
                connection.Open();
                if (IsReduction)
                {
                    //make sure we have sufficient inventory
                    Int32 qtyOnHand = GetCurrentInventory(connection, ItemId);
                    if (qtyOnHand < Quantity)
                    {
                        throw new ArgumentException(
                            "Insufficient inventory for item");
                    }
                }

                //update the inventory
                UpdateInventory(connection, ItemId, Quantity, IsReduction);

                connection.Close();
            }
            return base.Execute(executionContext);
        }

        /// <summary>
        /// Retrieve the current inventory for an item
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        private Int32 GetCurrentInventory(
            SqlConnection connection, Int32 itemId)
        {
            Int32 inventory = 0;
            String sql =
                @"select qtyOnHand from itemInventory where itemId = @ItemId";

            //setup Sql command object
            SqlCommand command = new SqlCommand(sql);
            //setup parameters
            SqlParameter p = new SqlParameter("@ItemId", itemId);
            command.Parameters.Add(p);
            command.Connection = connection;

            Object result = command.ExecuteScalar();
            if (result != null)
            {
                inventory = (Int32)result;
            }

            return inventory;
        }

        /// <summary>
        /// Update the inventory
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="itemId"></param>
        /// <param name="quantity"></param>
        /// <param name="isReduction"></param>
        private void UpdateInventory(SqlConnection connection,
            Int32 itemId, Int32 quantity, Boolean isReduction)
        {
            String sql;
            if (IsReduction)
            {
                sql =
                @"update itemInventory 
                  set qtyOnHand = qtyOnHand - @Quantity
                  where itemId = @ItemId";
                Console.WriteLine(
                    "InventoryUpdateActivity: Reducing inventory");
            }
            else
            {
                sql =
                @"update itemInventory 
                  set qtyOnHand = qtyOnHand + @Quantity
                  where itemId = @ItemId";
                Console.WriteLine(
                    "InventoryUpdateActivity: Compensating inventory");
            }
            //setup Sql command object
            SqlCommand command = new SqlCommand(sql);
            //setup parameters
            SqlParameter p = new SqlParameter("@ItemId", itemId);
            command.Parameters.Add(p);
            p = new SqlParameter("@Quantity", quantity);
            command.Parameters.Add(p);
            command.Connection = connection;

            command.ExecuteNonQuery();
        }
    }
}
