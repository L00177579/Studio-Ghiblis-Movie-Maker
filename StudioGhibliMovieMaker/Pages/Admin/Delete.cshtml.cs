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
    public class DeleteModel : PageModel
    {
        private readonly StudioGhibliMovieMaker.BusinessObjects.Contexts.StudentContext _context;

        public DeleteModel(StudioGhibliMovieMaker.BusinessObjects.Contexts.StudentContext context)
        {
            _context = context;
        }

        [BindProperty]
      public StudentsDataModel StudentsDataModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var studentsdatamodel = await _context.Students.FirstOrDefaultAsync(m => m.StudentId == id);

            if (studentsdatamodel == null)
            {
                return NotFound();
            }
            else 
            {
                StudentsDataModel = studentsdatamodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }
            var studentsdatamodel = await _context.Students.FindAsync(id);

            if (studentsdatamodel != null)
            {
                StudentsDataModel = studentsdatamodel;
                _context.Students.Remove(StudentsDataModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
