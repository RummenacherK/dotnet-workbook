using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Menu.Models;

namespace Menu.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Size small = new Size() { ID = 1, Portion = "Small", Price=2.00};
            Size medium = new Size() { ID = 2, Portion = "Medium", Price=3.50 };
            Size large = new Size() { ID = 3, Portion = "Large", Price=5.00 };

            MenuModel Pork_Fritters_small = new MenuModel() { Name = "Small Pork Fritters", Sizes = small};
            MenuModel Pork_Fritters_medium = new MenuModel() { Name = "Medium Pork Fritters", Sizes = medium };
            MenuModel Pork_Fritters_large = new MenuModel() { Name = "Large Pork Fritters", Sizes = large };

            MenuModel ChickWings_small = new MenuModel() { Name = "Small Chicken Wings", Sizes = small };
            MenuModel ChickWings_medium = new MenuModel() { Name = "Medium Chicken Wings", Sizes = medium };
            MenuModel ChickWings_large = new MenuModel() { Name = "Large Chicken Wings", Sizes = large };

            MenuModel Steak_small = new MenuModel() { Name = "Small Steak", Sizes = small };
            MenuModel Steak_medium = new MenuModel() { Name = "Medium Steak", Sizes = medium };
            MenuModel Steak_large = new MenuModel() { Name = "Large Steak", Sizes = large };

            List<MenuModel> bigList = new List<MenuModel>();

            bigList.Add(Pork_Fritters_small);
            bigList.Add(Pork_Fritters_medium);
            bigList.Add(Pork_Fritters_large);

            bigList.Add(ChickWings_small);
            bigList.Add(ChickWings_medium);
            bigList.Add(ChickWings_large);

            bigList.Add(Steak_small);
            bigList.Add(Steak_medium);
            bigList.Add(Steak_large);

            return View(bigList);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
