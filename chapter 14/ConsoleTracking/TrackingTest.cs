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
using System.Workflow.ComponentModel;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Tracking;

using Bukovics.Workflow.Hosting;
using SharedWorkflows;

namespace ConsoleTracking
{
    /// <summary>
    /// Test the TrackingExampleWorkflow
    /// </summary>
    public class TrackingTest
    {
        private static String _connStringTracking = String.Format(
            "Initial Catalog={0};Data Source={1};Integrated Security={2};",
                "WorkflowTracking", @"localhost\SQLEXPRESS", "SSPI");

        public static void Run()
        {
#if USE_APP_CONFIG
            //load the tracking service via the app.config.
            //requires a reference to System.Configuration
            using (WorkflowRuntimeManager manager
                = new WorkflowRuntimeManager(
                    new WorkflowRuntime("WorkflowRuntime")))
#else
            using (WorkflowRuntimeManager manager
                = new WorkflowRuntimeManager(new WorkflowRuntime()))
#endif
            {
#if (!USE_APP_CONFIG)
                //add services that we require
                AddServices(manager.WorkflowRuntime);
#endif
#if CUSTOM_PROFILE
                //add a custom tracking profile for this workflow
                AddCustomTrackingProfile();
#endif
                //start the runtime 
                manager.WorkflowRuntime.StartRuntime();

#if RULES_TRACKING
                Console.WriteLine("Executing TrackingRulesWorkflow");
                WorkflowInstanceWrapper instance =
                    manager.StartWorkflow(
                        typeof(SharedWorkflows.TrackingRulesWorkflow), null);
                manager.WaitAll(2000);
                Console.WriteLine("Completed TrackingRulesWorkflow\n\r");
#elif USER_DATA_TRACKING
                Console.WriteLine("Executing TrackingExampleWorkflow");
                WorkflowInstanceWrapper instance =
                    manager.StartWorkflow(
                        typeof(SharedWorkflows.TrackingUserDataWorkflow), null);
                manager.WaitAll(2000);
                Console.WriteLine("Completed TrackingExampleWorkflow\n\r");
#else
                Console.WriteLine("Executing TrackingExampleWorkflow");
                WorkflowInstanceWrapper instance =
                    manager.StartWorkflow(
                        typeof(SharedWorkflows.TrackingExampleWorkflow), null);
                manager.WaitAll(2000);
                Console.WriteLine("Completed TrackingExampleWorkflow\n\r");
#endif

#if (!CUSTOM_SERVICE)
                //query and display tracking data for this single instance
                TrackingConsoleWriter trackingWriter
                    = new TrackingConsoleWriter(_connStringTracking);
                trackingWriter.DisplayTrackingData(instance.Id);
#endif

#if CUSTOM_PROFILE
                //delete the tracking profile that we created
                DeleteCustomTrackingProfile();
#endif
            }
        }

#if (!USE_APP_CONFIG)
        /// <summary>
        /// Add any services needed by the runtime engine
        /// </summary>
        /// <param name="instance"></param>
        private static void AddServices(WorkflowRuntime instance)
        {
#if CUSTOM_SERVICE
            //use the custom Console tracking service
            ConsoleTrackingService tracking
                = new ConsoleTrackingService();
#else
            //use the standard SQL Server tracking service
            SqlTrackingService tracking
                = new SqlTrackingService(_connStringTracking);
#endif

//#if RULES_TRACKING || USER_DATA_TRACKING || CUSTOM_SERVICE
            //when tracking rules or custom user track points, 
            //the PartitionOnCompletion causes
            //a problem with the SqlTrackingQuery class. The class
            //is unable to retrieve user tracking entries as 
            //UserEvents.  Turning PartitionOnCompletion off 
            //solves the problem.
//#else
            //use automatic database partitioning.  this will create 
            //a new set of tables for each time period.  the default 
            //time period is monthly ('m') but can be changed using
            //the SetPartitionInterval stored procedure. 
            //tracking.PartitionOnCompletion = true;
//#endif
            //add the service to the runtime
            instance.AddService(tracking);
        }
#endif

#if CUSTOM_PROFILE
        /// <summary>
        /// Add a custom tracking profile for this workflow
        /// </summary>
        private static void AddCustomTrackingProfile()
        {
            //get the default profile for the workflow
            TrackingProfileHelper helper
                = new TrackingProfileHelper(_connStringTracking);
            TrackingProfile profile = helper.RetrieveProfile(
                typeof(SharedWorkflows.TrackingRulesWorkflow));
            if (profile != null)
            {
                //add an activity track point that captures workflow
                //field values prior to the RuleSet execution
                ActivityTrackingLocation location = new ActivityTrackingLocation();
                location.ActivityTypeName = "PolicyActivity";
                location.ExecutionStatusEvents.Add(
                    ActivityExecutionStatus.Executing);
                ActivityTrackPoint point = new ActivityTrackPoint();
                point.Extracts.Add(new WorkflowDataTrackingExtract("field1"));
                point.Extracts.Add(new WorkflowDataTrackingExtract("field2"));
                point.Extracts.Add(new WorkflowDataTrackingExtract("field3"));
                point.Annotations.Add("Before RuleSet execution");
                point.MatchingLocations.Add(location);
                profile.ActivityTrackPoints.Add(point);

                //extract values for the same fields after RuleSet execution
                location = new ActivityTrackingLocation();
                location.ActivityTypeName = "PolicyActivity";
                location.ExecutionStatusEvents.Add(ActivityExecutionStatus.Closed);
                point = new ActivityTrackPoint();
                point.Extracts.Add(new WorkflowDataTrackingExtract("field1"));
                point.Extracts.Add(new WorkflowDataTrackingExtract("field2"));
                point.Extracts.Add(new WorkflowDataTrackingExtract("field3"));
                point.Annotations.Add("After RuleSet execution");
                point.MatchingLocations.Add(location);
                profile.ActivityTrackPoints.Add(point);

                //assign a new version that +1 greater than the last
                profile.Version = new Version(
                    profile.Version.Major, profile.Version.Minor + 1, 0);
                //apply the update to the tracking profile
                helper.UpdateProfile(
                    profile, typeof(SharedWorkflows.TrackingRulesWorkflow));
            }
        }

        /// <summary>
        /// Delete the tracking profile for this workflow
        /// </summary>
        private static void DeleteCustomTrackingProfile()
        {
            //get the default profile
            TrackingProfileHelper helper
                = new TrackingProfileHelper(_connStringTracking);
            helper.DeleteProfile(
                typeof(SharedWorkflows.TrackingRulesWorkflow));
        }
#endif

    }
}


