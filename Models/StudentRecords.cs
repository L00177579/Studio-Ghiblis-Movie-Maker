using System.ComponentModel.DataAnnotations;

namespace StudioGhibliMovieMaker.Models
{
    public class StudentRecords
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public List<CourseDetails> CourseIDs { get; set; }

        public string Comments { get; set; }
    }
}
