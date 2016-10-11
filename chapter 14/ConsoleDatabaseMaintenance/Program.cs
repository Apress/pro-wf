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
using System.Workflow.Runtime;
using System.Workflow.Runtime.Tracking;
using Bukovics.Workflow.Hosting;

//requires a reference to the SharedWorkflows assembly at runtime 

namespace ConsoleDatabaseMaintenance
{
    class Program
    {
        private static String _connStringTracking = String.Format(
            "Initial Catalog={0};Data Source={1};Integrated Security={2};",
                "WorkflowTracking", @"localhost\SQLEXPRESS", "SSPI");

        /// <summary>
        /// Determine what action to take
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                switch (args[0].ToLower())
                {
                    case "displaytrackingdata":
                        DisplayCompletedWorkflows();
                        break;
                    case "displaypartitions":
                        DisplayAllPartitions();
                        break;
                    case "setdaily":
                        SetPartitionInterval('d');
                        break;
                    case "setweekly":
                        SetPartitionInterval('w');
                        break;
                    case "setmonthly":
                        SetPartitionInterval('m');
                        break;
                    case "setyearly":
                        SetPartitionInterval('y');
                        break;
                    case "droppartition":
                        if (args.Length >= 2)
                        {
                            Int32 partitionId;
                            if (Int32.TryParse(args[1], out partitionId))
                            {
                                DropPartition(partitionId);
                            }
                            else
                            {
                                Console.WriteLine(
                                    "{0} must be a partition Id", args[1]);
                            }
                        }
                        break;
                    case "partitioncompleted":
                        PartitionCompletedInstances();
                        break;
                    default:
                        DisplayHelp();
                        break;
                }
            }
            else
            {
                DisplayHelp();
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        #region Partition Functions

        /// <summary>
        /// Set the partition interval 
        /// </summary>
        /// <param name="interval"></param>
        private static void SetPartitionInterval(char interval)
        {
            try
            {
                using (SqlConnection conn
                    = new SqlConnection(_connStringTracking))
                {
                    SqlCommand command
                        = new SqlCommand("SetPartitionInterval", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(
                        new SqlParameter("@Interval", interval));
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Partition Interval set to {0}", interval);
            }
            catch (SqlException e)
            {
                Console.WriteLine(
                    "SqlException in SetPartitionInterval: {0}", e.Message);
            }
        }

        /// <summary>
        /// Drop a partition
        /// </summary>
        /// <param name="partitionId"></param>
        private static void DropPartition(Int32 partitionId)
        {
            try
            {
                using (SqlConnection conn
                    = new SqlConnection(_connStringTracking))
                {
                    SqlCommand command
                        = new SqlCommand("DropPartition", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(
                        new SqlParameter("@PartitionName", null));
                    command.Parameters.Add(
                        new SqlParameter("@PartitionId", partitionId));
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Partition {0} dropped", partitionId);
            }
            catch (SqlException e)
            {
                Console.WriteLine(
                    "SqlException in DropPartition: {0}", e.Message);
            }
        }

        /// <summary>
        /// Display all known partitions in the tracking database
        /// </summary>
        private static void DisplayAllPartitions()
        {
            try
            {
                using (SqlConnection conn
                    = new SqlConnection(_connStringTracking))
                {
                    SqlCommand command = new SqlCommand(
                        @"SELECT * from vw_TrackingPartitionSetName
                          ORDER BY PartitionId", conn);
                    command.Connection.Open();
                    Console.WriteLine("{0,-4} {1,-13} {2,-22} {3,-22}",
                        "Id", "Name", "CreatedDateTime", "EndDateTime");
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0,-4} {1,-13} {2,-22} {3,-22}",
                                reader["PartitionId"],
                                reader["Name"],
                                reader["CreatedDateTime"],
                                reader["EndDateTime"]);
                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(
                    "SqlException in SetPartitionInterval: {0}",
                    e.Message);
            }
        }

        /// <summary>
        /// Partition any completed workflow instances
        /// </summary>
        /// <remarks>
        /// Use this to move completed workflow instances to the
        /// partition tables if you don't specify true for the
        /// SqlTrackingService.PartitionOnCompletion property.
        /// </remarks>
        private static void PartitionCompletedInstances()
        {
            try
            {
                using (SqlConnection conn
                    = new SqlConnection(_connStringTracking))
                {
                    SqlCommand command = new SqlCommand(
                        "PartitionCompletedWorkflowInstances", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Partitioning of workflows completed");
            }
            catch (SqlException e)
            {
                Console.WriteLine(
                    "SqlException in PartitionCompletedInstances: {0}", e.Message);
            }
        }

        #endregion

        #region Other functions

        /// <summary>
        /// Display tracking data for all completed workflows
        /// </summary>
        private static void DisplayCompletedWorkflows()
        {
            //query and display tracking data for multiple workflows
            TrackingConsoleWriter trackingWriter
                = new TrackingConsoleWriter(_connStringTracking);
            //only display completed workflows
            SqlTrackingQueryOptions options = new SqlTrackingQueryOptions();
            options.WorkflowStatus = WorkflowStatus.Completed;
            trackingWriter.DisplayAllTrackingData(options);
        }

        private static void DisplayHelp()
        {
            Console.WriteLine("Available Command-line Options:");
            Console.WriteLine("   DisplayTrackingData");
            Console.WriteLine("   DisplayPartitions");
            Console.WriteLine("   SetDaily");
            Console.WriteLine("   SetWeekly");
            Console.WriteLine("   SetMonthly");
            Console.WriteLine("   SetYearly");
            Console.WriteLine("   DropPartition [Id]");
            Console.WriteLine("   PartitionCompleted");
        }

        #endregion
    }
}
