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
        public string Get(string id = "")
        {
            return id;
        }
    }
}
