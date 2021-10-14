using System.Windows.Controls;
using System.Windows.Media;

namespace MaterialDesignThemes.Wpf
{
    public static class SidebarAssist
    {

        public static void AutoExpandOnSelect(TreeView sidebar, object selected)
        {
            var visualItem = FindSelectedItem(sidebar, selected);

            if (visualItem != null)
            {
                visualItem.IsSelected = true;
                visualItem.UpdateLayout();
            }
        }

        private static TreeViewItem FindSelectedItem(ItemsControl container, object item)
        {
            if (container == null)
            {
                return null;
            }

            if (container.DataContext == item)
            {
                return container as TreeViewItem;
            }

            var children = GetChildren(container);
            if (children.Count == 0)
            {
                return null;
            }

            TreeViewItem result = null;
            for (int i = 0, count = container.Items.Count; i < count; i++)
            {
                var subContainer = (TreeViewItem)container.ItemContainerGenerator.ContainerFromIndex(i);
                subContainer.BringIntoView();

                var resultContainer = FindSelectedItem(subContainer, item);
                if (resultContainer != null)
                {
                    result = resultContainer;
                }
                else
                {
                    if (subContainer.IsExpanded)
                    {
                        subContainer.IsExpanded = false;
                    }
                }
            }

            return result;
        }

        private static UIElementCollection GetChildren(ItemsControl container)
        {
            container.ApplyTemplate();

            var itemsPresenter = VisualHelper.FindVisualChild<ItemsPresenter>(container);
            itemsPresenter.ApplyTemplate();

            Panel itemsHostPanel = (Panel)VisualTreeHelper.GetChild(itemsPresenter, 0);
            return itemsHostPanel.Children;
        }
        public static TreeViewItem ContainerFromItemRecursive(this ItemContainerGenerator root, object item)
        {
            if (item == null || root == null)
            {
                return null;
            }

            var treeViewItem = root.ContainerFromItem(item) as TreeViewItem;
            if (treeViewItem != null)
                return treeViewItem;
            foreach (var subItem in root.Items)
            {
                treeViewItem = root.ContainerFromItem(subItem) as TreeViewItem;
                var search = treeViewItem?.ItemContainerGenerator.ContainerFromItemRecursive(item);
                if (search != null)
                    return search;
            }
            return null;
        }

        private static ItemsPresenter GetItemsPresenter(ItemsControl container)
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
                        return null;
                    }
                }
            }
            return itemsPresenter;
        }

        public static void ExpandSidebar(ItemsControl container, bool expand)
        {
            if (container != null && container.Items.Count > 0)
            {
                var itemsPresenter = GetItemsPresenter(container);

                Panel itemsHostPanel = (Panel)VisualTreeHelper.GetChild(itemsPresenter, 0);
                UIElementCollection children = itemsHostPanel.Children;
                if (children.Count == 0)
                {
                    return;
                }

                for (int i = 0, count = container.Items.Count; i < count; i++)
                {
                    TreeViewItem subContainer;

                    subContainer =
                        (TreeViewItem)container.ItemContainerGenerator.
                        ContainerFromIndex(i);

                    subContainer.BringIntoView();


                    if (subContainer != null)
                    {
                        ExpandSidebar(subContainer, expand);
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

        public static TreeViewItem FindItemNode(Sidebar sidebar, object item)
        {
            TreeViewItem node = null;
            foreach (object data in sidebar.Items)
            {
                node = sidebar.ItemContainerGenerator.ContainerFromItem(data) as TreeViewItem;
                if (node != null)
                {
                    sidebar.ParentSelectedItem = node;
                    if (data == item)
                    {
                        break;
                    }

                    node = FindItemNodeInChildren(sidebar, node, item);
                    if (node != null)
                    {
                        break;
                    }
                }
            }
            return node;
        }

        public static TreeViewItem FindItemNodeInChildren(Sidebar sidebar, TreeViewItem parent, object item)
        {
            TreeViewItem node = null;
            if (parent == null)
            {
                return null;
            }

            foreach (object data in parent.Items)
            {
                node = parent.ItemContainerGenerator.ContainerFromItem(data) as TreeViewItem;
                if (data == item && node != null)
                {
                    break;
                }

                node = FindItemNodeInChildren(sidebar, node, item);
                if (node != null)
                {
                    sidebar.ParentSelectedItem = data;
                    break;
                }
            }

            return node;
        }
    }
}
