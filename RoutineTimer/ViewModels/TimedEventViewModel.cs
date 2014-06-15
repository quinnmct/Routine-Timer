using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace RoutineTimer.ViewModels
{
    public class TimedEventViewModel : INotifyPropertyChanged
    {
        public TimedEventViewModel()
        {
            recordingDate = new DateTime();
            recordedTimes = new ObservableCollection<TimedInstanceViewModel>();
            LastTimeElapsed = new TimedInstanceViewModel();
            totalRecords = recordedTimes.Count;
        }

        private string title;
        private DateTime recordingDate;
        private TimedInstanceViewModel lastTimeElapsed;
        private int totalRecords;

        public int TotalRecords
        {
            get
            {
                return totalRecords;
            }
            set
            {
                if (value != totalRecords)
                {
                    totalRecords = value;
                    NotifyPropertyChanged("TotalRecords");
                }
            }
        }

        //A String representing the title of the Event
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (value != title)
                {
                    title = value;
                    NotifyPropertyChanged("Title");
                }
            }
        }

        //Stores the DateTime of the last recording
        public DateTime RecordingDate
        {
            get
            {
                return recordingDate;
            }
            set
            {
                if (value != recordingDate)
                {
                    recordingDate = value;
                    NotifyPropertyChanged("RecordingDate");
                }
            }
        }

        //The last recorded time is stored in the LastTimeElapsed
        public TimedInstanceViewModel LastTimeElapsed
        {
            get
            {
                return lastTimeElapsed;
            }
            set
            {
                if (value != lastTimeElapsed)
                {
                    lastTimeElapsed = value;
                    NotifyPropertyChanged("LastTimeElapsed");
                }
            }
        }
        
        //Observable collection stores all recorded times for this event
        private ObservableCollection<TimedInstanceViewModel> recordedTimes;
        public ObservableCollection<TimedInstanceViewModel> RecordedTimes
        {
            get
            {
                return recordedTimes;
            }
            set
            {
                if (value != recordedTimes)
                {
                    recordedTimes = value;
                    NotifyPropertyChanged("RecordedTimes");
                }
            }
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