using System.Collections.ObjectModel;

namespace MaterialDesignThemes.Wpf
{
    public sealed class SecondLevel
    {
        public SecondLevel(string title, string description, params Item[] items)
        {
            Title = title;
            Description = description;
            Items = new ObservableCollection<Item>(items);
        }

        public string Title { get; }
        public string Description { get; }
        public ObservableCollection<Item> Items { get; }
    }
}
