using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.NET_CORE_PractSite
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        //public String Index()
        public IActionResult Index()// this is what ASP.NET CORE MVC would implicitly change the line(14) above into
        {
            return View();
        }
    }
}
