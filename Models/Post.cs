using System;
namespace ASP.NET_CORE_PractSite.Models
{
    public class Post
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Body { get; set; }
        public DateTime Posted { get; set; }
    }
}
