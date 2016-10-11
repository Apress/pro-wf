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
using System.Workflow.Runtime.Tracking;
using System.Workflow.Activities.Rules;

namespace Bukovics.Workflow.Hosting
{
    /// <summary>
    /// A tracking channel that writes tracking data
    /// directly to the Console
    /// </summary>
    public class ConsoleTrackingChannel : TrackingChannel
    {
        /// <summary>
        /// Invoked by the runtime to send tracking data 
        /// to the service
        /// </summary>
        /// <param name="record"></param>
        protected override void Send(TrackingRecord record)
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
                    RuleActionTrackingEvent ruleAction
                        = userRecord.UserData as RuleActionTrackingEvent;
                    Console.WriteLine(
                        "{0:HH:mm:ss.fff} RuleAction from {1} Rule:{2} Result:{3}",
                        userRecord.EventDateTime,
                        userRecord.QualifiedName,
                        ruleAction.RuleName,
                        ruleAction.ConditionResult);
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
        /// The workflow instance has completed or terminated
        /// </summary>
        protected override void InstanceCompletedOrTerminated()
        {
            Console.WriteLine("Workflow instance completed or terminated");
        }
    }
}
