using System;

using CryptoFolio.ViewModels;

using Windows.UI.Xaml.Controls;

namespace CryptoFolio.Views
{
    public sealed partial class LoginPage : Page
    {
        private LoginViewModel ViewModel
        {
            get { return DataContext as LoginViewModel; }
        }

        public LoginPage()
        {
            InitializeComponent();
        }
    }
}
