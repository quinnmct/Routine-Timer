using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;

namespace RoutineTimer.ViewModels
{
    public class RoutineAppointmentSource : AppointmentSource
    {
        public RoutineAppointmentSource()
        {
            
        }

        public override void FetchData(DateTime startDate, DateTime endDate)
        {
            this.AllAppointments.Clear();
            foreach (TimedInstanceViewModel t in App.ViewModel.SelectedEvent.RecordedTimes)
            {
                this.AllAppointments.Add(new RoutineAppointment()
                {
                    StartDate = t.RecordedDate,
                    EndDate = t.RecordedDate,
                    Subject = "#"+t.Iteration.ToString()+": "+t.TimeElapsed.ToString()+" seconds.",
                    Details = "Some Long Details are coming here",
                    Location = "My Home Town"
                });
            }

            this.OnDataLoaded(); // notify that there is new data to display
        }
    }
}
