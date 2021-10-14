using AutoMapper;
using MaterialDesignSidebarDemo.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MaterialDesignSidebarDemo.ViewModels
{
    public class SimpleSidebarViewModel : ViewModelBase
    {
        public SimpleSidebarViewModel()
        {
            SelectFirstItemCommand = new DelegateCommand((o) => SelectFirstItem(), (o) => true);
            SelectLastItemCommand = new DelegateCommand((o) => SelectLastItem(), (o) => true);
        }

        public async Task LoadData()
        {
            var items = await ReadData.Current.GetSimpleData();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Item, SidebarItemViewModel>();
            });

            IMapper iMapper = config.CreateMapper();
            Items = iMapper.Map<IEnumerable<Item>, ObservableCollection<SidebarItemViewModel>>(items);
        }

        public ICommand SelectFirstItemCommand { get; set; }
        public ICommand SelectLastItemCommand { get; set; }

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