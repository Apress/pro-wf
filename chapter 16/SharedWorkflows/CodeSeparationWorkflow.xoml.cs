using System;
using System.Workflow.Activities;

namespace SharedWorkflows
{
    /// <summary>
    /// A simple workflow defined with code separation
    /// </summary>
    public partial class CodeSeparationWorkflow
        : SequentialWorkflowActivity
    {
        private Int32 _theNumber;

        public Int32 TheNumber
        {
            get { return _theNumber; }
            set { _theNumber = value; }
        }

        private void IsNumberPositive(
            object sender, ConditionalEventArgs e)
        {
            e.Result = (TheNumber > 0);
        }

        private void codeNumberIsPositive_ExecuteCode(
            object sender, EventArgs e)
        {
            Console.WriteLine("The number is positive");
        }

        private void codeNumberNotPositive_ExecuteCode(
            object sender, EventArgs e)
        {
            Console.WriteLine("The number is NOT positive");
        }
    }
}
