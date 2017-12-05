using Windows.UI.Xaml.Controls;
using CryptoFolio.ViewModels;
using System;
using System.Diagnostics;
using CryptoFolio.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CryptoFolio.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    ///

    
    public sealed partial class NewsPage : Page
    {
        private NewsPageViewModel ViewModel
        {
            get { return DataContext as NewsPageViewModel; }
        }
        public NewsPage()
        {
            InitializeComponent();
            NewsPageViewModel vm = new NewsPageViewModel();
        }

        

        private async void StackPanel_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            var sp = sender as StackPanel;
            Debug.WriteLine(e);
            Article theValue = sp.DataContext as Article;
            Debug.WriteLine(theValue);
            await Windows.System.Launcher.LaunchUriAsync(new Uri(theValue.url));
        }
    }
}
