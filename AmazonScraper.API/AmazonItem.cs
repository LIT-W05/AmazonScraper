using System;
using System.Text;
using System.Threading.Tasks;

namespace AmazonScraper.API
{
    public class AmazonItem
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
