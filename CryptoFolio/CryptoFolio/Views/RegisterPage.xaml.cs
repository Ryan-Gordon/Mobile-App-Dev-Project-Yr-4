using System;

using CryptoFolio.ViewModels;

using Windows.UI.Xaml.Controls;

namespace CryptoFolio.Views
{
    public sealed partial class RegisterPage : Page
    {
        private RegisterViewModel ViewModel
        {
            get { return DataContext as RegisterViewModel; }
        }

        public RegisterPage()
        {
            InitializeComponent();
        }
    }
}
