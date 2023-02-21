using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudioGhibliMovieMaker.BusinessObjects.Contexts;
using StudioGhibliMovieMaker.BusinessObjects.Models;
using StudioGhibliMovieMaker.BusinessObjects.Models.Contexts;

namespace StudioGhibliMovieMaker.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly StudentContext _studencontext;
        private readonly CourseContext _coursescontext;

        [BindProperty]
        public int[] SelectedCoursesIds { get; set; }

        public SignUpModel(StudentContext studencontext, CourseContext coursescontext)
        {
            _studencontext = studencontext;
            _coursescontext = coursescontext;
        }

        public async Task OnGetAsync()
        {
            if (_coursescontext.Courses != null)
            {
                CoursesDataModels = await _coursescontext.Courses.ToListAsync();
            }
        }

        [BindProperty]
        public StudentsDataModel StudentsDataModel { get; set; }
        [BindProperty]
        public List<CoursesDataModel> CoursesDataModels { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(List<CoursesDataModel> selectedCoursesIds)
        {
            string joinedIds = String.Join(", ", SelectedCoursesIds);
            this.StudentsDataModel.Courses = joinedIds;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _studencontext.Students.Add(StudentsDataModel);
            await _studencontext.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
