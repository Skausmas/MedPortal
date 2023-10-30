using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace MedPortal.Pages
{
    public class RegistrationModel : PageModel
    {

        ApplicationContext context;

        [BindProperty]

        public Registration registr { get; set; } = new();


        public List<User> Users = new List<User>();
        public List<Hospitals> Hospitals { get; private set; } = new();
        public List<Doctors> Doctors { get; private set; } = new();
        public RegistrationModel(ApplicationContext db)
        {
            context = db;
        }
        async public Task OnGet([FromServices] IGetAllUsers getus)
        {
            Hospitals = context.Hospitals.AsNoTracking().ToList();
            Doctors = context.Doctors.AsNoTracking().ToList();
            Users = await getus.GetAllUsers();

        }
        public async Task<IActionResult> OnPost()
        {
            registr.DateVisit = registr.DateVisit.ToUniversalTime();
            context.Registration.Add(registr);
            await context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
