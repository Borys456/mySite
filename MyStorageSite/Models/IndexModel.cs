using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyStorageSite.Models
{
    public class IndexModel : PageModel
    {
        public string SomMsg { get; set; }

        public void OnPost()
        {
            SomMsg = "Helllo from razor" + DateTime.Now;
        }
    }
}
