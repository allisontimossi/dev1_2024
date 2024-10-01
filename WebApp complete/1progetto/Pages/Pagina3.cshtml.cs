using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace _1progetto.Pages
{
    public class Pagina3 : PageModel
    {
        private readonly ILogger<Pagina3> _logger;

        public Pagina3(ILogger<Pagina3> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}