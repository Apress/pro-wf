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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Workflow.Runtime.Tracking;

namespace Bukovics.Workflow.Hosting
{
    /// <summary>
    /// Routines that assist with tracking profile management
    /// </summary>
    public class TrackingProfileHelper
    {
        private String _connectionString = String.Empty;

        public TrackingProfileHelper(String connString)
        {
            _connectionString = connString;
        }

        /// <summary>
        /// Retrieve the tracking profile for the workflow type
        /// </summary>
        /// <param name="workflowType"></param>
        /// <returns></returns>
        public TrackingProfile RetrieveProfile(Type workflowType)
        {
            TrackingProfile profile = null;
            try
            {
                String profileXml = null;
                using (SqlConnection conn
                    = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(
                        "GetTrackingProfile", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter(
                        "@TypeFullName", workflowType.FullName));
                    command.Parameters.Add(new SqlParameter(
                        "@AssemblyFullName", workflowType.Assembly.FullName));
                    command.Parameters.Add(new SqlParameter(
                        "@Version", null));
                    command.Parameters.Add(new SqlParameter(
                        "@CreateDefault", true));

                    command.Connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            profileXml = reader["TrackingProfile"] as String;
                        }
                        reader.Close();
                    }
                }

                if (profileXml != null)
                {
                    TrackingProfileSerializer serializer
                        = new TrackingProfileSerializer();
                    using (StringReader reader = new StringReader(profileXml))
                    {
                        profile = serializer.Deserialize(reader);
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(
                    "SqlException in RetrieveProfile: {0}", e.Message);
                throw;
            }

            return profile;
        }

        /// <summary>
        /// Update a tracking profile
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="workflowType"></param>
        public void UpdateProfile(TrackingProfile profile, Type workflowType)
        {
            try
            {
                String profileXml = null;
                TrackingProfileSerializer serializer
                    = new TrackingProfileSerializer();
                using (StringWriter writer = new StringWriter(new StringBuilder()))
                {
                    serializer.Serialize(writer, profile);
                    profileXml = writer.ToString();
                }

                if (profileXml != null)
                {
                    using (SqlConnection conn
                        = new SqlConnection(_connectionString))
                    {
                        SqlCommand command = new SqlCommand(
                            "UpdateTrackingProfile", conn);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter(
                            "@TypeFullName", workflowType.FullName));
                        command.Parameters.Add(new SqlParameter(
                            "@AssemblyFullName", workflowType.Assembly.FullName));
                        command.Parameters.Add(new SqlParameter(
                            "@Version", profile.Version.ToString()));
                        command.Parameters.Add(new SqlParameter(
                            "@TrackingProfileXml", profileXml));

                        command.Connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(
                    "SqlException in UpdateProfile: {0}", e.Message);
                throw;
            }
        }

        /// <summary>
        /// Delete a tracking profile for a workflow
        /// </summary>
        /// <param name="workflowType"></param>
        public void DeleteProfile(Type workflowType)
        {
            try
            {
                using (SqlConnection conn
                    = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(
                        @"DELETE FROM TrackingProfile
                          WHERE WorkflowTypeId IN
                          (SELECT TypeId FROM Type
                           WHERE TypeFullName = @TypeFullName 
                            AND  AssemblyFullName = @AssemblyFullName)",
                        conn);
                    command.Parameters.Add(new SqlParameter(
                        "@TypeFullName", workflowType.FullName));
                    command.Parameters.Add(new SqlParameter(
                        "@AssemblyFullName", workflowType.Assembly.FullName));
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(
                    "SqlException in DeleteProfile: {0}", e.Message);
                throw;
            }
        }
    }
}
