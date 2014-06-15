using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 *Timed Instance:
 *
 * A timed event. The time elapsed is stored and the iteration of timing is stored.
 * 
 * The TimeElapsed property stores the time recorded.
 * The Iteration property is the count of which event was timed (starting from 1, going to infinity)
 */
namespace RoutineTimer.ViewModels
{
    public class TimedInstanceViewModel : INotifyPropertyChanged
    {
        public int Iteration { get; set; }
        public double TimeElapsed { get; set; }
        public DateTime RecordedDate { get; set; }


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
