using System.Collections.Generic;

namespace MaterialDesignSidebarDemo.ViewModels
{
    public class SimpleSidebarViewModel : ViewModelBase, ISidebarViewModel
    {
        public SimpleSidebarViewModel()
        {

        }

        public IEnumerable<SidebarItemViewModel> Items
        {
            get { return GetValue<IEnumerable<SidebarItemViewModel>>(); }
            set { SetValue(value); }
        }

        public object SelectedItem
        {
            get { return GetValue<object>(); }
            set { SetValue(value); }
        }
    }
}