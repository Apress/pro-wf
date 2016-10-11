using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace SharedWorkflows
{
    partial class CarWorkflow
    {
        #region Designer generated code
        
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding1 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding2 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding3 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding4 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding5 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding6 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding7 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding8 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding9 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            this.setRunning2 = new System.Workflow.Activities.SetStateActivity();
            this.callExternalMethodActivity7 = new System.Workflow.Activities.CallExternalMethodActivity();
            this.handleStopMovement2 = new System.Workflow.Activities.HandleExternalEventActivity();
            this.setRunning = new System.Workflow.Activities.SetStateActivity();
            this.callExternalMethodActivity6 = new System.Workflow.Activities.CallExternalMethodActivity();
            this.handleStopMovement = new System.Workflow.Activities.HandleExternalEventActivity();
            this.setMovingInReverse = new System.Workflow.Activities.SetStateActivity();
            this.callExternalMethodActivity5 = new System.Workflow.Activities.CallExternalMethodActivity();
            this.handleGoReverse = new System.Workflow.Activities.HandleExternalEventActivity();
            this.setMovingForward = new System.Workflow.Activities.SetStateActivity();
            this.callExternalMethodActivity4 = new System.Workflow.Activities.CallExternalMethodActivity();
            this.handleGoForward = new System.Workflow.Activities.HandleExternalEventActivity();
            this.setNotRunning = new System.Workflow.Activities.SetStateActivity();
            this.callExternalMethodActivity3 = new System.Workflow.Activities.CallExternalMethodActivity();
            this.handleStopEngine = new System.Workflow.Activities.HandleExternalEventActivity();
            this.callExternalMethodActivity9 = new System.Workflow.Activities.CallExternalMethodActivity();
            this.setDoneWithCar = new System.Workflow.Activities.SetStateActivity();
            this.callExternalMethodActivity2 = new System.Workflow.Activities.CallExternalMethodActivity();
            this.handleLeaveCar = new System.Workflow.Activities.HandleExternalEventActivity();
            this.setRunningState = new System.Workflow.Activities.SetStateActivity();
            this.callExternalMethodActivity1 = new System.Workflow.Activities.CallExternalMethodActivity();
            this.handleStartEngine = new System.Workflow.Activities.HandleExternalEventActivity();
            this.callExternalMethodActivity8 = new System.Workflow.Activities.CallExternalMethodActivity();
            this.handleBeepHorn = new System.Workflow.Activities.HandleExternalEventActivity();
            this.eventStopMovement2 = new System.Workflow.Activities.EventDrivenActivity();
            this.eventStopMovement = new System.Workflow.Activities.EventDrivenActivity();
            this.eventGoReverse = new System.Workflow.Activities.EventDrivenActivity();
            this.eventGoForward = new System.Workflow.Activities.EventDrivenActivity();
            this.eventStopEngine = new System.Workflow.Activities.EventDrivenActivity();
            this.stateInitializationActivity1 = new System.Workflow.Activities.StateInitializationActivity();
            this.eventLeaveCar = new System.Workflow.Activities.EventDrivenActivity();
            this.eventStartEngine = new System.Workflow.Activities.EventDrivenActivity();
            this.eventBeepHorn = new System.Workflow.Activities.EventDrivenActivity();
            this.DoneWithCarState = new System.Workflow.Activities.StateActivity();
            this.MovingInReverseState = new System.Workflow.Activities.StateActivity();
            this.MovingForwardState = new System.Workflow.Activities.StateActivity();
            this.RunningState = new System.Workflow.Activities.StateActivity();
            this.NotRunningState = new System.Workflow.Activities.StateActivity();
            // 
            // setRunning2
            // 
            this.setRunning2.Name = "setRunning2";
            this.setRunning2.TargetStateName = "RunningState";
            // 
            // callExternalMethodActivity7
            // 
            this.callExternalMethodActivity7.InterfaceType = typeof(SharedWorkflows.ICarServices);
            this.callExternalMethodActivity7.MethodName = "OnSendMessage";
            this.callExternalMethodActivity7.Name = "callExternalMethodActivity7";
            workflowparameterbinding1.ParameterName = "message";
            workflowparameterbinding1.Value = "Stopping movement";
            this.callExternalMethodActivity7.ParameterBindings.Add(workflowparameterbinding1);
            // 
            // handleStopMovement2
            // 
            this.handleStopMovement2.EventName = "StopMovement";
            this.handleStopMovement2.InterfaceType = typeof(SharedWorkflows.ICarServices);
            this.handleStopMovement2.Name = "handleStopMovement2";
            // 
            // setRunning
            // 
            this.setRunning.Name = "setRunning";
            this.setRunning.TargetStateName = "RunningState";
            // 
            // callExternalMethodActivity6
            // 
            this.callExternalMethodActivity6.InterfaceType = typeof(SharedWorkflows.ICarServices);
            this.callExternalMethodActivity6.MethodName = "OnSendMessage";
            this.callExternalMethodActivity6.Name = "callExternalMethodActivity6";
            workflowparameterbinding2.ParameterName = "message";
            workflowparameterbinding2.Value = "Stopping movement";
            this.callExternalMethodActivity6.ParameterBindings.Add(workflowparameterbinding2);
            // 
            // handleStopMovement
            // 
            this.handleStopMovement.EventName = "StopMovement";
            this.handleStopMovement.InterfaceType = typeof(SharedWorkflows.ICarServices);
            this.handleStopMovement.Name = "handleStopMovement";
            // 
            // setMovingInReverse
            // 
            this.setMovingInReverse.Name = "setMovingInReverse";
            this.setMovingInReverse.TargetStateName = "MovingInReverseState";
            // 
            // callExternalMethodActivity5
            // 
            this.callExternalMethodActivity5.InterfaceType = typeof(SharedWorkflows.ICarServices);
            this.callExternalMethodActivity5.MethodName = "OnSendMessage";
            this.callExternalMethodActivity5.Name = "callExternalMethodActivity5";
            workflowparameterbinding3.ParameterName = "message";
            workflowparameterbinding3.Value = "Moving in reverse";
            this.callExternalMethodActivity5.ParameterBindings.Add(workflowparameterbinding3);
            // 
            // handleGoReverse
            // 
            this.handleGoReverse.EventName = "GoReverse";
            this.handleGoReverse.InterfaceType = typeof(SharedWorkflows.ICarServices);
            this.handleGoReverse.Name = "handleGoReverse";
            // 
            // setMovingForward
            // 
            this.setMovingForward.Name = "setMovingForward";
            this.setMovingForward.TargetStateName = "MovingForwardState";
            // 
            // callExternalMethodActivity4
            // 
            this.callExternalMethodActivity4.InterfaceType = typeof(SharedWorkflows.ICarServices);
            this.callExternalMethodActivity4.MethodName = "OnSendMessage";
            this.callExternalMethodActivity4.Name = "callExternalMethodActivity4";
            workflowparameterbinding4.ParameterName = "message";
            workflowparameterbinding4.Value = "Moving forward";
            this.callExternalMethodActivity4.ParameterBindings.Add(workflowparameterbinding4);
            // 
            // handleGoForward
            // 
            this.handleGoForward.EventName = "GoForward";
            this.handleGoForward.InterfaceType = typeof(SharedWorkflows.ICarServices);
            this.handleGoForward.Name = "handleGoForward";
            // 
            // setNotRunning
            // 
            this.setNotRunning.Name = "setNotRunning";
            this.setNotRunning.TargetStateName = "NotRunningState";
            // 
            // callExternalMethodActivity3
            // 
            this.callExternalMethodActivity3.InterfaceType = typeof(SharedWorkflows.ICarServices);
            this.callExternalMethodActivity3.MethodName = "OnSendMessage";
            this.callExternalMethodActivity3.Name = "callExternalMethodActivity3";
            workflowparameterbinding5.ParameterName = "message";
            workflowparameterbinding5.Value = "Stopping the engine";
            this.callExternalMethodActivity3.ParameterBindings.Add(workflowparameterbinding5);
            // 
            // handleStopEngine
            // 
            this.handleStopEngine.EventName = "StopEngine";
            this.handleStopEngine.InterfaceType = typeof(SharedWorkflows.ICarServices);
            this.handleStopEngine.Name = "handleStopEngine";
            // 
            // callExternalMethodActivity9
            // 
            this.callExternalMethodActivity9.InterfaceType = typeof(SharedWorkflows.ICarServices);
            this.callExternalMethodActivity9.MethodName = "OnSendMessage";
            this.callExternalMethodActivity9.Name = "callExternalMethodActivity9";
            workflowparameterbinding6.ParameterName = "message";
            workflowparameterbinding6.Value = "The car is parked and not running";
            this.callExternalMethodActivity9.ParameterBindings.Add(workflowparameterbinding6);
            // 
            // setDoneWithCar
            // 
            this.setDoneWithCar.Name = "setDoneWithCar";
            this.setDoneWithCar.TargetStateName = "DoneWithCarState";
            // 
            // callExternalMethodActivity2
            // 
            this.callExternalMethodActivity2.InterfaceType = typeof(SharedWorkflows.ICarServices);
            this.callExternalMethodActivity2.MethodName = "OnSendMessage";
            this.callExternalMethodActivity2.Name = "callExternalMethodActivity2";
            workflowparameterbinding7.ParameterName = "message";
            workflowparameterbinding7.Value = "Leaving the car";
            this.callExternalMethodActivity2.ParameterBindings.Add(workflowparameterbinding7);
            // 
            // handleLeaveCar
            // 
            this.handleLeaveCar.EventName = "LeaveCar";
            this.handleLeaveCar.InterfaceType = typeof(SharedWorkflows.ICarServices);
            this.handleLeaveCar.Name = "handleLeaveCar";
            // 
            // setRunningState
            // 
            this.setRunningState.Name = "setRunningState";
            this.setRunningState.TargetStateName = "RunningState";
            // 
            // callExternalMethodActivity1
            // 
            this.callExternalMethodActivity1.InterfaceType = typeof(SharedWorkflows.ICarServices);
            this.callExternalMethodActivity1.MethodName = "OnSendMessage";
            this.callExternalMethodActivity1.Name = "callExternalMethodActivity1";
            workflowparameterbinding8.ParameterName = "message";
            workflowparameterbinding8.Value = "Started Engine";
            this.callExternalMethodActivity1.ParameterBindings.Add(workflowparameterbinding8);
            // 
            // handleStartEngine
            // 
            this.handleStartEngine.EventName = "StartEngine";
            this.handleStartEngine.InterfaceType = typeof(SharedWorkflows.ICarServices);
            this.handleStartEngine.Name = "handleStartEngine";
            // 
            // callExternalMethodActivity8
            // 
            this.callExternalMethodActivity8.InterfaceType = typeof(SharedWorkflows.ICarServices);
            this.callExternalMethodActivity8.MethodName = "OnSendMessage";
            this.callExternalMethodActivity8.Name = "callExternalMethodActivity8";
            workflowparameterbinding9.ParameterName = "message";
            workflowparameterbinding9.Value = "Beep!";
            this.callExternalMethodActivity8.ParameterBindings.Add(workflowparameterbinding9);
            // 
            // handleBeepHorn
            // 
            this.handleBeepHorn.EventName = "BeepHorn";
            this.handleBeepHorn.InterfaceType = typeof(SharedWorkflows.ICarServices);
            this.handleBeepHorn.Name = "handleBeepHorn";
            // 
            // eventStopMovement2
            // 
            this.eventStopMovement2.Activities.Add(this.handleStopMovement2);
            this.eventStopMovement2.Activities.Add(this.callExternalMethodActivity7);
            this.eventStopMovement2.Activities.Add(this.setRunning2);
            this.eventStopMovement2.Name = "eventStopMovement2";
            // 
            // eventStopMovement
            // 
            this.eventStopMovement.Activities.Add(this.handleStopMovement);
            this.eventStopMovement.Activities.Add(this.callExternalMethodActivity6);
            this.eventStopMovement.Activities.Add(this.setRunning);
            this.eventStopMovement.Name = "eventStopMovement";
            // 
            // eventGoReverse
            // 
            this.eventGoReverse.Activities.Add(this.handleGoReverse);
            this.eventGoReverse.Activities.Add(this.callExternalMethodActivity5);
            this.eventGoReverse.Activities.Add(this.setMovingInReverse);
            this.eventGoReverse.Name = "eventGoReverse";
            // 
            // eventGoForward
            // 
            this.eventGoForward.Activities.Add(this.handleGoForward);
            this.eventGoForward.Activities.Add(this.callExternalMethodActivity4);
            this.eventGoForward.Activities.Add(this.setMovingForward);
            this.eventGoForward.Name = "eventGoForward";
            // 
            // eventStopEngine
            // 
            this.eventStopEngine.Activities.Add(this.handleStopEngine);
            this.eventStopEngine.Activities.Add(this.callExternalMethodActivity3);
            this.eventStopEngine.Activities.Add(this.setNotRunning);
            this.eventStopEngine.Name = "eventStopEngine";
            // 
            // stateInitializationActivity1
            // 
            this.stateInitializationActivity1.Activities.Add(this.callExternalMethodActivity9);
            this.stateInitializationActivity1.Name = "stateInitializationActivity1";
            // 
            // eventLeaveCar
            // 
            this.eventLeaveCar.Activities.Add(this.handleLeaveCar);
            this.eventLeaveCar.Activities.Add(this.callExternalMethodActivity2);
            this.eventLeaveCar.Activities.Add(this.setDoneWithCar);
            this.eventLeaveCar.Name = "eventLeaveCar";
            // 
            // eventStartEngine
            // 
            this.eventStartEngine.Activities.Add(this.handleStartEngine);
            this.eventStartEngine.Activities.Add(this.callExternalMethodActivity1);
            this.eventStartEngine.Activities.Add(this.setRunningState);
            this.eventStartEngine.Name = "eventStartEngine";
            // 
            // eventBeepHorn
            // 
            this.eventBeepHorn.Activities.Add(this.handleBeepHorn);
            this.eventBeepHorn.Activities.Add(this.callExternalMethodActivity8);
            this.eventBeepHorn.Name = "eventBeepHorn";
            // 
            // DoneWithCarState
            // 
            this.DoneWithCarState.Name = "DoneWithCarState";
            // 
            // MovingInReverseState
            // 
            this.MovingInReverseState.Activities.Add(this.eventStopMovement2);
            this.MovingInReverseState.Name = "MovingInReverseState";
            // 
            // MovingForwardState
            // 
            this.MovingForwardState.Activities.Add(this.eventStopMovement);
            this.MovingForwardState.Name = "MovingForwardState";
            // 
            // RunningState
            // 
            this.RunningState.Activities.Add(this.eventStopEngine);
            this.RunningState.Activities.Add(this.eventGoForward);
            this.RunningState.Activities.Add(this.eventGoReverse);
            this.RunningState.Name = "RunningState";
            // 
            // NotRunningState
            // 
            this.NotRunningState.Activities.Add(this.eventStartEngine);
            this.NotRunningState.Activities.Add(this.eventLeaveCar);
            this.NotRunningState.Activities.Add(this.stateInitializationActivity1);
            this.NotRunningState.Name = "NotRunningState";
            // 
            // CarWorkflow
            // 
            this.Activities.Add(this.NotRunningState);
            this.Activities.Add(this.RunningState);
            this.Activities.Add(this.MovingForwardState);
            this.Activities.Add(this.MovingInReverseState);
            this.Activities.Add(this.DoneWithCarState);
            this.Activities.Add(this.eventBeepHorn);
            this.CompletedStateName = "DoneWithCarState";
            this.DynamicUpdateCondition = null;
            this.InitialStateName = "NotRunningState";
            this.Name = "CarWorkflow";
            this.CanModifyActivities = false;

        }

        #endregion

        private StateActivity DoneWithCarState;
        private StateActivity MovingInReverseState;
        private StateActivity MovingForwardState;
        private StateActivity RunningState;
        private EventDrivenActivity eventStartEngine;
        private HandleExternalEventActivity handleStartEngine;
        private SetStateActivity setRunningState;
        private CallExternalMethodActivity callExternalMethodActivity1;
        private HandleExternalEventActivity handleLeaveCar;
        private EventDrivenActivity eventLeaveCar;
        private SetStateActivity setDoneWithCar;
        private CallExternalMethodActivity callExternalMethodActivity2;
        private EventDrivenActivity eventGoReverse;
        private EventDrivenActivity eventGoForward;
        private EventDrivenActivity eventStopEngine;
        private HandleExternalEventActivity handleStopEngine;
        private CallExternalMethodActivity callExternalMethodActivity3;
        private SetStateActivity setNotRunning;
        private SetStateActivity setMovingForward;
        private CallExternalMethodActivity callExternalMethodActivity4;
        private HandleExternalEventActivity handleGoForward;
        private SetStateActivity setMovingInReverse;
        private CallExternalMethodActivity callExternalMethodActivity5;
        private HandleExternalEventActivity handleGoReverse;
        private SetStateActivity setRunning;
        private CallExternalMethodActivity callExternalMethodActivity6;
        private HandleExternalEventActivity handleStopMovement;
        private EventDrivenActivity eventStopMovement;
        private SetStateActivity setRunning2;
        private CallExternalMethodActivity callExternalMethodActivity7;
        private HandleExternalEventActivity handleStopMovement2;
        private EventDrivenActivity eventStopMovement2;
        private EventDrivenActivity eventBeepHorn;
        private CallExternalMethodActivity callExternalMethodActivity8;
        private HandleExternalEventActivity handleBeepHorn;
        private CallExternalMethodActivity callExternalMethodActivity9;
        private StateInitializationActivity stateInitializationActivity1;
        private StateActivity NotRunningState;

















































    }
}
