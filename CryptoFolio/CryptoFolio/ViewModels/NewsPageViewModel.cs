using CryptoFolio.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
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

        async Task<HttpResponseMessage> GetGoogle()
        {

            HttpClient client = new HttpClient();

            Uri uri = new Uri("https://newsapi.org/v2/top-headlines?sources=crypto-coins-news&apiKey=1068e856ce444a8cb981e1b31ced616f");

            var result = await client.GetAsync(uri);
            Debug.WriteLine(result);
            Debug.WriteLine(result.Content);
            Debug.WriteLine(result.RequestMessage);
            Debug.WriteLine(result.ToString());

            var responseBodyAsText = await result.Content.ReadAsStringAsync();
           

            Debug.WriteLine(responseBodyAsText);
            return result;
        }


        private async Task<IEnumerable<Article>> GetMoreItems(uint count)
        {
            await Task.Delay(1000);
            if (this.currentCount >= 10)
            {
                return null;
            }
            
            var newsArticles =   await GetGoogle();
            using (var result1 = await GetGoogle())
            {
                Debug.WriteLine(result1);

                var resultObject = JsonConvert.DeserializeObject(await result1.Content.ReadAsStringAsync());
                JObject jObject = JObject.Parse(await result1.Content.ReadAsStringAsync());

                foreach (var item in jObject["articles"])
                {
                    Debug.WriteLine(item["title"]);
                }
                    Article deserializedObject = JsonConvert.DeserializeObject<Article>(await result1.Content.ReadAsStringAsync());

                Debug.WriteLine(deserializedObject);

            }



            var random = new Random(Environment.TickCount);
            var result = Enumerable.Range(this.currentCount, (int)count).Select(x => new Article { Label = "item " + x.ToString(), Height = random.Next(50, 150) }).ToList();
            currentCount += (int)count;
            return result;
        }
    }
}

