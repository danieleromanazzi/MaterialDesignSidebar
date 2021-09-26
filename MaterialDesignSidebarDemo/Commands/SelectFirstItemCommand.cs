using MaterialDesignThemes.Wpf;
using System;
using System.Linq;
using System.Windows.Input;

namespace MaterialDesignSidebarDemo
{
    public class SelectFirstItemCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ThreeLevelSidebarViewModel vm)
            {
                var firstItem = ((SubGroupItem)vm.Items[0].Items[0]).Items.First();
                vm.SelectedItem = firstItem;
            }
            if (parameter is TwoLevelSidebarViewModel vm2)
            {
                var firstItem = vm2.Items.First().Items.First();
                vm2.SelectedItem = firstItem;
            }
        }
    }
}
