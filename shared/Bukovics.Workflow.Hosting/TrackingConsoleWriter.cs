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
using System.Collections.Generic;
using System.Workflow.Runtime.Tracking;
using System.Workflow.Activities.Rules;

namespace Bukovics.Workflow.Hosting
{
    /// <summary>
    /// A utility class that retrieves tracking data from
    /// the SQL tracking database and writes it
    /// to the Console
    /// </summary>
    public class TrackingConsoleWriter
    {
        private String _connectionString = String.Empty;

        public TrackingConsoleWriter(String connString)
        {
            _connectionString = connString;
        }

        #region Single Instance Data

        /// <summary>
        /// Write tracking data for a single workflow instance
        /// to the Console
        /// </summary>
        /// <param name="instanceId"></param>
        public void DisplayTrackingData(Guid instanceId)
        {
            //retrieve the tracking data 
            SortedList<Int32, TrackingRecord> records
                = QueryTrackingData(instanceId);

            //write the tracking data to the Console
            WriteSingleInstanceToConsole(instanceId, records);
        }

        /// <summary>
        /// Retrieve tracking data from the database for a 
        /// workflow instance.
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns>
        /// Returns a sorted list of all available TrackingRecords
        /// </returns>
        private SortedList<Int32, TrackingRecord> QueryTrackingData(
            Guid instanceId)
        {
            //create a sorted list for all of the tracking records
            SortedList<Int32, TrackingRecord> records
                = new SortedList<int, TrackingRecord>();

            try
            {
                //create an object that queries the tracking database
                SqlTrackingQuery query
                    = new SqlTrackingQuery(_connectionString);

                //retrieve tracking data for a workflow instance
                SqlTrackingWorkflowInstance instance = null;
                query.TryGetWorkflow(instanceId, out instance);

                //build a sorted list of TrackingRecords
                BuildSortedList(records, instance);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                Console.WriteLine("SqlException in QueryTrackingData: {0}",
                    e.Message);
            }

            return records;
        }

        /// <summary>
        /// Build a sorted list of TrackingRecords for a single
        /// workflow instance
        /// </summary>
        /// <param name="records"></param>
        /// <param name="instance"></param>
        private static void BuildSortedList(
            SortedList<Int32, TrackingRecord> records,
            SqlTrackingWorkflowInstance instance)
        {
            if (instance != null)
            {
                //add workflow events to the sorted list
                foreach (TrackingRecord record in instance.WorkflowEvents)
                {
                    records.Add(record.EventOrder, record);
                }

                //add activity events to the sorted list
                foreach (TrackingRecord record in instance.ActivityEvents)
                {
                    records.Add(record.EventOrder, record);
                }

                //add user events to the sorted list
                foreach (TrackingRecord record in instance.UserEvents)
                {
                    records.Add(record.EventOrder, record);
                }
            }
        }

        /// <summary>
        /// Write tracking data for a single instance to the Console
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="records"></param>
        private void WriteSingleInstanceToConsole(
            Guid instanceId, SortedList<Int32, TrackingRecord> records)
        {
            Console.WriteLine("Tracking data for workflow instance {0}",
                instanceId);

            foreach (TrackingRecord record in records.Values)
            {
                if (record is WorkflowTrackingRecord)
                {
                    WorkflowTrackingRecord wfRecord
                        = record as WorkflowTrackingRecord;
                    Console.WriteLine("{0:HH:mm:ss.fff} Workflow {1}",
                        wfRecord.EventDateTime,
                        wfRecord.TrackingWorkflowEvent);
                }
                else if (record is ActivityTrackingRecord)
                {
                    ActivityTrackingRecord actRecord
                        = record as ActivityTrackingRecord;
                    Console.WriteLine("{0:HH:mm:ss.fff} {1} {2}, Type={3}",
                        actRecord.EventDateTime,
                        actRecord.ExecutionStatus,
                        actRecord.QualifiedName,
                        actRecord.ActivityType.Name);
                    WriteBodyToConsole(actRecord);
                }
                else if (record is UserTrackingRecord)
                {
                    UserTrackingRecord userRecord
                        = record as UserTrackingRecord;
                    if (userRecord.UserData is RuleActionTrackingEvent)
                    {
                        WriteRuleData(userRecord);
                    }
                    else
                    {
                        Console.WriteLine(
                            "{0:HH:mm:ss.fff} UserData from {1} {2}:{3}",
                            userRecord.EventDateTime,
                            userRecord.QualifiedName,
                            userRecord.UserDataKey,
                            userRecord.UserData);
                    }
                }
            }

            Console.WriteLine("End of tracking data for {0}\n\r",
                instanceId);
        }

        /// <summary>
        /// Write any annotations and body data to the Console
        /// </summary>
        /// <param name="record"></param>
        private void WriteBodyToConsole(ActivityTrackingRecord record)
        {
            //write annotations
            if (record.Annotations.Count > 0)
            {
                foreach (String annotation in record.Annotations)
                {
                    Console.WriteLine("     {0}", annotation);
                }
            }

            //write extracted data
            if (record.Body.Count > 0)
            {
                foreach (TrackingDataItem data in record.Body)
                {
                    Console.WriteLine("       {0}={1}",
                        data.FieldName, data.Data);
                }
            }
        }

        /// <summary>
        /// Write rule data to the Console
        /// </summary>
        /// <param name="userRecord"></param>
        private static void WriteRuleData(UserTrackingRecord userRecord)
        {
            RuleActionTrackingEvent ruleAction
                = userRecord.UserData as RuleActionTrackingEvent;
            Console.WriteLine(
                "{0:HH:mm:ss.fff} RuleAction from {1} Rule:{2} Result:{3}",
                userRecord.EventDateTime,
                userRecord.QualifiedName,
                ruleAction.RuleName,
                ruleAction.ConditionResult);
        }

        #endregion

        #region Display All Workflow Instances

        /// <summary>
        /// Write tracking data to the Console for 
        /// all workflow instances
        /// </summary>
        public void DisplayAllTrackingData(SqlTrackingQueryOptions options)
        {
            //retrieve all workflow instances
            IList<SqlTrackingWorkflowInstance> workflows
                = QueryWorkflowList(options);

            SortedList<Int32, TrackingRecord> records
                = new SortedList<int, TrackingRecord>();
            //process all workflow instances in the collection
            foreach (SqlTrackingWorkflowInstance wf in workflows)
            {
                //build a sorted list of TrackingRecords
                records.Clear();
                BuildSortedList(records, wf);
                //write the tracking data to the Console
                WriteSingleInstanceToConsole(wf.WorkflowInstanceId, records);
            }
        }

        /// <summary>
        /// Retrieve tracking data for all workflow instances 
        /// matching the specified options
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        private IList<SqlTrackingWorkflowInstance> QueryWorkflowList(
            SqlTrackingQueryOptions options)
        {
            IList<SqlTrackingWorkflowInstance> workflows
                = new List<SqlTrackingWorkflowInstance>();

            try
            {
                //create an object that queries the tracking database
                SqlTrackingQuery query
                    = new SqlTrackingQuery(_connectionString);

                //retrieve all workflows based on query options
                workflows = query.GetWorkflows(options);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                Console.WriteLine("SqlException in QueryWorkflowList: {0}",
                    e.Message);
            }

            return workflows;
        }

        #endregion
    }
}
