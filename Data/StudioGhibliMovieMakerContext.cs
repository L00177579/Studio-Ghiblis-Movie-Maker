using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudioGhibliMovieMaker.Models;

namespace StudioGhibliMovieMaker.Data
{
    public class StudioGhibliMovieMakerContext : DbContext
    {
        public StudioGhibliMovieMakerContext (DbContextOptions<StudioGhibliMovieMakerContext> options)
            : base(options)
        {
        }

        public DbSet<StudioGhibliMovieMaker.Models.StudentRecords> StudentRecords { get; set; } = default!;
    }
}
