using System;

using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.UI.Xaml.Controls.Grid;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Collections.ObjectModel;
using CryptoFolio.Services;
using NoobsMuc.Coinmarketcap.Client;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections;

namespace CryptoFolio.ViewModels
{
    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
            private static readonly int Deviation = 2;

        private DispatcherTimer timer;

        private double updateProgress;
        private bool showLoading;

        public bool ShowLoading
        {
            get { return showLoading; }
            set
            {
                showLoading = value;

                Set<bool>(() => ShowLoading, ref showLoading, value);
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ShowLoading"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            ShowLoading = true;
            Data = GetData();

            lastTick = DateTime.Now;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(50);
            timer.Tick += timer_Tick;
        }

        public void OnLoaded()
        {
            timer.Start();
        }

        public void OnUnloaded()
        {
            this.timer.Stop();
        }

        private IList<Currency> GetData()
        {
            var data = new ObservableCollection<Currency>();
            foreach(Currency c in CoinMarketCapService.getAll())
            {
                data.Add(new Currency
                {
                    Rank = c.Rank,
                    Symbol = c.Name,
                    MarketCapConvert = c.MarketCapConvert,
                    PriceConvert = c.PriceConvert,
                    PercentChange24h = c.PercentChange24h
                });


                    
            }

            ShowLoading = false;

            return data;

        }

        public double UpdateProgress
        {
            get { return updateProgress; }
            set
            {
                updateProgress = value;


                Set<double>(() => UpdateProgress, ref updateProgress, value);

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("UpdateProgress"));
                    PropertyChanged(this, new PropertyChangedEventArgs("Data"));
                }
            }
        }

        public IList<Currency> Data { get; set; }

        private Random rand = new Random();

        private DateTime lastTick;

        void timer_Tick(object sender, object e)
        {
            if (this.UpdateProgress > 2000)
            {
                timer.Stop();
                this.UpdateData();
                timer.Start();

                this.UpdateProgress = 0;
            }
            else
            {
                this.UpdateProgress += (DateTime.Now - lastTick).TotalMilliseconds / this.timer.Interval.TotalMilliseconds;
            }
            lastTick = DateTime.Now;
        }

        private void UpdateData()
        {
            IEnumerable<Currency> coins = CoinMarketCapService.getAll();

            foreach (var item in Data)
            {

                foreach(Currency coin in coins)
                {
                    if (coin.Name == item.Symbol ){
                        if (item.PriceConvert != coin.PriceConvert) {
                            Debug.WriteLine("Updating " + item.Symbol + "'s price from " + item.PriceConvert + " to +" + coin.PriceConvert);

                            item.PriceConvert = coin.PriceConvert;
                            item.PercentChange24h = ((rand.Next(0, 200 * Deviation) - 100 * Deviation) / 10000.0).ToString();

                            item.Rank = coin.Rank;
                            item.MarketCapConvert = coin.MarketCapConvert;
                            item.PriceConvert = coin.PriceConvert;
                            item.PercentChange24h = coin.PercentChange24h;
                        }
                    }

                }

                if (item.Name == "Ethereum")
                    {
                        Debug.WriteLine(item.PriceConvert);
                    }
                
            }
        }
    }

}



    



        
    

