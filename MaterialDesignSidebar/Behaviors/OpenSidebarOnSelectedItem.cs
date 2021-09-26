using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MaterialDesignThemes.Wpf
{
    public class OpenSidebarOnSelectedItem : DependencyObject
    {
        public static bool GetEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(EnabledProperty);
        }

        public static void SetEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(EnabledProperty, value);
        }

        public static readonly DependencyProperty EnabledProperty =
            DependencyProperty.RegisterAttached("Enabled", typeof(bool), typeof(OpenSidebarOnSelectedItem),
                new UIPropertyMetadata(false, EnabledPropertyChanged
                    ));

        private static void EnabledPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var enabled = GetEnabled(dependencyObject);
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

            if (dependencyObject is ThreeLevelSidebar threeSidebar)
            {
                if (enabled)
                {
                    threeSidebar.ParentSelectedItemChangedEvent += OnParentSelectedItemChangedEvent;
                }
                else
                {
                    threeSidebar.ParentSelectedItemChangedEvent -= OnParentSelectedItemChangedEvent;
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
            ////var visualItem = sidebar.FindChildren<TreeViewItem>();



            ////////TODO Refactoring
            ////var parentItem = visualItem.TryFindParent<TreeViewItem>();
            ////if (parentItem != null)
            ////{
            ////    if (parentItem.HasItems && !parentItem.IsExpanded)
            ////    {
            ////        parentItem.IsExpanded = true;
            ////        parentItem.UpdateLayout();
            ////    }

            ////    parentItem = parentItem.TryFindParent<TreeViewItem>();
            ////    if (parentItem != null)
            ////    {
            ////        if (parentItem.HasItems && !parentItem.IsExpanded)
            ////        {
            ////            parentItem.IsExpanded = true;
            ////            parentItem.UpdateLayout();
            ////        }
            ////    }
            ////}
            visualItem.IsSelected = true;
            visualItem.UpdateLayout();

            return null;
        }

        private static TreeViewItem GetTreeViewItem2(ItemsControl container, object item)
        {
            if (container != null)
            {
                if (container.DataContext == item)
                {
                    return container as TreeViewItem;
                }

                if (container is TreeViewItem && !((TreeViewItem)container).IsExpanded)
                {
                    container.SetValue(TreeViewItem.IsExpandedProperty, false);
                }

                container.ApplyTemplate();
                ItemsPresenter itemsPresenter =
                    (ItemsPresenter)container.Template.FindName("ItemsHost", container);
                if (itemsPresenter != null)
                {
                    itemsPresenter.ApplyTemplate();
                }
                else
                {
                    itemsPresenter = FindVisualChild<ItemsPresenter>(container);
                    if (itemsPresenter == null)
                    {
                        container.UpdateLayout();

                        itemsPresenter = FindVisualChild<ItemsPresenter>(container);
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
                            return resultContainer;
                        }
                        else
                        {
                            // The object is not under this TreeViewItem
                            // so collapse it.
                            if (subContainer.IsExpanded)
                            {
                                subContainer.IsExpanded = false;
                            }

                        }
                    }
                }
            }

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
                    itemsPresenter = FindVisualChild<ItemsPresenter>(container);
                    if (itemsPresenter == null)
                    {
                        container.UpdateLayout();

                        itemsPresenter = FindVisualChild<ItemsPresenter>(container);
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

                            //return resultContainer;
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

        private static T FindVisualChild<T>(Visual visual) where T : Visual
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(visual); i++)
            {
                Visual child = (Visual)VisualTreeHelper.GetChild(visual, i);
                if (child != null)
                {
                    T correctlyTyped = child as T;
                    if (correctlyTyped != null)
                    {
                        return correctlyTyped;
                    }

                    T descendent = FindVisualChild<T>(child);
                    if (descendent != null)
                    {
                        return descendent;
                    }
                }
            }

            return null;
        }




        static void TreeViewSelectedItemChanged(TreeView treeView, object item)
        {
            //TreeView treeView = sender as TreeView;
            if (treeView == null)
            {
                return;
            }

            //treeView.SelectedItemChanged -= new RoutedPropertyChangedEventHandler<object>(treeView_SelectedItemChanged);
            //treeView.SelectedItemChanged += new RoutedPropertyChangedEventHandler<object>(treeView_SelectedItemChanged);

            //TreeViewItem thisItem = treeView.ItemContainerGenerator.ContainerFromItem(item) as TreeViewItem;
            //if (thisItem != null)
            //{
            //    thisItem.IsSelected = true;
            //    return;
            //}

            for (int i = 0; i < treeView.Items.Count; i++)
            {
                SelectItem(item, treeView.ItemContainerGenerator.ContainerFromIndex(i) as TreeViewItem);
                //var itemInt = (TreeViewItem)treeView.ItemContainerGenerator.ContainerFromIndex(i);
                //if (itemInt.HasItems)
                //{
                //    for (int t = 0; t < itemInt.Items.Count; t++)
                //    {
                //        SelectItem(item, itemInt.ItemContainerGenerator.ContainerFromIndex(t) as TreeViewItem);
                //    }
                //}
            }
        }

        //static void treeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        //{
        //    TreeView treeView = sender as TreeView;
        //    //SetTreeViewSelectedItem(treeView, e.NewValue);
        //}

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
            //if (item != null)
            //{
            //    item.IsSelected = true;
            //    return true;
            //}

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


    }
}
