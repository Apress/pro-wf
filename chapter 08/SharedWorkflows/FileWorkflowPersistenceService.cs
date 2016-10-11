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
using System.Collections.Generic;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.Workflow.ComponentModel;

namespace SharedWorkflows
{
    /// <summary>
    /// A file based workflow persistence service
    /// </summary>
    public class FileWorkflowPersistenceService
        : WorkflowPersistenceService
    {
        private String _path = Environment.CurrentDirectory;

        #region Abstract method implementations

        /// <summary>
        /// Persist the current state of the entire workflow
        /// </summary>
        /// <param name="rootActivity"></param>
        /// <param name="unlock"></param>
        protected override void SaveWorkflowInstanceState(
            Activity rootActivity, bool unlock)
        {
            //get the workflow instance Id
            Guid instanceId = WorkflowEnvironment.WorkflowInstanceId;

            //determine the status of the workflow
            WorkflowStatus status =
                WorkflowPersistenceService.GetWorkflowStatus(rootActivity);
            switch (status)
            {
                case WorkflowStatus.Completed:
                case WorkflowStatus.Terminated:
                    //delete the persisted workflow
                    DeleteWorkflow(instanceId);
                    break;
                default:
                    //save the workflow
                    Serialize(instanceId, Guid.Empty, rootActivity);
                    break;
            }
        }

        /// <summary>
        /// Load an entire workflow 
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        protected override Activity LoadWorkflowInstanceState(
            Guid instanceId)
        {
            Activity activity = Deserialize(instanceId, Guid.Empty, null);
            if (activity == null)
            {
                ThrowException(instanceId,
                    "Unable to deserialize workflow", null);
            }
            return activity;
        }

        /// <summary>
        /// Persist a completed activity context
        /// </summary>
        /// <remarks>
        /// This persists completed activities that were part
        /// of an execution scope. Example:  Activities
        /// within a CompensatableSequenceActivity. 
        /// </remarks>
        /// <param name="activity"></param>
        protected override void SaveCompletedContextActivity(
            Activity activity)
        {
            //get the workflow instance Id
            Guid instanceId = WorkflowEnvironment.WorkflowInstanceId;

            //get the context Id which identifies the activity scope
            //within the workflow instance
            Guid contextId = (Guid)activity.GetValue(
                Activity.ActivityContextGuidProperty);

            //persist the activity for this workflow
            Serialize(instanceId, contextId, activity);
        }

        /// <summary>
        /// Load an activity context
        /// </summary>
        /// <param name="scopeId"></param>
        /// <param name="outerActivity"></param>
        /// <returns></returns>
        protected override Activity LoadCompletedContextActivity(
            Guid scopeId, Activity outerActivity)
        {
            //get the workflow instance Id
            Guid instanceId = WorkflowEnvironment.WorkflowInstanceId;

            Activity activity = Deserialize(instanceId, scopeId, outerActivity);
            if (activity == null)
            {
                ThrowException(instanceId,
                    "Unable to deserialize activity", null);
            }
            return activity;
        }

        protected override void UnlockWorkflowInstanceState(
            Activity rootActivity)
        {
            //locking not implemented
        }

        protected override bool UnloadOnIdle(Activity activity)
        {
            //always unload on idle
            return true;
        }

        #endregion

        #region Persistence and File Management

        /// <summary>
        /// Serialize the workflow or an activity context
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="contextId"></param>
        /// <param name="activity"></param>
        private void Serialize(
            Guid instanceId, Guid contextId, Activity activity)
        {
            try
            {
                String fileName = GetFilePath(instanceId, contextId);
                using (FileStream stream = new FileStream(
                    fileName, FileMode.Create))
                {
                    activity.Save(stream);
                }
            }
            catch (ArgumentException e)
            {
                ThrowException(instanceId,
                    "Serialize: Path has invalid argument", e);
            }
            catch (DirectoryNotFoundException e)
            {
                ThrowException(instanceId,
                    "Serialize: Directory not found", e);
            }
            catch (Exception e)
            {
                ThrowException(instanceId,
                    "Serialize: Unknown exception", e);
            }
        }

        /// <summary>
        /// Deserialize a workflow or an activity context
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="contextId"></param>
        /// <param name="rootActivity"></param>
        /// <returns></returns>
        private Activity Deserialize(
            Guid instanceId, Guid contextId, Activity rootActivity)
        {
            Activity activity = null;
            try
            {
                String fileName = GetFilePath(instanceId, contextId);
                using (FileStream stream = new FileStream(
                    fileName, FileMode.Open))
                {
                    activity = Activity.Load(stream, rootActivity);
                }
            }
            catch (ArgumentException e)
            {
                ThrowException(instanceId,
                    "Deserialize: Path has invalid argument", e);
            }
            catch (FileNotFoundException e)
            {
                ThrowException(instanceId,
                    "Deserialize: File not found", e);
            }
            catch (DirectoryNotFoundException e)
            {
                ThrowException(instanceId,
                    "Deserialize: Directory not found", e);
            }
            catch (Exception e)
            {
                ThrowException(instanceId,
                    "Deserialize: Unknown exception", e);
            }
            return activity;
        }

        /// <summary>
        /// Delete a workflow and any related activity context files
        /// </summary>
        /// <param name="instanceId"></param>
        private void DeleteWorkflow(Guid instanceId)
        {
            try
            {
                String[] files = Directory.GetFiles(
                    _path, instanceId.ToString() + "*");

                foreach (String file in files)
                {
                    if (File.Exists(file))
                    {
                        File.Delete(file);
                    }
                }
            }
            catch (ArgumentException e)
            {
                ThrowException(instanceId,
                    "Delete: Path has invalid argument", e);
            }
            catch (DirectoryNotFoundException e)
            {
                ThrowException(instanceId,
                    "Delete: Directory not found", e);
            }
            catch (Exception e)
            {
                ThrowException(instanceId,
                    "Delete: Unknown exception", e);
            }
        }

        /// <summary>
        /// Determine the full file path
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="contextId"></param>
        /// <returns></returns>
        private String GetFilePath(Guid instanceId, Guid contextId)
        {
            String fullPath = String.Empty;
            if (contextId == Guid.Empty)
            {
                //create a path for the entire workflow.
                //Naming convention is [instanceId].wf
                fullPath = Path.Combine(_path, String.Format("{0}.{1}",
                    instanceId, "wf"));
            }
            else
            {
                //create a path for a single activity context
                //within the workflow.
                //naming convention is [instanceId].[contextId].wfc
                fullPath = Path.Combine(_path, String.Format("{0}.{1}.{2}",
                    instanceId, contextId, "wfc"));
            }
            return fullPath;
        }

        #endregion

        #region Existing Workflow Management

        /// <summary>
        /// Return a list of all workflow Ids that are persisted
        /// </summary>
        /// <returns></returns>
        public List<Guid> GetAllWorkflows()
        {
            List<Guid> workflows = new List<Guid>();
            String[] files = Directory.GetFiles(_path, "*.wf");
            foreach (String file in files)
            {
                //turn the file name into a Guid
                Guid instanceId = new Guid(
                    Path.GetFileNameWithoutExtension(file));
                workflows.Add(instanceId);
            }

            return workflows;
        }

        #endregion

        #region Common Error handling

        /// <summary>
        /// Throw an exception due to an error
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        private void ThrowException(Guid instanceId, String message,
            Exception inner)
        {
            if (inner == null)
            {
                throw new PersistenceException(
                    String.Format("Workflow: {0} Error: {1}",
                        instanceId, message));
            }
            else
            {
                throw new PersistenceException(
                    String.Format("Workflow: {0} Error: {1}: Inner: {2}",
                        instanceId, message, inner.Message), inner);
            }
        }

        #endregion
    }
}
