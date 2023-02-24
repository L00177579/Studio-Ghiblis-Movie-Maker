using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudioGhibliMovieMaker.BusinessObjects.Contexts;
using StudioGhibliMovieMaker.BusinessObjects.Models;
using StudioGhibliMovieMaker.BusinessObjects.Models.Contexts;

namespace StudioGhibliMovieMaker.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly UserContext userContext;

        public IndexModel(ILogger<IndexModel> logger, UserContext userContext)
        {
            _logger = logger;
            this.userContext = userContext;
        }

        public void OnGet()
        {

        }
    }
}