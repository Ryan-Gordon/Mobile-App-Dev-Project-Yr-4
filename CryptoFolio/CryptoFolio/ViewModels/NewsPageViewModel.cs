using CryptoFolio.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Telerik.Core.Data;

namespace CryptoFolio.ViewModels
{
    public class NewsPageViewModel : ShellViewModel, INotifyPropertyChanged
    {
        private int currentCount = 0;
        public IncrementalLoadingCollection<Article> Months { get; set; }
      
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


        public NewsPageViewModel()
        {
            Months = new IncrementalLoadingCollection<Article>(this.GetMoreItems) { BatchSize = 5 };
            
            ShowLoading = true;
        }

        async Task<HttpResponseMessage> GetNews()
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
            var result = new List<Article>();
            var newsArticles =   await GetNews();
            using (var result1 = await GetNews())
            {
                Debug.WriteLine(result1);
                
                var resultObject = JsonConvert.DeserializeObject(await result1.Content.ReadAsStringAsync());
                JObject jObject = JObject.Parse(await result1.Content.ReadAsStringAsync());

                foreach (var item in jObject["articles"])
                {

                    Debug.WriteLine(item["title"]);
                    Debug.WriteLine(item["urlToImage"]);
                    Article a = new Article();
                    a.UrlImage = item["urlToImage"].ToString();
                    var random = new Random(Environment.TickCount);
                    result.Add(new Article { Label = item["title"].ToString(), Height = random.Next(150, 450), UrlImage = item["urlToImage"].ToString(), url = item["url"].ToString() });
                    

                    
                }
                ShowLoading = false;
                Article deserializedObject = JsonConvert.DeserializeObject<Article>(await result1.Content.ReadAsStringAsync());

                Debug.WriteLine(deserializedObject);

            }



             currentCount += (int)count;
            return result;
        }
    }

   
    }

