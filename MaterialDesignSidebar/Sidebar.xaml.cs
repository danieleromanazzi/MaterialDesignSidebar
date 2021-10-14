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

        void Sidebar_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeViewItem tvi = this.ItemContainerGenerator.ContainerFromItemRecursive(e.NewValue);
            if (tvi.HasItems)
            {
                e.Handled = true;
                return;
            }

            this.SelectedItem = e.NewValue;
        }

        public new object SelectedItem
        {
            get { return this.GetValue(Sidebar.SelectedItemProperty); }
            set { this.SetValue(Sidebar.SelectedItemProperty, value); }
        }

        internal object ParentSelectedItem;

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

                var tvi = SidebarAssist.FindItemNode(targetObject, targetObject.SelectedItem);
                if (tvi != null && !tvi.HasItems)
                {
                    tvi.IsSelected = true;
                }

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
    }
}
