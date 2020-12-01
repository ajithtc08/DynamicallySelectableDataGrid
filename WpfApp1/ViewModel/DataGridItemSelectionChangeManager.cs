using System;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{

    public class DataGridItemSelectionChangeManager : ViewModelBase
    {
        public static readonly DependencyProperty SelectingItemProperty = DependencyProperty.RegisterAttached(
            "SelectingItem",
            typeof(User),
            typeof(DataGridItemSelectionChangeManager),
            new PropertyMetadata(default(User), OnSelectingItemChanged));

        public static User GetSelectingItem(DependencyObject target)
        {
            return (User)target.GetValue(SelectingItemProperty);
        }

        public static void SetSelectingItem(DependencyObject target, User value)
        {
            target.SetValue(SelectingItemProperty, value);
        }


        static void OnSelectingItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var grid = sender as DataGrid;
            if (grid == null || grid.SelectedItem == null)
                return;

            grid.Dispatcher.InvokeAsync(() =>
            {
                grid.UpdateLayout();
                grid.ScrollIntoView(grid.SelectedItem, null);
            });
        }
    }
}
