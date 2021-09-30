using MaterialDesignThemes.Wpf;

namespace MaterialDesignSidebarDemo
{
    public interface IItem
    {
        string Description { get; }
        PackIconKind? Icon { get; set; }
        string Title { get; }
    }
}