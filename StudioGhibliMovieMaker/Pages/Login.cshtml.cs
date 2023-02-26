using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudioGhibliMovieMaker.BusinessObjects.Models;
using System.Security.Claims;

namespace StudioGhibliMovieMaker.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public UsersDataModel UsersDataModel { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (UsersDataModel.UserName == "Test" && UsersDataModel.Password == "TestPassword")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "admin")
                };

                var identity = new ClaimsIdentity(claims, "SGMMCookie");

                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("SGMMCookie", principal);

                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}
