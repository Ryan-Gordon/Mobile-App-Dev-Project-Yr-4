using System;

using CryptoFolio.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

namespace CryptoFolio.Views
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel ViewModel
        {
            get { return DataContext as MainViewModel; }
        }

        public MainPage()
        {
            InitializeComponent();
            this.Loaded += Example_Loaded;
            this.Unloaded += Example_Unloaded;

        }
        void Example_Loaded(object sender, RoutedEventArgs e)
        {
            var model = new MainViewModel();
            model.OnLoaded();
        }

        void Example_Unloaded(object sender, RoutedEventArgs e)
        {
            var model = new MainViewModel();
            model.OnUnloaded();
        }





    }
}
