using MaterialDesignThemes.Wpf;
using MaterialSidebar;
using System.Collections.ObjectModel;

namespace MaterialDesignSidebarDemo
{
    public class TwoLevelSidebarViewModel : ViewModelBase
    {
        public TwoLevelSidebarViewModel()
        {
            Items = new ObservableCollection<TwoLevelSidebar>
            {
                new TwoLevelSidebar("Big Tech", "3 Elements",
                    new Item[3]
                    {
                        new Item("Microsoft","Redmond", MaterialDesignThemes.Wpf.PackIconKind.Microsoft),
                        new Item("Google","Mountain View", MaterialDesignThemes.Wpf.PackIconKind.Google),
                        new Item("Apple","Cupertino", MaterialDesignThemes.Wpf.PackIconKind.Apple),
                    }),
                new TwoLevelSidebar("Mobile Operative System", "2 Elements",
                    new Item[2]
                    {
                        new Item("Android","", PackIconKind.Android),
                        new Item("Ios","", PackIconKind.AppleIos)
                    })
            };
        }

        public ObservableCollection<TwoLevelSidebar> Items { get; set; }

        public object SelectedItem
        {
            get { return GetValue<object>(); }
            set { SetValue(value); }
        }

    }
}