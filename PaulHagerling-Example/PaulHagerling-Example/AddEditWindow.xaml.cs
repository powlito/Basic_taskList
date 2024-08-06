using PaulHagerling_Example;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp
{
    public partial class AddEditWindow : Window
    {
        public new string Name { get; set; } = "";
        public DayOfWeek Day { get; set; }

        public AddEditWindow(string name, DayOfWeek day)
        {
            InitializeComponent();
            if (name != null)
            {
                TextBoxItem.Text = name;
                Name = name;
            }

            ComboBoxDay.SelectedItem =  ComboBoxDay.Items.Cast<ComboBoxItem>().FirstOrDefault(cbi => Helper.dayFromString(cbi.Content?.ToString()?? "Sunday") == day);
                Day = day;
            
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Name = TextBoxItem.Text;
            if (ComboBoxDay.SelectedItem is ComboBoxItem selectedItem)
            {
                Day = Helper.dayFromString(selectedItem.Content?.ToString()?? "");
            }
            DialogResult = true;
            Close();
        }
    }
}
