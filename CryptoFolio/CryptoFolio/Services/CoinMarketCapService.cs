using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoobsMuc.Coinmarketcap;
using NoobsMuc.Coinmarketcap.Client;
using System.Diagnostics;

namespace CryptoFolio.Services
{
    class CoinMarketCapService
    {




        public static Currency getTicker(string id)
        {
            ICoinmarketcapClient client = new CoinmarketcapClient();
            Currency currency = client.GetCurrencyById(id);


            return currency;
        }

        public static IEnumerable<Currency> getAll()
        {
            ICoinmarketcapClient client = new CoinmarketcapClient();
            IEnumerable<Currency> currency = client.GetCurrencies(20, "EUR");

            //Debug.WriteLine(currency.ToList());


            return currency;
        }


    }
}
