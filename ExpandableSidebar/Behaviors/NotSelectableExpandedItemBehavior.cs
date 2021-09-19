using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MaterialDesignThemes.Wpf
{
    public class NotSelectableExpandedItemBehavior : DependencyObject
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
            DependencyProperty.RegisterAttached("Enabled", typeof(bool), typeof(NotSelectableExpandedItemBehavior),
                new UIPropertyMetadata(false, EnabledPropertyChangedCallback
                    ));

        private static void EnabledPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            if (!(dependencyObject is Sidebar control)) return;
            control.PreviewMouseDown += Control_PreviewMouseDown;
            control.MouseUp += TreeView_MouseUp;
            control.SelectedItemChanged += Control_SelectedItemChanged;
        }

        private static void Control_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var treeViewItem = VisualUpwardSearch<TreeViewItem>(e.OriginalSource as DependencyObject) as TreeViewItem;
            if (treeViewItem.HasItems)
            {
                e.Handled = true;
            }
        }

        private static void Control_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (!typeof(Item).IsAssignableFrom(e.NewValue?.GetType()))
            {
                e.Handled = true;
            }
        }

        private static void TreeView_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var sidebar = sender as Sidebar;
            if (VisualUpwardSearch<TreeViewItem>(e.OriginalSource as DependencyObject) is TreeViewItem treeViewItem)
            {
                if (treeViewItem.HasItems && treeViewItem.IsExpanded)
                {
                    TreeViewItem tvi = ContainerFromItemRecursive(sidebar.ItemContainerGenerator, sidebar.SelectedItem);
                    if (tvi != null)
                        tvi.IsSelected = true;
                }
            }
        }

        public static TreeViewItem ContainerFromItemRecursive(ItemContainerGenerator root, object item)
        {
            if (item == null)
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

        static DependencyObject VisualUpwardSearch<T>(DependencyObject source)
        {
            while (source != null && source.GetType() != typeof(T))
            {
                source = VisualTreeHelper.GetParent(source);
            }

            return source;
        }
    }
}
