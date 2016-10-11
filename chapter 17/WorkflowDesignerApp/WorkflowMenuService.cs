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
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel;

namespace WorkflowDesignerApp
{
    /// <summary>
    /// A workflow menu service that provides a 
    /// context-menu for the selected component
    /// </summary>
    public class WorkflowMenuService : MenuCommandService
    {
        public WorkflowMenuService(IServiceProvider provider)
            : base(provider)
        {
        }

        /// <summary>
        /// The context menu is about to be shown. Build the
        /// available list of menu items based on the
        /// selected activity.
        /// </summary>
        /// <param name="menuID"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public override void ShowContextMenu(
            CommandID menuID, int x, int y)
        {
            base.ShowContextMenu(menuID, x, y);
            if (menuID == WorkflowMenuCommands.SelectionMenu)
            {
                ContextMenu contextMenu = new ContextMenu();
                //add a context menu item for each designer
                //verb that is available
                foreach (DesignerVerb verb in Verbs)
                {
                    MenuItem menuItem = new MenuItem(verb.Text,
                        new EventHandler(OnMenuClicked));
                    menuItem.Tag = verb;
                    contextMenu.MenuItems.Add(menuItem);
                }

                //add any context menu items based on the
                //selected object
                foreach (MenuItem menu in BuildItemsForSelection())
                {
                    contextMenu.MenuItems.Add(menu);
                }

                //show the newly constructed context menu
                //on the workflow view
                WorkflowView workflowView =
                    GetService(typeof(WorkflowView)) as WorkflowView;
                if (workflowView != null)
                {
                    //show the context menu
                    contextMenu.Show(workflowView,
                        workflowView.PointToClient(new Point(x, y)));
                }
            }
        }

        /// <summary>
        /// Build the menu items based on the selected context
        /// </summary>
        /// <returns></returns>
        private IList<MenuItem> BuildItemsForSelection()
        {
            List<MenuItem> items = new List<MenuItem>();

            //determine if all selected items are valid for
            //our context menu
            Boolean isActivity = false;
            Boolean isComposite = false;
            ISelectionService selectionService
                = GetService(typeof(ISelectionService))
                    as ISelectionService;
            if (selectionService != null)
            {
                ICollection selectedObjects
                    = selectionService.GetSelectedComponents();
                if (selectedObjects.Count > 1)
                {
                    //more than one object has been selected.
                    //just make sure that all selected objects
                    //derive from Activity
                    isActivity = true;
                    foreach (Object selection in selectedObjects)
                    {
                        if (!(selection is Activity))
                        {
                            //not a valid selection
                            isActivity = false;
                            break;
                        }
                    }
                }
                else
                {
                    //only a single item was selected, so we can
                    //be more specific with the context menu
                    foreach (Object selection in selectedObjects)
                    {
                        isComposite = (selection is CompositeActivity);
                        isActivity = (selection is Activity);
                    }
                }
            }

            if (isActivity)
            {
                //if the selection was valid, add menu items
                Dictionary<CommandID, String> commands
                    = new Dictionary<CommandID, String>();
                commands.Add(WorkflowMenuCommands.Copy, "Copy");
                commands.Add(WorkflowMenuCommands.Cut, "Cut");
                commands.Add(WorkflowMenuCommands.Paste, "Paste");
                commands.Add(WorkflowMenuCommands.Delete, "Delete");
                if (isComposite)
                {
                    //add other menu items if a composite is selected
                    commands.Add(WorkflowMenuCommands.Collapse, "Collapse");
                    commands.Add(WorkflowMenuCommands.Expand, "Expand");
                }

                //add the divider
                items.Add(new MenuItem("-"));

                //add the menu items
                foreach (KeyValuePair<CommandID, String> pair in commands)
                {
                    //get the MenuCommand to execute for the menu item
                    MenuCommand command = FindCommand(pair.Key);
                    if (command != null)
                    {
                        MenuItem menuItem = new MenuItem(pair.Value,
                            new EventHandler(OnMenuClicked));
                        menuItem.Tag = command;
                        items.Add(menuItem);
                    }
                }
            }

            return items;
        }

        /// <summary>
        /// Common handler for all context menu items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMenuClicked(Object sender, EventArgs e)
        {
            if (sender is MenuItem)
            {
                MenuItem menu = sender as MenuItem;
                if ((menu != null) && (menu.Tag is MenuCommand))
                {
                    ((MenuCommand)menu.Tag).Invoke();
                }
            }
        }
    }
}
