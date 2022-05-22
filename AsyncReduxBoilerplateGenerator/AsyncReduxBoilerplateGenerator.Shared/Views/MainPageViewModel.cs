using AsyncReduxBoilerplateGenerator.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AsyncReduxBoilerplateGenerator
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _widgetName;
        private ObservableCollection<Parameter> _paramList;

        public string WidgetName
        {
            get { return _widgetName; }
            set
            {
                _widgetName = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs(
                        nameof(WidgetName)));
            }
        }

        public ObservableCollection<Parameter> Parameters
        {
            get { return _paramList; }
            set
            {
                _paramList = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs(
                        nameof(Parameters)));
            }
        }

        public MainPageViewModel()
        {
            _widgetName="";
            _paramList = new ObservableCollection<Parameter>()
            {
                new Parameter("", "")
            };
        }
    }
}