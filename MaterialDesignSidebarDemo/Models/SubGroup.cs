using System.Collections.ObjectModel;

namespace MaterialDesignSidebarDemo
{
    public class SubGroup : GroupBase
    {
        public SubGroup(string title, string description, ObservableCollection<IItem> items) : base(title, description, items)
        {

        }
    }
}
