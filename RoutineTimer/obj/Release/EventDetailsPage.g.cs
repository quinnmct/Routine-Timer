﻿#pragma checksum "C:\Users\mctiernan\documents\visual studio 2012\Projects\RoutineTimer\RoutineTimer\EventDetailsPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "AD3DCC317DDCC3FCF966B48560E75937"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18051
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace RoutineTimer {
    
    
    public partial class EventDetailsPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock eventNameTextBlock;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBlock totalRecordsText;
        
        internal System.Windows.Controls.TextBlock lastRecordText;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/RoutineTimer;component/EventDetailsPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.eventNameTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("eventNameTextBlock")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.totalRecordsText = ((System.Windows.Controls.TextBlock)(this.FindName("totalRecordsText")));
            this.lastRecordText = ((System.Windows.Controls.TextBlock)(this.FindName("lastRecordText")));
        }
    }
}

