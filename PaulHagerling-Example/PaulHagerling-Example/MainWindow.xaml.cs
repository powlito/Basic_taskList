using PaulHagerling_Example;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<CheckListItem> Checklist { get; set; }
        private string selectedDay = "All";

        public MainWindow()
        {
            InitializeComponent();
            Checklist = new ObservableCollection<CheckListItem>();
            DataContext = this;
        }

        private void ItemsViewSource_Filter(object sender, FilterEventArgs e)
        {
            e.Accepted = true;
        }


        private void SundayViewSource_Filter(object sender, FilterEventArgs e)
        {
            if (e.Item is CheckListItem item)
            {
                e.Accepted = item.day == DayOfWeek.Sunday;
            }
        }
        private void MondayViewSource_Filter(object sender, FilterEventArgs e)
        {
            if (e.Item is CheckListItem item)
            {
                e.Accepted = item.day == DayOfWeek.Monday;
            }
        }
        private void TuesdayViewSource_Filter(object sender, FilterEventArgs e)
        {
            if (e.Item is CheckListItem item)
            {
                e.Accepted = item.day == DayOfWeek.Tuesday; ;
            }
        }
        private void WednesdayViewSource_Filter(object sender, FilterEventArgs e)
        {
            if (e.Item is CheckListItem item)
            {
                e.Accepted = item.day == DayOfWeek.Wednesday;
            }
        }
        private void ThursdayViewSource_Filter(object sender, FilterEventArgs e)
        {
            if (e.Item is CheckListItem item)
            {
                e.Accepted = item.day == DayOfWeek.Thursday;
            }
        }

        private void FridayViewSource_Filter(object sender, FilterEventArgs e)
        {
            if (e.Item is CheckListItem item)
            {
                e.Accepted = item.day == DayOfWeek.Friday;
            }
        }

        private void SaturdayViewSource_Filter(object sender, FilterEventArgs e)
        {
            if (e.Item is CheckListItem item)
            {
                e.Accepted = item.day == DayOfWeek.Saturday;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddEditWindow addWindow = new AddEditWindow("", Helper.dayFromString( GetSelectedDay()));
            if (addWindow.ShowDialog() == true)
            {
                Checklist.Add(new CheckListItem { day = addWindow.Day, name = addWindow.Name });
                RefreshViewSource();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            ListBox listBox = GetSelectedListBox();
            if (listBox != null && listBox.SelectedItem is CheckListItem selectedItem)
            {
                AddEditWindow editWindow = new AddEditWindow(selectedItem.name, selectedItem.day);
                if (editWindow.ShowDialog() == true)
                {
                    selectedItem.Name = editWindow.Name;
                    selectedItem.Day = editWindow.Day;
                    RefreshViewSource();
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            ListBox listBox = GetSelectedListBox();
            if (listBox != null && listBox.SelectedItem is CheckListItem selectedItem)
            {
                Checklist.Remove(selectedItem);
                RefreshViewSource();
            }
        }

        private ListBox GetSelectedListBox()
        {
            if (TabControlDays.SelectedItem is TabItem selectedTab)
            {
                return selectedTab?.Content as ListBox?? new ListBox();
            }
            return new ListBox();
        }

        private string GetSelectedDay()
        {
            if (TabControlDays.SelectedItem is TabItem selectedTab)
            {
                return selectedTab?.Header?.ToString()?? "all";
            }
            return "all";
        }

        private void TabControlDays_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedDay = GetSelectedDay();
        }

        private void RefreshViewSource()
        {
            ((CollectionViewSource)Resources["ItemsViewSource"]).View.Refresh();
            ((CollectionViewSource)Resources["SundayViewSource"]).View.Refresh();
            ((CollectionViewSource)Resources["MondayViewSource"]).View.Refresh();
            ((CollectionViewSource)Resources["TuesdayViewSource"]).View.Refresh();
            ((CollectionViewSource)Resources["WednesdayViewSource"]).View.Refresh();
            ((CollectionViewSource)Resources["ThursdayViewSource"]).View.Refresh();
            ((CollectionViewSource)Resources["FridayViewSource"]).View.Refresh();
            ((CollectionViewSource)Resources["SaturdayViewSource"]).View.Refresh();
        }
    }

}
