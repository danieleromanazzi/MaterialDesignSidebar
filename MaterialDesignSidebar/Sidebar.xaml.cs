using System.Windows;
using System.Windows.Controls;

namespace MaterialDesignThemes.Wpf
{
    public delegate void ParentSelectedItemChangedHandler(TreeView sender, object e);
    /// <summary>
    /// Interaction logic for Sidebar.xaml
    /// </summary>
    public partial class Sidebar : TreeView
    {
        public event ParentSelectedItemChangedHandler ParentSelectedItemChangedEvent;

        public Sidebar()
        {
            InitializeComponent();
            this.SelectedItemChanged += new RoutedPropertyChangedEventHandler<object>(Sidebar_SelectedItemChanged);
        }

        //public bool ShowItemSeparator
        //{
        //    get { return (bool)GetValue(ShowItemSeparatorProperty); }
        //    set { SetValue(ShowItemSeparatorProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for ShowItemSeparator.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty ShowItemSeparatorProperty =
        //    DependencyProperty.Register("ShowItemSeparator", typeof(bool), typeof(Sidebar), new PropertyMetadata(true));

        void Sidebar_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            this.SelectedItem = e.NewValue;
        }

        public new object SelectedItem
        {
            get { return this.GetValue(Sidebar.SelectedItemProperty); }
            set { this.SetValue(Sidebar.SelectedItemProperty, value); }
        }

        private object ParentSelectedItem;

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public new static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(object), typeof(Sidebar),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, SelectedItemProperty_Changed));

        static void SelectedItemProperty_Changed(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var targetObject = dependencyObject as Sidebar;
            if (targetObject != null)
            {
                var previous = targetObject.ParentSelectedItem;

                var tvi = targetObject.FindItemNode(targetObject.SelectedItem) as TreeViewItem;
                if (tvi != null)
                {
                    tvi.IsSelected = true;
                }

                //if (targetObject.ParentSelectedItem != previous)
                if (targetObject.ParentSelectedItem != previous ||
                    (targetObject.ParentSelectedItem == null && previous == null))
                {
                    targetObject.OnSidebarSelectedItemChangedEvent(targetObject, targetObject.SelectedItem);
                }
            }
        }

        protected void OnSidebarSelectedItemChangedEvent(TreeView sender, object e)
        {
            ParentSelectedItemChangedEvent?.Invoke(sender, e);
        }

        public TreeViewItem FindItemNode(object item)
        {
            TreeViewItem node = null;
            foreach (object data in this.Items)
            {
                node = this.ItemContainerGenerator.ContainerFromItem(data) as TreeViewItem;
                if (node != null)
                {
                    ParentSelectedItem = node;
                    if (data == item)
                    {
                        break;
                    }

                    node = FindItemNodeInChildren(node, item);
                    if (node != null)
                    {
                        break;
                    }
                }
            }
            return node;
        }

        protected TreeViewItem FindItemNodeInChildren(TreeViewItem parent, object item)
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

                node = FindItemNodeInChildren(node, item);
                if (node != null)
                {
                    ParentSelectedItem = data;
                    break;
                }
            }

            return node;
        }

        private void TreeView_Selected(object sender, RoutedEventArgs e)
        {
            var treeViewItem = VisualHelper.VisualUpwardSearch<TreeViewItem>(e.OriginalSource as DependencyObject) as TreeViewItem;
            if (treeViewItem != null)
            {
                treeViewItem.IsExpanded = !treeViewItem.IsExpanded;
                e.Handled = true;
            }
        }
    }
}
