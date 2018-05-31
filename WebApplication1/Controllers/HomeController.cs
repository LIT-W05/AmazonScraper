using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AmazonScraper.API;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string searchText)
        {
            var vm = new HomePageViewModel();
            if (String.IsNullOrEmpty(searchText))
            {
                return View(vm);
            }
            var scraper = new Scraper();
            vm.Items = scraper.Search(searchText);
            vm.SearchText = searchText;
            return View(vm);
        }
    }
}