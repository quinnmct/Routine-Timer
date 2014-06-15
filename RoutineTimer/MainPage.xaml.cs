using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using RoutineTimer.ViewModels;
using Telerik.Windows.Controls;
using System.Collections.ObjectModel;

/* REWORDING MESSAGE:
 * 
 * There is a 'TimedEvent' object referred to frequently as an 'Event', so user "events" are referred to as "event-handlers" 
 * */
namespace RoutineTimer
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

			//Shows the rate reminder message, according to the settings of the RateReminder.
            (App.Current as App).rateReminder.Notify();

            DataContext = App.ViewModel;
        }

        //Event-handler fires when user selects the 'remove' option on the application bar
        public void Remove_Click(object sender, EventArgs e)
        {
            this.radWindow2.IsOpen = true;
        }

        //Event-handler fires when user selects the 'add' option on the application bar
        public void Add_Click(object sender, EventArgs e)
        {
            this.radWindow.IsOpen = true;
        }

        //event-handler fires when user accepts the newly named event object
        public void ApplicationBarInfo_ButtonClick(object sender, ApplicationBarButtonClickEventArgs e)
        {
            if (e.Button.Text == "OK")
            {
                if(!WindowTextBox.Text.Equals(""))  
                    App.ViewModel.Events.Add(new TimedEventViewModel() {Title = WindowTextBox.Text});
                this.radWindow.IsOpen = false;

            }
        }

        //event-handler fires when user selects an Event to remove
        public void ItemSelectedToRemove(object sender, ApplicationBarButtonClickEventArgs e)
        {
            ObservableCollection<TimedEventViewModel> names = App.ViewModel.Events;
            TimedEventViewModel currentSelection = removeList.SelectedItem as TimedEventViewModel;
            foreach (TimedEventViewModel t in names)
            {
                if (currentSelection.Title.ToString().Equals(t.Title))
                {
                    names.Remove(t);
                    radWindow2.IsOpen = false;
                    return;
                }
            }
        }

        //RadDataBoundListBox SelectionChanged
        public void SelectedEventChanged(object sender, SelectionChangedEventArgs e)
        {
            //if event is removed, this event-handler fires. this prevents null reference errors
            if ((sender as RadDataBoundListBox).SelectedItem != null)
            {
                var selectedEvent = ((sender as RadDataBoundListBox).SelectedItem as TimedEventViewModel);
                App.ViewModel.SelectedEvent = selectedEvent as TimedEventViewModel;

                NavigationService.Navigate(new Uri("/EventDetailsPage.xaml", UriKind.RelativeOrAbsolute));
            }
        }

        //This event fires when the user selects the previously selected item
        private void SelectedEventSame(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var selectedEvent = ((sender as RadDataBoundListBox).SelectedItem as TimedEventViewModel);
            App.ViewModel.SelectedEvent = selectedEvent as TimedEventViewModel;

            NavigationService.Navigate(new Uri("/EventDetailsPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
