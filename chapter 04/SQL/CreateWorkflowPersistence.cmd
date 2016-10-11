@echo off
@echo CREATE WORKFLOWPERSISTENCE DATABASE
sqlcmd -S localhost\SQLEXPRESS -E -m-1 -r1 -Q "create database WorkflowPersistence"
sqlcmd -S localhost\SQLEXPRESS -E -m-1 -r1 -d WorkflowPersistence -i SqlPersistenceService_Schema.sql
sqlcmd -S localhost\SQLEXPRESS -E -m-1 -r1 -d WorkflowPersistence -i SqlPersistenceService_Logic.sql
pause