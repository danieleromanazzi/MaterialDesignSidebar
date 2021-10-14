using MaterialDesignThemes.Wpf;
using System.Collections.Generic;

namespace MaterialDesignSidebarDemo
{
    public class Item : ViewModelBase, IItem
    {
        public Item(string title, string description, PackIconKind? icon)
        {
            Title = title;
            Description = description;
            Icon = icon;
        }

        public Item(string title, string description, IEnumerable<Item> items)
        {
            Title = title;
            Description = description;
            Items = items;
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public PackIconKind? Icon { get; set; }

        public IEnumerable<Item> Items { get; set; }

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
