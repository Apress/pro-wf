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
    public partial class OrderDetailActivity : Activity
    {
        /// <summary>
        /// OrderId Dependency Property
        /// </summary>
        public static DependencyProperty OrderIdProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
                "OrderId", typeof(Int32), typeof(OrderDetailActivity));
        [Description("Identifies the order")]
        [Category("ProWorkflow")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 OrderId
        {
            get
            {
                return ((Int32)(base.GetValue(
                    OrderDetailActivity.OrderIdProperty)));
            }
            set
            {
                base.SetValue(OrderDetailActivity.OrderIdProperty, value);
            }
        }

        /// <summary>
        /// AccountId Dependency Property
        /// </summary>
        public static DependencyProperty AccountIdProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
                "AccountId", typeof(Int32), typeof(OrderDetailActivity));
        [Description("Identifies the account")]
        [Category("ProWorkflow")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 AccountId
        {
            get
            {
                return ((Int32)(base.GetValue(
                    OrderDetailActivity.AccountIdProperty)));
            }
            set
            {
                base.SetValue(OrderDetailActivity.AccountIdProperty, value);
            }
        }

        /// <summary>
        /// ItemId Dependency Property
        /// </summary>
        public static DependencyProperty ItemIdProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
                "ItemId", typeof(Int32), typeof(OrderDetailActivity));
        [Description("Identifies the item being ordered")]
        [Category("ProWorkflow")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 ItemId
        {
            get
            {
                return ((Int32)(base.GetValue(
                    OrderDetailActivity.ItemIdProperty)));
            }
            set
            {
                base.SetValue(OrderDetailActivity.ItemIdProperty, value);
            }
        }

        /// <summary>
        /// Quantity Dependency Property
        /// </summary>
        public static DependencyProperty QuantityProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
                "Quantity", typeof(Int32), typeof(OrderDetailActivity));
        [Description("The quantity of the item to order")]
        [Category("ProWorkflow")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 Quantity
        {
            get
            {
                return ((Int32)(base.GetValue(
                    OrderDetailActivity.QuantityProperty)));
            }
            set
            {
                base.SetValue(OrderDetailActivity.QuantityProperty, value);
            }
        }

        /// <summary>
        /// IsAddOrder Dependency Property
        /// </summary>
        public static DependencyProperty IsAddOrderProperty
            = System.Workflow.ComponentModel.DependencyProperty.Register(
                "IsAddOrder", typeof(Boolean), typeof(OrderDetailActivity));
        [Description("True to add the item to the order, false to remove it")]
        [Category("ProWorkflow")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Boolean IsAddOrder
        {
            get
            {
                return ((Boolean)(base.GetValue(
                    OrderDetailActivity.IsAddOrderProperty)));
            }
            set
            {
                base.SetValue(OrderDetailActivity.IsAddOrderProperty, value);
            }
        }

        public OrderDetailActivity()
        {
            InitializeComponent();
        }

        protected override ActivityExecutionStatus Execute(
            ActivityExecutionContext executionContext)
        {
            using (SqlConnection connection = new SqlConnection(
                ConfigurationManager.ConnectionStrings
                    ["ProWorkflow"].ConnectionString))
            {
                connection.Open();
                if (IsAddOrder)
                {
                    InsertOrderDetail(connection, OrderId,
                        AccountId, ItemId, Quantity);
                    Console.WriteLine(
                        "OrderDetailActivity: Inserting orderDetail row");
                }
                else
                {
                    DeleteOrderDetail(connection, OrderId,
                        AccountId, ItemId);
                    Console.WriteLine(
                        "OrderDetailActivity: Compensating orderDetail row");
                }
                connection.Close();
            }
            return base.Execute(executionContext);
        }

        /// <summary>
        /// Insert a new order detail row
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="orderId"></param>
        /// <param name="accountId"></param>
        /// <param name="itemId"></param>
        /// <param name="quantity"></param>
        private void InsertOrderDetail(SqlConnection connection,
            Int32 orderId, Int32 accountId, Int32 itemId, Int32 quantity)
        {
            String sql =
                @"insert into orderDetail
                  (orderId, accountId, itemId, quantity)
                  values(@OrderId, @AccountId, @ItemId, @Quantity)";

            //setup Sql command object
            SqlCommand command = new SqlCommand(sql);
            //setup parameters
            SqlParameter p = new SqlParameter("@OrderId", orderId);
            command.Parameters.Add(p);
            p = new SqlParameter("@AccountId", accountId);
            command.Parameters.Add(p);
            p = new SqlParameter("@ItemId", itemId);
            command.Parameters.Add(p);
            p = new SqlParameter("@Quantity", quantity);
            command.Parameters.Add(p);
            command.Connection = connection;

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Delete an order detail row
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="orderId"></param>
        /// <param name="accountId"></param>
        /// <param name="itemId"></param>
        private void DeleteOrderDetail(SqlConnection connection,
            Int32 orderId, Int32 accountId, Int32 itemId)
        {
            String sql =
                @"delete from orderDetail
                  where orderId = @OrderId
                   and  accountId = @AccountId
                   and  itemId = @ItemId ";
            //setup Sql command object
            SqlCommand command = new SqlCommand(sql);
            //setup parameters
            SqlParameter p = new SqlParameter("@OrderId", orderId);
            command.Parameters.Add(p);
            p = new SqlParameter("@AccountId", accountId);
            command.Parameters.Add(p);
            p = new SqlParameter("@ItemId", itemId);
            command.Parameters.Add(p);
            command.Connection = connection;

            command.ExecuteNonQuery();
        }
    }
}
