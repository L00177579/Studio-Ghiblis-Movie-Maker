using System.ComponentModel.DataAnnotations;

namespace StudioGhibliMovieMaker.BusinessObjects.Models
{
    public class CoursesDataModel
    {
        [Key]
        public int? CourseId { get; set; }
        public string CourseName { get; set; }
        public bool Running { get; set; }
    }
}
