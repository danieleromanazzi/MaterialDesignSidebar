using System.Windows.Controls;
using System.Windows.Media;

namespace MaterialDesignThemes.Wpf
{
    public class SidebarAssist
    {
        protected SidebarAssist()
        {

        }

        public static void AutoExpandOnSelect(TreeView sidebar, object selected)
        {
            var visualItem = FindSelectedItem(sidebar, selected);

            visualItem.IsSelected = true;
            visualItem.UpdateLayout();
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

            container.ApplyTemplate();

            var itemsPresenter = VisualHelper.FindVisualChild<ItemsPresenter>(container);
            itemsPresenter.ApplyTemplate();

            Panel itemsHostPanel = (Panel)VisualTreeHelper.GetChild(itemsPresenter, 0);
            UIElementCollection children = itemsHostPanel.Children;
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

        public static void ExpandSidebar(ItemsControl container, bool expand)
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
    }
}
