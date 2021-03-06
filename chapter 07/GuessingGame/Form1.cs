using System;
using System.Windows.Forms;

using System.Workflow.Activities;
using System.Workflow.Runtime;

using Bukovics.Workflow.Hosting;
using SharedWorkflows;

namespace GuessingGame
{
    /// <summary>
    /// The WinForm for the number guessing game
    /// </summary>
    public partial class Form1 : Form
    {
        private WorkflowRuntimeManager _workflowManager;
        private GuessingGameService _gameService;
        private Guid _instanceId = Guid.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //create workflow runtime and manager
            _workflowManager = new WorkflowRuntimeManager(
                new WorkflowRuntime());

            //add the external data exchange service to the runtime
            ExternalDataExchangeService exchangeService
                = new ExternalDataExchangeService();
            _workflowManager.WorkflowRuntime.AddService(exchangeService);

            //add our local service 
            _gameService = new GuessingGameService();
            exchangeService.AddService(_gameService);

            //subscribe to the service event that sends us messages
            _gameService.MessageReceived
                += new EventHandler<MessageReceivedEventArgs>(
                    gameService_MessageReceived);

            //handle the terminated event
            _workflowManager.WorkflowRuntime.WorkflowTerminated
                += new EventHandler<WorkflowTerminatedEventArgs>(
                    WorkflowRuntime_WorkflowTerminated);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            //cleanup the workflow runtime
            if (_workflowManager != null)
            {
                _workflowManager.Dispose();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //start the workflow without any parameters
            _workflowManager.StartWorkflow(
                typeof(GuessingGameWorkflow), null);

            //start the workflow that uses custom activities
            //generated by the WCA utility
            //_workflowManager.StartWorkflow(
            //    typeof(GuessingGameWcaWorkflow), null);

            btnGuess.Enabled = true;
        }

        private void btnGuess_Click(object sender, EventArgs e)
        {
            //pass the guess to the running workflow
            try
            {
                Int32 nextGuess = Int32.Parse(txtNextNumber.Text);
                //raise the GuessReceived event in the game service
                _gameService.OnGuessReceived(
                    new GuessReceivedEventArgs(_instanceId, nextGuess));
            }
            catch (FormatException)
            {
                MessageBox.Show("Could not parse the number");
            }
            catch (OverflowException)
            {
                MessageBox.Show("The number exceeded the allowed limits");
            }
            catch (EventDeliveryFailedException)
            {
                MessageBox.Show(
                    "Your guess was not delivered.\n\rStart a new game.",
                    "Game Ended", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private delegate void UpdateDelegate();

        private void gameService_MessageReceived(object sender,
            MessageReceivedEventArgs e)
        {
            UpdateDelegate theDelegate = delegate()
            {
                //update the UI with the message
                lblMessage.Text = e.Message;
                txtNextNumber.SelectAll();
                txtNextNumber.Focus();
            };

            //save the workflow instance Id. we will need it
            //when we make the return trip with a guess.
            _instanceId = e.InstanceId;

            //execute the anonymous delegate on the UI thread
            this.Invoke(theDelegate);
        }

        void WorkflowRuntime_WorkflowTerminated(object sender,
            WorkflowTerminatedEventArgs e)
        {
            MessageBox.Show(
                "Sorry, but the time expired since your last guess.",
                "Start a New Game", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}