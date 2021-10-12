using MaterialDesignSidebarDemo.Commands;
using MaterialDesignSidebarDemo.Data;
using MaterialSidebar;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MaterialDesignSidebarDemo
{
    public class TwoLevelSidebarViewModel : ViewModelBase
    {
        public TwoLevelSidebarViewModel()
        {
            var json = ReadData.ReadResource("MaterialDesignSidebarDemo.Data.TwoLevelData.json");
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
            var firstItem = Items.First().Items.First();
            SelectedItem = firstItem;
        }

        private void SelectLastItem()
        {
            var firstItem = Items.Last().Items.Last();
            SelectedItem = firstItem;
        }
    }
}