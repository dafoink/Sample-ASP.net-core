using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using aspnetcoreapp.Repositories;
using System.Collections.Generic;

namespace aspnetcoreapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDBContextRepository _dbContextRepository;


        public HomeController(IDBContextRepository dbContextRepository, ILoggerFactory loggerFactory)
        {
            _dbContextRepository = dbContextRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_dbContextRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Index(string id)
        {
            List<Models.Customer> returnItems = new List<Models.Customer>();

            try
            {
                var customerRecord = _dbContextRepository.Get(id);
                if (customerRecord != null)
                {
                    returnItems.Add(customerRecord);
                }
            }
            catch
            {

            }
            return View(returnItems);
        }
    }
}