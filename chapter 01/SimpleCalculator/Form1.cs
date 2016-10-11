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
using System.Threading;
using System.Windows.Forms;
using System.Workflow.Runtime;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        private WorkflowRuntime _workflowRuntime;
        private AutoResetEvent _waitHandle = new AutoResetEvent(false);
        private String _operation = String.Empty;
        private Int32 _number1;
        private Int32 _number2;
        private Double _result;

        public Form1()
        {
            InitializeComponent();

            //start up the workflow runtime. must be done
            //only once per AppDomain
            InitializeWorkflowRuntime();
        }

        /// <summary>
        /// Start the workflow runtime
        /// </summary>
        private void InitializeWorkflowRuntime()
        {
            _workflowRuntime = new WorkflowRuntime();
            _workflowRuntime.WorkflowCompleted
                += delegate(object sender, WorkflowCompletedEventArgs e)
                {
                    _result = (Double)e.OutputParameters["Result"];
                    _waitHandle.Set();
                };
            _workflowRuntime.WorkflowTerminated
                += delegate(object sender, WorkflowTerminatedEventArgs e)
                {
                    MessageBox.Show(String.Format(
                        "Workflow Terminated: {0}", e.Exception.Message),
                        "Error in Workflow");
                    _waitHandle.Set();
                };
        }

        private void NumericButton_Click(object sender, EventArgs e)
        {
            txtNumber.AppendText(((Button)sender).Text.Trim());
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        /// <summary>
        /// An operation button was pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OperationButton_Click(object sender, EventArgs e)
        {
            try
            {
                _number1 = Int32.Parse(txtNumber.Text);
                _operation = ((Button)sender).Text.Trim();
                txtNumber.Clear();
            }
            catch (Exception exception)
            {
                MessageBox.Show(String.Format(
                    "Operation_Click error: {0}",
                    exception.Message));
            }
        }

        /// <summary>
        /// The equals button was pressed. Invoke the workflow
        /// that performs the calculation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Equals_Click(object sender, EventArgs e)
        {
            try
            {
                _number2 = Int32.Parse(txtNumber.Text);

                //create a dictionary with input arguments
                Dictionary<String, Object> wfArguments
                    = new Dictionary<string, object>();
                wfArguments.Add("Number1", _number1);
                wfArguments.Add("Number2", _number2);
                wfArguments.Add("Operation", _operation);

                WorkflowInstance instance
                    = _workflowRuntime.CreateWorkflow(
                        typeof(SimpleCalculatorWorkflow.Workflow1),
                            wfArguments);
                instance.Start();

                _waitHandle.WaitOne();

                //display the result
                Clear();
                txtNumber.Text = _result.ToString();
            }
            catch (Exception exception)
            {
                MessageBox.Show(String.Format(
                    "Equals error: {0}", exception.Message));
            }
        }

        private void Clear()
        {
            txtNumber.Clear();
            _number1 = 0;
            _number2 = 0;
            _operation = String.Empty;
        }
    }
}