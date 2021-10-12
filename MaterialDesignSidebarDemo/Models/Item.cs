using MaterialDesignThemes.Wpf;
using MaterialSidebar;
using System.Collections.ObjectModel;

namespace MaterialDesignSidebarDemo
{
    public class Item : ViewModelBase, IItem
    {
        public Item()
        {

        }

        public Item(string title, string description, PackIconKind icon)
        {
            Title = title;
            Description = description;
            Icon = icon;
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public PackIconKind? Icon
        {
            get { return GetValue<PackIconKind?>(); }
            set { SetValue(value); }
        }

        public ObservableCollection<Item> Items
        {
            get { return GetValue<ObservableCollection<Item>>(); }
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
