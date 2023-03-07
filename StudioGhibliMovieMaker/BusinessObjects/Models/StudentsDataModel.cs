using System.ComponentModel.DataAnnotations;

namespace StudioGhibliMovieMaker.BusinessObjects.Models
{
    public class StudentsDataModel
    {
        [Key]
        public int? StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }

        public string? Courses { get; set; }
        [Display(Name = "Requests (Max 200 Characters)")]
        public string NiceToHaveRequests { get; set; }
        
    }
}
