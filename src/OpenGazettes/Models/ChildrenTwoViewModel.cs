using System.ComponentModel;

namespace OpenGazettes.Models
{
    public class ChildrenTwoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Text { get; set; }

        public SearchResult SearchResult { get; set; }
    }
}