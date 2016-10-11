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
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Reflection;
using System.Workflow.ComponentModel;

namespace WorkflowDesignerApp
{
    /// <summary>
    /// A PropertyDescriptor for workflow events that
    /// Adds or Removes ActivityBind objects
    /// </summary>
    public class EventPropertyDescriptor : PropertyDescriptor
    {
        private EventDescriptor _eventDescriptor;
        private IServiceProvider _serviceProvider;
        private DependencyProperty _eventProperty;

        public EventPropertyDescriptor(EventDescriptor eventDesc,
            IServiceProvider serviceProvider)
            : base(eventDesc)
        {
            _eventDescriptor = eventDesc;
            _serviceProvider = serviceProvider;

            //get the dependency property that defines the
            //component event from the ComponentType object.
            FieldInfo eventFieldInfo =
                _eventDescriptor.ComponentType.GetField(
                    _eventDescriptor.Name + "Event");
            if (eventFieldInfo != null)
            {
                _eventProperty = eventFieldInfo.GetValue(
                    _eventDescriptor.ComponentType)
                        as DependencyProperty;
            }
        }

        public EventDescriptor EventDescriptor
        {
            get { return _eventDescriptor; }
        }

        public override bool CanResetValue(object component)
        {
            return false;
        }

        public override Type ComponentType
        {
            get { return _eventDescriptor.ComponentType; }
        }

        public override object GetValue(object component)
        {
            return null;
        }

        public override bool IsReadOnly
        {
            get { return false; }
        }

        public override Type PropertyType
        {
            get { return _eventDescriptor.EventType; }
        }

        public override void ResetValue(object component)
        {
            //reset by setting the property value to null
            SetValue(component, null);
        }

        /// <summary>
        /// Set the new binding for an event
        /// </summary>
        /// <param name="component"></param>
        /// <param name="value"></param>
        public override void SetValue(object component, object value)
        {
            DependencyObject dependencyObject
                = component as DependencyObject;
            String eventHandlerName = value as String;
            if (dependencyObject == null || _eventProperty == null)
            {
                return;
            }

            //is an event handler already defined for this event?
            String currentHandlerName = String.Empty;
            if (dependencyObject.IsBindingSet(_eventProperty))
            {
                currentHandlerName =
                    dependencyObject.GetBinding(_eventProperty).Path;
            }

            //the handler name is the same so just get out now
            if (eventHandlerName == currentHandlerName)
            {
                return;
            }

            IDesignerHost designerHost
                = _serviceProvider.GetService(
                    typeof(IDesignerHost)) as IDesignerHost;
            //use the IComponentChangeService to notify the
            //designer of the change
            IComponentChangeService changeService
                = _serviceProvider.GetService(
                    typeof(IComponentChangeService))
                        as IComponentChangeService;
            if (changeService != null)
            {
                //notify that the component is changing
                changeService.OnComponentChanging(
                    component, _eventDescriptor);
            }

            //set or remove the binding
            String bindingName = String.Empty;
            if (eventHandlerName == null ||
                eventHandlerName == "[Clear]")
            {
                //remove the old binding
                dependencyObject.RemoveProperty(_eventProperty);
            }
            else
            {
                //Add a new ActivityBind object to the component
                ActivityBind bind = new ActivityBind(
                    ((Activity)designerHost.RootComponent).Name,
                        eventHandlerName);
                dependencyObject.SetBinding(_eventProperty, bind);
            }

            if (changeService != null)
            {
                //notify that the component has changed
                changeService.OnComponentChanged(
                    component, _eventDescriptor,
                    currentHandlerName, bindingName);
            }
        }

        public override bool ShouldSerializeValue(object component)
        {
            //yes, persist the value of this property
            return true;
        }

        /// <summary>
        /// Provide a custom type converter to 
        /// use for this event property
        /// </summary>
        public override TypeConverter Converter
        {
            get
            {
                return new WorkflowEventTypeConverter(
                    _eventDescriptor);
            }
        }

        #region Private WorkflowEventTypeConverter class

        /// <summary>
        /// Implement a TypeConverter for workflow event properties
        /// </summary>
        private class WorkflowEventTypeConverter : TypeConverter
        {
            EventDescriptor _eventDescriptor;

            public WorkflowEventTypeConverter(
                EventDescriptor eventDesc)
            {
                //save the EventDescriptor that we convert
                _eventDescriptor = eventDesc;
            }

            /// <summary>
            /// Get a list of standard values that are supported for this
            /// event.  Use the GetCompatibleMethods method of the
            /// IEventBindingService to retrieve the list of valid values
            /// for the current event property
            /// </summary>
            /// <param name="context"></param>
            /// <returns></returns>
            public override TypeConverter.StandardValuesCollection
                GetStandardValues(ITypeDescriptorContext context)
            {
                ICollection compatibleMethods = new ArrayList();
                if (context != null)
                {
                    IEventBindingService bindingService
                        = (IEventBindingService)context.GetService(
                            typeof(IEventBindingService));
                    if (bindingService != null)
                    {
                        //use the IEventBindingService to generate
                        //a list of compatible methods
                        compatibleMethods
                            = bindingService.GetCompatibleMethods(
                                _eventDescriptor);
                    }
                }

                return new StandardValuesCollection(compatibleMethods);
            }

            public override bool GetStandardValuesSupported(
                ITypeDescriptorContext context)
            {
                //Yes, a call to GetStandardValues should be made
                return true;
            }

            public override bool GetStandardValuesExclusive(
                ITypeDescriptorContext context)
            {
                // Only the values returned from GetStandardValues
                // are valid. You can't enter new string values.
                return true;
            }
        }

        #endregion
    }
}

