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
using System.Workflow.Runtime.Tracking;

namespace Bukovics.Workflow.Hosting
{
    /// <summary>
    /// A tracking service that uses the ConsoleTrackingChannel
    /// to write tracking data to the Console
    /// </summary>
    public class ConsoleTrackingService : TrackingService
    {
        private TrackingProfile _defaultProfile;

        public ConsoleTrackingService()
            : base()
        {
            //create and save a default profile
            _defaultProfile = BuildDefaultProfile();
        }

        /// <summary>
        /// Retrieve the tracking channel
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        protected override TrackingChannel GetTrackingChannel(
            TrackingParameters parameters)
        {
            //return an instance of the custom tracking channel
            return new ConsoleTrackingChannel();
        }

        /// <summary>
        /// Retrieve a tracking profile for a workflow instance
        /// </summary>
        /// <param name="workflowInstanceId"></param>
        /// <returns></returns>
        protected override TrackingProfile GetProfile(
            Guid workflowInstanceId)
        {
            //always return the default profile
            return _defaultProfile;
        }

        /// <summary>
        /// Retrieve a tracking profile for a workflow type
        /// </summary>
        /// <param name="workflowType"></param>
        /// <param name="profileVersionId"></param>
        /// <returns></returns>
        protected override TrackingProfile GetProfile(
            Type workflowType, Version profileVersionId)
        {
            //always return the default profile
            return _defaultProfile;
        }

        /// <summary>
        /// Called to retrieve a tracking profile
        /// </summary>
        /// <param name="workflowType"></param>
        /// <param name="profile"></param>
        /// <returns></returns>
        protected override bool TryGetProfile(
            Type workflowType, out TrackingProfile profile)
        {
            //always return the default profile
            profile = _defaultProfile;
            return true;
        }

        /// <summary>
        /// Called to reload a tracking profile that has changed
        /// </summary>
        /// <param name="workflowType"></param>
        /// <param name="workflowInstanceId"></param>
        /// <param name="profile"></param>
        /// <returns></returns>
        protected override bool TryReloadProfile(
            Type workflowType, Guid workflowInstanceId,
            out TrackingProfile profile)
        {
            //always return false to indicate that the profile
            //has not changed
            profile = null;
            return false;
        }

        /// <summary>
        /// Creates and saves a default tracking profile
        /// </summary>
        /// <returns></returns>
        private TrackingProfile BuildDefaultProfile()
        {
            //return a default profile that tracks all possible
            //workflow events and activity status values
            TrackingProfile profile = new TrackingProfile();

            //
            //create a workflow track point and location
            //
            WorkflowTrackPoint workflowPoint
                = new WorkflowTrackPoint();
            //add all possible workflow events
            List<TrackingWorkflowEvent> workflowEvents
                = new List<TrackingWorkflowEvent>();
            workflowEvents.AddRange(
                Enum.GetValues(typeof(TrackingWorkflowEvent))
                    as IEnumerable<TrackingWorkflowEvent>);
            WorkflowTrackingLocation workflowLocation
                = new WorkflowTrackingLocation(workflowEvents);
            workflowPoint.MatchingLocation = workflowLocation;
            profile.WorkflowTrackPoints.Add(workflowPoint);

            //
            //create an activity track point and location
            //
            ActivityTrackPoint activityPoint
                = new ActivityTrackPoint();
            //add all possible activity execution status values
            List<ActivityExecutionStatus> activityStatus
                = new List<ActivityExecutionStatus>();
            activityStatus.AddRange(
                Enum.GetValues(typeof(ActivityExecutionStatus))
                    as IEnumerable<ActivityExecutionStatus>);
            ActivityTrackingLocation activityLocation
                = new ActivityTrackingLocation(
                    typeof(Activity), true, activityStatus);
            activityPoint.MatchingLocations.Add(activityLocation);
            profile.ActivityTrackPoints.Add(activityPoint);

            //
            //create a user track point and location
            //
            UserTrackPoint userPoint = new UserTrackPoint();
            UserTrackingLocation userLocation
                = new UserTrackingLocation(
                    typeof(Object), typeof(Activity));
            userLocation.MatchDerivedActivityTypes = true;
            userLocation.MatchDerivedArgumentTypes = true;
            userPoint.MatchingLocations.Add(userLocation);
            profile.UserTrackPoints.Add(userPoint);

            //set the profile version
            profile.Version = new Version(1, 0, 0);
            return profile;
        }
    }
}
