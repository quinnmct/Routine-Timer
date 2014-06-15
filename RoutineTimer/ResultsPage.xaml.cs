using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace RoutineTimer
{
    public partial class ResultsPage : PhoneApplicationPage
    {
        public ResultsPage()
        {
            InitializeComponent();

            DataContext = App.ViewModel.SelectedEvent;
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            chart.Series[0].ItemsSource = App.ViewModel.SelectedEvent.RecordedTimes;
            string titleText = App.ViewModel.SelectedEvent.Title.ToString()+" graph";
            ChartTitle.Text = titleText;
        }
    }
}