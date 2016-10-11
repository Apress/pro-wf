@echo off
@echo Compile Rules Workflow
@echo Must be run from a Windows SDK CMD Shell
rem add /library:bin if this is not executed in the bin directory

wfc.exe bin\SerializedCodedWorkflow.xoml /target:assembly /debug:- /resource:bin\ProWF.MyNewWorkflowClass.rules /reference:bin\SharedWorkflows.dll /out:bin\MyNewAssembly.dll

pause