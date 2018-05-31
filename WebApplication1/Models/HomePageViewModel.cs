using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AmazonScraper.API;

namespace WebApplication1.Models
{
    public class HomePageViewModel
    {
        public IEnumerable<AmazonItem> Items { get; set; }
        public string SearchText { get; set; }
    }
}