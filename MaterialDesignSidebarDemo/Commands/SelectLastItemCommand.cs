using MaterialDesignThemes.Wpf;
using System;
using System.Linq;
using System.Windows.Input;

namespace MaterialDesignSidebarDemo
{
    public class SelectLastItemCommand : ICommand
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
                var firstItem = ((SubGroupItem)vm.Items.Last().Items.Last()).Items.Last();
                vm.SelectedItem = firstItem;
            }
            if (parameter is TwoLevelSidebarViewModel vm2)
            {
                var firstItem = vm2.Items.Last().Items.Last();
                vm2.SelectedItem = firstItem;
            }
        }
    }
}