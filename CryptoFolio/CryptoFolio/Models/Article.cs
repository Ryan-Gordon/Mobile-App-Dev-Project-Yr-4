using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFolio.Models
{
    public class Article
    {
        public string Label { get; set; }
        public int Height { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string UrlImage { get; set; }

        public string publishedAt { get; set; }



    }
}
