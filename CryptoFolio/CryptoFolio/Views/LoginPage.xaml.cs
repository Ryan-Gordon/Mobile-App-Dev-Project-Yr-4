using System;

using CryptoFolio.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

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

        //takes the details provided in the view and attempts to create a user in the viewmodel
        private void registerBT_Click(object sender, RoutedEventArgs e)
        {
                Frame.Navigate(typeof(RegisterPage));
        }
        //Navigate to the login page 
        private async void loginBT_Click(object sender, RoutedEventArgs e)
        {
            if (loginUsernameTextBox.Text != "" && loginPasswordTextBox.Password != "")
            {
                // create a new user
                LoginViewModel vm = new LoginViewModel();
                if (await vm.loginUser(loginUsernameTextBox.Text, loginPasswordTextBox.Password))
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
    }
}
