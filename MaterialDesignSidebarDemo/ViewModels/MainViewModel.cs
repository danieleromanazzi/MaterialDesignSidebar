
using AutoMapper;
using MaterialDesignSidebarDemo.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MaterialDesignSidebarDemo.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            SimpleSidebarViewModel = new SimpleSidebarViewModel();
            CompositeSidebarViewModel = new CompositeSidebarViewModel();

            SelectFirstItemCommand = new DelegateCommand((o) => SelectFirstItem(), (o) => true);
            SelectLastItemCommand = new DelegateCommand((o) => SelectLastItem(), (o) => true);

            AutoExpandOnSelect = true;

            LoadAsync();
        }

        private void LoadAsync()
        {
            Task.Run(async () =>
            {
                await LoadData(SimpleSidebarViewModel, async () => await ReadData.Current.GetSimpleData());
                await LoadData(CompositeSidebarViewModel, async () => await ReadData.Current.GetCompositeData());
            });
        }

        public async Task LoadData(ISidebarViewModel vm, Func<Task<IEnumerable<Item>>> readData)
        {
            var items = await readData.Invoke();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Item, SidebarItemViewModel>();
            });

            IMapper iMapper = config.CreateMapper();
            vm.Items = iMapper.Map<IEnumerable<Item>, ObservableCollection<SidebarItemViewModel>>(items);
        }

        public ICommand SelectFirstItemCommand { get; set; }
        public ICommand SelectLastItemCommand { get; set; }

        public CompositeSidebarViewModel CompositeSidebarViewModel
        {
            get { return GetValue<CompositeSidebarViewModel>(); }
            set { SetValue(value); }
        }

        public SimpleSidebarViewModel SimpleSidebarViewModel
        {
            get { return GetValue<SimpleSidebarViewModel>(); }
            set { SetValue(value); }
        }

        public bool ShowSeparator
        {
            get { return GetValue<bool>(); }
            set { SetValue(value); }
        }

        public bool ExpandAll
        {
            get { return GetValue<bool>(); }
            set { SetValue(value); }
        }

        public bool AutoExpandOnSelect
        {
            get { return GetValue<bool>(); }
            set { SetValue(value); }
        }

        private void SelectFirstItem()
        {
            SimpleSidebarViewModel.SelectedItem = SimpleSidebarViewModel.Items.First().Items.First();

            CompositeSidebarViewModel.SelectedItem = CompositeSidebarViewModel.Items.First().Items.First().Items.First();
        }

        private void SelectLastItem()
        {
            SimpleSidebarViewModel.SelectedItem = SimpleSidebarViewModel.Items.Last().Items.Last();

            CompositeSidebarViewModel.SelectedItem = CompositeSidebarViewModel.Items.Last().Items.Last().Items.Last();
        }
    }
}
