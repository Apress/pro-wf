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
using System.Threading;
using System.Collections.Generic;
using System.Workflow.Runtime;
using NUnit.Framework;

namespace ActivitiesUnitTest
{
    /// <summary>
    /// NUnit tests for the ValidateAccountActivity
    /// </summary>
    [TestFixture]
    public class ValidateAccountActivityTest
    {
        private WorkflowRuntime _workflowRuntime;
        private AutoResetEvent _waitHandle = new AutoResetEvent(false);
        private WorkflowCompletedEventArgs _completedArgs;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            _workflowRuntime = new WorkflowRuntime();
            _workflowRuntime.WorkflowCompleted
                += delegate(object sender, WorkflowCompletedEventArgs e)
                {
                    //save the completed event args
                    _completedArgs = e;
                    _waitHandle.Set();
                };
            _workflowRuntime.WorkflowTerminated
                += delegate(object sender, WorkflowTerminatedEventArgs e)
                {
                    Assert.Fail(
                        "Workflow terminated: {0}", e.Exception.Message);
                    _waitHandle.Set();
                };
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            if (_workflowRuntime != null)
            {
                _workflowRuntime.StopRuntime();
            }
        }

        /// <summary>
        /// Test for a valid account
        /// </summary>
        [Test]
        public void ValidAccountTest()
        {
            Dictionary<String, Object> wfArguments
                = new Dictionary<string, object>();
            wfArguments.Add("AccountId", 1001);

            WorkflowInstance instance = _workflowRuntime.CreateWorkflow(
                typeof(OrderEntryActivities.ValidateAccountActivity),
                wfArguments);
            Assert.IsNotNull(instance,
                "Could not create workflow instance");
            instance.Start();

            _waitHandle.WaitOne(5000, false);

            Assert.IsNotNull(_completedArgs,
                "Completed workflow event args should not be null");

            Decimal credit
                = (Decimal)_completedArgs.OutputParameters["AvailableCredit"];
            Assert.AreEqual((Decimal)100.00, credit,
                "AvailableCredit value is incorrect");

            Boolean accountVerified
                = (Boolean)_completedArgs.OutputParameters["IsAccountVerified"];
            Assert.IsTrue(accountVerified,
                "IsAccountVerified value is incorrect");
        }

        /// <summary>
        /// Test for an invalid account
        /// </summary>
        [Test]
        public void InValidAccountTest()
        {
            Dictionary<String, Object> wfArguments
                = new Dictionary<string, object>();
            wfArguments.Add("AccountId", 9999); //invalid

            WorkflowInstance instance = _workflowRuntime.CreateWorkflow(
                typeof(OrderEntryActivities.ValidateAccountActivity),
                wfArguments);
            Assert.IsNotNull(instance,
                "Could not create workflow instance");
            instance.Start();

            _waitHandle.WaitOne(5000, false);

            Assert.IsNotNull(_completedArgs,
                "Completed workflow event args should not be null");

            Decimal credit
                = (Decimal)_completedArgs.OutputParameters["AvailableCredit"];
            Assert.AreEqual((Decimal)0, credit,
                "AvailableCredit value is incorrect");

            Boolean accountVerified
                = (Boolean)_completedArgs.OutputParameters["IsAccountVerified"];
            Assert.IsFalse(accountVerified,
                "IsAccountVerified value is incorrect");
        }
    }
}
