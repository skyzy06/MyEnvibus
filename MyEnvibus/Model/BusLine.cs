using MyEnvibus.Utils;

namespace MyEnvibus.Model
{
    public class BusLine : NotifyPropertyChanged
    {
        public BusLine()
        {
        }

        public BusLine(string id, string label, string category)
        {
            Id = id;
            Label = label;
            Category = category;
        }

        string id;
        public string Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged();
                }
            }
        }

        string label;
        public string Label
        {
            get { return label; }
            set
            {
                if (label != value)
                {
                    label = value;
                    OnPropertyChanged();
                }
            }
        }

        string category;
        public string Category
        {
            get { return category; }
            set
            {
                if (category != value)
                {
                    category = value;
                    OnPropertyChanged();
                }
            }
        }

        public override string ToString()
        {
            return string.Format("[BusLine: Id={0}, Label={1}, Category={2}]", Id, Label, Category);
        }
    }
}
