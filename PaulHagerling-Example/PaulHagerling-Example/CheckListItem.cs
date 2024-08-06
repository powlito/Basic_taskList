
using System.ComponentModel;


namespace PaulHagerling_Example
{
    public class CheckListItem : INotifyPropertyChanged
    {
        public DayOfWeek day;
        public bool done;
        //Can add any number of tags to an item to filter them.
        public List<string> tags = new();
        //Description of task is optional for tasks that need more detail.
        public string? description;
        public required string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(name));
                }
            }
        }

        public DayOfWeek Day
        {
            get { return day; }
            set
            {
                if (day != value)
                {
                    day = value;
                    OnPropertyChanged(nameof(Day));
                }
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
