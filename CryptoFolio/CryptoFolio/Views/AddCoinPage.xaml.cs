using System;

using CryptoFolio.ViewModels;

using Windows.UI.Xaml.Controls;

using Telerik.Data.Core;

using Windows.UI.Xaml;

using Windows.UI.Xaml.Controls;

namespace CryptoFolio.Views
{
    public sealed partial class AddCoinPage : Page
    {
        private AddCoinViewModel ViewModel
        {
            get { return DataContext as AddCoinViewModel; }
        }

        public AddCoinPage()
        {
            InitializeComponent();


            this.DataContext = new Item() { Amount = 0, Coin = Coin.Bitcoin, watchOnly = true, Notes = "First Transaction" };

        }

       



        public class Item

        {
            [Display(Group = "Add coin to portfolio", Header = "Coin")]

            public Coin Coin { get; set; }

            

            [Display(Header = "Amount")]

            public double Amount { get; set; }



            

            [Display(Group = "Watch Only ? Holdings wont be tracked", Header = "Watch only?")]

            public bool watchOnly { get; set; }

            [Display(Header = "Notes")]

            public string Notes { get; set; }

        }

        public enum Coin

        {

            Bitcoin,
Ethereum,
BCash,
IOTA,
Ripple,
Dash,
Litecoin,
BGold,
Monero,
Cardano,
EthereumClassic,
StellarLumens,
NEM,
NEO,
EOS,
BitConnect,
Lisk,
Stratis,
Qtum,
MonaCoin,

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }



    public class DataFormGroupHeaderSelector : DataTemplateSelector

    {

        public DataTemplate HeaderTemplate { get; set; }

        protected override Windows.UI.Xaml.DataTemplate SelectTemplateCore(object item, Windows.UI.Xaml.DependencyObject container)

        {

            if (item.ToString() == "Additional Information")

            {

                return this.HeaderTemplate;

            }



            return base.SelectTemplateCore(item, container);

        }

    }
    

}
