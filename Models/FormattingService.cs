using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ASP.NET_CORE_PractSite.Models
{
    public class FormattingService
    { 
        public string AsReadableDate(DateTime date)
        {
            return date.ToString("d");
        }

    }
}
