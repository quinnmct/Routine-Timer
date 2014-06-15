using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using RoutineTimer.ViewModels;

namespace RoutineTimer
{
    public partial class CalendarPage : PhoneApplicationPage
    {
        public CalendarPage()
        {
            InitializeComponent();
            radCalendar.AppointmentSource = new RoutineAppointmentSource();
            radCalendar.MonthInfoDisplayMode = Telerik.Windows.Controls.Calendar.MonthInfoDisplayMode.Large;
        }

        private void SelectionMade(object sender, Telerik.Windows.Controls.ValueChangedEventArgs<object> e)
        {
             PopulateModalWindow();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RadModalWindow.IsOpen=false;
        }

        private void SameSelectionMade(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PopulateModalWindow();
        }

        private void PopulateModalWindow()
        {
            DateTime selectedDay;
            modalText.Text = "";
            int count = 0;

            selectedDay = (DateTime)radCalendar.SelectedValue;

            foreach (TimedInstanceViewModel t in App.ViewModel.SelectedEvent.RecordedTimes)
            {
                if (t.RecordedDate.Day == selectedDay.Day &&
                    t.RecordedDate.Month == selectedDay.Month &&
                    t.RecordedDate.Year == selectedDay.Year)
                {
                    modalText.Text += String.Format("Timed at: {0:hh:mm:ss tt}", t.RecordedDate) + "\n";

                    TimeSpan tspan = TimeSpan.FromSeconds(t.TimeElapsed);

                    //if current time is greater than 60 seconds, display as minutes
                    if (t.TimeElapsed >= 60d)
                    {
                        modalText.Text += "Total time: " + string.Format("{0:D2}:{1:D2}:{2:D2} minutes\n\n",
                                                            tspan.Minutes, tspan.Seconds, tspan.Milliseconds);   
                    }
                    else
                    {
                        modalText.Text += "Total time: " + string.Format("{0:D2}:{1:D2} seconds\n\n", 
                                                            tspan.Seconds, tspan.Milliseconds);
                    }
                    count++;
                }
            }
            if (count == 0)
            {
                modalText.Text += "No records found on \nthe selected day.\n\n";
            }
            RadModalWindow.IsOpen = true;
        }

    }
}