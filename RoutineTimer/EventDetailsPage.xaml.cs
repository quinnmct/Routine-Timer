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
    public partial class EventDetailsPage : PhoneApplicationPage
    {
        TimedEventViewModel thisEvent = App.ViewModel.SelectedEvent;

        public EventDetailsPage()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/TimerPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/CalendarPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void PhoneApplicationPage_Loaded_1(object sender, RoutedEventArgs e)
        {
            eventNameTextBlock.Text = thisEvent.Title;
            totalRecordsText.Text = thisEvent.TotalRecords.ToString();
            lastRecordText.Text = thisEvent.LastTimeElapsed.TimeElapsed.ToString() +" seconds";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ResultsPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}