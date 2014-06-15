

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineTimer.ViewModels
{
    public class RoutineListViewModel : INotifyPropertyChanged
    {
        public RoutineListViewModel()
        {
            Events = new ObservableCollection<TimedEventViewModel>();

            this.LoadData();
        }

        //A list of all chosen Events
        private ObservableCollection<TimedEventViewModel> events = new ObservableCollection<TimedEventViewModel>();
        public ObservableCollection<TimedEventViewModel> Events
        {
            get
            {
                if (IsolatedStorageSettings.ApplicationSettings.Contains("SavedEvents"))
                {
                    return (ObservableCollection<TimedEventViewModel>)IsolatedStorageSettings.ApplicationSettings["SavedEvents"];
                }
                else
                {
                    return events;
                }
            }
            set
            {
                if (value != events)
                {
                    events = value;
                    NotifyPropertyChanged("Events");
                }
            }
        }

        public TimedEventViewModel SelectedEvent {get; set;}

        public bool IsDataLoaded
        { get; private set; }


        private void LoadData()
        {

            this.IsDataLoaded = true;
        }
        

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
