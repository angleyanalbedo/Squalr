﻿namespace Squalr.View
{
    using Squalr.Engine.Common.DataStructures;
    using Squalr.Engine.Projects.Items;
    using Squalr.Source.ProjectExplorer;
    using Squalr.Source.ProjectExplorer.ProjectItems;
    using Squalr.Source.PropertyViewer;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for Settings.xaml.
    /// </summary>
    public partial class ProjectExplorer : UserControl
    {
        private static readonly PropertyInfo IsSelectionChangeActiveProperty = typeof(TreeView).GetProperty("IsSelectionChangeActive", BindingFlags.NonPublic | BindingFlags.Instance);

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectExplorer" /> class.
        /// </summary>
        public ProjectExplorer()
        {
            this.InitializeComponent();

            this.ProjectItemCache = new TtlCache<ProjectItemView>();

            // This works, but can be offloaded to a helper class, or perhaps rolled into the viewmodel itself.
            // Should be modified to support keyboard ctrl/shift+arrow stuff.
            // It's shit, but it's a great place to start.
            ProjectExplorer.AllowMultiSelection(ProjectExplorerTreeView);
        }

        private TtlCache<ProjectItemView> ProjectItemCache { get; set; }

        public static void AllowMultiSelection(TreeView treeView)
        {
            if (IsSelectionChangeActiveProperty == null)
            {
                return;
            }

            treeView.SelectedItemChanged += (a, b) =>
            {
                if (ProjectExplorerViewModel.GetInstance().SelectedProjectItems == null)
                {
                    ProjectExplorerViewModel.GetInstance().SelectedProjectItems = new List<ProjectItemView>();
                }

                Boolean isShiftSelecting = Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift);
                Boolean isControlSelecting = Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl);

                if (isShiftSelecting)
                {
                    // Suppress selection change notification, select all selected items, then restore selection change notifications
                    Object isSelectionChangeActive = IsSelectionChangeActiveProperty.GetValue(treeView, null);

                    IsSelectionChangeActiveProperty.SetValue(treeView, true, null);
                    ProjectExplorer.ShiftSelect(treeView);

                    IsSelectionChangeActiveProperty.SetValue(treeView, isSelectionChangeActive, null);
                }
                else if (isControlSelecting)
                {
                    ProjectExplorer.ReselectPriorSelectedItems(treeView);
                    ProjectExplorer.ToggleSelection(treeView);
                }
                else
                {
                    ProjectExplorer.NormalSelect(treeView);
                    ProjectExplorer.ToggleSelection(treeView);
                }

                PropertyViewerViewModel.GetInstance().SetTargetObjects(ProjectExplorerViewModel.GetInstance().SelectedProjectItems?.ToArray());
            };
        }

        private static void ReselectPriorSelectedItems(TreeView treeView)
        {
            // Suppress selection change notification, select all selected items, then restore selection change notifications
            Object isSelectionChangeActive = IsSelectionChangeActiveProperty.GetValue(treeView, null);

            IsSelectionChangeActiveProperty.SetValue(treeView, true, null);
            ProjectExplorerViewModel.GetInstance().SelectedProjectItems?.ForEach(item => item.IsSelected = true);
            
            IsSelectionChangeActiveProperty.SetValue(treeView, isSelectionChangeActive, null);
        }

        private static void ShiftSelect(TreeView treeView)
        {
            ProjectItemView clickedTreeViewItem = treeView.SelectedItem as ProjectItemView;
            ProjectItemView selectedItem = ProjectExplorerViewModel.GetInstance().SelectedProjectItems?.FirstOrDefault();
            DirectoryItemView root = ProjectExplorerViewModel.GetInstance().ProjectRoot?.FirstOrDefault();

            if (root == null || clickedTreeViewItem == null || selectedItem == null)
            {
                return;
            }

            Boolean isSelecting = (root == selectedItem) || (root == clickedTreeViewItem);

            ProjectExplorerViewModel.GetInstance().SelectedProjectItems?.Clear();
            ProjectExplorer.SelectRange(root, selectedItem, clickedTreeViewItem, ref isSelecting);
        }

        private static Boolean SelectRange(DirectoryItemView currentDirectory, ProjectItemView rangeStart, ProjectItemView rangeEnd, ref Boolean isSelecting)
        {
            Boolean selectionComplete = false;

            if (currentDirectory.ChildItems == null)
            {
                return selectionComplete;
            }

            foreach (ProjectItem projectItem in currentDirectory.ChildItems)
            {
                ProjectItemView projectItemView = projectItem.MappedView as ProjectItemView;
                DirectoryItemView directoryItemView = projectItemView as DirectoryItemView;
                Boolean selectionStarted = false;

                if (!isSelecting)
                {
                    isSelecting = (projectItemView == rangeStart) || (projectItemView == rangeEnd);
                    selectionStarted = true;
                }

                if (projectItemView != null)
                {
                    projectItemView.IsSelected = isSelecting;

                    if (isSelecting)
                    {
                        ProjectExplorerViewModel.GetInstance().SelectedProjectItems?.Add(projectItemView);
                    }
                }

                if (directoryItemView != null && directoryItemView.IsExpanded)
                {
                    selectionComplete = ProjectExplorer.SelectRange(directoryItemView, rangeStart, rangeEnd, ref isSelecting);
                }

                if (!selectionStarted && isSelecting && ((projectItemView == rangeStart) || (projectItemView == rangeEnd)))
                {
                    isSelecting = false;
                    selectionComplete = true;
                    break;
                }
            }

            return selectionComplete;
        }

        private static void NormalSelect(TreeView treeView)
        {
            // deselect all selected items except the current one
            ProjectItemView clickedTreeViewItem = treeView.SelectedItem as ProjectItemView;
            ProjectExplorerViewModel.GetInstance().SelectedProjectItems?.ForEach(item => item.IsSelected = item == clickedTreeViewItem);
            ProjectExplorerViewModel.GetInstance().SelectedProjectItems?.Clear();
        }

        private static void ToggleSelection(TreeView treeView)
        {
            ProjectItemView clickedTreeViewItem = treeView.SelectedItem as ProjectItemView;

            if (clickedTreeViewItem == null)
            {
                return;
            }

            if (!ProjectExplorerViewModel.GetInstance().SelectedProjectItems?.Contains(clickedTreeViewItem) ?? false)
            {
                ProjectExplorerViewModel.GetInstance().SelectedProjectItems?.Add(clickedTreeViewItem);
            }
            else
            {
                clickedTreeViewItem.IsSelected = false;
                ProjectExplorerViewModel.GetInstance().SelectedProjectItems?.Remove(clickedTreeViewItem);
            }
        }

        private void ValueMouseDown(Object sender, MouseButtonEventArgs e)
        {
            ProjectItemView hitResult = (sender as FrameworkElement)?.DataContext as ProjectItemView;

            if (hitResult == null)
            {
                return;
            }

            if (this.ProjectItemCache.Contains(hitResult))
            {
                ProjectExplorerViewModel.GetInstance().EditProjectItemValueCommand.Execute(hitResult);
            }
            else
            {
                this.ProjectItemCache.Invalidate();
                this.ProjectItemCache.Add(hitResult, TimeSpan.FromMilliseconds(System.Windows.Forms.SystemInformation.DoubleClickTime));
            }
        }

        private void NameMouseDown(Object sender, MouseButtonEventArgs e)
        {
            ProjectItemView hitResult = (sender as FrameworkElement)?.DataContext as ProjectItemView;

            if (hitResult == null)
            {
                return;
            }

            if (this.ProjectItemCache.Contains(hitResult))
            {
                ProjectExplorerViewModel.GetInstance().EditProjectItemNameCommand.Execute(hitResult);
            }
            else
            {
                this.ProjectItemCache.Invalidate();
                this.ProjectItemCache.Add(hitResult, TimeSpan.FromMilliseconds(System.Windows.Forms.SystemInformation.DoubleClickTime));
            }
        }
    }
    //// End class
}
//// End namespace