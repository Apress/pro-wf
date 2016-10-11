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
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Workflow.Activities;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;

namespace WorkflowDesignerApp
{
    /// <summary>
    /// A UserControl and service that provides a toolbox 
    /// list of workflow activities
    /// </summary>
    public class WorkflowToolboxService : UserControl, IToolboxService
    {
        private ListBox _activitiesList;
        private List<Type> _standardActivities = new List<Type>();
        private IServiceProvider _serviceProvider;

        public WorkflowToolboxService(IServiceProvider provider)
        {
            _serviceProvider = provider;
            Dock = DockStyle.Fill;

            //create a ListBox to view the toolbox items
            _activitiesList = new ListBox();
            _activitiesList.Dock = DockStyle.Fill;
            _activitiesList.ItemHeight = 23;
            _activitiesList.DrawMode = DrawMode.OwnerDrawFixed;
            _activitiesList.DrawItem
                += new DrawItemEventHandler(ActivitiesList_DrawItem);
            _activitiesList.MouseMove
                += new MouseEventHandler(ActivitiesList_MouseMove);
            Controls.Add(_activitiesList);

            //create a list of standard activities that we support
            _standardActivities.Add(typeof(CallExternalMethodActivity));
            _standardActivities.Add(typeof(CancellationHandlerActivity));
            _standardActivities.Add(typeof(CodeActivity));
            _standardActivities.Add(typeof(CompensatableSequenceActivity));
            _standardActivities.Add(
                typeof(CompensatableTransactionScopeActivity));
            _standardActivities.Add(typeof(CompensateActivity));
            _standardActivities.Add(typeof(ConditionedActivityGroup));
            _standardActivities.Add(typeof(DelayActivity));
            _standardActivities.Add(typeof(EventDrivenActivity));
            _standardActivities.Add(typeof(EventHandlersActivity));
            _standardActivities.Add(typeof(EventHandlingScopeActivity));
            _standardActivities.Add(typeof(FaultHandlerActivity));
            _standardActivities.Add(typeof(FaultHandlersActivity));
            _standardActivities.Add(typeof(HandleExternalEventActivity));
            _standardActivities.Add(typeof(IfElseActivity));
            _standardActivities.Add(typeof(InvokeWebServiceActivity));
            _standardActivities.Add(typeof(InvokeWorkflowActivity));
            _standardActivities.Add(typeof(ListenActivity));
            _standardActivities.Add(typeof(ParallelActivity));
            _standardActivities.Add(typeof(PolicyActivity));
            _standardActivities.Add(typeof(ReplicatorActivity));
            _standardActivities.Add(typeof(SequenceActivity));
            _standardActivities.Add(typeof(SetStateActivity));
            _standardActivities.Add(typeof(StateActivity));
            _standardActivities.Add(typeof(StateFinalizationActivity));
            _standardActivities.Add(typeof(StateInitializationActivity));
            _standardActivities.Add(typeof(SuspendActivity));
            _standardActivities.Add(typeof(SynchronizationScopeActivity));
            _standardActivities.Add(typeof(TerminateActivity));
            _standardActivities.Add(typeof(ThrowActivity));
            _standardActivities.Add(typeof(TransactionScopeActivity));
            _standardActivities.Add(typeof(WebServiceFaultActivity));
            _standardActivities.Add(typeof(WebServiceInputActivity));
            _standardActivities.Add(typeof(WebServiceOutputActivity));
            _standardActivities.Add(typeof(WhileActivity));

            //add toolbox items for all activities in the list
            CreateToolboxItems(_activitiesList, _standardActivities);
        }

        #region IToolboxService Members

        /// <summary>
        /// Get a category name for the items in the toolbox
        /// </summary>
        public CategoryNameCollection CategoryNames
        {
            get
            {
                return new CategoryNameCollection(
                    new String[] { "WindowsWorkflow" });
            }
        }

        /// <summary>
        /// Get the category name of the currently selected
        /// tool in the toolbox
        /// </summary>
        public string SelectedCategory
        {
            get { return "WindowsWorkflow"; }
            set { }
        }

        /// <summary>
        /// Get the ActivityToolboxItem from the serialized 
        /// toolbox item
        /// </summary>
        /// <param name="serializedObject"></param>
        /// <param name="host"></param>
        /// <returns></returns>
        public ToolboxItem DeserializeToolboxItem(
            object serializedObject, IDesignerHost host)
        {
            ToolboxItem result = null;
            if (serializedObject is IDataObject)
            {
                result = ((IDataObject)serializedObject).GetData(
                    typeof(ToolboxItem)) as ToolboxItem;
            }
            return result;
        }

        public ToolboxItem DeserializeToolboxItem(
            object serializedObject)
        {
            return DeserializeToolboxItem(serializedObject, null);
        }

        /// <summary>
        /// Get a serialized object that represents the toolbox item
        /// </summary>
        /// <param name="toolboxItem"></param>
        /// <returns></returns>
        public object SerializeToolboxItem(ToolboxItem toolboxItem)
        {
            //use a DataObject which is a general data transfer 
            //mechanism used for clipboard and drag-drop operations.
            DataObject dataObject = new DataObject();
            dataObject.SetData(typeof(ToolboxItem), toolboxItem);
            return dataObject;
        }

        /// <summary>
        /// Set cursor for the currently selected tool
        /// </summary>
        /// <returns></returns>
        public bool SetCursor()
        {
            return false; //just use standard cursor
        }

        /// <summary>
        /// Does the designer host support this toolbox item?
        /// </summary>
        /// <param name="serializedObject"></param>
        /// <param name="filterAttributes"></param>
        /// <returns></returns>
        public bool IsSupported(object serializedObject,
            ICollection filterAttributes)
        {
            return true;
        }

        public bool IsSupported(object serializedObject,
            IDesignerHost host)
        {
            return true;
        }

        #region IToolboxService Members Not Fully Implemented

        public void AddCreator(ToolboxItemCreatorCallback creator,
            string format, IDesignerHost host)
        {
            throw new NotImplementedException(
                "Method not implemented");
        }

        public void AddCreator(ToolboxItemCreatorCallback creator,
            string format)
        {
            throw new NotImplementedException(
                "Method not implemented");
        }

        public void AddLinkedToolboxItem(ToolboxItem toolboxItem,
            string category, IDesignerHost host)
        {
            throw new NotImplementedException(
                "Method not implemented");
        }

        public void AddLinkedToolboxItem(ToolboxItem toolboxItem,
            IDesignerHost host)
        {
            throw new NotImplementedException(
                "Method not implemented");
        }

        public void AddToolboxItem(ToolboxItem toolboxItem,
            string category)
        {
            throw new NotImplementedException(
                "Method not implemented");
        }

        public void AddToolboxItem(ToolboxItem toolboxItem)
        {
            throw new NotImplementedException(
                "Method not implemented");
        }

        public ToolboxItem GetSelectedToolboxItem(
            IDesignerHost host)
        {
            throw new NotImplementedException(
                "Method not implemented");
        }

        public ToolboxItem GetSelectedToolboxItem()
        {
            throw new NotImplementedException(
                "Method not implemented");
        }

        public ToolboxItemCollection GetToolboxItems(
            string category, IDesignerHost host)
        {
            throw new NotImplementedException(
                "Method not implemented");
        }

        public ToolboxItemCollection GetToolboxItems(
            string category)
        {
            throw new NotImplementedException(
                "Method not implemented");
        }

        public ToolboxItemCollection GetToolboxItems(
            IDesignerHost host)
        {
            throw new NotImplementedException(
                "Method not implemented");
        }

        public ToolboxItemCollection GetToolboxItems()
        {
            throw new NotImplementedException(
                "Method not implemented");
        }

        public bool IsToolboxItem(object serializedObject,
            IDesignerHost host)
        {
            throw new NotImplementedException(
                "Method not implemented");
        }

        public bool IsToolboxItem(object serializedObject)
        {
            throw new NotImplementedException(
                "Method not implemented");
        }

        public void RemoveCreator(
            string format, IDesignerHost host)
        {
            throw new NotImplementedException(
                "Method not implemented");
        }

        public void RemoveCreator(string format)
        {
            throw new NotImplementedException(
                "Method not implemented");
        }

        public void RemoveToolboxItem(
            ToolboxItem toolboxItem, string category)
        {
            throw new NotImplementedException(
                "Method not implemented");
        }

        public void RemoveToolboxItem(ToolboxItem toolboxItem)
        {
            throw new NotImplementedException(
                "Method not implemented");
        }

        public void SelectedToolboxItemUsed()
        {
            throw new NotImplementedException(
                "Method not implemented");
        }

        public void SetSelectedToolboxItem(ToolboxItem toolboxItem)
        {
            throw new NotImplementedException(
                "Method not implemented");
        }
        #endregion

        /// <summary>
        /// Refresh the toolbox items for all activities in the list.
        /// </summary>
        /// <remarks>
        /// new added to method so we don't 
        /// override the Refresh method
        /// of the UserControl
        /// </remarks>
        public new void Refresh()
        {
            CreateToolboxItems(_activitiesList, _standardActivities);
        }

        #endregion

        #region Toolbox Item Construction

        /// <summary>
        /// Create all toolbox items 
        /// </summary>
        /// <param name="lb"></param>
        private void CreateToolboxItems(
            ListBox listbox, List<Type> activities)
        {
            listbox.Items.Clear();

            //add Toolbox items for referenced assemblies
            LoadReferencedTypes(listbox);

            //add Toolbox items for standard activities
            foreach (Type activityType in activities)
            {
                ToolboxItem item =
                    CreateItemForActivityType(activityType);
                if (item != null)
                {
                    listbox.Items.Add(item);
                }
            }
        }

        /// <summary>
        ///Add Toolbox items for any WF types found
        ///in referenced assemblies
        /// </summary>
        private void LoadReferencedTypes(ListBox listbox)
        {
            ITypeProvider typeProvider =
                _serviceProvider.GetService(typeof(ITypeProvider))
                    as ITypeProvider;
            if (typeProvider == null)
            {
                return;
            }
            foreach (Assembly assembly
                in typeProvider.ReferencedAssemblies)
            {
                Type[] types = assembly.GetTypes();
                foreach (Type type in types)
                {
                    //if the Type is assignable to Activity, then
                    //add it to the toolbox
                    if (typeof(Activity).IsAssignableFrom(type))
                    {
                        ToolboxItem item =
                            CreateItemForActivityType(type);
                        if (item != null)
                        {
                            listbox.Items.Add(item);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Create a ToolboxItem for the specified activity type
        /// </summary>
        /// <param name="activityType"></param>
        /// <returns></returns>
        private ToolboxItem CreateItemForActivityType(Type activityType)
        {
            ToolboxItem result = null;

            //does the activity type include the ToolboxItemAttribute
            ToolboxItemAttribute toolboxAttribute = null;
            foreach (Attribute attribute in
                activityType.GetCustomAttributes(
                    typeof(ToolboxItemAttribute), true))
            {
                if (attribute is ToolboxItemAttribute)
                {
                    toolboxAttribute = (ToolboxItemAttribute)attribute;
                    break;
                }
            }

            if (toolboxAttribute != null)
            {
                if (toolboxAttribute.ToolboxItemType != null)
                {
                    //construct the ToolboxItemType specified 
                    //by the attribute.
                    ConstructorInfo constructor =
                        toolboxAttribute.ToolboxItemType.GetConstructor(
                            new Type[] { typeof(Type) });
                    if (constructor != null)
                    {
                        result = constructor.Invoke(
                            new Object[] { activityType })
                                as ToolboxItem;
                    }
                }
            }
            else
            {
                //no attribute found
                result = new ToolboxItem(activityType);
            }

            return result;
        }

        /// <summary>
        /// Perform owner drawing of the toolbox items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActivitiesList_DrawItem(
            object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
            {
                return;
            }

            ActivityToolboxItem item
                = ((ListBox)sender).Items[e.Index] as ActivityToolboxItem;
            if (item != null)
            {
                Graphics graphics = e.Graphics;
                if ((e.State & DrawItemState.Selected)
                    == DrawItemState.Selected)
                {
                    //draw a border around the selected item
                    graphics.FillRectangle(
                        SystemBrushes.Window, e.Bounds);
                    Rectangle rect = e.Bounds;
                    rect.Width -= 2;
                    rect.Height -= 2;
                    graphics.DrawRectangle(SystemPens.ActiveBorder, rect);
                }
                else
                {
                    //not the selected item, just fill the rect
                    graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
                }

                //draw the toolbox item image
                Int32 bitmapWidth = 0;
                if (item.Bitmap != null)
                {
                    graphics.DrawImage(item.Bitmap,
                        e.Bounds.X + 2, e.Bounds.Y + 2,
                        item.Bitmap.Width, item.Bitmap.Height);
                    bitmapWidth = item.Bitmap.Width;
                }

                //add the display name
                graphics.DrawString(item.DisplayName,
                    e.Font, SystemBrushes.ControlText,
                    e.Bounds.X + bitmapWidth + 2, e.Bounds.Y + 2);
            }
        }

        #endregion

        #region Drag / Drop operation

        /// <summary>
        /// Begin a drag / drop operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActivitiesList_MouseMove(
            object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_activitiesList.SelectedItem is ActivityToolboxItem)
                {
                    ActivityToolboxItem selectedItem =
                        _activitiesList.SelectedItem
                            as ActivityToolboxItem;
                    IDataObject dataObject = SerializeToolboxItem(
                        selectedItem) as IDataObject;
                    DoDragDrop(dataObject, DragDropEffects.All);
                }
            }
        }

        #endregion
    }
}
