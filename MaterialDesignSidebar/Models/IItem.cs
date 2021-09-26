namespace MaterialDesignThemes.Wpf
{
    public interface IItem
    {
        string Description { get; }
        PackIconKind? Icon { get; set; }
        //ObservableCollection<IItem> Items { get; set; }
        string Title { get; }
    }
}