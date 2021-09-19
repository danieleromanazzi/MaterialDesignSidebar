using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;

namespace ExpandableSidebarDemo
{
    public class ThreeLevelSidebarViewModel : ViewModelBase
    {
        public ThreeLevelSidebarViewModel()
        {
            Items = new ObservableCollection<ThreeLevelSidebar>
            {
                new ThreeLevelSidebar("Archive One", "3 registrations",
                    new SecondLevel("Registration 12 june 2021", "3 documents",
                    new Item[3]
                    {
                        new Item("Document 1","subtitle document 1", PackIconKind.FileDocument),
                        new Item("Document 2","subtitle document 2", PackIconKind.FileDocument),
                        new Item("Document 3","subtitle document 3", PackIconKind.FileDocument),
                    }),
                    new SecondLevel("Registration 16 agust 2021", "2 documents",
                    new Item[2]
                    {
                        new Item("Document 1","subtitle document 1"),
                        new Item("Document 2","subtitle document 2"),
                    }),
                    new SecondLevel("Registration 14 september 2021", "1 document",
                    new Item[1]
                    {
                        new Item("Document 1","subtitle document 1")
                    })),
                new ThreeLevelSidebar("Archive two", "3 Registrazioni",
                    new SecondLevel("Registration 1 june 2021", "1 document",
                    new Item[1]
                    {
                        new Item("Document 1","subtitle document 1")
                    }),
                    new SecondLevel("Registration 12 october 2021", "2 documents",
                    new Item[2]
                    {
                        new Item("Document 1","subtitle document 1"),
                        new Item("Document 2","subtitle document 2")
                    }))
            };
        }

        public ObservableCollection<ThreeLevelSidebar> Items { get; set; }

        public object SelectedItem
        {
            get { return GetValue<object>(); }
            set { SetValue(value); }
        }

    }
}
