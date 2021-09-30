using MaterialDesignThemes.Wpf;
using MaterialSidebar;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MaterialDesignSidebarDemo
{
    public class TwoLevelSidebarViewModel : ViewModelBase
    {
        public TwoLevelSidebarViewModel()
        {
            Items = new ObservableCollection<Group>()
            {
                new Group("Big Tech","3 Elements", new ObservableCollection<IItem>()
                {
                    new Item("Microsoft","Redmond", PackIconKind.Microsoft),
                    new Item("Google","Mountain View", PackIconKind.Google),
                    new Item("Apple","Cupertino", PackIconKind.Apple),
                }),
                new Group("Mobile Operative System","2 Elements", new ObservableCollection<IItem>()
                {
                    new Item("Android","Redmond", PackIconKind.Android),
                    new Item("Ios","Mountain View", PackIconKind.AppleIos),
                })
            };
            SelectFirstItemCommand = new SelectFirstItemCommand();
            SelectLastItemCommand = new SelectLastItemCommand();
        }

        public ICommand SelectFirstItemCommand { get; set; }
        public ICommand SelectLastItemCommand { get; set; }

        public ObservableCollection<Group> Items { get; set; }

        public object SelectedItem
        {
            get { return GetValue<object>(); }
            set { SetValue(value); }
        }

    }
}