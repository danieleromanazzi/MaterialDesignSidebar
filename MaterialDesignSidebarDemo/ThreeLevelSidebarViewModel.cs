using MaterialDesignThemes.Wpf;
using MaterialSidebar;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MaterialDesignSidebarDemo
{
    public class ThreeLevelSidebarViewModel : ViewModelBase
    {
        public ThreeLevelSidebarViewModel()
        {
            Items = new ObservableCollection<GroupItem>()
            {
                new GroupItem("Archive One","3 registrations", new ObservableCollection<IItem>()
                {
                    new SubGroupItem("Registration 12 june 2021","3 documents", new ObservableCollection<IItem>()
                    {
                        new Item("Document 1","subtitle document 1", PackIconKind.FileDocument),
                        new Item("Document 2","subtitle document 2", PackIconKind.FileDocument),
                        new Item("Document 3","subtitle document 3", PackIconKind.FileDocument),
                    }),
                    new SubGroupItem("Registration 16 agust 2021","3 documents", new ObservableCollection<IItem>()
                    {
                        new Item("Document 4","subtitle document 1", PackIconKind.FileDocument),
                        new Item("Document 5","subtitle document 2", PackIconKind.FileDocument),
                        new Item("Document 6","subtitle document 3", PackIconKind.FileDocument),
                    })
                }),
                new GroupItem("Archive Two","3 registrations", new ObservableCollection<IItem>()
                {
                    new SubGroupItem("Registration 13 june 2021","3 documents", new ObservableCollection<IItem>()
                    {
                        new Item("Document 7","subtitle document 1", PackIconKind.FileDocument),
                        new Item("Document 8","subtitle document 2", PackIconKind.FileDocument),
                        new Item("Document 9","subtitle document 3", PackIconKind.FileDocument),
                    }),
                    new SubGroupItem("Registration 15 agust 2021","3 documents", new ObservableCollection<IItem>()
                    {
                        new Item("Document 10","subtitle document 1", PackIconKind.FileDocument),
                        new Item("Document 11","subtitle document 2", PackIconKind.FileDocument),
                        new Item("Document 12","subtitle document 3", PackIconKind.FileDocument),
                    })
                })
            };
            SelectFirstItemCommand = new SelectFirstItemCommand();
            SelectLastItemCommand = new SelectLastItemCommand();
        }

        public ICommand SelectFirstItemCommand { get; set; }
        public ICommand SelectLastItemCommand { get; set; }

        public ObservableCollection<GroupItem> Items { get; set; }

        public object SelectedItem
        {
            get { return GetValue<object>(); }
            set { SetValue(value); }
        }
    }
}
