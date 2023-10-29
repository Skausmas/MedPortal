using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MedPortal.Pages
{
    public class RegistrationModel : PageModel
    {

        ApplicationContext context;
        public List<Hospitals> Hospitals { get; private set; } = new();
        public bool Flag = false;
        public List<Doctors> Doctors { get; private set; } = new();
        public RegistrationModel(ApplicationContext db)
        {
            context = db;
        }
        public void OnGet()
        {
            Hospitals = context.Hospitals.AsNoTracking().ToList();
            Doctors = context.Doctors.AsNoTracking().ToList();

        }
        public async Task<IActionResult> OnPost()
        {
           Flag = true;
           return RedirectToPage("Registration");
        }
    }
}
