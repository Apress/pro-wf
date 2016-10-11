@echo off
@echo CREATE WORKFLOWTRACKING DATABASE
sqlcmd -S localhost\SQLEXPRESS -E -m-1 -r1 -Q "create database WorkflowTracking"
sqlcmd -S localhost\SQLEXPRESS -E -m-1 -r1 -d WorkflowTracking -i Tracking_Schema.sql
sqlcmd -S localhost\SQLEXPRESS -E -m-1 -r1 -d WorkflowTracking -i Tracking_Logic.sql
pause
