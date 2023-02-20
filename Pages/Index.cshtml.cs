using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudioGhibliMovieMaker.BusinessObjects.Contexts;
using StudioGhibliMovieMaker.BusinessObjects.Models;

namespace StudioGhibliMovieMaker.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}