using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Threading;
using System.Windows.Media;
using RoutineTimer.ViewModels;

namespace RoutineTimer
{
    public partial class TimerPage
    {
        DispatcherTimer timer;
        DateTime startTime;
        bool timerGoing;
        

        public TimerPage()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timerGoing = false;
            
            DataContext = App.ViewModel;
        }


        void TimerPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            timer.Interval = new TimeSpan(0, 0, 0, 0, 150);//150 milliseconds
            timer.Tick += OnTimerTick;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (!timerGoing)
            {
                startTime = DateTime.Now;
                timer.Start();
                timerGoing = true;
                button1.Content = " Stop \ntimer";
                button1.BorderBrush = new SolidColorBrush(Color.FromArgb(255,255,0,0));

                FinalTimeText.Visibility = System.Windows.Visibility.Collapsed;
                TotalRecordsText.Visibility = System.Windows.Visibility.Collapsed;
                graphButton.Visibility = System.Windows.Visibility.Collapsed;
                timeText.Visibility = System.Windows.Visibility.Collapsed;
                recordCountText.Visibility = System.Windows.Visibility.Collapsed;
                recordDate.Visibility = System.Windows.Visibility.Collapsed;

            }
            else
            {
                timer.Stop();
                timerGoing = false;
                button1.Content = " Start \ntimer";
                time = (DateTime.Now - startTime).TotalSeconds;
                 TimedInstanceViewModel thisTime = new TimedInstanceViewModel() {TimeElapsed = Math.Round(time, 2), 
                                                                                Iteration = App.ViewModel.SelectedEvent.RecordedTimes.Count+1,
                                                                                RecordedDate = DateTime.Now};

                App.ViewModel.SelectedEvent.RecordedTimes.Add(thisTime);
                App.ViewModel.SelectedEvent.LastTimeElapsed = thisTime;
                App.ViewModel.SelectedEvent.TotalRecords = App.ViewModel.SelectedEvent.RecordedTimes.Count;
                App.ViewModel.SelectedEvent.RecordingDate = DateTime.Now;
                string finalTime = App.ViewModel.SelectedEvent.LastTimeElapsed.TimeElapsed.ToString();
                txtClock.Text = finalTime;
                //MessageBox.Show(finalTime);
                //NavigationService.Navigate(new Uri("/ResultsPage.xaml", UriKind.RelativeOrAbsolute));

                FinalTimeText.Visibility = System.Windows.Visibility.Visible;
                TotalRecordsText.Visibility = System.Windows.Visibility.Visible;
                graphButton.Visibility = System.Windows.Visibility.Visible;
                recordDate.Visibility = System.Windows.Visibility.Visible;

                timeText.Text = finalTime;
                recordCountText.Text = App.ViewModel.SelectedEvent.TotalRecords.ToString();
                timeText.Visibility = System.Windows.Visibility.Visible;
                recordCountText.Visibility = System.Windows.Visibility.Visible;
                recordDate.Text = App.ViewModel.SelectedEvent.RecordingDate.ToString();

                button1.BorderBrush = new SolidColorBrush(Color.FromArgb(255,0,180,0));
            }
        }
        TimeSpan count;
        double time;
        private void OnTimerTick(object sender, EventArgs e)
        {
            count = DateTime.Now - startTime;
            time = count.TotalSeconds;
            time = Math.Round(time, 2);
            txtClock.Text = time.ToString();
            
        }

        private void graphButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ResultsPage.xaml", UriKind.RelativeOrAbsolute));
        }


        
    }
}