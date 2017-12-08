﻿using System;

using CryptoFolio.ViewModels;

using Windows.UI.Xaml.Controls;

namespace CryptoFolio.Views
{
    public sealed partial class ChartPage : Page
    {
        private ChartViewModel ViewModel
        {
            get { return DataContext as ChartViewModel; }
        }

        // TODO WTS: Change the chart as appropriate to your app.
        // For help see http://docs.telerik.com/windows-universal/controls/radchart/getting-started
        public ChartPage()
        {
            InitializeComponent();
        }
    }
}
