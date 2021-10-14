using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;

namespace MaterialDesignSidebarDemo.ViewModels
{
    public class SidebarItemViewModel : ViewModelBase
    {
        public SidebarItemViewModel()
        {

        }

        public string Title
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string Description
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public PackIconKind? Icon
        {
            get { return GetValue<PackIconKind?>(); }
            set { SetValue(value); }
        }

        public ObservableCollection<Item> Items
        {
            get { return GetValue<ObservableCollection<Item>>(); }
            set { SetValue(value); }
        }
    }
}
