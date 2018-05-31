using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ConsoleApp80
{
    class Program
    {
        static void Main(string[] args)
        {
            //scraping
            //var client = new WebClient();
            //string html = client.DownloadString("http://lakewoodprogramming.com");
            //var parser = new HtmlParser();
            //IHtmlDocument document = parser.Parse(html);
            ////IElement section = document.QuerySelector("#section-services");
            ////Console.WriteLine(section.TextContent);

            //var element = document.QuerySelectorAll(".align-center").First();
            //var h2 = element.QuerySelectorAll("h2").ElementAt(1);
            //Console.WriteLine(h2.TextContent);


            //DoPost();

            //IWebDriver driver = new ChromeDriver();
            //driver.Navigate().GoToUrl("http://www.google.com");
            //driver.FindElement(By.Id("lst-ib")).SendKeys("hello world");
            //driver.FindElement(By.Name("btnK")).Submit();
            string searchText = "macbook";
            string url = $"https://www.amazon.com/s/?field-keywords={searchText}";
            var client = new WebClient();
            client.Headers[HttpRequestHeader.UserAgent] = "whatever!!!";
            var html = client.DownloadString(url);
            var parser = new HtmlParser();
            var document = parser.Parse(html);
            var lis = document.QuerySelectorAll("li.s-result-item");
            foreach (var li in lis)
            {
                DoItem(li);
            }

            Console.ReadKey(true);
        }

        static void DoItem(IElement li)
        {
            var h2 = li.QuerySelector("h2");
            if (h2 == null)
            {
                return;
            }
            Console.WriteLine("Title: " + h2.TextContent);
            var a = li.QuerySelector("a.a-link-normal");
            if (a != null)
            {
                Console.WriteLine("Url: " + a.Attributes["href"].Value);
            }

            var img = li.QuerySelector("img");
            if (img != null)
            {
                Console.WriteLine("Image: " + img.Attributes["src"].Value);
            }

            var priceSpan = li.QuerySelector(".a-offscreen");
            if (priceSpan != null)
            {
                Console.WriteLine("Price: " + priceSpan.TextContent);
            }
        }

        static void DoPost()
        {
            var client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            string query = "firstName=hacked&lastname=your face&age=111";
            client.UploadString("http://localhost:49820/assignmentpeople/add", query);

        }
    }
}
