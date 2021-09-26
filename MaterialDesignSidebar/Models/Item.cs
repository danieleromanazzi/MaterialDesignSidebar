using MaterialSidebar;
using System.Collections.ObjectModel;

namespace MaterialDesignThemes.Wpf
{
    public class Item : ViewModelBase, IItem
    {
        //public Item(string title, string description, GroupLevel level)
        //{
        //    Title = title;
        //    Description = description;
        //    Level = level;
        //}

        //public Item(string title, string description, ObservableCollection<IItem> items, GroupLevel level)
        //{
        //    Title = title;
        //    Description = description;
        //    Items = items;
        //    Level = level;
        //}

        public Item(string title, string description, PackIconKind icon)
        {
            Title = title;
            Description = description;
            Icon = icon;
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

        //public GroupLevel Level
        //{
        //    get { return GetValue<GroupLevel>(); }
        //    set { SetValue(value); }
        //}

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
