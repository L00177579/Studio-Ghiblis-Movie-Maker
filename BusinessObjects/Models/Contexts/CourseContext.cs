using Microsoft.EntityFrameworkCore;
using StudioGhibliMovieMaker.BusinessObjects.Contexts;

namespace StudioGhibliMovieMaker.BusinessObjects.Models.Contexts
{
    public class CourseContext : DbContext
    {
        public virtual DbSet<CoursesDataModel> Courses { get; set; }
        public CourseContext(DbContextOptions<CourseContext> options) : base(options)
        {

        }
        public async Task<bool> Insert(CoursesDataModel CourseInsert)
        {
            if (CourseInsert.CourseId != null)
            {
                return false;
            }

            var result = await this.Courses.AddAsync(CourseInsert);
            if (result != default)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<CoursesDataModel>> Get()
        {
            return await this.Courses.ToListAsync();
        }

        public async Task<CoursesDataModel?> Get(int id)
        {
            var result = await this.Courses.FirstOrDefaultAsync(x => x.CourseId == id);

            if (result != default)
            {
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}

