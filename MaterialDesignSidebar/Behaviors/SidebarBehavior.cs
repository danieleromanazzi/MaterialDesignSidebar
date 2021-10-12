using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace MaterialDesignThemes.Wpf
{
    public class SidebarBehavior
    {
        protected SidebarBehavior()
        {

        }

        public static bool GetShowSeparator(DependencyObject obj)
        {
            return (bool)obj.GetValue(ShowSeparatorProperty);
        }

        public static void SetShowSeparator(DependencyObject obj, bool value)
        {
            obj.SetValue(ShowSeparatorProperty, value);
        }

        // Using a DependencyProperty as the backing store for ShowSeparator.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowSeparatorProperty =
            DependencyProperty.RegisterAttached("ShowSeparator", typeof(bool), typeof(SidebarBehavior), new PropertyMetadata(false));

        public static bool GetOneClickExpandEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(OneClickExpandEnabledProperty);
        }

        public static void SetOneClickExpandEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(OneClickExpandEnabledProperty, value);
        }

        // Using a DependencyProperty as the backing store for OneClickExpandEnabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OneClickExpandEnabledProperty =
            DependencyProperty.RegisterAttached("OneClickExpandEnabled", typeof(bool), typeof(SidebarBehavior), new UIPropertyMetadata(false, EnabledPropertyChangedCallback));

        private static void EnabledPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            if (dependencyObject is Sidebar sidebar)
            {
                sidebar.MouseUp += TreeView_MouseUp;
            }
        }

        private static void TreeView_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (VisualHelper.VisualUpwardSearch<TreeViewItem>(e.OriginalSource as DependencyObject) is TreeViewItem treeViewItem)
            {
                treeViewItem.IsExpanded = !treeViewItem.IsExpanded;
            }
        }

        public static bool GetAutoExpandOnSelect(DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoExpandOnSelectProperty);
        }

        public static void SetAutoExpandOnSelect(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoExpandOnSelectProperty, value);
        }

        // Using a DependencyProperty as the backing store for AutoExpandOnSelect.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AutoExpandOnSelectProperty =
            DependencyProperty.RegisterAttached("AutoExpandOnSelect", typeof(bool), typeof(SidebarBehavior), new UIPropertyMetadata(false, EnabledPropertyChanged));

        private static void EnabledPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            if (dependencyObject is Sidebar sidebar)
            {
                var enabled = GetAutoExpandOnSelect(dependencyObject);
                if (enabled)
                {
                    sidebar.ParentSelectedItemChangedEvent += OnParentSelectedItemChangedEvent;
                }
                else
                {
                    sidebar.ParentSelectedItemChangedEvent -= OnParentSelectedItemChangedEvent;
                }
            }
        }

        private static void OnParentSelectedItemChangedEvent(TreeView sender, object e)
        {
            SidebarAssist.AutoExpandOnSelect(sender, e);
        }


        public static bool GetSelectBranchDisable(DependencyObject obj)
        {
            return (bool)obj.GetValue(SelectBranchDisableProperty);
        }

        public static void SetSelectBranchDisable(DependencyObject obj, bool value)
        {
            obj.SetValue(SelectBranchDisableProperty, value);
        }

        // Using a DependencyProperty as the backing store for SelectBranchDisable.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectBranchDisableProperty =
            DependencyProperty.RegisterAttached("SelectBranchDisable", typeof(bool), typeof(SidebarBehavior), new UIPropertyMetadata(false, SelectBranchDisableChangedCallback));

        private static void SelectBranchDisableChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            if (dependencyObject is Sidebar control)
            {
                control.PreviewMouseDown += Sidebar_PreviewMouseDown;
                control.MouseUp += Sidebar_MouseUp;
                control.SelectedItemChanged += Sidebar_SelectedItemChanged;
            }
        }

        private static void Sidebar_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var toggle = VisualHelper.VisualUpwardSearch<ToggleButton>(e.OriginalSource as DependencyObject) as ToggleButton;
            var treeViewItem = VisualHelper.VisualUpwardSearch<TreeViewItem>(e.OriginalSource as DependencyObject) as TreeViewItem;

            if (treeViewItem == null)
            {
                return;
            }

            if (treeViewItem.HasItems && toggle == null)
            {
                e.Handled = true;
            }
        }

        private static void Sidebar_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var treeViewItem = VisualHelper.VisualUpwardSearch<TreeViewItem>(e.OriginalSource as DependencyObject) as TreeViewItem;
            if (treeViewItem == null)
            {
                return;
            }
            if (treeViewItem.HasItems)
            {
                e.Handled = true;
            }
        }

        private static void Sidebar_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var sidebar = sender as Sidebar;
            if (VisualHelper.VisualUpwardSearch<TreeViewItem>(e.OriginalSource as DependencyObject) is TreeViewItem treeViewItem)
            {
                if (treeViewItem.HasItems && treeViewItem.IsExpanded)
                {
                    TreeViewItem tvi = SidebarAssist.ContainerFromItemRecursive(sidebar.ItemContainerGenerator, sidebar.SelectedItem);
                    if (tvi != null)
                    {
                        tvi.IsSelected = true;
                    }
                }
            }
        }


        public static bool? GetExpandAll(DependencyObject obj)
        {
            return (bool?)obj.GetValue(ExpandAllProperty);
        }

        public static void SetExpandAll(DependencyObject obj, bool? value)
        {
            obj.SetValue(ExpandAllProperty, value);
        }

        // Using a DependencyProperty as the backing store for ExpandAll.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ExpandAllProperty =
            DependencyProperty.RegisterAttached("ExpandAll", typeof(bool?), typeof(SidebarBehavior), new PropertyMetadata(null, OnExpandAllChanged));

        private static void OnExpandAllChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var status = GetExpandAll(d);
            if (!status.HasValue)
            {
                return;
            }

            if (d is Sidebar sidebar)
            {
                SidebarAssist.ExpandSidebar(sidebar, status.Value);
            }
        }
    }
}
