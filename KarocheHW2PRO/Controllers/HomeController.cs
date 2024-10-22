using KarocheHW2PRO.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KarocheHW2PRO.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new OrderViewModel();

            InitializeMenu(model);

            return View(model);
        }

        [HttpPost]
        public IActionResult Calculate(OrderViewModel order)
        {
            var prices = new Dictionary<string, double>
            {
                {"GreenSoup" , 2.5 },
                {"Borshch", 3.25 },
                {"Potate", 1.75 },
                {"Fisch" , 4.15 },
                {"Coffee", 1.50 },
                {"Tea", 3.45 }
            };

            order.TotalPrice = (prices.ContainsKey(order.SelectedFirstCourse) ? prices[order.SelectedFirstCourse] : 0)
                             + (prices.ContainsKey(order.SelectedSecondCourse) ? prices[order.SelectedSecondCourse] : 0)
                             + (prices.ContainsKey(order.SelectedDrink) ? prices[order.SelectedDrink] : 0);

            InitializeMenu(order);

            return View("Index", order);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private OrderViewModel InitializeMenu(OrderViewModel order)
        {
            order.FirstCourse = new List<MenuItem>
            {
                new MenuItem { Name = "GreenSoup", Price = 2.5 },
                new MenuItem { Name = "Borshch", Price = 3.25 }
            };
            order.SecondCourse = new List<MenuItem>
            {
                new MenuItem {Name = "Potate", Price = 1.75 },
                new MenuItem {Name = "Fisch", Price = 4.15 }
            };
            order.Drink = new List<MenuItem>
            {
                new MenuItem {Name = "Coffee", Price = 1.5 },
                new MenuItem {Name = "Tea", Price = 3.45 }
            };

            return order;
        }
    }
}
