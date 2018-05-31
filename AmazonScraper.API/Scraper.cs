using System.Collections.Generic;
using System.Linq;
using System.Net;
using AngleSharp.Dom;
using AngleSharp.Parser.Html;

namespace AmazonScraper.API
{
    public class Scraper
    {
        public IEnumerable<AmazonItem> Search(string searchText)
        {
            string url = $"https://www.amazon.com/s/?field-keywords={searchText}";
            var client = new WebClient();
            client.Headers[HttpRequestHeader.UserAgent] = "whatever!!!";
            var html = client.DownloadString(url);
            var parser = new HtmlParser();
            var document = parser.Parse(html);
            IEnumerable<IElement> lis = document.QuerySelectorAll("li.s-result-item");
            return lis.Select(ParseLi).Where(li => li != null);
        }

        private AmazonItem ParseLi(IElement li)
        {
            var h2 = li.QuerySelector("h2");
            if (h2 == null)
            {
                return null;
            }

            var result = new AmazonItem();
            result.Title = h2.TextContent;
            var a = li.QuerySelector("a.a-link-normal");
            if (a != null)
            {
                result.Url = a.Attributes["href"].Value;
            }

            var img = li.QuerySelector("img");
            if (img != null)
            {
                result.ImageUrl = img.Attributes["src"].Value;
            }

            var priceSpan = li.QuerySelector(".a-offscreen");
            if (priceSpan != null)
            {
                decimal price;
                if (decimal.TryParse(priceSpan.TextContent.Replace("$", ""), out price))
                {
                    result.Price = price;
                }
                
            }
            return result;
        }
    }
}