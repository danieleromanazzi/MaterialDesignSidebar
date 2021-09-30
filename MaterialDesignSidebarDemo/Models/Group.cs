using System.Collections.ObjectModel;

namespace MaterialDesignSidebarDemo
{
    public class Group : GroupBase
    {
        public Group(string title, string description, ObservableCollection<IItem> items) : base(title, description, items)
        {

        }
    }
}
