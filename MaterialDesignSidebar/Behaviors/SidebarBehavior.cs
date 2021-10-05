using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

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
            var treeViewItem = VisualHelper.VisualUpwardSearch<TreeViewItem>(e.OriginalSource as DependencyObject) as TreeViewItem;
            if (treeViewItem != null)
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
            var enabled = GetAutoExpandOnSelect(dependencyObject);
            if (dependencyObject is Sidebar sidebar)
            {
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
            ExpandItems(sender, e);
            //TreeViewSelectedItemChanged(sender, e);
        }

        private static TreeViewItem ExpandItems(TreeView sidebar, object selected)
        {

            TreeViewItem item = (TreeViewItem)sidebar.ItemContainerGenerator.ContainerFromItem(sidebar.Items.CurrentItem);
            var visualItem = GetTreeViewItem(sidebar, selected);

            visualItem.IsSelected = true;
            visualItem.UpdateLayout();

            return null;
        }

        private static TreeViewItem GetTreeViewItem(ItemsControl container, object item)
        {
            TreeViewItem result = null;

            if (container != null)
            {
                if (container.DataContext == item)
                {
                    return container as TreeViewItem;
                }

                //if (container is TreeViewItem && !((TreeViewItem)container).IsExpanded)
                //{
                //    container.SetValue(TreeViewItem.IsExpandedProperty, true);
                //}

                container.ApplyTemplate();
                ItemsPresenter itemsPresenter =
                    (ItemsPresenter)container.Template.FindName("ItemsHost", container);
                if (itemsPresenter != null)
                {
                    itemsPresenter.ApplyTemplate();
                }
                else
                {
                    itemsPresenter = VisualHelper.FindVisualChild<ItemsPresenter>(container);
                    if (itemsPresenter == null)
                    {
                        container.UpdateLayout();

                        itemsPresenter = VisualHelper.FindVisualChild<ItemsPresenter>(container);
                    }
                }

                Panel itemsHostPanel = (Panel)VisualTreeHelper.GetChild(itemsPresenter, 0);
                UIElementCollection children = itemsHostPanel.Children;


                for (int i = 0, count = container.Items.Count; i < count; i++)
                {
                    TreeViewItem subContainer;

                    subContainer =
                        (TreeViewItem)container.ItemContainerGenerator.
                        ContainerFromIndex(i);

                    subContainer.BringIntoView();


                    if (subContainer != null)
                    {
                        TreeViewItem resultContainer = GetTreeViewItem(subContainer, item);
                        if (resultContainer != null)
                        {
                            result = resultContainer;
                        }
                        else
                        {
                            if (subContainer.IsExpanded)
                            {
                                // The object is not under this TreeViewItem
                                // so collapse it.
                                subContainer.IsExpanded = false;
                            }
                        }
                    }
                }
            }

            return result;
        }

        private static bool SelectItem(object o, TreeViewItem parentItem)
        {
            if (parentItem == null)
                return false;

            bool isExpanded = parentItem.IsExpanded;
            if (!isExpanded)
            {
                parentItem.IsExpanded = true;
                parentItem.UpdateLayout();
            }

            TreeViewItem item = parentItem.ItemContainerGenerator.ContainerFromItem(o) as TreeViewItem;

            bool wasFound = false;
            for (int i = 0; i < parentItem.Items.Count; i++)
            {
                TreeViewItem itm = parentItem.ItemContainerGenerator.ContainerFromIndex(i) as TreeViewItem;

                var found = SelectItem(o, itm);
                if (!found)
                {
                    if (itm != null)
                    {
                        itm.IsExpanded = false;
                    }
                }
                else
                    wasFound = true;
            }

            return wasFound;
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
                control.PreviewMouseDown += Control_PreviewMouseDown;
                control.MouseUp += Sidebar_MouseUp;
                control.SelectedItemChanged += Control_SelectedItemChanged;
            }
        }

        private static void Control_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
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

        private static void Control_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
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
                    TreeViewItem tvi = ContainerFromItemRecursive(sidebar.ItemContainerGenerator, sidebar.SelectedItem);
                    if (tvi != null)
                    {
                        tvi.IsSelected = true;
                    }
                }
            }
        }

        public static TreeViewItem ContainerFromItemRecursive(ItemContainerGenerator root, object item)
        {
            if (item == null || root == null)
            {
                return null;
            }

            if (root.ContainerFromItem(item) is TreeViewItem treeViewItem)
            {
                return treeViewItem;
            }

            foreach (var subItem in root.Items)
            {
                treeViewItem = root.ContainerFromItem(subItem) as TreeViewItem;
                var search = ContainerFromItemRecursive(treeViewItem?.ItemContainerGenerator, item);
                if (search != null)
                {
                    return search;
                }
            }
            return null;
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
                ExpandTreeView(sidebar, status.Value);
            }
        }

        private static void ExpandTreeView(ItemsControl container, bool expand)
        {
            if (container != null && container.Items.Count > 0)
            {
                container.ApplyTemplate();
                ItemsPresenter itemsPresenter =
                    (ItemsPresenter)container.Template.FindName("ItemsHost", container);
                if (itemsPresenter != null)
                {
                    itemsPresenter.ApplyTemplate();
                }
                else
                {
                    itemsPresenter = VisualHelper.FindVisualChild<ItemsPresenter>(container);
                    if (itemsPresenter == null)
                    {
                        container.UpdateLayout();

                        itemsPresenter = VisualHelper.FindVisualChild<ItemsPresenter>(container);

                        if (itemsPresenter == null)
                        {
                            return;
                        }
                    }
                }

                Panel itemsHostPanel = (Panel)VisualTreeHelper.GetChild(itemsPresenter, 0);
                UIElementCollection children = itemsHostPanel.Children;


                for (int i = 0, count = container.Items.Count; i < count; i++)
                {
                    TreeViewItem subContainer;

                    subContainer =
                        (TreeViewItem)container.ItemContainerGenerator.
                        ContainerFromIndex(i);

                    subContainer.BringIntoView();


                    if (subContainer != null)
                    {
                        ExpandTreeView(subContainer, expand);
                        if (subContainer.IsExpanded)
                        {
                            // The object is not under this TreeViewItem
                            // so collapse it.
                            subContainer.IsExpanded = expand;
                        }
                    }
                }
            }
        }
    }
}
