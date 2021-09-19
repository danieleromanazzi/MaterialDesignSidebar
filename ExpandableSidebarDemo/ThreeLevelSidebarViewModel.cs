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
                new ThreeLevelSidebar("Visita", "3 Registrazioni",
                    new SecondLevel("Registrazione del 1 giugno 2021", "3 documenti",
                    new Item[3]
                    {
                        new Item("Documento 1","sottotitolo documento 1", MaterialDesignThemes.Wpf.PackIconKind.Microsoft),
                        new Item("Documento 2","sottotitolo documento 2", MaterialDesignThemes.Wpf.PackIconKind.Google),
                        new Item("Documento 3","sottotitolo documento 3", MaterialDesignThemes.Wpf.PackIconKind.AppleIos),
                    }),
                    new SecondLevel("Registrazione del 12 agosto 2021", "3 documenti",
                    new Item[3]
                    {
                        new Item("Documento 1","sottotitolo documento 1"),
                        new Item("Documento 2","sottotitolo documento 2"),
                        new Item("Documento 3","sottotitolo documento 3"),
                    }),
                    new SecondLevel("Registrazione del 14 settembre 2021", "3 documenti",
                    new Item[3]
                    {
                        new Item("Documento 1","sottotitolo documento 1"),
                        new Item("Documento 2","sottotitolo documento 2"),
                        new Item("Documento 3","sottotitolo documento 3"),
                    })),
                new ThreeLevelSidebar("Analisi", "3 Registrazioni",
                    new SecondLevel("Registrazione del 1 giugno 2021", "3 documenti",
                    new Item[3]
                    {
                        new Item("Documento 1","sottotitolo documento 1"),
                        new Item("Documento 2","sottotitolo documento 2"),
                        new Item("Documento 3","sottotitolo documento 3"),
                    }),
                    new SecondLevel("Registrazione del 12 agosto 2021", "3 documenti",
                    new Item[3]
                    {
                        new Item("Documento 1","sottotitolo documento 1"),
                        new Item("Documento 2","sottotitolo documento 2"),
                        new Item("Documento 3","sottotitolo documento 3"),
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
