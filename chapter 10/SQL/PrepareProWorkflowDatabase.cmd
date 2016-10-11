@echo off
@echo CREATE TEST DATABASE
sqlcmd -S localhost\SQLEXPRESS -E -m-1 -r1 -d master -i ProWorkflowCreate.sql 
sqlcmd -S localhost\SQLEXPRESS -E -m-1 -r1 -d ProWorkflow -i PopulateTestTables.sql 
pause