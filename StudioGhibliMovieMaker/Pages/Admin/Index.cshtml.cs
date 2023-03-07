using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudioGhibliMovieMaker.BusinessObjects.Contexts;
using StudioGhibliMovieMaker.BusinessObjects.Models;

namespace StudioGhibliMovieMaker.Pages.Admin
{
    [Authorize(Policy = "AdminOnly")]
    public class IndexModel : PageModel
    {
        private readonly StudioGhibliMovieMaker.BusinessObjects.Contexts.StudentContext _context;

        public IndexModel(StudioGhibliMovieMaker.BusinessObjects.Contexts.StudentContext context)
        {
            _context = context;
        }

        public IList<StudentsDataModel> StudentsDataModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Students != null)
            {
                StudentsDataModel = await _context.Students.ToListAsync();
            }
        }
    }
}
