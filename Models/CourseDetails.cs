using System.ComponentModel.DataAnnotations;

namespace StudioGhibliMovieMaker.Models
{
    public class CourseDetails
    {
        [Key]
        public int CourseID { get; set; }

        public string CourseName { get; set; }

    }
}
