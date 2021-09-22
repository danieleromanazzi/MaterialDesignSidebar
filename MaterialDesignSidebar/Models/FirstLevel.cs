using System.Collections.ObjectModel;

namespace MaterialDesignThemes.Wpf
{
    public class FirstLevel
    {
        public FirstLevel(string title, string description, params SecondLevel[] secondLevels)
        {
            Title = title;
            Description = description;
            SecondLevelItems = new ObservableCollection<SecondLevel>(secondLevels);
        }

        public FirstLevel(string title, string description, params Item[] items)
        {
            Title = title;
            Description = description;
            Items = new ObservableCollection<Item>(items);
        }

        public string Title { get; }
        public string Description { get; }
        public ObservableCollection<SecondLevel> SecondLevelItems { get; }
        public ObservableCollection<Item> Items { get; }
    }
}
