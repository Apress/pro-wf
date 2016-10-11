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
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace WorkflowDesignerApp
{
    /// <summary>
    /// Workflow event binding service
    /// </summary>
    public class WorkflowEventBindingService : IEventBindingService
    {
        private IServiceProvider _serviceProvider;

        public WorkflowEventBindingService(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        #region IEventBindingService Members

        public string CreateUniqueMethodName(
            IComponent component, EventDescriptor e)
        {
            return String.Empty;
        }

        /// <summary>
        /// Get a list of any methods in the root component class
        /// that are candidates as event handlers for the
        /// specified EventDescriptor.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public ICollection GetCompatibleMethods(EventDescriptor e)
        {
            List<String> compatibleMethods = new List<String>();

            IDesignerHost designerHost =
                _serviceProvider.GetService(typeof(IDesignerHost))
                    as IDesignerHost;
            if (designerHost == null || designerHost.RootComponent == null)
            {
                return compatibleMethods;
            }

            //get the event handler Type for the event
            EventInfo eventInfo
                = e.ComponentType.GetEvent(e.Name);
            ParameterInfo[] eventParameters = null;
            if (eventInfo != null)
            {
                //get the member info for the Invoke method
                MethodInfo invokeMethod =
                    eventInfo.EventHandlerType.GetMethod("Invoke");
                if (invokeMethod != null)
                {
                    //get the parameters associated with this method
                    eventParameters = invokeMethod.GetParameters();
                }
            }

            if (eventParameters != null)
            {
                //get the methods in the root component
                Type rootType = designerHost.RootComponent.GetType();
                MethodInfo[] methods = rootType.GetMethods(
                    BindingFlags.Public | BindingFlags.NonPublic |
                    BindingFlags.Instance | BindingFlags.DeclaredOnly);

                //look for a method with a matching set of arguments
                foreach (MethodInfo method in methods)
                {
                    ParameterInfo[] parameters
                        = method.GetParameters();
                    if (parameters.Length == eventParameters.Length)
                    {
                        if (IsCandidateMethod(eventParameters, parameters))
                        {
                            compatibleMethods.Add(method.Name);
                        }
                    }
                }

                //provide an entry that allows the selection
                //to be cleared
                compatibleMethods.Add("[Clear]");
            }

            return compatibleMethods;
        }

        /// <summary>
        /// Do the method parameters match what the event expects?
        /// </summary>
        /// <param name="eventParameters"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private static Boolean IsCandidateMethod(
            ParameterInfo[] eventParameters,
            ParameterInfo[] parameters)
        {
            Boolean isCandidate = true;
            for (Int32 i = 0; i < eventParameters.Length; i++)
            {
                if (!eventParameters[i].ParameterType.IsAssignableFrom(
                    parameters[i].ParameterType))
                {
                    isCandidate = false;
                    break;
                }
            }
            return isCandidate;
        }

        public EventDescriptor GetEvent(PropertyDescriptor property)
        {
            if (property is EventPropertyDescriptor)
            {
                return ((EventPropertyDescriptor)
                    property).EventDescriptor;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Convert a collection of event descriptors to 
        /// property descriptors
        /// </summary>
        /// <param name="events"></param>
        /// <returns></returns>
        public PropertyDescriptorCollection GetEventProperties(
            EventDescriptorCollection events)
        {
            List<PropertyDescriptor> properties
                = new List<PropertyDescriptor>();
            foreach (EventDescriptor eventDesc in events)
            {
                properties.Add(new EventPropertyDescriptor(
                    eventDesc, _serviceProvider));
            }
            PropertyDescriptorCollection propertiesCollection
                = new PropertyDescriptorCollection(
                    properties.ToArray(), true);
            return propertiesCollection;
        }

        /// <summary>
        /// Convert an EventDescriptor to a PropertyDescriptor
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public PropertyDescriptor GetEventProperty(EventDescriptor e)
        {
            return new EventPropertyDescriptor(e, _serviceProvider);
        }

        /// <summary>
        /// Display the code editor?
        /// </summary>
        /// <param name="component"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public bool ShowCode(IComponent component, EventDescriptor e)
        {
            return false;
        }

        public bool ShowCode(int lineNumber)
        {
            return false;
        }

        public bool ShowCode()
        {
            return false;
        }

        #endregion
    }
}
