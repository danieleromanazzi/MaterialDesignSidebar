using MaterialSidebar;
using System.Collections.ObjectModel;

namespace MaterialDesignThemes.Wpf
{
    public enum GroupLevel
    {
        Primary,
        Secondary
    }

    public class GroupItem : Group, IItem
    {
        public GroupItem(string title, string description, ObservableCollection<IItem> items) : base(title, description, items, GroupLevel.Primary)
        {

        }
    }

    public class SubGroupItem : Group, IItem
    {
        public SubGroupItem(string title, string description, ObservableCollection<IItem> items) : base(title, description, items, GroupLevel.Secondary)
        {

        }
    }

    public class Group : ViewModelBase, IItem
    {
        public Group(string title, string description, ObservableCollection<IItem> items, GroupLevel level)
        {
            Title = title;
            Description = description;
            Items = items;
            Level = level;
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

        public GroupLevel Level
        {
            get { return GetValue<GroupLevel>(); }
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
