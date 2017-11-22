using Windows.UI.Xaml.Controls;
using CryptoFolio.ViewModels;

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
    }
}
