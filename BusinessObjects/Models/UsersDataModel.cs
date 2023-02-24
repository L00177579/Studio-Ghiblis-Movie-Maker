using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudioGhibliMovieMaker.BusinessObjects.Models
{
    public class UsersDataModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
