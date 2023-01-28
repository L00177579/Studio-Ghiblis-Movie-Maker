using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudioGhibliMovieMaker.Data;
using StudioGhibliMovieMaker.Models;

namespace StudioGhibliMovieMaker.Pages
{
    public class AddStudentRecordsModel : PageModel
    {
        private readonly StudioGhibliMovieMaker.Data.StudioGhibliMovieMakerContext _context;

        public AddStudentRecordsModel(StudioGhibliMovieMaker.Data.StudioGhibliMovieMakerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StudentRecords StudentRecords { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.StudentRecords.Add(StudentRecords);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
