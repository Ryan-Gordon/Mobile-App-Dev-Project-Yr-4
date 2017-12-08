using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.UI.Xaml.Controls.Grid;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using NoobsMuc.Coinmarketcap.Client;
namespace CryptoFolio.ViewModels
{
    public class DeviationStyleSelector : StyleSelector
    {
        public Style NegativeStyle
        {
            get;
            set;
        }

        public Style PositiveStyle
        {
            get;
            set;
        }

        protected override Style SelectStyleCore(object item, DependencyObject container)
        {
            var cellInfo = item as DataGridCellInfo;
            var stock = cellInfo.Item as Currency;

            if (Convert.ToInt32(stock.PercentChange24h) == 0)
                return null;

            return Convert.ToInt32(stock.PercentChange24h) > 0 ? PositiveStyle : NegativeStyle;
        }
    }
}
