using CryptoFolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Core.Data;

namespace CryptoFolio.ViewModels
{
    public class NewsPageViewModel : ShellViewModel
    {
        private int currentCount = 0;
        public IncrementalLoadingCollection<Article> Months { get; set; }
        public NewsPageViewModel()
        {
            Months = new IncrementalLoadingCollection<Article>(this.GetMoreItems) { BatchSize = 5 };
        }
         

        private async Task<IEnumerable<Article>> GetMoreItems(uint count)
        {
            await Task.Delay(1000);
            if (this.currentCount >= 100)
            {
                return null;
            }

            var random = new Random(Environment.TickCount);
            var result = Enumerable.Range(this.currentCount, (int)count).Select(x => new Article { Label = "item " + x.ToString(), Height = random.Next(50, 150) }).ToList();
            currentCount += (int)count;
            return result;
        }
    }
}

