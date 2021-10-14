using System.Collections.Generic;

namespace MaterialDesignSidebarDemo.ViewModels
{
    public interface ISidebarViewModel
    {
        IEnumerable<SidebarItemViewModel> Items { get; set; }
        object SelectedItem { get; set; }
    }
}