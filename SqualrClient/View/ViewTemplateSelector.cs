﻿namespace SqualrClient.View
{
    using SqualrClient.Source.Browse;
    using SqualrClient.Source.Browse.StreamConfig;
    using SqualrClient.Source.Browse.TwitchLogin;
    using System;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Provides the template required to view a pane.
    /// </summary>
    internal class ViewTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewTemplateSelector" /> class.
        /// </summary>
        public ViewTemplateSelector()
        {
        }

        /// <summary>
        /// Gets or sets the template for the Process Selector.
        /// </summary>
        public DataTemplate ProcessSelectorViewTemplate { get; set; }

        /// <summary>
        /// Gets or sets the template for the Change Counter.
        /// </summary>
        public DataTemplate ChangeCounterViewTemplate { get; set; }

        /// <summary>
        /// Gets or sets the template for the Input Correlator.
        /// </summary>
        public DataTemplate InputCorrelatorViewTemplate { get; set; }

        /// <summary>
        /// Gets or sets the template for the Label Thresholder.
        /// </summary>
        public DataTemplate LabelThresholderViewTemplate { get; set; }

        /// <summary>
        /// Gets or sets the template for the Manual Scanner.
        /// </summary>
        public DataTemplate ManualScannerViewTemplate { get; set; }

        /// <summary>
        /// Gets or sets the template for the Pointer Scanner.
        /// </summary>
        public DataTemplate PointerScannerViewTemplate { get; set; }

        /// <summary>
        /// Gets or sets the template for the Snapshot Manager.
        /// </summary>
        public DataTemplate SnapshotManagerViewTemplate { get; set; }

        /// <summary>
        /// Gets or sets the template for the Scan Results.
        /// </summary>
        public DataTemplate ScanResultsViewTemplate { get; set; }

        /// <summary>
        /// Gets or sets the template for the Pointer Scan Results.
        /// </summary>
        public DataTemplate PointerScanResultsViewTemplate { get; set; }

        /// <summary>
        /// Gets or sets the template for the Browser.
        /// </summary>
        public DataTemplate BrowseViewTemplate { get; set; }

        /// <summary>
        /// Gets or sets the template for the Cheat Browser.
        /// </summary>
        public DataTemplate CheatBrowserViewTemplate { get; set; }

        /// <summary>
        /// Gets or sets the template for the Twitch Login.
        /// </summary>
        public DataTemplate TwitchLoginViewTemplate { get; set; }

        /// <summary>
        /// Gets or sets the template for the Stream Weaver.
        /// </summary>
        public DataTemplate TwitchConfigViewTemplate { get; set; }

        /// <summary>
        /// Gets or sets the template for the Stream Table.
        /// </summary>
        public DataTemplate StreamTableViewTemplate { get; set; }

        /// <summary>
        /// Gets or sets the template for the Stream Icon Editor.
        /// </summary>
        public DataTemplate StreamIconEditorViewTemplate { get; set; }

        /// <summary>
        /// Gets or sets the template for the .Net Explorer.
        /// </summary>
        public DataTemplate DotNetExplorerViewTemplate { get; set; }

        /// <summary>
        /// Gets or sets the template for the Property Viewer.
        /// </summary>
        public DataTemplate PropertyViewerViewTemplate { get; set; }

        /// <summary>
        /// Gets or sets the template for the Settings.
        /// </summary>
        public DataTemplate SettingsViewTemplate { get; set; }

        /// <summary>
        /// Gets or sets the template for the Project Explorer.
        /// </summary>
        public DataTemplate ProjectExplorerViewTemplate { get; set; }

        /// <summary>
        /// Gets or sets the template for the Signature Collector.
        /// </summary>
        public DataTemplate SignatureCollectorViewTemplate { get; set; }

        /// <summary>
        /// Gets or sets the template for the Output.
        /// </summary>
        public DataTemplate OutputViewTemplate { get; set; }

        /// <summary>
        /// Gets or sets the template for the Offset Editor.
        /// </summary>
        public DataTemplate OffsetEditorViewTemplate { get; set; }

        /// <summary>
        /// Gets or sets the template for the Script Editor.
        /// </summary>
        public DataTemplate ScriptEditorViewTemplate { get; set; }

        /// <summary>
        /// Gets or sets the template for the Text Editor.
        /// </summary>
        public DataTemplate TextEditorViewTemplate { get; set; }

        /// <summary>
        /// Gets or sets the template for the Hotkey Manager.
        /// </summary>
        public DataTemplate HotkeyManagerViewTemplate { get; set; }

        /// <summary>
        /// Gets or sets the template for the Hotkey Editor.
        /// </summary>
        public DataTemplate HotkeyEditorViewTemplate { get; set; }

        /// <summary>
        /// Returns the required template to display the given view model.
        /// </summary>
        /// <param name="item">The view model.</param>
        /// <param name="container">The dependency object.</param>
        /// <returns>The template associated with the provided view model.</returns>
        public override DataTemplate SelectTemplate(Object item, DependencyObject container)
        {
            if (item is BrowseViewModel)
            {
                return this.BrowseViewTemplate;
            }
            else if (item is TwitchLoginViewModel)
            {
                return this.TwitchLoginViewTemplate;
            }
            else if (item is StreamConfigViewModel)
            {
                return this.TwitchConfigViewTemplate;
            }

            return base.SelectTemplate(item, container);
        }
    }
    //// End class
}
//// End namespace