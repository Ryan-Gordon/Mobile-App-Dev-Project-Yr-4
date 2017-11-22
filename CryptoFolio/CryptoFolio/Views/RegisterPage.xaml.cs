using System;

using CryptoFolio.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

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
        //takes the details provided in the view and attempts to create a user in the viewmodel
        private async void registerBT_Click(object sender, RoutedEventArgs e)
        {
            if (registerUsernameTextBox.Text != "" && registerPasswordTextBox.Password != "")
            {
                // create a new user
                RegisterViewModel vm = new RegisterViewModel();
                if (await vm.createUser(registerUsernameTextBox.Text, registerPasswordTextBox.Password))
                {
                    //If the result of create user is true; We successfully register the details
                    Frame.Navigate(typeof(MainPage));
                }
                else
                {
                    errorTextBlock.Text = "Error occured on server on user exists. Try login";
                }
            }
            else
            {
                //tell user to include all details needed
                errorTextBlock.Text = "Error! A Username AND Password must be entered!";
            } 
        }
        //Navigate to the login page 
        private void loginBT_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LoginPage));
        } 
    }
}

