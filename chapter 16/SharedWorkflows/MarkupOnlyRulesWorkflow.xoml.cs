using System;
using System.Workflow.Activities;

namespace SharedWorkflows
{
    public partial class MarkupOnlyRulesWorkflow
        : SequentialWorkflowActivity
    {
        private Int32 _theNumber;

        public Int32 TheNumber
        {
            get { return _theNumber; }
            set { _theNumber = value; }
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
