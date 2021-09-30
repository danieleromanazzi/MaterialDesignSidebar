using MaterialDesignThemes.Wpf;
using MaterialSidebar;
using System.Collections.ObjectModel;

namespace MaterialDesignSidebarDemo
{
    public class GroupBase : ViewModelBase, IItem
    {
        public GroupBase(string title, string description, ObservableCollection<IItem> items)
        {
            Title = title;
            Description = description;
            Items = items;
        }

        public string Title { get; }

        public string Description { get; }

        public PackIconKind? Icon
        {
            get { return GetValue<PackIconKind?>(); }
            set { SetValue(value); }
        }

        public ObservableCollection<IItem> Items
        {
            get { return GetValue<ObservableCollection<IItem>>(); }
            set { SetValue(value); }
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Description))
            {
                return Title;
            }
            return $"{Title}, {Description}";
        }
    }
}
