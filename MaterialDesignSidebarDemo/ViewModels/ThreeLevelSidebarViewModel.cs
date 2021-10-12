using MaterialDesignSidebarDemo.Commands;
using MaterialDesignSidebarDemo.Data;
using MaterialSidebar;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MaterialDesignSidebarDemo
{
    public class ThreeLevelSidebarViewModel : ViewModelBase
    {
        public ThreeLevelSidebarViewModel()
        {
            //Items = new ObservableCollection<Group>()
            //{
            //    new Group("Archive One","3 registrations", new ObservableCollection<IItem>()
            //    {
            //        new SubGroup("Registration 12 june 2021","3 documents", new ObservableCollection<IItem>()
            //        {
            //            new Item("Document 1","subtitle document 1", PackIconKind.FileDocument),
            //            new Item("Document 2","subtitle document 2", PackIconKind.FileDocument),
            //            new Item("Document 3","subtitle document 3", PackIconKind.FileDocument),
            //        }),
            //        new SubGroup("Registration 16 agust 2021","3 documents", new ObservableCollection<IItem>()
            //        {
            //            new Item("Document 4","subtitle document 1", PackIconKind.FileDocument),
            //            new Item("Document 5","subtitle document 2", PackIconKind.FileDocument),
            //            new Item("Document 6","subtitle document 3", PackIconKind.FileDocument),
            //        })
            //    }),
            //    new Group("Archive Two","3 registrations", new ObservableCollection<IItem>()
            //    {
            //        new SubGroup("Registration 13 june 2021","3 documents", new ObservableCollection<IItem>()
            //        {
            //            new Item("Document 7","subtitle document 1", PackIconKind.FileDocument),
            //            new Item("Document 8","subtitle document 2", PackIconKind.FileDocument),
            //            new Item("Document 9","subtitle document 3", PackIconKind.FileDocument),
            //        }),
            //        new SubGroup("Registration 15 agust 2021","3 documents", new ObservableCollection<IItem>()
            //        {
            //            new Item("Document 10","subtitle document 1", PackIconKind.FileDocument),
            //            new Item("Document 11","subtitle document 2", PackIconKind.FileDocument),
            //            new Item("Document 12","subtitle document 3", PackIconKind.FileDocument),
            //        })
            //    })
            //};
            var json = ReadData.ReadResource("MaterialDesignSidebarDemo.Data.ThreeLevelData.json");
            Items = JsonConvert.DeserializeObject<ObservableCollection<Item>>(json);

            SelectFirstItemCommand = new DelegateCommand((o) => SelectFirstItem(), (o) => true);
            SelectLastItemCommand = new DelegateCommand((o) => SelectLastItem(), (o) => true);
        }

        public ICommand SelectFirstItemCommand { get; set; }
        public ICommand SelectLastItemCommand { get; set; }

        public ObservableCollection<Item> Items { get; set; }

        public object SelectedItem
        {
            get { return GetValue<object>(); }
            set { SetValue(value); }
        }

        private void SelectFirstItem()
        {
            var firstItem = Items[0].Items[0].Items.First();
            SelectedItem = firstItem;
        }

        private void SelectLastItem()
        {
            var firstItem = Items.Last().Items.Last().Items.Last();
            SelectedItem = firstItem;
        }
    }
}
