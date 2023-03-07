using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudioGhibliMovieMaker.BusinessObjects.Contexts;
using StudioGhibliMovieMaker.BusinessObjects.Models;

namespace StudioGhibliMovieMaker.Pages.Admin
{
    [Authorize(Policy = "AdminOnly")]
    public class EditModel : PageModel
    {
        private readonly StudioGhibliMovieMaker.BusinessObjects.Contexts.StudentContext _context;

        public EditModel(StudioGhibliMovieMaker.BusinessObjects.Contexts.StudentContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StudentsDataModel StudentsDataModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var studentsdatamodel =  await _context.Students.FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentsdatamodel == null)
            {
                return NotFound();
            }
            StudentsDataModel = studentsdatamodel;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(StudentsDataModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsDataModelExists(StudentsDataModel.StudentId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StudentsDataModelExists(int? id)
        {
          return _context.Students.Any(e => e.StudentId == id);
        }
    }
}
