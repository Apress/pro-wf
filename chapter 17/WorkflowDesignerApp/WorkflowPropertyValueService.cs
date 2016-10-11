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
using System.Drawing.Design;
using System.Collections;
using System.ComponentModel;

namespace WorkflowDesignerApp
{
    /// <summary>
    /// A service that provides images and tooltips for
    /// property grid entries
    /// </summary>
    public class WorkflowPropertyValueService
        : IPropertyValueUIService
    {
        private PropertyValueUIHandler _UIHandler;

        #region IPropertyValueUIService Members

        /// <summary>
        /// Add a handler
        /// </summary>
        /// <param name="newHandler"></param>
        public void AddPropertyValueUIHandler(
            PropertyValueUIHandler newHandler)
        {
            if (newHandler != null)
            {
                //combine the handler with the current delegates
                _UIHandler += newHandler;
            }
        }

        /// <summary>
        /// Remove a handler
        /// </summary>
        /// <param name="newHandler"></param>
        public void RemovePropertyValueUIHandler(
            PropertyValueUIHandler newHandler)
        {
            if (newHandler != null)
            {
                //remove a handler
                _UIHandler -= newHandler;
            }
        }

        /// <summary>
        /// Get a list of UI items for a property
        /// </summary>
        /// <param name="context"></param>
        /// <param name="propDesc"></param>
        /// <returns></returns>
        public PropertyValueUIItem[] GetPropertyUIValueItems(
            ITypeDescriptorContext context, PropertyDescriptor propDesc)
        {
            PropertyValueUIItem[] result = new PropertyValueUIItem[0];
            if (propDesc == null || _UIHandler == null)
            {
                return result;
            }

            //call any subscribed handlers allowing them
            //to provide a list of UI items. the UI items
            //provide images and tooltips for the properties
            //grid.
            ArrayList propertyItems = new ArrayList();
            _UIHandler(context, propDesc, propertyItems);
            if (propertyItems.Count > 0)
            {
                result = new PropertyValueUIItem[propertyItems.Count];
                propertyItems.CopyTo(result);
            }
            return result;
        }

        /// <summary>
        /// Notify any subscribers that the list of 
        /// PropertyValueUIItems has changed
        /// </summary>
        public void NotifyPropertyValueUIItemsChanged()
        {
            if (PropertyUIValueItemsChanged != null)
            {
                PropertyUIValueItemsChanged(this, new EventArgs());
            }
        }

        public event EventHandler PropertyUIValueItemsChanged;

        #endregion
    }
}
