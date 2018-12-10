using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_CORE_PractSite.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.NET_CORE_PractSite.Controllers
{
    [Route("blog")]
    public class BlogController : Controller
    {
        // GET: /<controller>/

        //[Route(" ")]
        public IActionResult Index()
        {
            var posts = new[]
           {
                new Post
                {
                    Title = "My blog post",
                    Posted = DateTime.Now,
                    Author = "Sav Chips",
                    Body = "This is a great blog post, don't ya think?",
                },
                new Post
                {
                    Title = "My second blog post",
                    Posted = DateTime.Now,
                    Author = "Sav Chips",
                    Body = "This is ANOTHER great blog post, don't ya think?",
                },
            };

            return View(posts);

        }



        [Route("{year:min(2000)}/{month:range(1,12)}/{key}")]
        public IActionResult Post(int year, int month, string key)
        {
            var post = new Post
            {

                Title = "My blog post",
                Posted = DateTime.Now,
                Author = "Sav Chips",
                Body = "This is a great blog post, don't ya think?",

            };

            return View(post);
        }
    }
} 
