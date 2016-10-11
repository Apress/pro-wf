<%@ Application Language="C#" %>

<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        //create an instance of the workflow runtime, loading
        //settings from the Web.Config
        System.Workflow.Runtime.WorkflowRuntime workflowRuntime =
            new System.Workflow.Runtime.WorkflowRuntime("WorkflowRuntime");

        //start the workflow runtime
        workflowRuntime.StartRuntime();

        //save the runtime for use by individual pages
        Application["WorkflowRuntime"] = workflowRuntime;
    }

    void Application_End(object sender, EventArgs e)
    {
        //shut down the workflow runtime
        System.Workflow.Runtime.WorkflowRuntime workflowRuntime =
            Application["WorkflowRuntime"]
                as System.Workflow.Runtime.WorkflowRuntime;
        workflowRuntime.StopRuntime();
    }
</script>

