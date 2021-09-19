namespace MaterialDesignThemes.Wpf
{
    public sealed class Item
    {
        public Item(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public Item(string title, string description, PackIconKind icon)
        {
            Title = title;
            Description = description;
            Icon = icon;
        }

        public string Title { get; }

        public string Description { get; }

        public PackIconKind? Icon { get; }

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
