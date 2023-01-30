using Microsoft.EntityFrameworkCore;
using StudioGhibliMovieMaker.BusinessObjects.Models;

namespace StudioGhibliMovieMaker.BusinessObjects.Contexts
{
    public class StudentContext : DbContext
    {
        public virtual DbSet<StudentsDataModel> Students { get; set; }
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {

        }
        public async Task<bool> Insert(StudentsDataModel StudentInsert)
        {
            if (StudentInsert.StudentId != null)
            {
                return false;
            }

            var result = await this.Students.AddAsync(StudentInsert);
            if (result != default)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<StudentsDataModel>> Get()
        {
            return await this.Students.ToListAsync();
        }

        public async Task<StudentsDataModel?> Get(int id)
        {
            var result = await this.Students.FirstOrDefaultAsync(x => x.StudentId == id);

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
