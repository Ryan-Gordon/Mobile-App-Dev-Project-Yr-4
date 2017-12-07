
using CryptoFolio.Services;
using GalaSoft.MvvmLight;
using NoobsMuc.Coinmarketcap.Client;
using System.Collections;
using System.Diagnostics;
using static CryptoFolio.Views.AddCoinPage;

namespace CryptoFolio.ViewModels
{
    public class AddCoinViewModel : ViewModelBase
    {
        public AddCoinViewModel()
        {
            test();
            get_All_Names();

        }

        public void test()
        {
            Currency test = CoinMarketCapService.getTicker();
            Debug.WriteLine(CoinMarketCapService.getTicker());
            new Item() { Amount = 0, Coin = Coin.Bitcoin, watchOnly = true, Notes = "First Transaction" };

            Debug.WriteLine(test.Id);
            Debug.WriteLine(test.PriceUsd);
        }

        public ArrayList get_All_Names()
        {
            //Currency test = CoinMarketCapService.getAll();
            Debug.WriteLine(CoinMarketCapService.getAll());
            ArrayList currencyList= new ArrayList();

            foreach (Currency coin in CoinMarketCapService.getAll())
            {
                Debug.WriteLine(coin.Name);
                currencyList.Add(coin.Name);
            }

            return currencyList;
        }
    }
}
