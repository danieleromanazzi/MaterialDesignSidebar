using MaterialDesignThemes.Wpf;

namespace MaterialDesignSidebarDemo
{
    public interface IItem
    {
        string Title { get; set; }
        string Description { get; set; }
        PackIconKind? Icon { get; set; }
    }
}