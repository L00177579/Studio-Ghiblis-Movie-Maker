using Microsoft.EntityFrameworkCore;
using StudioGhibliMovieMaker.BusinessObjects.Contexts;

namespace StudioGhibliMovieMaker.BusinessObjects.Models.Contexts
{
    public class UserContext : DbContext
    {
        public virtual DbSet<UsersDataModel> Users { get; set; }
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }
        public async Task<bool> Insert(UsersDataModel UserInsert)
        {
            if (UserInsert == null)
            {
                return false;
            }

            var result = await this.Users.AddAsync(UserInsert);
            if (result != default)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<UsersDataModel>> Get()
        {
            return await this.Users.ToListAsync();
        }

        public async Task<UsersDataModel?> Get(string id)
        {
            var result = await this.Users.FirstOrDefaultAsync(x => x.UserName == id);

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
