namespace ExpandableSidebarDemo
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            ThreeLevelSidebar = new ThreeLevelSidebarViewModel();
            TwoLevelSidebar = new TwoLevelSidebarViewModel();
        }

        public ThreeLevelSidebarViewModel ThreeLevelSidebar
        {
            get { return GetValue<ThreeLevelSidebarViewModel>(); }
            set { SetValue(value); }
        }

        public TwoLevelSidebarViewModel TwoLevelSidebar
        {
            get { return GetValue<TwoLevelSidebarViewModel>(); }
            set { SetValue(value); }
        }
    }
}
