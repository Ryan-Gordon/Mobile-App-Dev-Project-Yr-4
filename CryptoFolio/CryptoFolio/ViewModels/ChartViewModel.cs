using System;
using System.Collections.ObjectModel;

using CryptoFolio.Models;
using CryptoFolio.Services;

using GalaSoft.MvvmLight;

namespace CryptoFolio.ViewModels
{
    public class ChartViewModel : ViewModelBase
    {
        public ChartViewModel()
        {
        }

        public ObservableCollection<DataPoint> Source
        {
            get
            {
                return SampleDataService.GetChartSampleData();
            }
        }
    }
}
