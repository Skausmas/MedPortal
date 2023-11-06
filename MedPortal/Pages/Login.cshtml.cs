using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Security.Principal;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authentication;

namespace MedPortal.Pages
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(string Name)
        {
            ServiceUser? user = ServiceUser.users.FirstOrDefault(user => user.Name == Name);
            if (user == null)
            {
                return Unauthorized();
            }

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Name),
                                            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                                           };

            ClaimsIdentity identity = new ClaimsIdentity(claims, "Cookies");
            await PageContext.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            return RedirectToPage("Index");
        }
    }
}
