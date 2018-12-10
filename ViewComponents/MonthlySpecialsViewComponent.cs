using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_CORE_PractSite.Models;




namespace ASP.NET_CORE_PractSite.ViewComponents
{
    [ViewComponent]
    public class MonthlySpecialsViewComponent : ViewComponent
    {

        private readonly SpecialsDataContext _specials;

        public MonthlySpecialsViewComponent(SpecialsDataContext special)
        {
            _specials = special;
        }

        public IViewComponentResult Invoke() 
        {
            var specials = _specials.GetMonthlySpecials();
            return View(specials);
        
        }

    }
}

