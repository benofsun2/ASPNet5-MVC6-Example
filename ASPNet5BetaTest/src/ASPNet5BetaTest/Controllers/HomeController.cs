using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Messages.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Messages.Controllers
{
    [Route("/[controller]"),Route("/")]
    public class HomeController : Controller
    {
        IGreetingService _greeter;
        public HomeController(IGreetingService greeter)
        {
            _greeter = greeter;
        }


        // GET: /<controller>/
        [Route("[action]"),Route("")]
        public IActionResult Default()
        {
            var greeting = _greeter.GetTodaysGreeting();
            return View(greeting);
        }
    }
}
