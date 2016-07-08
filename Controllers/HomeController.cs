using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcoreapp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Models.Customer> customers = new List<Models.Customer>();
            customers.Add(new Models.Customer{
                Id = "1",
                Name = "foinker",
                Address = "222 Boogie Woogie Ave",
                Email = "foink@doink.com"
            });
            customers.Add(new Models.Customer{
                Id = "2",
                Name = "yadaydyad",
                Address = "asdfasdfasdf",
                Email = "nobie@labiii.com"
            });
            return View(customers);
        }
    }
}