using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcoreapp.Controllers
{
    [Route("api/[controller]")]
    public class HelloController: Controller
    {
        public HelloController()
        {

        }

        [HttpGet("{id?}")]
        public List<Models.Customer> Get(string id = "")
        {
            if(id == "")
            {
                return Customers;
            }
            var customerReturn = from t in Customers
                                   where t.Id.ToUpper().Trim() == id.ToUpper().Trim()
                                   select t;
            return customerReturn.ToList();
        }

        public List<Models.Customer> Customers
        {
            get
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
                return customers;
            }
        }
        
    }
}
