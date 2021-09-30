using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace MaterialDesignThemes.Wpf
{
    public class TreeLevelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var level = -1;
            if (value is DependencyObject control)
            {
                var parent = VisualTreeHelper.GetParent(control);

                while (!(parent is TreeView) && (parent != null))
                {
                    if (parent is TreeViewItem)
                    {
                        level++;
                    }

                    parent = VisualTreeHelper.GetParent(parent);
                }
            }
            return level;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
