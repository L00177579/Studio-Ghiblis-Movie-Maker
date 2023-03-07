using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudioGhibliMovieMaker.BusinessObjects.Encryption;
using StudioGhibliMovieMaker.BusinessObjects.Models;
using StudioGhibliMovieMaker.BusinessObjects.Models.Contexts;
using System.Security.Claims;

namespace StudioGhibliMovieMaker.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public UsersDataModel UsersDataModel { get; set; }
        private readonly UserContext _context;

        public LoginModel(UserContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            UsersDataModel? enteredUser = _context.Get(UsersDataModel.UserName).Result;

            if (enteredUser != null)
            {
                PasswordEncryption encryption = new PasswordEncryption();

                if (encryption.ComparePassword(UsersDataModel.Password, enteredUser.Password, enteredUser.Salt))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, "admin"),
                        new Claim("admin", "true")
                    };

                    var identity = new ClaimsIdentity(claims, "SGMMCookie");

                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync("SGMMCookie", principal);

                    return RedirectToPage("/Index");
                }
            }

            return Page();
        }
    }
}
